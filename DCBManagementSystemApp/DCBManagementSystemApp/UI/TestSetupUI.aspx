<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DCBManagementSystemApp.UI.TestSetupUI1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Details Setup</title>
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
                                    <label for="testName">Test Name </label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="testNameTextBox"></asp:TextBox>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td for="fee">
                                    Fee
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="testFeeTestBox"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>BDT</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="testType">Test Type</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="testTypeDropDown"/>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="testDetailButton" Text="Save" OnClick="testDetailButton_Click"/>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="testExixtsLabel"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView AutoGenerateColumns="False" ID="testDetailsGridView" runat="server" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="DarkCyan">
                                        <Columns>
                                             <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <%#Eval("TestId") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Test Name">
                                                <ItemTemplate>
                                                    <%#Eval("TestName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fee">
                                                <ItemTemplate>
                                                    <%#Eval("Fee") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <%#Eval("TypeName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
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

