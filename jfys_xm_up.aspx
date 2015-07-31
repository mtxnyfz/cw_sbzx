<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfys_xm_up.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfys_xm_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel5" />
         <f:Panel ID="Panel5" runat="server" BodyPadding="5px"
            Title="经费预算申请" ShowBorder="false" ShowHeader="false"
            AutoScroll="true"   BoxConfigAlign="Stretch" Height="750px">
            <Items>
                   <f:SimpleForm  ID="Form2"   LabelAlign="Top"  BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server"  >
                    <Items>
                         <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                              <f:TextBox ID="TextBox_jfzl" Label="经费种类" Margin="0 5 0 0"  ColumnWidth="50%" runat="server" Enabled="false" >
                                </f:TextBox>
                                 
                            </Items>
                            
                        </f:Panel>
                          <f:GroupPanel ID="GroupPanel3"  Title="<strong>项目基本情况</strong>"  runat="server" >
                            <Items>
                         <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                                <f:TextBox ID="TextBox_xmmc" Label="项目名称" Margin="0 5 0 0" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server">
                                </f:TextBox>
                                 <f:TextBox ID="TextBox_sbbm" Label="申报部门" Margin="0 5 0 0"  Enabled="false" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server">
                                </f:TextBox>
                                 
                            </Items>
                        </f:Panel>
                         <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                                <f:TextBox ID="TextBox_fzr" Label="项目负责人" Margin="0 5 0 0" Enabled="false" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server">
                                </f:TextBox>
                                   <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期"  ID="DatePicker_zxksrq" ShowRedStar="True"  ColumnWidth="33%" Margin="0 5 0 0" ></f:DatePicker>
                                          <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_zxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期"  ID="DatePicker_zxjsrq" ShowRedStar="True"  ColumnWidth="33%" Margin="0 5 0 0" ></f:DatePicker>
                                 
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                               <f:DropDownList ID="DropDownList_yj" runat="server" Label="一级" Margin="2 5 0 0"  ColumnWidth="50%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_yj_SelectedIndexChanged" Required="true" ShowRedStar="true">
                                
                               </f:DropDownList>
                                 <f:DropDownList ID="DropDownList_ej" runat="server" Label="二级" Margin="2 5 0 0"  ColumnWidth="50%" Required="true" ShowRedStar="true">
                                
                               </f:DropDownList>
                              <%--  <f:DropDownList ID="DropDownList_sj" runat="server" Label="三级" Margin="2 5 0 0"  ColumnWidth="34%">
                                
                               </f:DropDownList>--%>
                            </Items>
                        </f:Panel>
                       <%--  <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_gznr" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="工作内容" Text=""  ColumnWidth="80%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>--%>
                         <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_xmnrms" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="项目内容概述" Text=""  ColumnWidth="80%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>
                     </Items>
                                </f:GroupPanel>
                        <%--  <f:Form runat="server" Title="预算明细" ID="Form4" ShowHeader="false" ShowBorder="false">
                                   <Items>--%>
                                        <f:GroupPanel ID="GroupPanel2"  Title="<strong>预算明细</strong>"  runat="server" >
                            <Items>
                         
                          <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:NumberBox ID="NumberBox_ysje" runat="server" Label="预算金额(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false"></f:NumberBox>
                                 </Items>
                        </f:Panel>
                         <f:GroupPanel ID="GroupPanel1"  Title="<strong>人员费用</strong>"  runat="server" >
                            <Items>
                         <f:Panel ID="Panel1" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                  <f:NumberBox ID="NumberBox_zz" runat="server" Label="在职(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_txry" runat="server" Label="退休人员(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_qtry" runat="server" Label="其他人员(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="34%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                            
                            </Items>
                        </f:Panel>
                                </Items>
                                </f:GroupPanel>
                         <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                  <f:NumberBox ID="NumberBox_flf" runat="server" Label="福利费(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_sbhc" runat="server" Label="设备耗材费(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_ywf" runat="server" Label="业务费(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_qt" runat="server" Label="其他(元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                            
                            </Items>
                        </f:Panel>
                       <%--  <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_bz" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="备注" Text=""  ColumnWidth="80%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>--%>
                                </Items>
                                </f:GroupPanel>
                                 
                        </Items>
                        <Toolbars>
                <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                       
                        <f:Button ID="Button_save" Text="保存"  runat="server" OnClick="Button_save_Click"   Margin="10 5 10 0">
                        </f:Button>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
                        </f:SimpleForm>
            </Items>
            </f:Panel>
    </form>
</body>
</html>
