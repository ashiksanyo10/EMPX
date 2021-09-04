<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewEmp.aspx.cs" Inherits="EmployeeProductivityManagement.NewEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-xl-9 col-lg-10 col-md-12 col-sm-12 mx-auto">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Add New Employee</h2>
              </div>
            </div>
            <div class="row tm-edit-product-row">
              <div class="col-xl-6 col-lg-6 col-md-12">
                  <div class="form-group mb-3">
                    <label>Employee Name
                    </label>
<%--                    <input
                      id="name"
                      name="name"
                      type="text"
                      class="form-control validate"
                      required
                    />--%>
                      <asp:TextBox ID="txtName" runat="server"  class="form-control validate"
                      required></asp:TextBox>
                  </div>
                  <div class="form-group mb-3">
                    <label
                      for="description"
                      >Job Description</label
                    >
                    <asp:TextBox ID="txtJD" runat="server" TextMode="MultiLine" Rows="3"  class="form-control validate"
                      required></asp:TextBox> 
                  </div>
                  <div class="form-group mb-3">
                    <label>Department</label>
                      <asp:DropDownList ID="ddlDept" runat="server"  class="custom-select tm-select-accounts">
                          <asp:ListItem>Select Department</asp:ListItem>
                          <asp:ListItem>Software Development</asp:ListItem>
                          <asp:ListItem>Software Testing</asp:ListItem>
                          <asp:ListItem>Marketing</asp:ListItem>
                          <asp:ListItem>Sales</asp:ListItem>
                          <asp:ListItem>HR</asp:ListItem>
                      </asp:DropDownList>
                  </div>
                  <div class="row">
                      <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="expire_date"
                            >Joined Date
                          </label>
                          <asp:TextBox ID="txtDOJ" runat="server"  class="form-control validate"
                      required></asp:TextBox>
                        </div>
                        <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="stock"
                            >Salary
                          </label>
                          <asp:TextBox ID="txtSalary" runat="server"  class="form-control validate"
                      required></asp:TextBox>
                        </div>
                  </div>
                  
              </div>
              <div class="col-xl-6 col-lg-6 col-md-12 mx-auto mb-4">
              <div class="form-group mb-3 ">
                          <label
                            for="expire_date"
                            >Email
                          </label>
                          <asp:TextBox ID="txtEmail" runat="server"  class="form-control validate"
                      required></asp:TextBox>
                        </div>
                        <div class="form-group mb-3 ">
                          <label
                            for="stock"
                            >Phone Number
                          </label>
                          <asp:TextBox ID="txtPhoneNumber" runat="server"  class="form-control validate"
                      required></asp:TextBox>
                        </div>
                <div class="tm-product-img-dummy mx-auto">
                  <i
                    class="fas fa-cloud-upload-alt tm-upload-icon"
                    onclick="document.getElementById('ContentPlaceHolder1_fileInput').click();"
                  ></i>
                </div>
                <div class="custom-file mt-3 mb-3">
                 <asp:FileUpload ID="fileInput" runat="server" style="display:none" />
                  <input
                    type="button"
                    class="btn btn-primary btn-block mx-auto"
                    value="UPLOAD EMPLOYEE IMAGE"
                    onclick="document.getElementById('ContentPlaceHolder1_fileInput').click();"
                  />
                </div>
              </div>
              <div class="col-12">
                <%--<button type="submit" class="btn btn-primary btn-block text-uppercase">Add Product Now</button>--%>
                  <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" 
                      class="btn btn-primary btn-block text-uppercase" 
                      onclick="btnAddEmployee_Click" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>  
</asp:Content>
