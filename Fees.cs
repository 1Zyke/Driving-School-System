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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
            ShowFees();
            GetLearner();
            GetCourse();
        }
        private void FetchPrice()
        {
            Mt.FetchCost(CourseCb, AmountTb);

        }

        private void GetLearner()
        {
            string Query = "select * from LearnerTbl";
            string Data = "LID";

            Mt.FillCombobox(Query, Data, LearnerCb);
        }

        private void GetCourse()
        {
            string Query = "select * from CourseTbl";
            string Data = "CID";

            Mt.FillCombobox(Query, Data, CourseCb);
        }

        Methods Mt = new Methods();
        String Query;
        private void ShowFees()
        {
            Query = "select * from FeesTbl";
            DataSet ds = Mt.ShowData(Query);
            FeesDGV.DataSource = ds.Tables[0];
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (LearnerCb.SelectedIndex == -1 || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Learner = LearnerCb.SelectedValue.ToString();
                    DateTime Paydate = PDate.Value.Date;
                    string Amount = AmountTb.Text;
                    string Course = CourseCb.SelectedValue.ToString();
                    Query = "insert into FeesTbl(FLearner, FDate, FAmount, FCourse)values(" + Learner + ",'" + PDate.Value.Date.ToString() + "'," + Amount + "," + Course + ")";
                    Mt.InsertData(Query, "Fees Paid!!!");
                    ShowFees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void CourseCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchPrice();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            LearnerCb.SelectedIndex = -1;
            AmountTb.Text = "";
            CourseCb.SelectedIndex = -1;

        }
        private void SearchLearner()
        {
            Query = "select FNum as ID, LName, as Learner,FDate as Date, FAmount as Cost, FCourse as course from FeesTbl join LearnerTbl on Flearner = LID WHERE LName LIKE '" + SearchTb.Text + "'+'%';";
            DataSet ds = Mt.ShowData(Query);
            FeesDGV.DataSource = ds.Tables[0];
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ShowFees();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Learners Obj = new Learners();
            Obj.Show();
            this.Hide();
        }
    }
}
