<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RestrictedApplications.aspx.cs" Inherits="EmployeeProductivityManagement.RestrictedApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
      <div class="row tm-content-row">
        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-products">
          <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Restricted Apps List</h2>
              </div>
            </div>
            <div class="tm-product-table-container">
                <asp:Label ID="lblMessage" class="text-white" runat="server" ></asp:Label>
                <asp:GridView ID="gvTest" runat="server" class="table table-hover table-borderless tm-table-small tm-product-table" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="resprocess" HeaderText="AppName" />
                        <asp:TemplateField>
                          <ItemTemplate>
                             
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Eval("pid") %>' onclick="LinkButton1_Click">
                                     <i class="far fa-trash-alt tm-product-delete-icon"></i>
                                    </asp:LinkButton>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvProcess" runat="server" class="table table-hover table-borderless tm-table-small tm-product-table" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="resprocess" HeaderText="App Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                             
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Eval("pid") %>' onclick="LinkButton1_Click">
                                     <i class="far fa-trash-alt tm-product-delete-icon"></i>
                                    </asp:LinkButton>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <!-- table container -->
            <button type="button" data-toggle="modal" data-target="#modalProcess"
              class="btn btn-primary btn-block text-uppercase mb-3">Add new Application</button>
          </div>
        </div>
        
      </div>
    </div>
    <div class="modal" id="modalProcess">
  <div class="modal-dialog ">
    <div class="modal-content bg-dark">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title text-white">Add Application</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
          <div class="form-group">
              <asp:Label Text="Enter Application Name" class="text-white" runat="server" />
              <asp:TextBox ID="txtAppName" runat="server" class="form-control"></asp:TextBox>
          </div>
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
          <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" OnClick="btnAdd_click" Text="Add Application" />
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
      </div>

    </div>
  </div>
</div>
          <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>\
</asp:Content>
