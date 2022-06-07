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
    public partial class Teacher_Module : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetTeacherID();
                BindGrid();
            }
        }
        private void GetTeacherID()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select teacher_id, teacher_name from teachers";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            idDDL.DataSource = dt;
            idDDL.DataTextField = "teacher_name";
            idDDL.DataValueField = "teacher_id";
            idDDL.DataBind();

        }
        private void BindGrid()
        {

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select t.teacher_id , t.teacher_name, t.teacher_phone, t.teacher_email,
                                m.module_code, m.module_name, m.module_head from
                                teachers t join teacher_module tm on t.teacher_id = tm.teacher_id
                                join modules m on m.module_code = tm.module_code";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher_module");

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
            string t_ID = idDDL.SelectedValue.ToString();

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @" Select t.teacher_id , t.teacher_name, t.teacher_phone, t.teacher_email,
                                m.module_code, m.module_name, m.module_head from
                                teachers t join teacher_module tm on t.teacher_id = tm.teacher_id
                                join modules m on m.module_code = tm.module_code
                                where tm.teacher_id = '"+ t_ID+ "' ";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher_Module");

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