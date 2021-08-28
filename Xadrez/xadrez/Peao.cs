using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.tabuleiro;

namespace Xadrez.xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        { }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
