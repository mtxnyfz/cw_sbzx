<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfsy_sh.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfsy_sh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
         <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="经费使用明细" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" 
                    DataKeyNames="LSH" OnPageIndexChange="Grid1_PageIndexChange"   EnableCheckBoxSelect="true" ClearSelectedRowsAfterPaging="false" OnRowDataBound="Grid1_RowDataBound" OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="ZT">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:DropDownList ID="DropDownList_xb" runat="server" Label="责任部门" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_xb_SelectedIndexChanged"></f:DropDownList>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" Text="审核通过" runat="server" OnClick="Button1_Click"  ConfirmText="所勾选的项目将审核通过，确定此操作？">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server" >
                                </f:ToolbarSeparator>
                               <f:Button ID="Button2" Text="审核不通过" runat="server"  OnClick="Button2_Click" ConfirmText="所勾选的项目将审核不通过，确定此操作？">
                                </f:Button>
                                <%--<f:ToolbarSeparator ID="ToolbarSeparator4" runat="server" >
                                </f:ToolbarSeparator>
                                <f:TextBox ID="TextBox_key" Label="关键字搜索"   runat="server" ShowLabel="false" EmptyText="一级或二级关键字" Width="200px">
                                </f:TextBox>
                                 <f:Button ID="Button3" Text="搜索" runat="server"  OnClick="Button3_Click">
                                </f:Button>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                      
                <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText="序号" Width="50px" TextAlign="Center"/>
                        
                         <f:BoundField Width="150px" DataField="BXRQ" HeaderText="报销日期" ID="BoundField7" SortField="BXRQ"/>
                         <f:BoundField Width="250px" DataField="BCJFJTYT" HeaderText="经费具体用途" ID="BoundField1" />
                           <f:BoundField Width="150px" DataField="JE" HeaderText="报销金额（元）" ID="BoundField8" DataFormatString="{0:N2}" SortField="JE"/>
                         <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid2_ylfw_ctl17" SortField="ZT">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                           <f:WindowField ColumnID="xq" TextAlign="Center" Text="详情"  Title="详情"
                        WindowID="Window1" DataIFrameUrlFields="LSH" DataIFrameUrlFormatString="~/admin/jfsymx_look.aspx?LSH={0}"
                        Width="100px" />
                     
                   
                    </Columns>
                </f:Grid>

               
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="850px" Height="760px" >
          
        </f:Window>
           <f:HiddenField ID="hfSelectedIDS1" runat="server">
    </f:HiddenField>
    </form>
    <%-- <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>--%>
  
</body>
</html>
