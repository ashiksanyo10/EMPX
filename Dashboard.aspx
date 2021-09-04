<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeProductivityManagement.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <%--<div class="mt-lg-4 ">
            <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
                
                <div class="row">
                    <div class="form-group col-lg-4">
                        <label>
                            Filter By</label>
                        <select class="custom-select">
                            <option value="0">Select Type</option>
                            <option value="1">IP Address</option>
                            <option value="2">User Name</option>
                        </select>
                    </div>
                    <div class="form-group col-lg-4">
                        <label>
                            Select Account</label>
                        <select class="custom-select">
                            <option value="0">Select account</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>--%>
    <div class="row tm-content-row mt-lg-4">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 tm-block-col">
            <div class="tm-bg-primary-dark tm-block">
                <h2 class="tm-block-title">
                    Date :  <asp:Label ID="lblDate" runat="server" Text='<%# Eval("recDate","{0:dd-MM-yyyy}") %>' ></asp:Label> </h2>
                <table class="table  table-hover">
                <tr>
                        <th>
                            IP Address
                        </th>
                        <td>
                            <asp:Label ID="lblIP" runat="server" Text='<%# Eval("ip") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Username
                        </th>
                        <td>
                             <asp:Label ID="lblUser" runat="server" Text='<%# Eval("user") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Idle Time(Seconds)
                        </th>
                        <td>
                             <asp:Label ID="lblIdle" runat="server" Text='<%# Eval("idleTime") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Restricted Applications Usage (Seconds)
                        </th>
                        <td>
                             <asp:Label ID="lblApplication" runat="server" Text='<%# Eval("restrictedProcess") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="mt-md-2">
                    <asp:Button ID="btnReset" OnClientClick="return confirm('Are You Sure?');" runat="server" Text="Reset" class="btn btn-info" OnClick="btnReset_Click" CommandArgument='<%# Eval("recDate")+","+Eval("ip") %>' />
                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-success" NavigateUrl='<%# "/Analysis.aspx?Date="+Eval("recDate") %>'>Visualize</asp:HyperLink>
                    <asp:Button ID="btnGenerate" runat="server" Text="Genrate Report" class="btn btn-danger" OnClick="btnGenerate_Click" CommandArgument='<%# Eval("recDate") %>' />
                </div>
            </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
        
        
    </div>
    </div>
</asp:Content>
