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
        //フォームクラス
        {
        public Form1()
        //初期設定
        {
            InitializeComponent();

            this.Text = "業務日誌基礎試験プログラム";
            this.button1.Text = "消去";
            this.button2.Text = "読み込み";
            this.button3.Text = "上書き";
            this.button4.Text = "ファイル消去";
            //時計起動
            timer1.Start();
            filecheck();
        }

        private void button1_Click(object sender, EventArgs e)
        //消去ボタン動作        
        {
            DialogResult result = MessageBox.Show("フォーム内を消去しますか？",
                "質問",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                textBox1.Text = "";
            }
            else if (result == DialogResult.No)
            {
                //「いいえ」が選択された時
                textBox1.Text = textBox1.Text;
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」が選択された時
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        //時計表示
        {
            DateTime datetime = DateTime.Now;
            string Wlet = ("日月火水木金土").Substring(
                        int.Parse(DateTime.Now.DayOfWeek.ToString("d")),
                        1); 

            label2.Text = datetime.ToLongDateString() + "（" + Wlet + "）";//ラベル２は日付
            label3.Text = datetime.ToLongTimeString();//ラベル３は時刻

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
            MessageBox.Show("読み込みます");
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
            writer.Write(textBox1.Text+name.dcode+label2+label3.Text);
            writer.Close();
            MessageBox.Show("書き込みました");
            filecheck();
        }

        private void button4_Click(object sender, EventArgs e)
        //全消去ボタン動作        
        {
            //string f_name = "test.csv";
            DialogResult result = MessageBox.Show("作業ファイルを消去しますか？",
                "質問",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                FileStream fs = File.Create(name.f_name);
                fs.Close();
                textBox1.Text = "";

            }
            else if (result == DialogResult.No)
            {
                //「いいえ」が選択された時
                textBox1.Text = textBox1.Text;
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」が選択された時
            }
            filecheck();
        }


        private void filecheck()
        //ファイル最終更新時刻取得
        {
            DateTime fct, flat, flwt;
            //string f_name = "test.csv";
            try
            {
                fct = File.GetCreationTime(name.f_name);
                flat = File.GetLastAccessTime(name.f_name);
                flwt = File.GetLastWriteTime(name.f_name);
            }
            catch
            {
                label1.Text = "ファイル名がＮＧです！";
                return;
            }
            label1.Text = "最終更新 = " + flwt.ToString() + ":作業ファイル名" + name.f_name;
        }
        //public void week()
        //曜日取得
        //{
            
            //textBox1.Text = "今日は、" + W + "曜日です。"
        //}

            // Note: DayOfWeek 列挙型は、曜日を表し、日曜日の 0 から土曜日の 7 までを示す。
            //       例) DateTime.Now.DayOfWeek.ToString("d")  →  1
            //           DateTime.Now.DayOfWeek.ToString("f")  →  Monday

    }
    class name
        //作業用ファイル名設定(クラス)
    {
        public static string f_name = "testdata.dat";//入出力ファイル
        //public static string kaigyo = "\r\n";//改行文字用固定変数
        public static string dcode = "[maketime]";//改行文字用固定変数
    }


}