<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfsy_up.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfsy_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style type="text/css">
         a:link {color: blue; text-decoration:none;}
        #Panel1_ContentPanel1_tb1
        {
            border: 1px solid black;
            border-collapse: collapse;
        }
        #Panel1_ContentPanel1_tb1 td
        {
           border: 1px solid black;
          
            padding:2px;
        }
        /*问题原因：你打开浏览器看生成的html源码，这个表格最终编译不是你定义的td1了，而是现在的Panel1_ContentPanel1_tb1*/
        
        .style3
        {
            height: 60px;
        }
         .style5
        {
          height: 50px;
           width: 5%;
        }
        
          .stylenew5
        {
          height: 30px;
           width: 55px;
        }
        
        
        .style7
        {
        }
                
        
        
        
        .style17
        {
            width: 121px;
            height: 38px;
        }
        .style19
        {
            height: 36px;
        }
        .style20
        {
            height: 37px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="tb1,,Button1" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px" 
        ShowBorder="false" Layout="Fit" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
        ShowHeader="false" Title="" AutoScroll="true">
        <Items>
            <f:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" 
                ShowBorder="true" ShowHeader="false" Title="经费报销单" >
                <div style="width:100%; height:500px; overflow:scroll;">
             <%--   <div id="div1" style="padding-left: 50%; vertical-align: middle;">
                <f:ContentPanel ID="ContentPanel2" runat="server" BodyPadding="5px" 
                ShowBorder="false" ShowHeader="false" Title="">
            <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server" 
         Title="列名"   >
        
        <Rows>
          <f:FormRow ColumnWidths="33% 33% 33%">
           <Items>
                 
                   
                  
              <f:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click">
                    </f:Button>
                     <f:Button ID="Button3" runat="server" Text="提交" OnClick="Button3_Click" ConfirmText="提交后将不能修改,确认提交？" Hidden="true">
                    </f:Button >
                     
                 
                  
                  
             </Items>
        </f:FormRow>
        </Rows>
        </f:Form>
        </f:ContentPanel>
        </div>--%>
                <table id="tb1" runat="server" width="100%" style="height: 366px">
                   
                 
                    <tr>
                        <td >
                            本次经费具体用途
                        </td>
                        <td id="Td2" runat="server" class="style3" colspan="12">
                            <asp:TextBox ID="TextBox1" runat="server" Height="46px" TextMode="MultiLine" 
                                Width="444px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13" class="style16" style="text-align: center">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改经费明细" UseSubmitBehavior="false" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2" style="text-align: center; height:100px; width:12%">
                            经费支出大类
                        </td>
                        <td id="Td3" runat="server" rowspan="2" style="text-align: center; height:100px; width:12%">
                            经费支出类别</td>
                        <td id="Td4" runat="server" rowspan="2" style="text-align: center; height:100px; width:12%">
                            经费支出具体内容</td>
                        <td colspan="8" style="text-align: center;height:50px">
                            金 额
                        </td>
                        <td rowspan="2" style="text-align: center">
                            备 注
                        </td>
                        <td rowspan="2" style="text-align: center">
                            单据张数
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" style="text-align:center">
                            十
                        </td>
                        <td class="style5" style="text-align:center">
                            万
                        </td>
                        <td class="style5" style="text-align:center">
                            千
                        </td>
                        <td class="style5" style="text-align:center">
                            百
                        </td>
                        <td class="style5" style="text-align:center">
                            十
                        </td>
                        <td class="style5" style="text-align:center">
                            元
                        </td>
                        <td class="style5" style="text-align:center">
                            角
                        </td>
                        <td class="style5" style="text-align:center">
                            分
                        </td>
                    </tr>
                </table>
                </div>
              
                <div>
                    备注：<br />
1.工程款应附合同、基建站核定单，审价费用还应附有审价核定单。<br />
2.金额在1万元以上的大额支出应附合同。<br />
3.发票上开具如日用品、图书等项目的，应附明细单。<br />
4.固定资产应办理登记手续，购买实物报销的应办理入库手续。<br />
5.差旅费报销应附会议通知。<br />
6.会费报销应附有关通知。<br />
7.餐费报销应附人员名单。<br />
                </div>
              <%--  <div id="div1" style="padding-left: 50%; vertical-align: middle;">--%>
                   <%-- <asp:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click" UseSubmitBehavior="false" />
                    <asp:Button ID="Button3" runat="server" Text="提交" OnClick="Button3_Click"  OnClientClick="return confirm('提交后将不能修改,确认提交？')"  />--%>
                  <%--  <f:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click">
                    </f:Button>
                     <f:Button ID="Button3" runat="server" Text="提交" OnClick="Button3_Click" ConfirmText="提交后将不能修改,确认提交？">
                    </f:Button>--%>
              <%--  </div>--%>
              <%--<div id="div1" style="padding-left: 50%; vertical-align: middle;">
                <f:ContentPanel ID="ContentPanel2" runat="server" BodyPadding="5px" 
                ShowBorder="false" ShowHeader="false" Title="">
            <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server" 
         Title="列名"   >
        
        <Rows>
          <f:FormRow ColumnWidths="33% 33% 33%">
           <Items>
                 
                   
                  
              <f:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click">
                    </f:Button>
                     <f:Button ID="Button3" runat="server" Text="提交" OnClick="Button3_Click" ConfirmText="提交后将不能修改,确认提交？" Hidden="true">
                    </f:Button >
                     
                 
                  
                  
             </Items>
        </f:FormRow>
        </Rows>
        </f:Form>
        </f:ContentPanel>
        </div>--%>
            </f:ContentPanel>
           

        
       
                 
                   
                  
            
                 
                   
                  
     
        </Items>
         <Toolbars>
                <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                       <f:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click">
                    </f:Button>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
    </f:Panel>
    <f:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="850px" Height="750px">
          
        </f:Window>
    </form>
</body>

</html>
