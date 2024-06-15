using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TongHop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private string VigenereEncrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char k = char.IsUpper(c) ? key[keyIndex] : char.ToLower(key[keyIndex]);
                    result.Append((char)(((c + k - 2 * offset) % 26) + offset));
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private string VigenereDecrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char k = char.IsUpper(c) ? key[keyIndex] : char.ToLower(key[keyIndex]);
                    result.Append((char)(((c - k + 26) % 26) + offset));
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private void btencrypt_Click(object sender, EventArgs e)
        {
            string input = txtinput.Text;
            string key = txtkey.Text;
            txtencrypt.Text = VigenereEncrypt(input, key);
        }

        private void btdecrypt_Click(object sender, EventArgs e)
        {
            string input = txtencrypt.Text;
            string key = txtkey.Text;
            txtdecrypt.Text = VigenereDecrypt(input, key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdecrypt.Clear();
            txtencrypt.Clear();
            txtinput.Clear();
            txtkey.Clear();
        }
    }
}
