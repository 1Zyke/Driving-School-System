using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School
{
    internal class Methods
    {
        protected SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\loren\Documents\CarDrivingDb.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }

        // Show Data in the DataGridView 

        public DataSet ShowData (String Query)
        {
            SqlConnection con = GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = Query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        // Fill ComboBox
        public void FillCombobox(String Query, String col, ComboBox Cb)
        {
            SqlConnection con = GetCon();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            cmd.CommandText= Query;
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add(col, typeof(int));
            dt.Load(Rdr);
            Cb.ValueMember = col;
            Cb.DataSource = dt;
            con.Close();
        }

        // DashBoard
        public void GetData(Label Lbl, string Query)
        {
            SqlConnection con = GetCon();
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Lbl.Text = dt.Rows[0][0].ToString();
        }

        // Fetch Data
        public void FetchCost(ComboBox Cb, TextBox Tb)
        {
            SqlConnection con = GetCon();
            string Query = "select * from CourseTbl where CID=" + Cb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Tb.Text = dr["CCost"].ToString();
            }
        }

        


        // Inserting Data in the database

        public void InsertData(String Query, String msg)
        {
            SqlConnection con = GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
