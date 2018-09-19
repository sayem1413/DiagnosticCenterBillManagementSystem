<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DCBManagementSystemApp.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment service</title>
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
                    <li>
                        <a href="Report2.aspx">Type Report</a>
                    </li>
                    <li>
                        <a href="UnpaidBillUI.aspx">Unpaid Bill</a>
                    </li>
                    <li>
                        <a href="TestRequestEntryUI.aspx">Test Request</a>
                    </li>
                    <li  class="selected">
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
                                        <label for="billNo">Bill No </label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="billNoTextBox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="searchButton" Text="Search" OnClick="searchButton_Click"/>
                                    </td>   
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td colspan="2">
                                        <asp:GridView runat="server" ID="orderTestGridview" AutoGenerateColumns="False" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="DarkCyan">
                                            <Columns>
                                             <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <span><%#Container.DataItemIndex+1%></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Test ">
                                                <ItemTemplate>
                                                    <%#Eval("TestName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fee">
                                                <ItemTemplate>
                                                    <%#Eval("Fee") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="billDate">Bill Date</label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="billDateLabel"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="totallFee">Totall Fee</label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="totallFeeLabel"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="paidAmount">Paid Amount</label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="paidAmountLabel"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                         <label for="dueAmount">Due Amount</label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="deuAmountLabel"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="amount">Amount</label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="amountTextBox"></asp:TextBox>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="payButton" Text="Pay" OnClick="payButton_Click"/>
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

