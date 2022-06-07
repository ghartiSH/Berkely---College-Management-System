using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Berkeley
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                this.showData();
            }
        }
        private void showData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT teacher_id , teacher_name as ""Full Name"", teacher_salary as ""Salary"", teacher_email as ""Email"", teacher_phone as ""Phone"", to_char(teacher_dob, 'dd-mon-yyyy') as Dob, teacher_gender as ""Gender"", teacher_qualification as ""Qualification"" FROM Teachers";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teachers");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            studentgv.DataSource = dt;
            studentgv.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                // insert code
                string id = idTextbox.Text.ToString();
                string name = nameTextbox.Text.ToString();
                int salary = Convert.ToInt32(salaryTextbox.Text);
                string email = emailTextbox.Text.ToString();
                string phone = phoneTextbox.Text.ToString();
                string dob = dateTextbox.Text.ToString();
                string gender = ddlGender.SelectedValue.ToString();
                string qual = qualTextbox.Text.ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnAdd.Text == "ADD")
                {

                    OracleCommand cmd = new OracleCommand("Insert into teachers Values('" + id + "','" + name + "','" + salary + "','" + email + "','" + phone + "','" + dob + "','" + gender + "','" + qual + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                else if (btnAdd.Text == "UPDATE")
                {

                    OracleCommand cmd = new OracleCommand("update teachers set teacher_name = '" + name + "',  teacher_salary= '" + salary + "', teacher_email = '" + email + "' , teacher_phone = '" + phone + "' , teacher_dob = '" + dob + "',teacher_gender = '" + gender + "',teacher_qualification = '" + qual + "' where teacher_id = '" + id + "'");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    btnAdd.Text = "ADD";
                    headLabel.Text = "ADD TEACHER";
                    studentgv.EditIndex = -1;

                }



                idTextbox.Text = "";
                nameTextbox.Text = "";
                salaryTextbox.Text = "";
                emailTextbox.Text = "";
                phoneTextbox.Text = "";
                dateTextbox.Text = "";
                qualTextbox.Text = "";
                invalid.Visible = false;
                this.showData();
            }
            catch (Exception)
            {
                invalid.Visible = true;
            }
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            this.showData();
            studentgv.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string teacher_id = (studentgv.DataKeys[e.RowIndex].Values[0]).ToString();
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Teachers WHERE teacher_id = '" + teacher_id + "'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                this.showData();
                studentgv.EditIndex = -1;
            }
            catch (Exception)
            {
                deleteInvalid.Visible = true;
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != studentgv.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
            //this.BindGrid();
            studentgv.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            idTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[1].Text;
            nameTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[2].Text;
            salaryTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[3].Text;
            emailTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[4].Text;
            phoneTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[5].Text;
            dateTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[6].Text;
            ddlGender.SelectedValue = this.studentgv.Rows[e.NewEditIndex].Cells[7].Text;
            qualTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[8].Text;
            headLabel.Text = "UPDATE TEACHER";
            btnAdd.Text = "UPDATE";


        }
    }
}