using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameDefine;

namespace KWU_Splendor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_coin_Click(object sender, EventArgs e)
        {
            //string 배열에 label 데이터 저장 
            string[] labelsData = { dia.Text, saf.Text, eme.Text, rub.Text, ony.Text };

            Form2 form2 = new Form2(labelsData);
            form2.DataUpdated += Form2_DataUpdated;
            form2.Show();
        }
        private void Form2_DataUpdated(object sender, string[] newData)
        {
            //form2에서 update된 값 label에 할당
            dia.Text = newData[0];
            saf.Text = newData[1];
            eme.Text = newData[2];
            rub.Text = newData[3];
            ony.Text = newData[4];
        }

        private void btn_card_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
