<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #main
        {
            width: 90%;
            margin-top: 10px;
            margin-right: auto;
            margin-bottom: 10px;
            margin-left: auto;
        }
        #top
        {
            font-family: "宋体";
            font-size: 16px;
            font-weight: bold;
            height: 30px;
            text-align: center;
            padding: 5px;
            margin: 5px;
        }
        #xmbh
        {
            font-family: "宋体";
            font-size: 14px;
            padding: 5px;
            margin: 5px;
        }
        .underline
        {
            border-bottom-style: solid;
            border-bottom-color: #333;
            border-bottom-width: 1px;
        }
        .borderall
        {
              /*border-top: 1px solid #333;*/
            border-bottom: 1px solid #333;
            border-right: 1px solid #333;
            border-left:1px solid #333;
        }
        .border01
        {
            border-bottom: 1px solid #333;
            border-right: 1px solid #333;
        }
        .border02
        {
            /*border-right: 1px solid #333;*/
             border-bottom: 1px solid #333;
        }
         .border03
        {
            border-left: 1px solid #333;
        }


          .border06
        {
           
            border-right: 1px solid #333;
        }

              .border07
        {
            border-top: 1px solid #333;
           border-right: 1px solid #333;
             border-bottom: 1px solid #333;
        }

                    .border08
        {
           
            border-top: 1px solid #333;
           
        }

                               .border09
        {
           
           border-top: 0px solid #FFFFFF;
           
        }

                                   .border10
        {
            border-top: 1px solid #333;
         
             border-bottom: 1px solid #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
   
                <div id="main">
        <div id="top">
            费用报销单
        </div>
                      <div id="xmbh">
             <table id="Table1" runat="server" width="100%" border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td bgcolor="#FFFFFF"  align="center" colspan="13">
                          <asp:Label ID="Label_bxrq" runat="server" Text=""></asp:Label>
                        </td>
                       
                    </tr>
                 </table>
                <table id="tb1" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0" class="borderall">
                   
                 
                    <tr>
                        <td bgcolor="#FFFFFF" class="border07" height="50" align="center">
                            本次经费具体用途
                        </td>
                        <td id="Td2" runat="server"  colspan="12" bgcolor="#FFFFFF" class="border10">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td rowspan="2" align="center" bgcolor="#FFFFFF" class="border01" height="40" width="15%">
                            经费支出大类
                        </td>
                        <td id="Td3" runat="server" rowspan="2" align="center" bgcolor="#FFFFFF" class="border01" width="15%">
                            经费支出类别</td>
                        <td id="Td4" runat="server" rowspan="2" align="center" bgcolor="#FFFFFF" class="border01" width="15%">
                            经费支出具体内容</td>
                        <td colspan="8" align="center" bgcolor="#FFFFFF" class="border01" height="20">
                            金 额
                        </td>
                        <td rowspan="2" align="center" bgcolor="#FFFFFF" class="border01" width="10%">
                            备 注
                        </td>
                        <td rowspan="2" align="center" bgcolor="#FFFFFF" class="underline" width="5%">
                            单据张数
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            十
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            万
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            千
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            百
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            十
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            元
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            角
                        </td>
                        <td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01">
                            分
                        </td>
                    </tr>
                </table>
                </div>
                    </div>
              
            
         
   
    </form>
</body>

</html>
