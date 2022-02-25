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
    public partial class Learners : Form
    {
        public Learners()
        {
            InitializeComponent();
            ShowLearners();
        }
        private void SearchLearner()
        {
            Query = "select * from LearnerTbl WHERE LName LIKE '" + SearchTb.Text + "'+'%';";
            DataSet ds = Mt.ShowData(Query);
            LearnerDGV.DataSource = ds.Tables[0];
        }

        private void ShowLearners()
        {
            Query = "select * from LearnerTbl";
            DataSet ds = Mt.ShowData(Query);
            LearnerDGV.DataSource = ds.Tables[0];
        }
        Methods Mt = new Methods();
        String Query;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (LNameTb.Text == "" || LPhoneTb.Text == "" || LAddressTb.Text == "" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string LName = LNameTb.Text;
                    string LPhone = LPhoneTb.Text;
                    string Address = LAddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string TDOB = LDOB.Value.Date.ToString();
                    Query = "insert into LearnerTbl(LName, LPhone, LAddress, LGender, LDOB)values('" + LName + "','" + LPhone + "','" + Address + "','" + Gender + "','" + LDOB.Value.Date + "')"; 
                    Mt.InsertData(Query, "Learner Inserted");
                    ShowLearners();
                    ClearData();
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
        int key = 0;
        private void LearnerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LNameTb.Text = LearnerDGV.SelectedRows[0].Cells[1].Value.ToString();
            LPhoneTb.Text = LearnerDGV.SelectedRows[0].Cells[2].Value.ToString();
            LAddressTb.Text = LearnerDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenderCb.Text = LearnerDGV.SelectedRows[0].Cells[4].Value.ToString();

            string LName = LNameTb.Text;
            string LPhone = LPhoneTb.Text;
            string Address = LAddressTb.Text;
            string Gender = GenderCb.SelectedItem.ToString();
            // string LDOB = LDOB.Value.Date.ToString();
            if (LNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LearnerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (LNameTb.Text == "" || LPhoneTb.Text == "" || LAddressTb.Text == "" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string LName = LNameTb.Text;
                    string LPhone = LPhoneTb.Text;
                    string Address = LAddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string TDOB = LDOB.Value.Date.ToString();
                    Query = "update LearnerTbl set LName='" + LName + "', LPhone='" + LPhone + "', LAddress='" + Address + "', LGender='" + Gender + "', LDOB='" + LDOB.Value.Date + "' where LID="+key+"";
                    Mt.InsertData(Query, "Learner Updated");
                    ShowLearners();
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            SearchLearner();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            ShowLearners();
            SearchTb.Text = "";
        }
        private void ClearData()
        {
            LNameTb.Text = "";
            LPhoneTb.Text = "";
            LAddressTb.Text = "";
            GenderCb.SelectedIndex = -1;
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Learner");
            }
            else
            {
                try
                {

                    Query = "delete from LearnerTbl where LID=" + key + "";
                    Mt.InsertData(Query, "Learner Deleted");
                    ShowLearners();
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }
    }
}
