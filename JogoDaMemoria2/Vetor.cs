using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaMemoriaF
{
    class Vetor
    {
        // atributos da classe
        string[] vetImg = new string[24];
        int limite;

        //construtor da classe
        public Vetor(int l)
        {
            vetImg = new string[l];
            limite = l;
        }
        // método para inserir o dado no vetor
        public void insereDados(int pos, string arqv)
        {
            vetImg[pos] = arqv;
        }

        //método para verificar se o dado (o nome da imagem) está no vetor
        public int buscarImagem(string arqv)
        {
            bool achou = false;
            int indice = 0;
            while((indice <= limite) && (!achou))
            {
                if(vetImg[indice] == arqv)
                {
                    achou = true;
                }
                indice++;
            }
            if (achou)
            {
                return indice;
            }
            else
            {
                return -1;
            }
        }
        // este método retorna conteúdo do vetor numa posição específica
        public string retornaPosicao(int pos)
        {
            return vetImg[pos];
        }

        //método para sortear números, usado para sortear as posições no vetor
        public int sortearNumero(int primeiro, int ultimo)
        {
            int numero = 0;
            Random sorteia = new Random();
            numero = sorteia.Next(primeiro, ultimo);
            return numero;
        }

        //verifica se há algum dado numa posição específica
        public bool posicaoOcupada(int pos)
        {
            if (vetImg[pos] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //método para limpar os dados do vetor para que o jogo possa recomeçar
        public void limparVetor(int l)
        {
            for (int i = 0; i <= l; i++)
            {
                vetImg[i] = null;
            }
        }
    }
}
