# Redimensionador
Redimensionamento
Este programa é um redimensionador de imagens (não possui Upscale) e para usá-lo siga os passos a seguir:

Abra a pasta "Program.cs" e procure pela variável "novaAltura" e mude para a altura (pixels) desejada.
Entre no diretório "SeuPC\bin\Debug\net8.0" e coloque as imagens dentro da pasta "Arquivos_Entrada".
Caso a pasta não exista nesse diretório, execute o programa e emm seguida procure a pasta novamente (não é necessário parar o programa para isso).
No mesmo diretório, busque as imagens originais na pasta "Arquivos_Finalizados".
Por fim, pegue as imagens redimensionadas na pasta "Arquivos_Redimensionados".

ATENÇÃO: AO INÍCIO DO PROGRAMA, TODO O CONTEÚDO DA PASTA "Arquivos_Redimensionados" É DELETADO.

Diretório de Entrada: \bin\Debug\net8.0\Arquivos_Entrada
Diretório de Saida: \bin\Debug\net8.0\Arquivos_Redimensionados

Caso queira varias imagens com varias alturas diferentes, commente a linha com a "novaAltura" padrão e descomente a proxima linha com a mesma variável.
Coloque os valores das alturas desejadas, dentro do array de mesmo nome.
Apague os dois símbolos de comentáio na linha contendo a palavra "Padrão", deixando dessa forma: "/*Padrão".
Coloque os dois símbolos de comentário na linha contendo a frase "Varios arquivos com alturas diferentes", deixando dessa forma: "///*Varios arquivos com alturas diferentes".
Salve e rode o programa novamente.
