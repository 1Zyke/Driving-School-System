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
    public partial class Trainers : Form
    {
        public Trainers()
        {
            InitializeComponent();
            ShowTrainer();
        }
        private void ShowTrainer()
        {
            Query = "select * from TrainerTbl";
            DataSet ds = Mt.ShowData(Query);
            TrainersDGV.DataSource = ds.Tables[0];
        }
        Methods Mt = new Methods();
        String Query;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ShowTrainer();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (TnameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Tname = TnameTb.Text;
                    string Tphone = PhoneTb.Text;
                    string Address = AddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string TDOB = DOB.Value.Date.ToString();
                    Query = "insert into TrainerTbl(TrName, TrPhone, TrAddress, TrGender, TrDOB)values('" + Tname + "','" + Tphone + "','" + Address + "','" + Gender + "','" + DOB.Value.Date + "')";
                    Mt.InsertData(Query, "Trainer Inserted");
                    ShowTrainer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }

        }
        int key = 0;
        private void TrainersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TnameTb.Text = TrainersDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = TrainersDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = TrainersDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenderCb.Text = TrainersDGV.SelectedRows[0].Cells[4].Value.ToString();

            string Tname = TnameTb.Text;
            string Tphone = PhoneTb.Text;
            string Address = AddressTb.Text;
            string Gender = GenderCb.SelectedItem.ToString();
            string TDOB = DOB.Value.Date.ToString();
            if (TnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TrainersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (TnameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Tname = TnameTb.Text;
                    string Tphone = PhoneTb.Text;
                    string Address = AddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string TDOB = DOB.Value.Date.ToString();
                    Query = "update TrainerTbl set TrName='" + Tname + "', TrPhone='" + Tphone + "', TrAddress='" + Address + "', TrGender='" + Gender + "', TrDOB='" + DOB.Value.Date + "'where TrId=" + key + "";
                    Mt.InsertData(Query, "Trainer Updated");
                    ShowTrainer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Trainer");
            }
            else
            {
                try
                {

                    Query = "delete from TrainerTbl where TrId=" + key + "";
                    Mt.InsertData(Query, "Trainer Deleted");
                    ShowTrainer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SearchTrainer()
        {
            Query = "select * from TrainerTbl WHERE TrName LIKE '" + SearchTb.Text + "'+'%';";
            DataSet ds = Mt.ShowData(Query);
            TrainersDGV.DataSource = ds.Tables[0];
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
