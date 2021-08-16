using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.tabuleiro
{
    class Tabuleiro
    {
        public int NumeroLinhas { get; set; }
        public int NumeroColunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            NumeroLinhas = linhas;
            NumeroColunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição");

            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
                return null;

            Peca aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= NumeroLinhas || pos.Coluna < 0 || pos.Coluna >= NumeroColunas)
                return false;

            else
                return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posição inválida");
        }
    }
}
