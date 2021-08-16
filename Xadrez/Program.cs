using System;
using Xadrez.tabuleiro;
using Xadrez.xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new();
                 

                Tela.ImprimirTabuleiro(partida.Tab);

                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
