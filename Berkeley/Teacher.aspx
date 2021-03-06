<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Berkeley.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        *{
            margin:auto
        }
      
        .input{
            margin-top:30px;
            width:50%;
        }
        .label{
            font-size:24px;
        }

        .box{
            height:40px;
            font-size:24px;
            width:80%;
            border-radius:5px;
        }
        .heading{
            width:100%;
            font-size:32px;
            text-align:center;
            font-weight:700;
        }

        .gridbox{
            margin-top:30px;
            display:flex;
            flex-direction:column;
        }
        .underline{
            position: relative;
            text-decoration: none;
}

        .underline::after{
            position: absolute;
            content: '';
            height: 3px;
            background: #34ccff;
            width: 50px;
            bottom: -4px;
            left: 0;
            right: 0;
            margin: auto;
         }
         .invalid{
            font-size:12px;
            color:red;
            text-align:center;
            font-style:italic;
        }
        .form-div{
            display:flex;
            flex-direction:column;
        }

        
    </style>
    <div class="jumbotron">
        <div class="form-div">
            <div style="width:55%; display:flex; flex-wrap:wrap;" >
            <asp:Label ID="headLabel" runat="server" class="heading underline">ADD TEACHER</asp:Label>

            <div class=" form-group-lg input">
                <asp:Label ID="idLabel" runat="server" Text="Teacher ID:"></asp:Label>
                <asp:TextBox ID="idTextbox" runat="server" class="form-control" placeholder="101A"></asp:TextBox>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="nameLabel" runat="server" Text="Full Name:"></asp:Label><br />
                <asp:TextBox ID="nameTextbox" runat="server" class="form-control" placeholder="John Smith"></asp:TextBox>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="addressLabel" runat="server" Text="Salary:"></asp:Label><br />
                <asp:TextBox ID="salaryTextbox" runat="server" class="form-control" placeholder="2000"></asp:TextBox>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label><br />
                <asp:TextBox ID="emailTextbox" runat="server" class="form-control" placeholder="abc@email.com"></asp:TextBox>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="phoneLabel" runat="server" Text="Phone No.:"></asp:Label><br />
                <asp:TextBox ID="phoneTextbox" runat="server" class="form-control" placeholder="98785465122"></asp:TextBox>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="dateLabel" runat="server" Text="Date of Birth:"></asp:Label><br />
                <asp:TextBox ID="dateTextbox" runat="server" class="form-control" placeholder="01-Jan-2000"></asp:TextBox> 
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="Label6" runat="server" Text="Gender:"></asp:Label><br />
                <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group-lg input">
                <asp:Label ID="Label1" runat="server" Text="Qualification:"></asp:Label><br />
                <asp:TextBox ID="qualTextbox" runat="server" class="form-control" placeholder="BIT"></asp:TextBox> 
            </div>
        </div>
        <div style="margin-top:20px;">
            <asp:Label ID="invalid" runat="server" Text="Invalid Data input" Visible="false" class="invalid"></asp:Label><br />
            <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" class="btn btn-primary"/>
        </div>
        </div>
        <hr />
        <div style="margin-top:50px; display:flex; flex-direction:column;">
            <asp:Label ID="manageLabel" runat="server" class="heading underline">MANAGE TEACHERS</asp:Label>
            <div class="gridbox">
                <asp:Label ID="deleteInvalid" runat="server" Text="Can't Delete a data which is linked to other tables..!!" Visible="false" class="invalid"></asp:Label><br />
                <asp:GridView ID="studentgv" class="table table-striped" runat="server" DataKeyNames="Teacher_id" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="True" AutoGenerateDeleteButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
