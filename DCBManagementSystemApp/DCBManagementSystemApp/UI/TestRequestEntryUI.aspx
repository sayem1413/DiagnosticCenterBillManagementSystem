<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DCBManagementSystemApp.UI.TestRequestEntryUI" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request Entry</title>
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
                    <li  class="selected">
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
                                    <label for="patientName">Name of the Patient </label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="patientNameTextBox"></asp:TextBox>
                                </td>
                             </tr>
                            <tr>
                                <td>
                                    <label for="birthDate">Date Of Birth</label>
                                </td>
                                <td>
                                    <input  type="date" id="birthDateTextBox" name="birthDateTextBox" runat="server" />
                                </td>
                             </tr>
                                <tr>
                                    <td>
                                        <label for="mobileNoType">Moblie No </label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="mobileNoTextBox"></asp:TextBox>
                                    </td>
                                </tr>
                            <tr>
                                <td>
                                    <label for="selectTestType">Select Test </label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="selectTestTypeDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectTestTypeDropDown_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <label for="fee">FEE </label>
                                    <asp:TextBox runat="server" ID="feeTextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView Width="340px" ID="requestTestGridView" runat="server" ViewStateMode="Enabled" AllowPaging="true"
                OnPageIndexChanging="requestTestGridView_PageIndexChanging" AutoGenerateColumns="false" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="DarkCyan">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <span><%#Container.DataItemIndex + 1%></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Test">
                                                <ItemTemplate>
                                                    <%#Eval("TestName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fee">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="testFee" ID="feeLabel" class="calculate" onchange="calculate()" runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                             <tr>
                                 <td>
                                     <label for="totall">Totall</label>
                                 </td>
                                 <td>
                                     <asp:TextBox runat="server" ID="totallTextBox"></asp:TextBox>
                                 </td>
                             </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="requestEntryButton" Text="Save" OnClick="requestEntryButton_Click"/>
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


