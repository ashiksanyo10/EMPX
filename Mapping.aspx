<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Mapping.aspx.cs" Inherits="EmployeeProductivityManagement.Mapping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row tm-content-row">
            <div class="col-12 tm-block-col">
                <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
                    <h2 class="tm-block-title">
                        List of Users</h2>
                    <p class="text-white">
                        Users</p>
                    <asp:DropDownList ID="ddlUsers" class="custom-select" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row tm-content-row">
            <div class="tm-block-col tm-col-avatar">
                <div class="tm-bg-primary-dark tm-block tm-block-avatar">
                    <h2 class="tm-block-title">
                    </h2>
                    <div class="tm-avatar-container">
                        <img id="userImage" src="img/usericon.jpg" alt="Avatar" class="tm-avatar img-fluid mb-4"
                            runat="server" />
                    </div>
                </div>
            </div>
            <div class="tm-block-col tm-col-account-settings">
                <div class="tm-bg-primary-dark tm-block tm-block-settings">
                    <h2 class="tm-block-title">
                        Employee Details</h2>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label>
                                Name</label>
                            <asp:TextBox ID="txtName" runat="server" class="form-control" required></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>
                                Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" required></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>
                                Phone Number</label>
                            <asp:TextBox ID="txtPhone" runat="server" class="form-control" required></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>
                                IP Address</label>
                            <asp:TextBox ID="txtIP" runat="server" class="form-control" required title="Invalid IP Address" pattern="\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b"></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-12">
                            <label class="tm-hide-sm">
                                &nbsp;</label>
                            <%--  <button
                    type="submit"
                    class="btn btn-primary btn-block text-uppercase"
                  >
                    Update Your Profile
                  </button>--%>
                            <asp:Button ID="btnAssignIP" runat="server" Text="ASSIGN IP" 
                                class="btn btn-primary btn-block text-uppercase" onclick="btnAssignIP_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
