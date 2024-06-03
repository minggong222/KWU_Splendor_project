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
        public event EventHandler<string[]> DataUpdated2;

        private string[] initialData;
        private bool decision; // 1: 보석 가져오기 0: 보석 버리기

        public Form2(string[] initialData, bool decision)
        {
            InitializeComponent();
            this.initialData = initialData;     //form1에서 받은 초기 데이터 저장
            this.decision = decision;
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

            if(decision) //보석 가져오기
            {
                num_dia.Visible = false;
                num_eme.Visible = false;
                num_ony.Visible = false;
                num_rub.Visible = false;
                num_saf.Visible = false;

                chk_dia.Visible = true;
                chk_eme.Visible = true;
                chk_ony.Visible = true;
                chk_rub.Visible = true;
                chk_saf.Visible = true;

                btn_buy.Text = "가져오기";
            }
            else //보석 버리기
            {
                chk_dia.Visible = false;
                chk_eme.Visible = false;
                chk_ony.Visible = false;
                chk_rub.Visible = false;
                chk_saf.Visible = false;

                num_dia.Visible = true;
                num_eme.Visible = true;
                num_ony.Visible = true;
                num_rub.Visible = true;
                num_saf.Visible = true;
                btn_buy.Text = "버리기";
            }

        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            if (decision)
            {
                int count = (chk_dia.Checked ? 1 : 0) + (chk_eme.Checked ? 1 : 0) + (chk_ony.Checked ? 1 : 0) + (chk_rub.Checked ? 1 : 0) + (chk_saf.Checked ? 1 : 0);
                bool countCheck = true;

                int dia_count = Convert.ToInt32(dia_num.Text.Substring(0, 1));
                int saf_count = Convert.ToInt32(saf_num.Text.Substring(0, 1));
                int eme_count = Convert.ToInt32(eme_num.Text.Substring(0, 1));
                int rub_count = Convert.ToInt32(rub_num.Text.Substring(0, 1));
                int ony_count = Convert.ToInt32(ony_num.Text.Substring(0, 1));

                if (count == 1)
                {
                    if (chk_dia.Checked)
                    {
                        if (dia_count < 4)
                        {
                            MessageBox.Show("보석의 갯수가 4개 이상이 아닙니다");
                        }
                        else
                        {
                            string[] updatedData = { (dia_count - 2).ToString() + "개", saf_num.Text, eme_num.Text, rub_num.Text, ony_num.Text };
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
                else if (count == 3)
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
            else
            {
                bool check = false;

                string dia_count = num_dia.Value.ToString() + "개";
                string eme_count = num_eme.Value.ToString() + "개";
                string saf_count = num_saf.Value.ToString() + "개";
                string rub_count = num_rub.Value.ToString() + "개";
                string ony_count = num_ony.Value.ToString() + "개";

                int total_gem = Convert.ToInt32(dia_num.Text.Substring(0, 1)) + Convert.ToInt32(eme_num.Text.Substring(0, 1))
                    + Convert.ToInt32(saf_num.Text.Substring(0, 1)) + Convert.ToInt32(rub_num.Text.Substring(0, 1)) + Convert.ToInt32(ony_num.Text.Substring(0, 1))
                    - Convert.ToInt32(num_dia.Value + num_ony.Value + num_eme.Value + num_saf.Value + num_rub.Value);

                if (total_gem <= 10) check = true;
                else MessageBox.Show("플레이어는 보석을 최대 10개까지 소지 할 수 있습니다!");

                if (Convert.ToInt32(dia_num.Text.Substring(0, 1)) < Convert.ToInt32(num_dia.Value))
                {
                    MessageBox.Show("현재 가지고 있는 보석보다 더 버릴수 없습니다!");
                    check = false;
                }
                if (Convert.ToInt32(saf_num.Text.Substring(0, 1)) < Convert.ToInt32(num_saf.Value))
                {
                    MessageBox.Show("현재 가지고 있는 보석보다 더 버릴수 없습니다!");
                    check = false;
                }
                if (Convert.ToInt32(eme_num.Text.Substring(0, 1)) < Convert.ToInt32(num_eme.Value))
                {
                    MessageBox.Show("현재 가지고 있는 보석보다 더 버릴수 없습니다!");
                    check = false;
                }
                if (Convert.ToInt32(rub_num.Text.Substring(0, 1)) < Convert.ToInt32(num_rub.Value))
                {
                    MessageBox.Show("현재 가지고 있는 보석보다 더 버릴수 없습니다!");
                    check = false;
                }
                if (Convert.ToInt32(ony_num.Text.Substring(0, 1)) < Convert.ToInt32(num_ony.Value))
                {
                    MessageBox.Show("현재 가지고 있는 보석보다 더 버릴수 없습니다!");
                    check = false;
                }


                if (check)
                {
                    string[] updatedData = { dia_count, saf_count, eme_count, rub_count, ony_count };
                    DataUpdated2.Invoke(this, updatedData);
                    this.Close();
                }
            }
        }

        private void numericupdown_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }
    }
}
