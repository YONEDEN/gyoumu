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
using System.Text.RegularExpressions ;  // for Regex

//Version0.1　中途半端な業務日誌用テキストエディタ

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
            //時計起動
            timer1.Start();
            filecheck();

        }




        private void button1_Click(object sender, EventArgs e)
        //消去ボタン動作        
        {
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
            //string f_name = "test.csv";
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamReader sr =
                        new StreamReader(name.f_name, sjisEnc);
            String s = sr.ReadToEnd();
            sr.Close();
            MessageBox.Show(s);
            textBox1.Text = s;
            filecheck();
        }



        private void button3_Click(object sender, System.EventArgs e)
        //ファイル出力ボタン操作
        {
        //  string f_name = "test.csv
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer =
                        new StreamWriter(name.f_name, false, sjisEnc);
            writer.Write(textBox1.Text+","+label3.Text);
            writer.Close();
            filecheck();
        }

        private void button4_Click(object sender, EventArgs e)
        //全消去ボタン動作        
        {
            //string f_name = "test.csv";
            DialogResult result = MessageBox.Show("ファイルを消去しますか？",
                "質問",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");
                FileStream fs = File.Create(name.f_name);
                fs.Close();

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
            filecheck();
        }


        private void filecheck()
        //ファイル更新時刻取得
        {
            DateTime fct, flat, flwt;
            string f_name = "test.csv";
            try
            {
                fct = File.GetCreationTime(f_name);
                flat = File.GetLastAccessTime(f_name);
                flwt = File.GetLastWriteTime(f_name);
            }
            catch
            {
                label1.Text = "ファイル名がＮＧです！";
                return;
            }
            label1.Text = "最終更新 = " + flwt.ToString() + "\r\n";
        }
    }
    class name
        //作業用ファイル名設定
    {
        public static string f_name = "test.csv";
        //public static string kaigyo = "\r\n";
    }
}