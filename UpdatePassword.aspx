<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="EmployeeProductivityManagement.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-12 mx-auto tm-login-col">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12 text-center">
                <h2 class="tm-block-title mb-4">UPDATE PASSWORD</h2>
              </div>
            </div>
            <div class="row mt-2">
              <div class="col-12">
                  <div class="form-group">
                    <label for="username">Old Password
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPasswordO" ErrorMessage="*" ForeColor="White" runat="server"  ValidationGroup="A"></asp:RequiredFieldValidator>
                    </label>
                      <asp:TextBox ID="txtPasswordO" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group mt-3">
                    <label for="password">New Password
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPasswordN" ErrorMessage="*" ForeColor="White" runat="server"  ValidationGroup="A"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtPasswordN" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
                   <div class="form-group mt-3">
                    <label for="password">Confirm Password
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPasswordC" ErrorMessage="*" ForeColor="White" runat="server"  ValidationGroup="A"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPasswordC" ControlToCompare="txtPasswordN" ValidationGroup="A" ErrorMessage="Passwords Don't Match" runat="server"></asp:CompareValidator>
                    </label>
                    <asp:TextBox ID="txtPasswordC" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group mt-4">
                    <%--<button
                      type="submit"
                      class="btn btn-primary btn-block text-uppercase"
                    >
                      Login
                    </button>--%>
                      <asp:Button ID="btnUpdatePassword" runat="server" ValidationGroup="A" 
                          Text="Update Password" class="btn btn-primary btn-block text-uppercase" 
                          onclick="btnUpdatePassword_Click"/>
                  </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
