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
    public partial class Address : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT address_id, address_details FROM Addresses";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("addresses");

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
                int id = Convert.ToInt32(idTextbox.Text);
                string name = nameTextbox.Text.ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnAdd.Text == "ADD")
                {

                    OracleCommand cmd = new OracleCommand("Insert into Addresses Values('" + id + "','" + name + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                else if (btnAdd.Text == "UPDATE")
                {

                    OracleCommand cmd = new OracleCommand("update Addresses set address_details = '" + name + "' where address_id = '" + id + "'");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    btnAdd.Text = "ADD";
                    headLabel.Text = "ADD ADDRESS";
                    studentgv.EditIndex = -1;

                }



                idTextbox.Text = "";
                nameTextbox.Text = "";
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
                string add_id = (studentgv.DataKeys[e.RowIndex].Values[0]).ToString();
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Addresses WHERE address_id = '" + add_id + "'"))
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
            nameTextbox.Text = this.studentgv.Rows[e.NewEditIndex].Cells[2].Text;;
            headLabel.Text = "UPDATE ADDRESS";
            btnAdd.Text = "UPDATE";


        }
    }
}