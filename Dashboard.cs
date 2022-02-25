using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            ShowTrainers();
            ShowLearners();
            SumAmount();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        Methods Mt = new Methods();
        String Query;
        private void ShowTrainers()
        {
            Query = "select count(*) from TrainerTbl";
            Mt.GetData(TrainerLbl, Query);
        }
        private void ShowLearners()
        {
            Query = "select count(*) from LearnerTbl";
            Mt.GetData(LearnerLbl, Query);
        }
        private void SumAmount()
        {
            Query = "select Sum(FAmount) from FeesTbl";
            Mt.GetData(FinanceLbl, Query);
            FinanceLbl.Text = "Rs "+ FinanceLbl.Text;
        }
        private void TrainerLbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Learners Obj = new Learners();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Courses Obj = new Courses();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }
    }
}
