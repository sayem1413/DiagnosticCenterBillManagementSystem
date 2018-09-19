<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DCBManagementSystemApp.UI.TestTypeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type Setup</title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
    <div>
        <div class="background">
        <div class="page">

            <a href="../html%20pages/index.html" id="logo">Void Diagnostic Center LTD</a>
            <div class="sidebar">
                <ul>
                    <li>
                        <a href="Report2.aspx">Type Report</a>
                    </li>
                    <li>
                        <a href="UnpaidBillUI.aspx">Unpaid Bill</a>
                    </li>
                    <li>
                        <a href="TestRequestEntryUI.aspx">Test Request</a>
                    </li>
                    <li>
                        <a href="PaymentUI.aspx">Payment</a>
                    </li>
                    <li class="selected">
                        <a href="../html%20pages/index.html">Log Out</a>
                    </li>
                    <li>
                        <a href="ReportUI.aspx">Test Report</a>
                    </li>
                </ul>               
            </div>
            <div class="body">
                    <div class="featured">
                        <img src="../images/doctors-2.jpg"  height="177px"/>
                    </div>
                <div id="margin-padding">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <label for="typeName">Type Name </label>
                                </td>
                                <td>
                                    <asp:TextBox ID="typeNameTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="saveTypeButton" runat="server" Text="Save" OnClick="saveTypeButton_Click"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="typeExistLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td> </td>
                            <td colspan="1">
                                <asp:GridView ID="testTypeGridView" runat="server" AutoGenerateColumns="False" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="DarkCyan">
                                    <Columns>
                                             <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <%#Eval("TypeId") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type Name">
                                                <ItemTemplate>
                                                    <%#Eval("TestTypeName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                    
                    </div>
                    <div id="margin-padding">
                        <button type="button" class="btn btn-default"><a href="TestSetupUI.aspx"><strong>Test Setup >>></strong></a></button>
                    </div>
                 </div>
            </div>
            <div class="footer">
                <div>
                    <div>
                        <h4>Contact Us</h4>
                        <p>
                            Address- some where some Place you can try to catch us. we are invisible.
                        </p>
                        <a href="../html%20pages/contact.html">Contact Us</a>
                    </div>
                    <div>
                        <h4></h4>
                        <ul>
                            <li>
                                <a href="../html%20pages/index.html">Home</a>
                            </li>
                            <li>
                                <a href="../html%20pages/Programs.html">Program</a>
                            </li>
                            <li>
                                <a href="../html%20pages/about.html">About</a>
                            </li>
                            <li>
                                <a href="../html%20pages/services.html">Services</a>
                            </li>
                            <li>
                                <a href="../html%20pages/blog.html">Blog</a>
                            </li>
                            <li>
                                <a href="../html%20pages/contact.html">Contact</a>
                            </li>
                        </ul>
                    </div>
                    <div class="connect">
                        <h4>Keep In Touch</h4>
                        <a href="http://wwww.twitter.com" id="twitter">twitter</a> <a href="http://wwww.facebook.com" id="facebook">facebook</a> <a href="http://plus.google.com" id="googleplus">google+</a>
                    </div>
                </div>
                <p>
                    &#169; Copyright 2016. All rights reserved
                </p>
            </div>
        </div>
    </div>
    
    </div>
    </form>
</body>
</html>
