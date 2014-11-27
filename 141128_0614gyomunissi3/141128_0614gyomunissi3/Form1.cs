using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.IO;

//Version0.1　Gitテスト用3


namespace _141128_0614gyomunissi3
{
    public partial class Form1 : Form
    {
        public Form1()
        //初期設定
        {
            InitializeComponent();
            this.Text = "業務日誌";
            this.button1.Text = "消去";
            //時計起動
            timer1.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        //消去ボタン動作        
        {
        //    this.Text = textBox1.Text;
        //    label1.Text = textBox1.Text;
        //    MessageBox.Show(textBox1.Text, textBox1.Text);
        DialogResult result = MessageBox.Show(textBox1.Text + "消去しますか？",
            "質問",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        //何が選択されたか調べる
            if (result == DialogResult.Yes)
                {
            //「はい」が選択された時
            Console.WriteLine("「はい」が選択されました");
            label1.Text = "";
            textBox1.Text = "";
                }
            else if (result == DialogResult.No)
                {
            //「いいえ」が選択された時
            Console.WriteLine("「いいえ」が選択されました");
            textBox1.Text = textBox1.Text;
                }
            else if (result == DialogResult.Cancel)
                {
            //「キャンセル」が選択された時
            Console.WriteLine("「キャンセル」が選択されました");
                }
        }
            
            
        private void timer1_Tick(object sender, EventArgs e)
        //時計表示
        {
            DateTime datetime = DateTime.Now;

            label2.Text = datetime.ToLongDateString();
            label3.Text = datetime.ToLongTimeString();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        //ラベルににテキストボックス転記
        {
            label1.Text = textBox1.Text;
        }
        class TestIO
        {
            static void sub()
            {
                if (!Directory.Exists("test"))
                    Directory.CreateDirectory("test");

                for (int i = 0; i < 5; ++i)
                {
                    string fileName = string.Format(@"test\{0}.txt", i);
                    string contents = string.Format("Test file No. {0}", i);
                    File.WriteAllText(fileName, contents);
                }
            }
}
  }
}