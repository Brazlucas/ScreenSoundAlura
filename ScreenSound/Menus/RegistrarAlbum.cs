using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (nomeDaBanda.ToUpper() == "X")
        {
            Console.Clear();
            return;
        }

        while (!bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.Write("Digite o nome da banda novamente ");
            Console.WriteLine("ou digite X para voltar ao menu.");
            nomeDaBanda = Console.ReadLine()!;

            if (nomeDaBanda.ToUpper() == "X")
            {
                Console.Clear();
                return;
            }
        }

        Console.Write("Agora digite o título do álbum: ");
        string tituloAlbum = Console.ReadLine()!;
        Banda banda = bandasRegistradas[nomeDaBanda];
        banda.AdicionarAlbum(new Album(tituloAlbum));

        Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }
}
