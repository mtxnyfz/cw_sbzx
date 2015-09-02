<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfsymx_xm_Add.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfsymx_xm_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                               
                               <f:DropDownList ID="DropDownList_jfzl" runat="server" Label="经费种类" Margin="0 5 0 0"  ColumnWidth="50%" OnSelectedIndexChanged="DropDownList_jfzl_SelectedIndexChanged" AutoPostBack="true">
                                      <f:ListItem Text="项目经费"  Value="2"/>
                                 <f:ListItem Text="工作经费"  Value="1"/>
                                  
                               </f:DropDownList>
                                 
                            </Items>
                            
                        </f:Panel>
                         <%-- <f:GroupPanel ID="GroupPanel3"  Title="<strong>项目基本情况</strong>"  runat="server" >
                            <Items>--%>
                        <%-- <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                                <f:TextBox ID="TextBox_xmmc" Label="项目名称" Margin="0 5 0 0" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server">
                                </f:TextBox>
                                 <f:TextBox ID="TextBox_sbbm" Label="申报部门" Margin="0 5 0 0" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Enabled="false">
                                </f:TextBox>
                                 
                            </Items>
                        </f:Panel>--%>
                        
                        <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                               <f:DropDownList ID="DropDownList_yj" runat="server" Label="一级" Margin="2 5 0 0"  ColumnWidth="33%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_yj_SelectedIndexChanged" Required="true" ShowRedStar="true">
                                
                               </f:DropDownList>
                                 <f:DropDownList ID="DropDownList_ej" runat="server" Label="二级" Margin="2 5 0 0"  ColumnWidth="33%" Required="true" ShowRedStar="true" AutoPostBack="true"  OnSelectedIndexChanged="DropDownList_ej_SelectedIndexChanged">
                                
                               </f:DropDownList>
                                <f:DropDownList ID="DropDownList_sj" runat="server" Label="项目名称" Margin="2 5 0 0"  ColumnWidth="34%">
                                
                               </f:DropDownList>
                            </Items>
                        </f:Panel>
                       <%--  <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_gznr" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="工作内容" Text=""  ColumnWidth="80%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>--%>
                        <%-- <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_xmnrms" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="项目内容概述" Text=""  ColumnWidth="80%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>--%>
                    <%-- </Items>
                                </f:GroupPanel>--%>
                          <f:Form runat="server" Title="预算明细" ID="Form4" ShowHeader="false" ShowBorder="false">
                                   <Items>
                                        <f:GroupPanel ID="GroupPanel2"  Title="<strong>经费使用明细</strong>"  runat="server" >
                            <Items>
                         
                          <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:NumberBox ID="NumberBox_syje" runat="server" Label="经费使用金额(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false"></f:NumberBox>
                                 </Items>
                        </f:Panel>
                         <f:GroupPanel ID="GroupPanel1"  Title="<strong>人员费用</strong>"  runat="server" >
                            <Items>
                         <f:Panel ID="Panel1" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                  <f:NumberBox ID="NumberBox_zz" runat="server" Label="在职(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_txry" runat="server" Label="退休人员(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_qtry" runat="server" Label="其他人员(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="34%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                            
                            </Items>
                        </f:Panel>
                                </Items>
                                </f:GroupPanel>
                         <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                  <f:NumberBox ID="NumberBox_flf" runat="server" Label="福利费(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_sbhc" runat="server" Label="设备耗材费(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 5 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_ywf" runat="server" Label="业务费(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_qt" runat="server" Label="其他(元)"  MinValue="0" MaxValue="999999" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="25%" Margin="2 2 5 0"  OnTextChanged="NumberBox_zz_TextChanged" AutoPostBack="true"></f:NumberBox>
                            
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:TextArea ID="TextArea_bz" runat="server" AutoGrowHeightMin="100" AutoGrowHeightMax="200" AutoGrowHeight="true" Label="备注" Text=""  ColumnWidth="50%" Margin="10 5 10 5" ></f:TextArea>
                                 </Items>
                        </f:Panel>
                                 <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                 <f:NumberBox ID="NumberBox_djzs" runat="server" Label="单据张数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 0" ></f:NumberBox>
                                 </Items>
                        </f:Panel>
                                </Items>
                                </f:GroupPanel>
                                       </Items>
                                <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" Text="添加到列表" ValidateForms="Form4" ValidateMessageBox="true" runat="server" OnClick="Button_add_Click"   Margin="10 5 10 0">
                        </f:Button>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                       </f:Form>
                          <f:Panel ID="Panel22"   CssClass="formitem"  runat="server"  Title="已添加的工作经费使用列表"  ShowBorder="false" ShowHeader="true" AutoScroll="true"   Layout="Fit"  Width="830px" Height="300px">
                                       <Items>
                                           <f:Grid ID="Grid2" Title="Grid1"  ShowBorder="true" BoxFlex="1"
                    ShowHeader="false" runat="server" DataKeyNames="id" EnableCheckBoxSelect="true" EnableMultiSelect="false"  >
 <Toolbars>
                        <f:Toolbar ID="Toolbar6" runat="server">
                           <Items>
                              
                                

                               
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button5" Text="删除" runat="server" OnClick="Button5_Click" ConfirmText="确定删除？">
                                </f:Button>
                               
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                     <Columns>
                       <f:RowNumberField EnablePagingNumber="true" ID="c1" HeaderText="序号" Width="50px" />
                        <f:BoundField Width="100px" DataField="YJMC"  HeaderText="经费支出大类"  ID="c2" />
                      
                        <f:BoundField Width="150px" DataField="EJMC" HeaderText="经费支出类别"    ID="c3"/>
                    
                         
                        <f:BoundField Width="150px" DataField="SJMC" HeaderText="项目名称"   ID="c4"/>
                        
                         <f:GroupField HeaderText="人员费用(元)" TextAlign="Center">
                    <Columns>
                      
                                <f:BoundField Width="100px" DataField="ZZRYFY" HeaderText="在职" ID="c5" DataFormatString="{0:N2}"/>
                                <f:BoundField Width="100px" DataField="TXRYFY" HeaderText="退休人员" ID="c6" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="100px" DataField="QTRYFY" HeaderText="其他人员" ID="c7" DataFormatString="{0:N2}"/>
                          
                    </Columns>
                </f:GroupField>
                          <f:BoundField Width="100px" DataField="FLF" HeaderText="福利费" ID="BoundField1" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="100px" DataField="SBHCF" HeaderText="设备耗材费" ID="BoundField3" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="100px" DataField="YWF" HeaderText="业务费" ID="BoundField4" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="100px" DataField="QT" HeaderText="其他" ID="BoundField5" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="100px" DataField="JE" HeaderText="使用金额(小计)" ID="BoundField7" DataFormatString="{0:N2}"/>
                       
                        
                        
                          <f:BoundField Width="100px" DataField="BZ" HeaderText="备注" ID="BoundField6"  DataToolTipField="BZ"/>
                           <f:BoundField Width="100px" DataField="DJZS" HeaderText="单据张数" ID="BoundField2" />
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>
                                 
                        </Items>
                        <Toolbars>

                <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button_save" Text="保存"   runat="server" OnClick="Button_save_Click"   Margin="10 5 10 0">
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