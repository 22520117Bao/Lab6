using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private string CaesarEncrypt(string text, int shift)
        {
            return new string(text.Select(c => EncryptChar(c, shift)).ToArray());
        }

        private string CaesarDecrypt(string text, int shift)
        {
            return CaesarEncrypt(text, 26 - shift);
        }

        private char EncryptChar(char c, int shift)
        {
            if (!char.IsLetter(c))
                return c;

            char offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)(((c + shift - offset) % 26) + offset);
        }

        private void btencrypt_Click(object sender, EventArgs e)
        {
            string input = txtinput.Text;
            int shift = int.Parse(txtshift.Text);
            txtencrypt.Text = CaesarEncrypt(input, shift);
        }

        private void btdecrypt_Click(object sender, EventArgs e)
        {
            string input = txtencrypt.Text;
            int shift = int.Parse(txtshift.Text);
            txtdecrypt.Text = CaesarDecrypt(input, shift);
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            txtdecrypt.Clear();
            txtencrypt.Clear();
            txtinput.Clear();
            txtshift.Clear();
        }
    }
}
