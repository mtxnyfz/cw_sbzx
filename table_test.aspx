<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table_test.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.table_test" %>

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
            runat="server" DataKeyNames="ID"  >
            <Columns>
                 <f:TemplateField Width="60px" EnableColumnHide="false" EnableHeaderMenu="false">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:TemplateField Width="160px" HeaderText="福利费"  ColumnID="Grid1_ctl12" >
                    <ItemTemplate>
                     <%--  <f:TextBox   runat="server"  OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true">
                        </f:TextBox>--%>
                        <asp:TextBox ID="TextBox_fl" Width="100px" runat="server" CssClass="fl"  TabIndex='<%# Container.DataItemIndex + 10 %>' Text='<%# Eval("c2") %>' ></asp:TextBox>
                    </ItemTemplate>
                </f:TemplateField>
                <f:TemplateField Width="160px" HeaderText="设备耗材费"  ColumnID="Grid1_ctl13">
                    <ItemTemplate>
                     <%--  <f:TextBox ID="TextBox1" Required="true" runat="server" OnTextChanged="tbxEditorName_TextChanged" AutoPostBack="true">
                        </f:TextBox>--%>
                         <asp:TextBox ID="TextBox_sbhc" Width="100px" runat="server" CssClass="sbhc"  TabIndex='<%# Container.DataItemIndex + 11 %>' Text='<%# Eval("c3") %>'></asp:TextBox>
                    </ItemTemplate>
                </f:TemplateField>
                 <f:TemplateField Width="160px" HeaderText="合计"  ColumnID="Grid1_ctl14">
                    <ItemTemplate>
                     
                         <asp:Label ID="Label_hj" runat="server" CssClass="hj"  Text="0"></asp:Label>
                         <input id="Hidden_hj" type="hidden" class="fyhj" runat="server" value="0" />
                    </ItemTemplate>
                </f:TemplateField>
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
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var gridClientID = '<%= Grid1.ClientID %>';
       
        var fl = '.f-grid-tpl input.fl';
        var sbhc = '.f-grid-tpl input.sbhc';
        //var fyhj = '.f-grid-tpl input.fyhj';

        function getRowNumber(row,el) {
            return parseFloat(row.find(el).val());
        }
        function registerNumberChangeEvents() {
            var grid = F(gridClientID);

            // 值改变事件
            // http://stackoverflow.com/questions/17384218/jquery-input-event
            $(grid.el.dom).find(fl).on('input propertychange', function (evt) {
                var $this = $(this);

                var row = $this.parents('.x-grid-row');
                var f1 = getRowNumber(row, fl);
                var f2 = getRowNumber(row, sbhc);
                var resultNode = row.find('.f-grid-tpl span.hj');

                resultNode.text((f1 + f2).toFixed(2));

               
            });

            $(grid.el.dom).find(sbhc).on('input propertychange', function (evt) {
                var $this = $(this);

                var row = $this.parents('.x-grid-row');
                var f1 = getRowNumber(row, fl);
                var f2 = getRowNumber(row, sbhc);
                var resultNode = row.find('.f-grid-tpl span.hj');
                var hj = row.find('.f-grid-tpl input.fyhj');
                hj.val((f1 + f2).toFixed(2));
                resultNode.text((f1 + f2).toFixed(2));


            });
        }

        F.ready(function () {
            registerNumberChangeEvents();
          
        });
    </script>
</body>
</html>
