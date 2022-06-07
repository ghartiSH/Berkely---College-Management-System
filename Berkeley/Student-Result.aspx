<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student-Result.aspx.cs" Inherits="Berkeley.Student_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .tablecss{
            margin-top:50px;
        }
        h2{
            padding:0px 0px;
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
            width: 100px;
            bottom: -10px;
            left: 0;
            right: 0;
         }
        .button1{
            margin-top:30px;
        }
        .dropdown{
            height:50px;
            font-size:18px;
            width:50%;
        }
    </style>
    <div>
        <h1 class="underline">Student - Result</h1>
    </div>
    <div class="jumbotron">
        <div class="form-group-lg">
            <asp:Label ID="Label1" runat="server" Text="Select Student : "></asp:Label> <br />
            <asp:DropDownList ID="idDDL" runat="server" class="dropdown"></asp:DropDownList><br />
            <asp:Button ID="searchBtn" runat="server" class="button1 btn btn-primary" Text="Search Student" OnClick="SearchBtn_Click" />
        </div>
        <div class="tablecss">
            <h2 class="underline">Details of Students and their Module Results:</h2>
            <asp:GridView ID="mainGrid" runat="server" DataKeyNames="student_id" class =" tablecss table table-striped" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" ForeColor="Black" GridLines="Vertical">
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
</asp:Content>
