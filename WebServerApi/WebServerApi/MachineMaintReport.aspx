<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineMaintReport.aspx.cs" Inherits="WebServerApi.MachineMaintReport" %>

<!DOCTYPE html>

<style type="text/css">
    .gvHeader {
        background-color: lightgray;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintenance Report</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div class="container">
            <div class="row mb-3">
                <div class="col-12 text-center">
                    <h2>Maintenance Report</h2>
                </div>
            </div>
            <div class="row form-group d-flex align-items-end">
                <div class="col-3">
                    <label>Equipment:</label>
                    <asp:TextBox runat="server" ID="TextBoxMachine" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-3">
                    <label>Work Order:</label>
                    <asp:TextBox runat="server" ID="TextBoxWorkOrder" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-3">
                    <label>Employee:</label>
                    <asp:TextBox runat="server" ID="TextBoxEmployee" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-3 d-flex justify-content-around">
                    <asp:Button runat="server" ID="ButtonClear" Text="Clear" CssClass="btn btn-secondary"
                        Onclick="ButtonClear_Click" UseSubmitBehavior="false"/>
                    <asp:Button runat="server" ID="ButtonSubmit" Text="Submit" CssClass="btn btn-primary" 
                        OnClick="ButtonSubmit_Click" UseSubmitBehavior="false"/>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-9 table-responsive">
                    <div class="text-center">
                        <h3>Maintenance</h3>
                    </div>
                    <asp:GridView runat="server" ID="GridViewMachineMaint" CssClass="table table-bordered" OnRowCommand="GridViewMachineMaint_RowCommand"
                        AutoGenerateColumns="false" UseAccessibleHeader="true" EmptyDataText="No maintenance records found" DataKeyNames="machineMaintId"> 
                        <Columns>
                            <asp:BoundField DataField="machine" HeaderText="Equipment">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="workOrder" HeaderText="Work Order">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="employee" HeaderText="Employee">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="scanInDtFormatted" HeaderText="Scan In">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="scanOutDtFormatted" HeaderText="Scan Out">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="duration" HeaderText="Time">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSelectParts" CssClass="btn btn-secondary btn-sm btn-block" Text="Parts"
                                        CommandName="PARTS" UseSubmitBehavior="false" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-3 table-responsive">
                    <div class="text-center">
                        <h3>Parts</h3>
                    </div>
                    <asp:GridView runat="server" ID="GridViewMachineMaintParts" CssClass="table table-bordered" 
                        AutoGenerateColumns="false" UseAccessibleHeader="true" EmptyDataText="No parts found"> 
                        <Columns>
                            <asp:BoundField DataField="part" HeaderText="Part">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="quantity" HeaderText="Quantity">
                                <HeaderStyle CssClass="text-center gvHeader" />
                                <ItemStyle CssClass="text-center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-10 offset-1">
                <asp:TextBox runat="server" CssClass="form-control" ID="TextBoxError" Visible="false"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
