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
            font-family: "微软雅黑";
            font-size: 22px;
            height: 30px;
            text-align: center;
            padding: 5px;
            margin: 5px;
			color: #1297D2;
        }
        #xmbh
        {
            font-family: "微软雅黑";
            font-size: 14px;
            padding: 5px;
            margin: 5px;
        }
        .underline
        {
            border-bottom-style: solid;
            border-bottom-color: #1297D2;
            border-bottom-width: 1px;
        }
        .borderall
        {
              /*border-top: 1px solid #333;*/
            border-bottom: 2px solid #1297D2;
            border-right: 2px solid #1297D2;
            border-left:2px solid #1297D2;
        }
        .border01
        {
            border-bottom: 1px solid #1297D2;
            border-right: 1px solid #1297D2;
        }
        .border02
        {
            /*border-right: 1px solid #333;*/
             border-bottom: 1px solid #1297D2;
        }
         .border03
        {
            border-left: 1px solid #1297D2;
        }


          .border06
        {
           
            border-right: 1px solid #1297D2;
        }

              .border07
        {
            border-top: 2px solid #1297D2;
           border-right: 1px solid #1297D2;
             border-bottom: 1px solid #1297D2;
			 color: #1297D2;

        }

                    .border08
        {
			color:#1297D2;
            border-top: 1px solid #1297D2;
           
        }

                               .border09
        {
           
           border-top: 0px solid #FFFFFF;
           
        }

                                   .border10
        {
            border-top: 2px solid #1297D2;
         
             border-bottom: 1px solid #1297D2;
        }
		.title{ color:#1297D2;}
		.line{border-bottom-style:double; color:#1297D2; width:140px; margin:0 auto;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
   
                <div id="main">
        <div id="top">
            费用报销单
        </div>
        <div class="line"></div>
                      <div id="xmbh">
             <table id="Table1" runat="server" width="100%" border="0" cellpadding="5" cellspacing="0">
	<tbody><tr>
		<td bgcolor="#FFFFFF" align="center" colspan="13">
                         <asp:Label ID="Label_bxrq" runat="server" Text=""></asp:Label>
            </td>
	</tr>
</tbody></table>

                <table id="tb1" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0" class="borderall">
	<tbody><tr>
		<td bgcolor="#FFFFFF" class="border07" height="50" align="left">
                            本次经费具体用途
                        </td>
		<td id="Td2" colspan="13" bgcolor="#FFFFFF" class="border10">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
	</tr>
	<tr>
		<td rowspan="2" align="left" bgcolor="#FFFFFF" class="border01 title" height="40" width="15%">
                            经费支出大类
                        </td>
		<td width="15%" colspan="2" rowspan="2" align="left" bgcolor="#FFFFFF" class="border01 title" id="Td3">
                            经费支出类别</td>
		<td id="Td4" rowspan="2" align="left" bgcolor="#FFFFFF" class="border01 title" width="15%">
                            经费支出具体内容</td>
		<td colspan="8" align="center" bgcolor="#FFFFFF" class="border01 title" height="20">
                            金 额
                        </td>
		<td rowspan="2" align="center" bgcolor="#FFFFFF" class="border01 title" width="10%">
                            备 注
                        </td>
		<td rowspan="2" align="center" bgcolor="#FFFFFF" class="underline title" width="5%">
                            单据张数
                        </td>
	</tr>
	<tr>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            十
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            万
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            千
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            百
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            十
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            元
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            角
                        </td>
		<td width="5%" height="20" align="center" bgcolor="#FFFFFF" class="border01 title">
                            分
                        </td>
	</tr>
</tbody></table>

                </div>
                    </div>
              
            
         
   
    </form>
</body>

</html>
