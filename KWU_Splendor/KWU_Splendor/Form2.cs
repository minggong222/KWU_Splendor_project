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
            //update된 data form1으로 보냄
            string[] updatedData = { dia_num.Text, saf_num.Text, eme_num.Text, rub_num.Text, ony_num.Text };
            DataUpdated?.Invoke(this, updatedData);
            this.Close();
        }
    }
}
