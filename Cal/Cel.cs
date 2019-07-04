using System;
using System.Drawing;
using System.Windows.Forms;


//파스텔톤이나 아이폰 감성 테마
namespace Cal
{
    public partial class Cel : Form
    {
        private String _tmpData;    //저장된 데이터
        private String _tmpOpr;     //마지막 입력 연산자
        public Cel()
        {
            InitializeComponent();
            _tmpData = "0";
            tb_data.Text = "0";
            _tmpOpr = "";
            setThemaFromCode("Basic");
        }

        /*
         * String convert_num(String data)
         * => 문장을 ,를 넣어서 반환한다. 
        */
        private String convert_num(String data)
        {
            bool com = false;
            String[] data__ = { };
            String data_ = data.Replace(",", "");
            if (data_.IndexOf('.') != -1)
            {
                char[] tmp_ = { '.' };
                data__ = data_.Split(tmp_);
                data_ = data__[0];
                com = true;
            }
            Char[] tmp = data_.ToCharArray();
            bool min = false;
            if (tmp.Length > 0)
            {
                if (tmp[0] == '-')
                {
                    min = true;
                    data_ = data_.Replace("-", "");
                }
                for (int i = 1; i <= (data_.Length / 4); i++)
                {
                    int index = data_.Length - (4 * (i - 1) + 3);
                    data_ = data_.Insert(index, ",");
                }
                if (min == true)
                {
                    data_ = data_.Insert(0, "-");
                }
                if (com == true)
                {
                    data_ += "." + data__[1];
                }
            }
            return data_;
        }

        /*
         * void tb_data_Insert(Button btn)
         * => tb_data에 값을 추가한다.
        */
        private void tb_data_Insert(Button btn)
        {
            bool com = false;
            if (tb_data.Text == "0" && btn.Text != ".")
            {
                tb_data.Text = "";
            }
            else if(btn.Text == "." && tb_data.Text.IndexOf('.') != -1)
            {
                com = true;
            }
            if (com != true)
            {
                tb_data.Text += btn.Text;
            }
            tb_data.Text = convert_num(tb_data.Text);
        }
        
        private void tb_data_opr(Button btn)
        {
            _tmpOpr = btn.Text;
            if (tb_data.Text == "0" || tb_data.Text == "")
            {
                if (_tmpData == "" || _tmpData == "0")
                {
                    tb_data.Text = "0";
                }
                else
                {
                    tb_data.Text = _tmpData;
                }
            }
            else
            {
                if (_tmpData == "" || _tmpData == "0")
                {
                    _tmpData = tb_data.Text;
                    tb_data.Text = "0";
                }
                else
                {
                    _tmpData = oprator(_tmpData, btn.Text, tb_data.Text);
                    tb_data.Text = "0";
                }
            }
        }

        /*
         * double oprator (double num1, String opr ,double num2)
         * => 번호 두개와 연산자를 주면 연산을 반환한다.
        */
        private double oprator(double num1, String opr, double num2)
        {
            double result = 0;
            switch (opr)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }
            return result;
        }
        private String oprator(String num1, String opr, String num2)
        {
            return convert_num(Convert.ToString(oprator(strToDb(num1),opr, strToDb(num2))));
        }

        /*
         * double double strToDb(String num)
         * => 문자를 double형 숫자로 변환
        */
        private double strToDb(String num)
        {
            return Convert.ToDouble(num.Replace(",", ""));
        }

        /*
         *  
         * 
        */
        private void setThemaFromImage(String Folder)
        {
            String path = ".\\Thema\\" + Folder;
            System.Drawing.Bitmap btm_main_background = new Bitmap(path + "\\Background.png");
            System.Drawing.Bitmap btm_btn_1 = new Bitmap(path + "\\Button_1.png");
            System.Drawing.Bitmap btm_btn_2 = new Bitmap(path + "\\Button_2.png");
            System.Drawing.Bitmap btm_btn_3 = new Bitmap(path + "\\Button_3.png");
            System.Drawing.Bitmap btm_btn_4 = new Bitmap(path + "\\Button_4.png");
            System.Drawing.Bitmap btm_btn_5 = new Bitmap(path + "\\Button_5.png");
            System.Drawing.Bitmap btm_btn_6 = new Bitmap(path + "\\Button_6.png");
            System.Drawing.Bitmap btm_btn_7 = new Bitmap(path + "\\Button_7.png");
            System.Drawing.Bitmap btm_btn_8 = new Bitmap(path + "\\Button_8.png");
            System.Drawing.Bitmap btm_btn_9 = new Bitmap(path + "\\Button_9.png");
            System.Drawing.Bitmap btm_btn_0 = new Bitmap(path + "\\Button_0.png");
            System.Drawing.Bitmap btm_btn_ce = new Bitmap(path + "\\Button_CE.png");
            System.Drawing.Bitmap btm_btn_c = new Bitmap(path + "\\Button_C.png");
            System.Drawing.Bitmap btm_btn_back = new Bitmap(path + "\\Button_Back.png");
            System.Drawing.Bitmap btm_btn_plus = new Bitmap(path + "\\Button_Plus.png");
            System.Drawing.Bitmap btm_btn_min = new Bitmap(path + "\\Button_Minus.png");
            System.Drawing.Bitmap btm_btn_mul = new Bitmap(path + "\\Button_Multip.png");
            System.Drawing.Bitmap btm_btn_div = new Bitmap(path + "\\Button_Div.png");
            System.Drawing.Bitmap btm_btn_result = new Bitmap(path + "\\Button_Result.png");
            System.Drawing.Bitmap btm_btn_plma = new Bitmap(path + "\\Button_Plma.png");
            System.Drawing.Bitmap btm_btn_decpoint = new Bitmap(path + "\\Button_Decpoint.png");
            

            btn_0.BackgroundImage = btm_btn_0;
            btn_1.BackgroundImage = btm_btn_1;
            btn_2.BackgroundImage = btm_btn_2;
            btn_3.BackgroundImage = btm_btn_3;
            btn_4.BackgroundImage = btm_btn_4;
            btn_5.BackgroundImage = btm_btn_5;
            btn_6.BackgroundImage = btm_btn_6;
            btn_7.BackgroundImage = btm_btn_7;
            btn_8.BackgroundImage = btm_btn_8;
            btn_9.BackgroundImage = btm_btn_9;
            btn_0.BackgroundImage = btm_btn_0;
            btn_ce.BackgroundImage = btm_btn_ce;
            btn_c.BackgroundImage = btm_btn_c;
            btn_back.BackgroundImage = btm_btn_back;
            btn_plus.BackgroundImage = btm_btn_plus;
            btn_min.BackgroundImage = btm_btn_min;
            btn_mul.BackgroundImage = btm_btn_mul;
            btn_div.BackgroundImage = btm_btn_div;
            btn_result.BackgroundImage = btm_btn_result;
            btn_plma.BackgroundImage = btm_btn_plma;
            btn_decpoint.BackgroundImage = btm_btn_decpoint;
            this.BackgroundImage = btm_main_background;
            tbl_main.BackgroundImage = btm_main_background;
        }

        private void setThemaFromCode(String Folder)
        {
            btn_0.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");
            btn_9.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffad2");

            btn_plma.BackColor = System.Drawing.ColorTranslator.FromHtml("#acccc9");
            btn_decpoint.BackColor = System.Drawing.ColorTranslator.FromHtml("#acccc9");

            btn_min.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_mul.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_div.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_result.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_ce.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_c.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_back.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");
            btn_plus.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9f5e7");

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#faac64");
            tbl_main.BackColor = System.Drawing.ColorTranslator.FromHtml("#faac64");
            ms_main.BackColor = System.Drawing.ColorTranslator.FromHtml("#faac64");

            btn_result.BackColor = System.Drawing.ColorTranslator.FromHtml("#a34f4d");

        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (tb_data.TextLength <= 1)
            {
                tb_data.Text = "0";
            }
            else
            {
                tb_data.Text = convert_num(tb_data.Text.Substring(0, tb_data.TextLength - 1));
            }
        }

        private void btn_c_Click(object sender, EventArgs e)
        {
            tb_data.Text = "0";
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            tb_data_opr((Button)sender);
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            if (_tmpOpr != "")
            {
                tb_data.Text = oprator(_tmpData, _tmpOpr, tb_data.Text);
                _tmpData = "0";
            }
        }

        private void btn_ce_Click(object sender, EventArgs e)
        {
            _tmpOpr = "";
            _tmpData = "0";
            tb_data.Text = "0";
        }

        private void btn_decpoint_Click(object sender, EventArgs e)
        {
            tb_data_Insert((Button)sender);
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            tb_data_opr((Button)sender);
        }

        private void btn_mul_Click(object sender, EventArgs e)
        {
            tb_data_opr((Button)sender);
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            tb_data_opr((Button)sender);
        }

        private void btn_plma_Click(object sender, EventArgs e)
        {
            tb_data.Text = oprator(tb_data.Text, "*", "-1");
        }

        private void Cel_Load(object sender, EventArgs e)
        {

        }

        private void 홈페이지바로가기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://duration.digimoon.net");
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void tb_data_TextChanged(object sender, EventArgs e)
        {
            tb_data.Text = convert_num(tb_data.Text);
            tb_data.Select(tb_data.Text.Length, 0);
        }

        private void tb_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "\t심플 계산기 Beta\n-'일단 뭐든 만들어 보자' 프로젝트 ①-\n\n문의 : cyydo96@naver.com\n\n\tⓒ2018 슬픔";
            string caption = "정보";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "개발 준비중입니다.";
            string caption = "Beta";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }
    }
}
