using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado2020
{
    public partial class Form1 : Form
    {
        String hiddenWord = chooseWord();
        int failNum = 0;
        public Form1()
        {
            InitializeComponent();

            String auxiliar = "";
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                auxiliar = auxiliar + "_ ";
            }
            label1.Text = auxiliar;
        }
        
        static String chooseWord()
        {
            String[] wordList = { "CETYS", "VENUSAUR", "CHARIZARD", "BLASTOISE", "SCEPTILE", "BLAZIKEN", "SWAMPERT" };
            Random random = new Random(); 
            int position = random.Next(wordList.Length);
            return wordList[position].ToUpper();
        }
       
        private void letterButton(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            String letter = myButton.Text;
            letter = letter.ToUpper();

            if (hiddenWord.Contains(letter))
            {
                int position = hiddenWord.IndexOf(letter);
                label1.Text = label1.Text.Remove(2 * position, 1).Insert(2 * position, letter);
            }
            else
            {
                failNum++;
            }
            if (!label1.Text.Contains('_'))
            {
                failNum = - 100;
            }
            switch (failNum)
            {
                case 0:pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                case -100: pictureBox1.Image = Properties.Resources.acertasteTodo; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }
        }
    }
}
