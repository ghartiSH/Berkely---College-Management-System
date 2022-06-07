using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Berkeley
{
    public partial class Student_Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetStudentID();
                BindGrid();
            }
        }
        private void GetStudentID()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select student_id, student_name from students";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("students");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            idDDL.DataSource = dt;
            idDDL.DataTextField = "student_name";
            idDDL.DataValueField = "student_id";
            idDDL.DataBind();

        }
        private void BindGrid()
        {

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select s.student_id , s.student_name, s.student_phone, s.student_email,
                                m.module_code, m.module_name, m.module_head, a.grade from
                                students s join assignment_result a on s.student_id = a.student_id
                                join modules m on m.module_code = a.module_code";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("assignment_result");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            mainGrid.DataSource = dt;
            mainGrid.DataBind();


        }


        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string s_ID = idDDL.SelectedValue.ToString();

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @" Select s.student_id , s.student_name, s.student_phone, s.student_email,
                                m.module_code, m.module_name, m.module_head, a.grade from
                                students s join assignment_result a on s.student_id = a.student_id
                                join modules m on m.module_code = a.module_code
                                where a.student_id = '" + s_ID + "' ";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("assignment_result");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            mainGrid.DataSource = dt;
            mainGrid.DataBind();

        }
    }
}