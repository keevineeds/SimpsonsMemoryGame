using JogoDaMemoriaF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaMemoria2
{
    public partial class Form1 : Form
    {
        // variáveis para contabilizar os acertos e os cliques totais
        int acertos = 0;
        int movimentos = 0;

        string[] confirmaNome = new string[2]; // vetor para confirmar
        int click; // variável que contabiliza o clique dos pares para saber quando verificar
        string[] pbvalue = new string[1]; // vetor para armazenar o valor do picture box

        Vetor vetImg = new Vetor(24); // instanciação da classe

        // variável que indica o local das imagens
        string pasta = @"C:\Program Files (x86)\JogoDaMemória\Simpsons\Resources\";

        // vetor que possui todas as imagens
        string[] vetArqv = new string[12] {"bart.png", "burns.png", "clancy.png", "homer.png", "krusty.png", "lisa.png",
        "maggie.png", "margie.png", "milhouse.png", "ned.png", "nelson.png", "vovo.png"};

        // método para iniciar o jogo (utilizado apenas no load do formulário)
        public void iniciarJogo()
        {
            foreach (PictureBox imagens in Controls.OfType<PictureBox>())
            {
                imagens.Image = Image.FromFile(pasta + "verso.png");
            }
            lbl_acertos.Text = "Seus acertos:";
            lbl_mov.Text = "Movimentos: ";
            int posicao;
            int indice = 0;
            int indice2 = 0;
            for (int i = 0; i <= 23; i++)
            {
            inicio:
                posicao = vetImg.sortearNumero(0, 24);
                if (vetImg.posicaoOcupada(posicao) == true)
                {
                    if (indice > 23)
                    {

                        if (indice2 > 11)
                        {
                            indice2 = 0;
                        }
                        indice++;
                        vetImg.insereDados(posicao, vetArqv[indice2]);
                        indice2++;
                        break;
                    }
                    else
                    {
                        goto inicio;
                    }
                }
                else
                {
                    indice++;
                    if (indice2 > 11)
                    {
                        indice2 = 0;
                    }
                    vetImg.insereDados(posicao, vetArqv[indice2]);
                    indice2++;
                }
            }
        }

        // método que reinicia o jogo pelo botão reiniciar
        public void recomecar()
        {
            vetImg.limparVetor(23);
            lbl_acertos.Text = "Seus acertos:";
            lbl_mov.Text = "Movimentos: ";
            int posicao;
            movimentos = 0;
            acertos = 0;
            int indice = 0;
            int indice2 = 0;
            for (int i = 0; i <= 23; i++)
            {
            inicio:
                posicao = vetImg.sortearNumero(0, 24);
                if (vetImg.posicaoOcupada(posicao) == true)
                {
                    if (indice > 23)
                    {

                        if (indice2 > 11)
                        {
                            indice2 = 0;
                        }
                        indice++;
                        vetImg.insereDados(posicao, vetArqv[indice2]);
                        indice2++;
                        break;
                    }
                    else
                    {
                        goto inicio;
                    }
                }
                else
                {
                    indice++;
                    if (indice2 > 11)
                    {
                        indice2 = 0;
                    }
                    vetImg.insereDados(posicao, vetArqv[indice2]);
                    indice2++;
                }
            }
            pictureBox1.Image = Image.FromFile(pasta + vetImg.retornaPosicao(0));
            pictureBox18.Image = Image.FromFile(pasta + vetImg.retornaPosicao(22));
            pictureBox19.Image = Image.FromFile(pasta + vetImg.retornaPosicao(21));
            pictureBox20.Image = Image.FromFile(pasta + vetImg.retornaPosicao(20));
            pictureBox21.Image = Image.FromFile(pasta + vetImg.retornaPosicao(19));
            pictureBox22.Image = Image.FromFile(pasta + vetImg.retornaPosicao(18));
            pictureBox23.Image = Image.FromFile(pasta + vetImg.retornaPosicao(17));
            pictureBox24.Image = Image.FromFile(pasta + vetImg.retornaPosicao(16));
            pictureBox9.Image = Image.FromFile(pasta + vetImg.retornaPosicao(15));
            pictureBox10.Image = Image.FromFile(pasta + vetImg.retornaPosicao(14));
            pictureBox11.Image = Image.FromFile(pasta + vetImg.retornaPosicao(13));
            pictureBox12.Image = Image.FromFile(pasta + vetImg.retornaPosicao(12));
            pictureBox13.Image = Image.FromFile(pasta + vetImg.retornaPosicao(11));
            pictureBox14.Image = Image.FromFile(pasta + vetImg.retornaPosicao(10));
            pictureBox15.Image = Image.FromFile(pasta + vetImg.retornaPosicao(9));
            pictureBox16.Image = Image.FromFile(pasta + vetImg.retornaPosicao(8));
            pictureBox17.Image = Image.FromFile(pasta + vetImg.retornaPosicao(23));
            pictureBox8.Image = Image.FromFile(pasta + vetImg.retornaPosicao(7));
            pictureBox7.Image = Image.FromFile(pasta + vetImg.retornaPosicao(6));
            pictureBox6.Image = Image.FromFile(pasta + vetImg.retornaPosicao(5));
            pictureBox5.Image = Image.FromFile(pasta + vetImg.retornaPosicao(4));
            pictureBox4.Image = Image.FromFile(pasta + vetImg.retornaPosicao(3));
            pictureBox3.Image = Image.FromFile(pasta + vetImg.retornaPosicao(2));
            pictureBox2.Image = Image.FromFile(pasta + vetImg.retornaPosicao(1));
        }
        // método para carregar o verso de todas as pictureboxes
        public void voltarCarta()
        {
            foreach (PictureBox imagens in Controls.OfType<PictureBox>())
            {
                imagens.Image = Image.FromFile(pasta + "verso.png");
            }
        }
        // verifica se as duas imagens são iguais
        public bool ChecarNome()
        {
            click = 0;
            if (confirmaNome[0] == confirmaNome[1])
                return true;
            else
                return false;
        }
        /* verifica a posição que o usuário clicou para que caso as imagens
          não sejam iguais, retorne para o verso */

        public bool checarPosicao() // este método poderia ter sido feito com Switch também
        {
            if (pbvalue[0] == "1")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox1.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "2")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox2.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "3")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox3.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "4")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox4.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "5")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox5.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "6")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox6.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "7")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox7.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "8")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox8.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "9")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox9.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "10")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox10.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "11")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox11.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "12")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox12.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "13")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox13.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "14")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox14.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "15")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox15.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "16")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox16.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "17")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox17.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "18")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox18.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "19")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox19.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "20")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox20.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "21")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox21.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "22")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox22.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "23")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox23.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            if (pbvalue[0] == "24")
            {
                Application.DoEvents();
                Thread.Sleep(400);
                pictureBox24.Image = Image.FromFile(pasta + "verso.png");
                return true;
            }
            return false;
        }
        public Form1()
        {
            InitializeComponent();
            iniciarJogo(); // começa o jogo no carregamento do formulário
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            recomecar(); // re-sorteia as imagens
            voltarCarta(); // carrega o verso nas mesmas
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(pasta + vetImg.retornaPosicao(0)); // carrega a imágem na posição zero
            click++; // contabiliza um clique
            movimentos++; // contabiliza um movimento (cliques totais)
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos); // adere ao label movimentos, a váriavel "movimentos"

            if (click == 1) // se o click for igual a um, apenas guarda a posição e o primeiro nome
            {
                pbvalue[0] = "1";
                confirmaNome[0] = vetImg.retornaPosicao(0);
            }
            if(click == 2) // se o click for igual a dois, guarda o segundo nome e verifica as imagens são iguais
            {
                confirmaNome[1] = vetImg.retornaPosicao(0);
                ChecarNome();
                if (ChecarNome() == true) // caso forem iguais, acrescenta um acerto
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12) // verifica se o usuário chegou ao número máximo de acertos
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        /* caso tenha atingido o número máximo, mostra uma messageBox de parabenização dando a opção de escolha para 
                          o jogador jogar novamente. */

                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No) // caso a resposta seja não;
                        {
                            MessageBox.Show("Obrigado por jogar!"); // mostra uma messageBox de agradecimento
                            Application.Exit(); // fecha o aplicativo
                        }
                        if (resultado == DialogResult.Yes) // caso a resposta seja sim;
                        {
                            recomecar(); // re-sorteia as imagens
                            voltarCarta(); // carrega o verso em todas
                        }
                    }
                }
                if (ChecarNome() == false) // caso as imagens não sejam iguais;
                {
                    checarPosicao(); // verifica a posição
                    if (checarPosicao() == true) // caso haja posição;
                    {
                        Application.DoEvents();
                        pictureBox1.Image = Image.FromFile(pasta + "verso.png"); // carrega o verso para a pictureBox1
                    }
                }
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            pictureBox18.Image = Image.FromFile(pasta + vetImg.retornaPosicao(22));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "18";
                confirmaNome[0] = vetImg.retornaPosicao(22);
            }
            if(click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(22);
                ChecarNome();
                if(ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox18.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            pictureBox19.Image = Image.FromFile(pasta + vetImg.retornaPosicao(21));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "19";
                confirmaNome[0] = vetImg.retornaPosicao(21);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(21);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox19.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            pictureBox20.Image = Image.FromFile(pasta + vetImg.retornaPosicao(20));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "20";
                confirmaNome[0] = vetImg.retornaPosicao(20);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(20);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox20.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            pictureBox21.Image = Image.FromFile(pasta + vetImg.retornaPosicao(19));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "21";
                confirmaNome[0] = vetImg.retornaPosicao(19);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(19);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox21.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            pictureBox22.Image = Image.FromFile(pasta + vetImg.retornaPosicao(18));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "22";
                confirmaNome[0] = vetImg.retornaPosicao(18);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(18);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
            
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox22.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            pictureBox23.Image = Image.FromFile(pasta + vetImg.retornaPosicao(17));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "23";
                confirmaNome[0] = vetImg.retornaPosicao(17);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(17);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox23.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            pictureBox24.Image = Image.FromFile(pasta + vetImg.retornaPosicao(16));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "24";
                confirmaNome[0] = vetImg.retornaPosicao(16);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(16);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox24.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = Image.FromFile(pasta + vetImg.retornaPosicao(15));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "9";
                confirmaNome[0] = vetImg.retornaPosicao(15);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(15);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox9.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = Image.FromFile(pasta + vetImg.retornaPosicao(14));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "10";
                confirmaNome[0] = vetImg.retornaPosicao(14);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(14);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox10.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(pasta + vetImg.retornaPosicao(13));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "11";
                confirmaNome[0] = vetImg.retornaPosicao(13);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(13);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox11.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Image = Image.FromFile(pasta + vetImg.retornaPosicao(12));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "12";
                confirmaNome[0] = vetImg.retornaPosicao(12);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(12);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox12.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = Image.FromFile(pasta + vetImg.retornaPosicao(11));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "13";
                confirmaNome[0] = vetImg.retornaPosicao(11);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(11);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox13.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox14.Image = Image.FromFile(pasta + vetImg.retornaPosicao(10));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "14";
                confirmaNome[0] = vetImg.retornaPosicao(10);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(10);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox14.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox15.Image = Image.FromFile(pasta + vetImg.retornaPosicao(9));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "15";
                confirmaNome[0] = vetImg.retornaPosicao(9);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(9);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox15.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox16.Image = Image.FromFile(pasta + vetImg.retornaPosicao(8));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "16";
                confirmaNome[0] = vetImg.retornaPosicao(8);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(8);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox16.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = Image.FromFile(pasta + vetImg.retornaPosicao(7));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "8";
                confirmaNome[0] = vetImg.retornaPosicao(7);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(7);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox8.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Image.FromFile(pasta + vetImg.retornaPosicao(6));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "7";
                confirmaNome[0] = vetImg.retornaPosicao(6);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(6);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if(acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox7.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = Image.FromFile(pasta + vetImg.retornaPosicao(5));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "6";
                confirmaNome[0] = vetImg.retornaPosicao(5);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(5);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox6.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = Image.FromFile(pasta + vetImg.retornaPosicao(4));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "5";
                confirmaNome[0] = vetImg.retornaPosicao(4);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(4);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox5.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Image.FromFile(pasta + vetImg.retornaPosicao(3));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "4";
                confirmaNome[0] = vetImg.retornaPosicao(3);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(3);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox4.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(pasta + vetImg.retornaPosicao(2));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "3";
                confirmaNome[0] = vetImg.retornaPosicao(2);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(2);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox3.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(pasta + vetImg.retornaPosicao(1));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                confirmaNome[0] = vetImg.retornaPosicao(1);
                pbvalue[0] = "2";
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(1);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox2.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox17.Image = Image.FromFile(pasta + vetImg.retornaPosicao(23));
            click++;
            movimentos++;
            lbl_mov.Text = Convert.ToString("Movimentos: " + movimentos);
            if (click == 1)
            {
                pbvalue[0] = "17";
                confirmaNome[0] = vetImg.retornaPosicao(23);
            }
            if (click == 2)
            {
                confirmaNome[1] = vetImg.retornaPosicao(23);
                ChecarNome();
                if (ChecarNome() == true)
                {
                    acertos++;
                    lbl_acertos.Text = Convert.ToString("Você acertou " + acertos);
                    if (acertos == 12)
                    {
                        string mensagem = "Você venceu o jogo com " + movimentos + " movimentos. Deseja jogar novamente?";
                        string titulo = "Você venceu!";
                        var resultado = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.No)
                        {
                            MessageBox.Show("Obrigado por jogar!");
                            Application.Exit();
                        }
                        if (resultado == DialogResult.Yes)
                        {
                            recomecar();
                            voltarCarta();
                        }
                    }
                }
                if (ChecarNome() == false)
                {
                    checarPosicao();
                    if (checarPosicao() == true)
                    {
                        Application.DoEvents();
                        pictureBox17.Image = Image.FromFile(pasta + "verso.png");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
