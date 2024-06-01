using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWU_Splendor
{
    public partial class Form2 : Form
    {
        public event EventHandler<string[]> DataUpdated;

        private string[] initialData;

        public Form2(string[] initialData)
        {
            InitializeComponent();
            this.initialData = initialData;     //form1에서 받은 초기 데이터 저장
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //초기값 label에 출력
            dia_num.Text = initialData[0];
            saf_num.Text = initialData[1];
            eme_num.Text = initialData[2];
            rub_num.Text = initialData[3];
            ony_num.Text = initialData[4];
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            int count = (chk_dia.Checked ? 1 : 0) + (chk_eme.Checked ? 1 : 0)+ (chk_ony.Checked ? 1 : 0) + (chk_rub.Checked ? 1 : 0) + (chk_saf.Checked ? 1 : 0);
            bool countCheck = true;

            int dia_count = Convert.ToInt32(dia_num.Text.Substring(0, 1));
            int saf_count = Convert.ToInt32(saf_num.Text.Substring(0, 1));
            int eme_count = Convert.ToInt32(eme_num.Text.Substring(0, 1));
            int rub_count = Convert.ToInt32(rub_num.Text.Substring(0, 1));
            int ony_count = Convert.ToInt32(ony_num.Text.Substring(0, 1));

            if ( count == 1)
            {
                if (chk_dia.Checked)
                {
                    if(dia_count < 4)
                    {
                        MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                    }
                    else
                    {
                        string[] updatedData = { (dia_count-2).ToString()+"개", saf_num.Text, eme_num.Text, rub_num.Text, ony_num.Text };
                        DataUpdated?.Invoke(this, updatedData);
                        this.Close();
                    }
                }
                if (chk_eme.Checked)
                {
                    if (eme_count < 4)
                    {
                        MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                    }
                    else
                    {
                        string[] updatedData = { dia_num.Text, saf_num.Text, (eme_count - 2).ToString() + "개", rub_num.Text, ony_num.Text };
                        DataUpdated?.Invoke(this, updatedData);
                        this.Close();
                    }
                }
                if (chk_ony.Checked)
                {
                    if (ony_count < 4)
                    {
                        MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                    }
                    else
                    {
                        string[] updatedData = { dia_num.Text, saf_num.Text, eme_num.Text, rub_num.Text, (ony_count - 2).ToString() + "개" };
                        DataUpdated?.Invoke(this, updatedData);
                        this.Close();
                    }
                }
                if (chk_rub.Checked)
                {
                    if (rub_count < 4)
                    {
                        MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                    }
                    else
                    {
                        string[] updatedData = { dia_num.Text, saf_num.Text, eme_num.Text, (rub_count - 2).ToString() + "개", ony_num.Text };
                        DataUpdated?.Invoke(this, updatedData);
                        this.Close();
                    }
                }
                if (chk_saf.Checked)
                {
                    if (saf_count < 4)
                    {
                        MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                    }
                    else
                    {
                        string[] updatedData = { dia_num.Text, (saf_count - 2).ToString() + "개", eme_num.Text, rub_num.Text, ony_num.Text };
                        DataUpdated?.Invoke(this, updatedData);
                        this.Close();
                    }
                }
            }
            else if( count == 3)
            {
                if (chk_dia.Checked)
                {
                    if (dia_count < 1)
                    {
                        MessageBox.Show("보석의 갯수가 1개 이상이 아닙니다");
                        countCheck = false;
                    }
                }
                if (chk_eme.Checked)
                {
                    if (eme_count < 1)
                    {
                        MessageBox.Show("보석의 갯수가 1개 이상이 아닙니다");
                        countCheck = false;
                    }
                }
                if (chk_ony.Checked)
                {
                    if (ony_count < 1)
                    {
                        MessageBox.Show("보석의 갯수가 1개 이상이 아닙니다");
                        countCheck = false;
                    }
                }
                if (chk_rub.Checked)
                {
                    if (rub_count < 1)
                    {
                        MessageBox.Show("보석의 갯수가 1개 이상이 아닙니다");
                        countCheck = false;
                    }
                }
                if (chk_saf.Checked)
                {
                    if (saf_count < 1)
                    {
                        MessageBox.Show("보석의 갯수가 1개 이상이 아닙니다");
                        countCheck = false;
                    }
                }
                if (countCheck)
                {
                    if (chk_dia.Checked) dia_num.Text = (dia_count - 1).ToString() + "개";
                    if (chk_eme.Checked) eme_num.Text = (eme_count - 1).ToString() + "개";
                    if (chk_ony.Checked) ony_num.Text = (ony_count - 1).ToString() + "개";
                    if (chk_rub.Checked) rub_num.Text = (rub_count - 1).ToString() + "개";
                    if (chk_saf.Checked) saf_num.Text = (saf_count - 1).ToString() + "개";
                    //update된 data form1으로 보냄
                    string[] updatedData = { dia_num.Text, saf_num.Text, eme_num.Text, rub_num.Text, ony_num.Text };
                    DataUpdated.Invoke(this, updatedData);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("잘못된 행동입니다");
            }
        }
    }
}
