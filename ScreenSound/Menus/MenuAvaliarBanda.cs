using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Avaliar banda");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;
            bool bandaEncontrada = false;

            foreach (var bandaRegistrada in bandasRegistradas)
            {
                if (bandaRegistrada.Key.Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase))
                {
                    Banda banda = bandaRegistrada.Value;
                    Console.Write($"Qual a nota que a banda {bandaRegistrada.Key} merece: ");
                    Avaliacao nota = Avaliacao.AvaliacaoParse(Console.ReadLine()!);
                    banda.AdicionarNota(nota);
                    while (nota.Nota > 10 || nota.Nota < 1)
                    {
                        Console.WriteLine("Nota inválida. A nota precisa estar entre 1 a 10...");
                        Console.Write("Digite a nota novamente: ");
                        nota = Avaliacao.AvaliacaoParse(Console.ReadLine()!);
                    }
                    Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a banda {bandaRegistrada.Key}");
                    Thread.Sleep(2000);
                    Console.Clear();
                    bandaEncontrada = true;
                    break;
                }
            }

            if (!bandaEncontrada)
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
