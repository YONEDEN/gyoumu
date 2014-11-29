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

//Version0.1　中途半端な業務日誌用テキストエディタ　GitHub設定検証用

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
            this.button5.Text = "終了";
            //時計起動
            timer1.Start();
            filecheck();
        }

        private void button1_Click(object sender, EventArgs e)
        //消去ボタン動作        
        {
            DialogResult result = MessageBox.Show("フォーム内を消去しますか？",
                "質問",
                MessageBoxButtons.YesNo,
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
            //String load_fn = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "プロジェクトファイルを開く";
            ofd.InitialDirectory = "";  // 最初に表示されるディレクトリ
            ofd.Filter = "datファイル(*.dat)|*.dat|すべてのファイル(*.*)|*.*";  //「ファイルの種類」を指定
            ofd.CheckFileExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label4.Text = ofd.FileName; System.IO.Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    //内容を読み込み、表示する
                    //Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                    System.IO.StreamReader sr =
                           new System.IO.StreamReader(stream,
                           System.Text.Encoding.GetEncoding("Shift_JIS"));
                    String s = sr.ReadToEnd();
                    sr.Close();
                    MessageBox.Show("読み込みます");
                    textBox1.Text = s;
                    filecheck();
                    //Console.WriteLine(sr.ReadToEnd());
                    //閉じる
                    sr.Close();
                    stream.Close();
                    //textBox1.Text = ofd.FileName;
                }
            }

        }
        private void button3_Click(object sender, System.EventArgs e)
        //ファイル出力ボタン操作
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer =
                        new StreamWriter(name.f_name, false, sjisEnc);
            writer.Write(textBox1.Text + name.dcode + DateTime.Now.ToString());
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void filecheck()
        //ファイル最終更新時刻取得
        {
            DateTime fct, flat, flwt;
            try
            {
                fct = File.GetCreationTime(label4.Text);
                flat = File.GetLastAccessTime(label4.Text);
                flwt = File.GetLastWriteTime(label4.Text);
            }
            catch
            {
                label1.Text = "ファイル名がＮＧです！";
                return;
            }
            label1.Text = "作成日　 = " + fct.ToString();
            label5.Text = "最終閲覧 = " + flat.ToString();
            label6.Text = "最終更新 = " + flwt.ToString();

        }

   
    }
    class name
        //作業用ファイル名設定(クラス)
    {
        public static string f_name = "testdata.dat";//入出力ファイル
        //public static string kaigyo = "\r\n";//改行文字用固定変数
        public static string dcode = "[maketime]";//改行文字用固定変数
    }

  //  class open
        //OpenFileDialogクラスのインスタンスを作成
  //  {
  //         OpenFileDialog ofd = new OpenFileDialog1();
  //  }
            //ダイアログを表示する
              

}
