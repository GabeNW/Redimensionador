using System.Data;
using System.Drawing;

namespace Redimensionador
{
	internal class Program 
	{
		static void Main (string[] args) 
		{
			Console.WriteLine("Iniciando programa");
			
			Thread thread = new Thread(Redimensionar);
			thread.Start();
		}
		
		static void Redimensionar() 
		{
			#region "Diretórios"
			//Achar/Criar diretórios
			string dirEntrada = "Arquivos_Entrada";
			string dirFinalizado = "Arquivos_Finalizados";
			string dirRedimensionados = "Arquivos_Redimensionados";
			if (!Directory.Exists(dirEntrada))
			{
				Console.WriteLine(Directory.CreateDirectory(dirEntrada));
			}
			
			if (!Directory.Exists(dirFinalizado))
			{
				Console.WriteLine(Directory.CreateDirectory(dirFinalizado));
			}
			
			if (!Directory.Exists(dirRedimensionados))
			{
				Console.WriteLine(Directory.CreateDirectory(dirRedimensionados));
			}
			#endregion
			
			//Deletar todos os arquivos antigos antes de criar novos
			DirectoryInfo arquivosAntigos = new DirectoryInfo(dirRedimensionados);
			foreach (FileInfo arquivos in arquivosAntigos.EnumerateFiles())
			{
				arquivos.Delete();
			}
			
			while(true) 
			{
				//Olhar a pasta de entrada
				var arquivosEntrada = Directory.EnumerateFiles(dirEntrada);
				
				//Ler o tamanho que irá redimensionar
				int novaAltura = 100;
				
				//Criar varios arquivos com alturas diferentes
				//int[] novaAltura = {200, 1920, 50, 1080};
				
				foreach (var arquivo in arquivosEntrada)
				{
					Console.WriteLine(arquivo);
					
					///*
					FileStream fileStream = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
					FileInfo fileInfo = new FileInfo(arquivo);
					
					string caminho = Environment.CurrentDirectory + @"\" + dirRedimensionados + @"\" + fileInfo.Name + "_" + DateTime.Now.Millisecond.ToString();
					
					//Redimensiona e copia arquivos para a pasta redimensionada
					Redimensionador(Image.FromStream(fileStream), novaAltura, caminho);
					
					//Fecha o Arquivo
					fileStream.Close();
					
					//Movendo os arquivos para pasta final
					string caminhoFinal = Environment.CurrentDirectory + @"\" + dirFinalizado + @"\" + fileInfo.Name;
					fileInfo.MoveTo(caminhoFinal);
					//*/
					
					/*Criar varios arquivos com alturas diferentes
					FileStream fileStream;
					FileInfo fileInfo = null;
					
					for (int i = 0; i < 4; i++)
					{
						fileStream = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
						fileInfo = new FileInfo(arquivo);
						string caminho = Environment.CurrentDirectory + @"\" + dirRedimensionados + @"\" + fileInfo.Name + "_" + DateTime.Now.Millisecond.ToString();
						Redimensionador(Image.FromStream(fileStream), novaAltura[i], caminho);
						fileStream.Close();
					}
					string caminhoFinal = Environment.CurrentDirectory + @"\" + dirFinalizado + @"\" + fileInfo.Name;
					fileInfo.MoveTo(caminhoFinal);
					//*/
				}
				
				Console.WriteLine("Procurando Imagens");
				Thread.Sleep(new TimeSpan(0, 0, 5));
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="img">Imagem  a ser redimensionada</param>
		/// <param name="altura">Altura que desejamos redimensionar</param>
		/// <param name="caminho">Local onde será salvo a imagem</param>
		/// <returns></returns>
		static void Redimensionador(Image img, int altura, string caminho) 
		{
			double ratio = (double)altura/(double)img.Height;
			int novaLargura = (int)(img.Width * ratio);
			int novaAltura = (int)(img.Height * ratio);
			
			Bitmap novaImg = new Bitmap(novaLargura, novaAltura);
			using(Graphics g = Graphics.FromImage(novaImg)) 
			{
				g.DrawImage(img, 0, 0, novaLargura, novaAltura);
			}
			novaImg.Save(caminho);
			img.Dispose();
		}
	}
}