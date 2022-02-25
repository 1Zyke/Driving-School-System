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
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
            ShowCourse();
        }
        
        Methods Mt = new Methods();
        String Query;
        private void ShowCourse()
        {
            Query = "select * from CourseTbl";
            DataSet ds = Mt.ShowData(Query);
            CourseDGV.DataSource = ds.Tables[0];
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CDurationTb.Text == "" || AmountTb.Text == "" || TrainerCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string CName = CNameTb.Text;
                    string Trainer = TrainerCb.SelectedItem.ToString();
                    string Duration = CDurationTb.Text;
                    string Cost = AmountTb.Text;
                    string BDate = CBDate.Value.Date.ToString();
                    Query = "insert into CourseTbl(CName, CTrainer, CDuration, CCost, CBDate)values('" + CName + "','" + Trainer + "','" + Duration + "','" + Cost + "','" + CBDate.Value.Date.ToString() + "')";
                    Mt.InsertData(Query, "Course Inserted");
                    ShowCourse();
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

        private void TrainerCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void CourseDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = CourseDGV.SelectedRows[0].Cells[1].Value.ToString();
            TrainerCb.Text = CourseDGV.SelectedRows[0].Cells[2].Value.ToString();
            CDurationTb.Text = CourseDGV.SelectedRows[0].Cells[3].Value.ToString();
            AmountTb.Text = CourseDGV.SelectedRows[0].Cells[4].Value.ToString();

            string CName = CNameTb.Text;
            string Trainer = TrainerCb.Text;
            string Duration = CDurationTb.Text;
            string Amount = AmountTb.Text;
            // string LDOB = LDOB.Value.Date.ToString();
            if (CNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CourseDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CDurationTb.Text == "" || AmountTb.Text == "" || TrainerCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string CName = CNameTb.Text;
                    string Trainer = TrainerCb.SelectedItem.ToString();
                    string Duration = CDurationTb.Text;
                    string Cost = AmountTb.Text;
                    string BDate = CBDate.Value.Date.ToString();
                    Query = "update CourseTbl set CName='" + CName + "', CTrainer='" + Trainer + "', CDuration='" + Duration + "', CCost='" + Cost + "', CBDate='" + CBDate.Value.Date.ToString() + "' where CID="+key+" ";
                    Mt.InsertData(Query, "Course Updated");
                    ShowCourse();
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
                MessageBox.Show("Select a Course");
            }
            else
            {
                try
                {

                    Query = "delete from CourseTbl where CID=" + key + "";
                    Mt.InsertData(Query, "Course Deleted");
                    ShowCourse();
                    //ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Learners Obj = new Learners();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Courses Obj = new Courses();
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
