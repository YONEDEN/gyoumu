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

//Version0.1　中途半端なテキストエディタ

namespace _141128_0614gyomunissi3
{
    public partial class Form1 : Form
    {
        public Form1()
        //初期設定
        {
            InitializeComponent();
            this.Text = "業務日誌基礎試験プログラム";
            this.button1.Text = "消去";
            this.button2.Text = "読み込み";
            this.button3.Text = "上書き";
            this.label1.Text = "入力したものがここに表示されます";
            this.label4.Text = "I/O";
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
      
        private void button2_Click(object sender, System.EventArgs e)
        //ファイル読み込みボタン動作
        {
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        StreamReader sr =
                    new StreamReader("Test.txt",sjisEnc);
        String s = sr.ReadToEnd();
        sr.Close();
        MessageBox.Show(s);
        textBox1.Text = s;
        }

 

        private void button3_Click(object sender, System.EventArgs e)
        //フィイル出力ボタン操作
        {
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        StreamWriter writer =
                    new StreamWriter("Test.txt", true, sjisEnc);
        writer.Write(textBox1.Text);
        writer.Close();
        }

           
                
          

//        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
//        {

//        }
    }
}