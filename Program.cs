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
					
					
					///*Padrão
					FileStream fileStream = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
					FileInfo fileInfo = new FileInfo(arquivo);
					
					string caminho = Environment.CurrentDirectory + @"\" + dirRedimensionados + @"\" + DateTime.Now.Millisecond.ToString() + "_" + fileInfo.Name;
					
					//Redimensiona e copia arquivos para a pasta redimensionada
#pragma warning disable CA1416 // Validate platform compatibility
					Redimensionador(Image.FromStream(fileStream), novaAltura, caminho);
#pragma warning restore CA1416 // Validate platform compatibility
					
					//Fecha o Arquivo
					fileStream.Close();
					
					//Movendo os arquivos para pasta final
					string caminhoFinal = Environment.CurrentDirectory + @"\" + dirFinalizado + @"\" + fileInfo.Name;
					fileInfo.MoveTo(caminhoFinal);
					//*/
					
					/*Varios arquivos com alturas diferentes
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
#pragma warning disable CA1416 // Validate platform compatibility
			double ratio = (double)altura/(double)img.Height;
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
			int novaLargura = (int)(img.Width * ratio);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
			int novaAltura = (int)(img.Height * ratio);
#pragma warning restore CA1416 // Validate platform compatibility
			
#pragma warning disable CA1416 // Validate platform compatibility
			Bitmap novaImg = new Bitmap(novaLargura, novaAltura);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
			using(Graphics g = Graphics.FromImage(novaImg)) 
			{
#pragma warning disable CA1416 // Validate platform compatibility
				g.DrawImage(img, 0, 0, novaLargura, novaAltura);
#pragma warning restore CA1416 // Validate platform compatibility
			}
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
			novaImg.Save(caminho);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
			img.Dispose();
#pragma warning restore CA1416 // Validate platform compatibility
		}
	}
}