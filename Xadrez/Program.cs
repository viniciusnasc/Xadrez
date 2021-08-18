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
                 
                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine($"\nTurno: {partida.Turno}");
                    Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                    Console.Write("\nPosicao de origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.Write("\nPosição de destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

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
