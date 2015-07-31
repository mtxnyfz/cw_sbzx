<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table_test1.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.table_test1" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" Width="850px"
            runat="server" DataKeyNames="ID"  AllowCellEditing="true" ClicksToEdit="1" >
            <Columns>
                 <f:TemplateField Width="160px" HeaderText="工作内容"  ColumnID="Grid1_ctl10">
                    <ItemTemplate>
                       <asp:Label ID="Label1" runat="server"  Text='<%# Eval("c1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </f:TemplateField>

               
                 <f:RenderField Width="100px" ColumnID="c1" DataField="c2" FieldType="String" 
                    HeaderText="费用1">
                    <Editor>
                       <%--  <f:NumberBox ID="NumberBox1" runat="server"  MinValue="0" DecimalPrecision="2" NoNegative="True"   OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true"></f:NumberBox>--%>
                        
                          <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </Editor>
                </f:RenderField>
               
                 <f:RenderField Width="100px" ColumnID="c2" DataField="c3" FieldType="String" 
                    HeaderText="费用2">
                    <Editor>
                      <%--  <f:NumberBox ID="NumberBox2" runat="server"  MinValue="0" DecimalPrecision="2" NoNegative="True"   OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true"></f:NumberBox>--%>
                          <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </Editor>
                </f:RenderField>
              
                
            </Columns>
        </f:Grid>
        <br />
        <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
        </f:Button>
        <br />
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
        <%-- <f:TextBox ID="TextBox4" Required="true" runat="server"  OnTextChanged="TextBox4_TextChanged" AutoPostBack="true">
                        </f:TextBox>--%>
        <br />
    </form>
    <script>

        function renderGender(value) {
            return value == 1 ? '男' : '女';
        }


    </script>
</body>
</html>
