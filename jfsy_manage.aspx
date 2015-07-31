<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfsy_manage.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfsy_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
         <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="费用报销管理" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" 
                    DataKeyNames="LSH,ZT,JFZL" OnPageIndexChange="Grid1_PageIndexChange" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnRowDataBound="Grid1_RowDataBound" OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="ZT">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                             
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:DropDownList ID="DropDownList_xb" runat="server" Label="筛选" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_xb_SelectedIndexChanged">
                                    <f:ListItem  Text="全部" Value="全部"/>
                                    <f:ListItem  Text="已审核" Value="已审核"/>
                                     <f:ListItem  Text="未审核" Value="未审核"/>
                                </f:DropDownList>
                               <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btn_add" Text="添加经费报销单" runat="server" OnClick="btn_add_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" Text="修改选中" runat="server" OnClick="Button1_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                               <f:Button ID="Button2" Text="删除选中" runat="server" ConfirmText="确定删除？"  OnClick="Button2_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                </f:ToolbarSeparator>
                                
                               
                             
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
</body>
</html>
