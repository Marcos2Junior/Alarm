using System;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        private int count = 0;
        System.Media.SoundPlayer player;
        private string[] texts = new string[]
        {
            "Não importa o que você decidiu. O que importa é que isso te faz feliz.",
            "Quando pensar em desistir, lembre-se porque começou.",
            "Se não puder fazer tudo, faça tudo que puder.",
            "Comece onde você está. Use o que você tem. Faça o que puder.",
            "Simplesmente viva a vida.",
            "Que venham dias melhores.",
            "O corpo alcança o que a mente acredita.",
            "Hoje vai dar tudo certo.",
            "Dias de luz sempre retornam para quem iluminado está"
        };

        public Form1()
        {
            InitializeComponent();
            player = new System.Media.SoundPlayer();
            player.SoundLocation = "alarm.wav";
            timer1.Start();
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                Start();
            }
            else
            {
                label1.Text = $"Alarme em {Convert.ToInt32(dateTimePicker1.Value.Subtract(DateTime.Now).TotalMinutes)} minutos";
            }
        }

        private void Start()
        {
            Cursor.Position = new System.Drawing.Point(0, 0);
            Activate();
            if (dateTimePicker1.Enabled)
            {
                dateTimePicker1.Enabled = false;
                player.PlayLooping();
                ShowText();
                textBox1.Text = "Digite a frase acima 5 vezes para desativar";
            }
        }
        private void Stop()
        {
            count = 0;
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
            dateTimePicker1.Enabled = true;
            player.Stop();
            timer1_Tick(null, null);
            MessageBox.Show("Pressione ESC para encerrar", "Alarme desativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowText()
        {
            string text = label1.Text;
            while (label1.Text == text)
            {
                text = texts[new Random().Next(0, texts.Length - 1)];
            }
            label1.Text = text;
            textBox1.Text = string.Empty;
            textBox1.Focus();
            if (count == 5)
            {
                Stop();
            }
            count++;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!dateTimePicker1.Enabled && textBox1.Text == label1.Text)
            {
                ShowText();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dateTimePicker1.Enabled)
            {
                Close();
            }
        }
    }
}
