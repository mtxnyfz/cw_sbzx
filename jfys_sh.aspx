<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfys_sh.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfys_sh" %>

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
            Title="经费预算明细" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" 
                    DataKeyNames="ID" OnPageIndexChange="Grid1_PageIndexChange"  OnPreRowDataBound="Grid1_PreRowDataBound" EnableCheckBoxSelect="true" ClearSelectedRowsAfterPaging="false" OnRowDataBound="Grid1_RowDataBound" OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="ZT">
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
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server" >
                                </f:ToolbarSeparator>
                                <f:TextBox ID="TextBox_key" Label="关键字搜索"   runat="server" ShowLabel="false" EmptyText="请输入部门，一级或二级关键字" Width="200px">
                                </f:TextBox>
                                 <f:Button ID="Button3" Text="搜索" runat="server"  OnClick="Button3_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText="序号" Width="50px" TextAlign="Center"/>
                         <f:BoundField Width="100px" DataField="SBBM" HeaderText="部门" ID="BoundField8"  DataToolTipField="SBBM" SortField="SBBM"/>
                       
                         <f:BoundField Width="100px" DataField="JFZL" HeaderText="经费种类" ID="BoundField7" SortField="JFZL"/>
                        <f:BoundField Width="100px" DataField="YJMC"  HeaderText="一级"  ColumnID="Panel7_Grid1_ctl09"  DataToolTipField="YJMC" SortField="YJMC"/>
                      
                       <f:BoundField Width="100px" DataField="EJMC"  HeaderText="二级"  ColumnID="Panel7_Grid1_ctl12"  DataToolTipField="EJMC" SortField="EJMC"/>
                        <f:BoundField Width="200px" DataField="SJMC" HeaderText="三级"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="SJMC"  SortField="SJMC"/>
                      <f:GroupField HeaderText="人员费用(元)" TextAlign="Center">
                    <Columns>
                      
                                <f:BoundField Width="100px" DataField="ZZRYFY" HeaderText="在职" ID="c5" DataFormatString="{0:N2}" SortField="ZZRYFY"/>
                                <f:BoundField Width="100px" DataField="TXRYFY" HeaderText="退休人员" ID="c6" DataFormatString="{0:N2}" SortField="TXRYFY"/>
                          <f:BoundField Width="100px" DataField="QTRYFY" HeaderText="其他人员" ID="c7" DataFormatString="{0:N2}" SortField="QTRYFY"/>
                          
                    </Columns>
                </f:GroupField>
                          <f:BoundField Width="100px" DataField="FLF" HeaderText="福利费(元)" ID="BoundField1" DataFormatString="{0:N2}" SortField="FLF"/>
                          <f:BoundField Width="100px" DataField="SBHCF" HeaderText="设备耗材费(元)" ID="BoundField2" DataFormatString="{0:N2}" SortField="SBHCF"/>
                          <f:BoundField Width="100px" DataField="YWF" HeaderText="业务费(元)" ID="BoundField3" DataFormatString="{0:N2}" SortField="YWF"/>
                          <f:BoundField Width="100px" DataField="QT" HeaderText="其他(元)" ID="BoundField4" DataFormatString="{0:N2}" SortField="QT"/>
                          <f:BoundField Width="150px" DataField="YSJE" HeaderText="预算金额(小计)(元)" ID="BoundField5" DataFormatString="{0:N2}" SortField="YSJE"/>
                          <f:BoundField Width="100px" DataField="BZ" HeaderText="备注" ID="BoundField6"  DataToolTipField="BZ" />
                          <f:BoundField Width="150px" DataField="CZSJ" HeaderText="申报时间" ID="BoundField13" SortField="CZSJ"/>
                         <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid2_ylfw_ctl17" SortField="ZT">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                           <f:WindowField ColumnID="xq" TextAlign="Center" Text="详情"  Title="详情"
                        WindowID="Window1" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/admin/jfys_xm_look.aspx?ID={0}"
                        Width="100px" />
                      <%--  <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ID="BoundField8" DataToolTipField="XMMC"/>
                         <f:BoundField Width="100px" DataField="SBBM" HeaderText="申报部门" ID="BoundField9" DataToolTipField="SBBM"/>
                         <f:BoundField Width="100px" DataField="XMFZR" HeaderText="项目负责人" ID="BoundField10" DataToolTipField="XMFZR"/>
                         <f:BoundField Width="200px" DataField="GZNR" HeaderText="工作内容" ID="BoundField11" DataToolTipField="GZNR"/>
                          <f:BoundField Width="200px" DataField="XMNRGS" HeaderText="项目内容概述" ID="BoundField12" DataToolTipField="XMNRGS"/>
                          <f:TemplateField HeaderText="执行期限" Width="180px"  ColumnID="Panel7_Grid1_ctl15" >--%>
                   <%-- <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZXKSRQ").ToString()+"至"+Eval("ZXJSRQ").ToString()%>'></asp:Label>
                    </ItemTemplate>

                </f:TemplateField>--%>
                    </Columns>
                </f:Grid>

               
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="850px" Height="750px" >
          
        </f:Window>
           <f:HiddenField ID="hfSelectedIDS1" runat="server">
    </f:HiddenField>
    </form>
     <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TextBox_key = '<%= TextBox_key.ClientID %>';
       

        F.ready(function () {

            var cache = {};



            $('#' + TextBox_key + ' input').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    var term1 = request.term;


                    $.getJSON("search_bykey.ashx?timestamp=" + new Date().getTime(), request, function (data, status, xhr) {
                        cache[term1] = data;
                        //alert(cache[term1])
                        response(cache[term1]);


                    });
                },
                select: function (event, ui) {
                    var $this = $(this);
                    $this.val(ui.item.key);

                 
                    cache = {};
                    return false;
                }
            }).autocomplete("instance")._renderItem = function (ul, item) {

                return $("<li>")
                    .append("<a><span class='autocomplete-item-title'>" + item.key + "</span></a>")
                    .appendTo(ul);
            };

        });

    </script>
</body>
</html>
