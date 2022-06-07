<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Berkeley._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .link{
            margin: 10px 0px;
            font-size:18px;
        }
        .link:hover{
            color:black;
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
            bottom: -10px;
            left: 0;
            right: 0;
         }
        ul{
           margin-top:30px;
        }
    </style>

    <div class="jumbotron">
        <h1>Welcome to Berkeley College Dashboard</h1>
        <p class="lead underline" > Manage Students, Teachers and other records very easily....</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="jumbotron">
                <h2 class="underline"> Simple Forms</h2>
                <ul class="nav navbar">
                    <li><a href="Student.aspx" class="link">Students <br /> <span style="font-size:16px; font-style:italic"> Create, Update, View and Delete Students Data..</span></a></li>
                    <hr style="border-color:white" />
                    <li><a href="Teacher.aspx" class="link">Teachers <br /> <span style="font-size:16px; font-style:italic"> Create, Update, View and Delete Teachers Data..</span></a></li>
                    <hr style="border-color:white" />
                    <li><a href="Module.aspx" class="link">Modules <br /> <span style="font-size:16px; font-style:italic"> Create, Update, View and Delete Modules Data..</span></a></li>
                    <hr style="border-color:white" />
                    <li><a href="Address.aspx" class="link">Addresses <br /> <span style="font-size:16px; font-style:italic"> Create, Update, View and Delete Addresses Data..</span></a></li>
                    <hr style="border-color:white" />
                    <li><a href="Department.aspx" class="link">Departments <br /> <span style="font-size:16px; font-style:italic"> Create, Update, View and Delete Departments Data..</span></a></li>
            </ul>
            </div>
        </div>
        <div class="col-md-6">
           <div class="jumbotron">
               <h2 class="underline">Complex Forms</h2>
                 <ul class="nav navbar">
                    <li><a href="Student-Fee.aspx" class="link">Student-Fee <br /> <span style="font-size:16px; font-style:italic"> View Students' details and their fee status. </span></a></li>
                    <hr style="border-color:white" />

                    <li><a href="Teacher-Module.aspx" class="link">Teacher-Module <br /> <span style="font-size:16px; font-style:italic"> View Teachers' details and their modules' details.</span></a></li>
                    <hr style="border-color:white" />

                    <li><a href="Student-Result.aspx" class="link">Student-Result <br /> <span style="font-size:16px; font-style:italic"> View Students' details and their module results.</span></a></li>
                    <hr style="border-color:white" />

                    <li><a class="link"> - <br /> <span style="font-size:16px; font-style:italic"> . </span></a></li>
                    <hr style="border-color:white" />

                    <li><a class="link"> -  <br /> <span style="font-size:16px; font-style:italic"> . </span> </a></li>
            </ul>
           </div>
        </div>
    </div>

</asp:Content>
