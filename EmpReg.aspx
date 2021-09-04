<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmpReg.aspx.cs" Inherits="EmployeeProductivityManagement.EmpReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
     <ProgressTemplate>
     <div class="loading">Loading...</div>
     </ProgressTemplate>
     
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="container mt-5">
      <div class="row tm-content-row">
        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-products">
          <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Employees List</h2>
              </div>
            </div>
            <div class="tm-product-table-container">
                <asp:Label ID="lblMessage" class="text-white" runat="server" ></asp:Label>
                <asp:GridView ID="gvEmployees" runat="server" class="table table-hover table-borderless tm-table-small tm-product-table" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="empid" HeaderText="#" />
                        <asp:BoundField DataField="name" HeaderText="NAME" />
                        <asp:BoundField DataField="email" HeaderText="EMAIL" />
                        <asp:BoundField DataField="doj" HeaderText="DOJ" />
                        <asp:BoundField DataField="dept" HeaderText="DEPARTMENT" />
                        <asp:TemplateField>
                            <ItemTemplate>
                             
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Eval("empid") %>' onclick="LinkButton1_Click">
                                     <i class="far fa-trash-alt tm-product-delete-icon"></i>
                                    </asp:LinkButton>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <!-- table container -->
            <a
              href="NewEmp.aspx"
              class="btn btn-primary btn-block text-uppercase mb-3">Add new Employee</a>
          </div>
        </div>
        
      </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
   
      
</asp:Content>
