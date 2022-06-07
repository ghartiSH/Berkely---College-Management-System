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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            cmd.CommandText = @"SELECT student_id, student_name, student_address, student_email, student_phone, to_char(student_dob, 'dd-mon-yyyy') as student_dob, student_gender FROM Students";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("students");

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
               
                string id = idTextbox.Text.ToString();
                string name = nameTextbox.Text.ToString();
                string address = addressTextbox.Text.ToString();
                string email = emailTextbox.Text.ToString();
                string phone = phoneTextbox.Text.ToString();
                string dob = dateTextbox.Text.ToString();
                string gender = ddlGender.SelectedValue.ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnAdd.Text == "ADD")
                {

                    OracleCommand cmd = new OracleCommand("Insert into students Values('" + id + "','" + name + "','" + address + "','" + email + "','" + phone + "','" + dob + "','" + gender + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                else if (btnAdd.Text == "UPDATE")
                {

                    OracleCommand cmd = new OracleCommand("update students set student_name = '" + name + "', student_address = '" + address + "', student_email = '" + email + "' , student_phone = '" + phone + "' , student_dob = '" + dob + "',student_gender = '" + gender + "' where student_id = '" + id + "'");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    btnAdd.Text = "ADD";
                    headLabel.Text = "ADD STUDENT";
                    studentgv.EditIndex = -1;
                }



                idTextbox.Text = "";
                nameTextbox.Text = "";
                addressTextbox.Text = "";
                emailTextbox.Text = "";
                phoneTextbox.Text = "";
                dateTextbox.Text = "";
                invalid.Visible = false;

                this.showData();
            }
            catch (Exception) { 
                invalid.Visible=true;
            }
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            this.showData();
            studentgv.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try {

                string student_id = (studentgv.DataKeys[e.RowIndex].Values[0]).ToString();
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Students WHERE student_id = '" + student_id + "'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                this.showData();
                studentgv.EditIndex = -1;
                deleteInvalid.Visible = false;
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
            addressTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[3].Text;
            emailTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[4].Text;
            phoneTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[5].Text;
            dateTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[6].Text;
            ddlGender.SelectedValue = this.studentgv.Rows[e.NewEditIndex].Cells[7].Text;
            headLabel.Text = "UPDATE STUDENT";
            btnAdd.Text = "UPDATE";
        }
    }
}