<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report2.aspx.cs" Inherits="DCBManagementSystemApp.UI.Report2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Wise Report</title>
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
    <div>
        <div class="background">
        <div class="page">

            <a href="../html%20pages/index.html" id="logo">Void Diagnostic Center LTD</a>
            <div class="sidebar">
                <ul>
                    <li  class="selected">
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
                    <li>
                        <a href="../html%20pages/index.html">Log Out</a>
                    </li>
                    <li>
                        <a href="ReportUI.aspx">Test Report</a>
                    </li>
                </ul>               
            </div>
            <div class="body">
                
                <div class="featured">
                        <img src="../images/doctors-2.jpg" />
                </div>
                    <div id="margin-padding">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <label for="fromDate2">From Date</label>
                                </td>
                                <td>
                                    <input type="date" id="fromDateInput" name="fromDateInput" runat="server"/>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="toDate2">To Date</label>
                                </td>
                                <td>
                                    <input type="date" id="toDateInput" name="toDateInput" runat="server"/>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="typeShowButton" Text="Show" OnClick="typeShowButton_Click"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView AutoGenerateColumns="False" ID="typeReportGridView" runat="server" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="DarkCyan">
                                        <Columns>
                                             <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                   <span><%#Container.DataItemIndex + 1%></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Test Type Name">
                                                <ItemTemplate>
                                                    <%#Eval("TestTypeName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total no Of Test">
                                                <ItemTemplate>
                                                    <%#Eval("TotalNoTest") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="totalAmountLabel" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="pdfTypeButton" Text="PDF" OnClick="pdfTypeButton_Click"/>
                                </td>
                                <td>
                                    <label for="totalTest">Total</label>
                                    <asp:TextBox runat="server" ID="totalAmountTestTextBox"></asp:TextBox>
                                </td>
                                <td>
                                    
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
