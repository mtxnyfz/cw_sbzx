<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfys_hz.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfys_hz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gbk"/>
    <title></title>
     <script src="../lib/jquery-1.10.2.js" charset="gbk"></script>
<link rel="stylesheet" href="../css/ui-dialog.css"/>
<script src="../dist/dialog-plus.js" charset="gbk"></script>
     <style>
 .odd{background:#FFFFAA;}
  .odd1{background:#FFC1E0;}
body {
    width: 1200px;
    margin: 40px auto;
    font-family: 'trebuchet MS', 'Lucida sans', Arial;
    font-size: 14px;
    color: #444;
}

table {
    *border-collapse: collapse; /* IE7 and lower */
    border-spacing: 0;
    width: 100%;    
}

.bordered {
    border: solid #ccc 1px;
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;
    -webkit-box-shadow: 0 1px 1px #ccc; 
    -moz-box-shadow: 0 1px 1px #ccc; 
    box-shadow: 0 1px 1px #ccc;         
}

.bordered tr:hover {
    background: #fbf8e9;
    -o-transition: all 0.1s ease-in-out;
    -webkit-transition: all 0.1s ease-in-out;
    -moz-transition: all 0.1s ease-in-out;
    -ms-transition: all 0.1s ease-in-out;
    transition: all 0.1s ease-in-out;     
}    
    
.bordered td, .bordered th {
    border-left: 1px solid #ccc;
    border-top: 1px solid #ccc;
    padding: 10px;
    text-align:center;    
}

.bordered th {
    background-color: #dce9f9;
    background-image: -webkit-gradient(linear, left top, left bottom, from(#dce9f9), to(#dce9f9));
    background-image: -webkit-linear-gradient(top, #dce9f9, #dce9f9);
    background-image:    -moz-linear-gradient(top, #dce9f9, #dce9f9);
    background-image:     -ms-linear-gradient(top, #dce9f9, #dce9f9);
    background-image:      -o-linear-gradient(top, #dce9f9, #dce9f9);
    background-image:         linear-gradient(top, #dce9f9, #dce9f9);
    -webkit-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset; 
    -moz-box-shadow:0 1px 0 rgba(255,255,255,.8) inset;  
    box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;        
    /*border-top: none;*/
    text-shadow: 0 1px 0 rgba(255,255,255,.5); 
}

/*.bordered td:first-child, .bordered th:first-child {
    border-left: none;
}*/

/*.bordered th:first-child {
    -moz-border-radius: 6px 0 0 0;
    -webkit-border-radius: 6px 0 0 0;
    border-radius: 6px 0 0 0;
}

.bordered th:last-child {
    -moz-border-radius: 0 6px 0 0;
    -webkit-border-radius: 0 6px 0 0;
    border-radius: 0 6px 0 0;
}

.bordered th:only-child{
    -moz-border-radius: 6px 6px 0 0;
    -webkit-border-radius: 6px 6px 0 0;
    border-radius: 6px 6px 0 0;
}

.bordered tr:last-child td:first-child {
    -moz-border-radius: 0 0 0 6px;
    -webkit-border-radius: 0 0 0 6px;
    border-radius: 0 0 0 6px;
}

.bordered tr:last-child td:last-child {
    -moz-border-radius: 0 0 6px 0;
    -webkit-border-radius: 0 0 6px 0;
    border-radius: 0 0 6px 0;
}*/



/*----------------------*/

.zebra td, .zebra th {
    padding: 10px;
    border-bottom: 1px solid #f2f2f2;    
}

/*.zebra tbody tr:nth-child(even) {
    background: #f5f5f5;
    -webkit-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset; 
    -moz-box-shadow:0 1px 0 rgba(255,255,255,.8) inset;  
    box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;        
}*/

.zebra th {
    text-align: left;
    text-shadow: 0 1px 0 rgba(255,255,255,.5); 
    border-bottom: 1px solid #ccc;
    background-color: #eee;
    background-image: -webkit-gradient(linear, left top, left bottom, from(#f5f5f5), to(#eee));
    background-image: -webkit-linear-gradient(top, #f5f5f5, #eee);
    background-image:    -moz-linear-gradient(top, #f5f5f5, #eee);
    background-image:     -ms-linear-gradient(top, #f5f5f5, #eee);
    background-image:      -o-linear-gradient(top, #f5f5f5, #eee); 
    background-image:         linear-gradient(top, #f5f5f5, #eee);
}

/*.zebra th:first-child {
    -moz-border-radius: 6px 0 0 0;
    -webkit-border-radius: 6px 0 0 0;
    border-radius: 6px 0 0 0;  
}

.zebra th:last-child {
    -moz-border-radius: 0 6px 0 0;
    -webkit-border-radius: 0 6px 0 0;
    border-radius: 0 6px 0 0;
}

.zebra th:only-child{
    -moz-border-radius: 6px 6px 0 0;
    -webkit-border-radius: 6px 6px 0 0;
    border-radius: 6px 6px 0 0;
}*/

.zebra tfoot td {
    border-bottom: 0;
    border-top: 1px solid #fff;
    background-color: #f1f1f1;  
}

/*.zebra tfoot td:first-child {
    -moz-border-radius: 0 0 0 6px;
    -webkit-border-radius: 0 0 0 6px;
    border-radius: 0 0 0 6px;
}

.zebra tfoot td:last-child {
    -moz-border-radius: 0 0 6px 0;
    -webkit-border-radius: 0 0 6px 0;
    border-radius: 0 0 6px 0;
}

.zebra tfoot td:only-child{
    -moz-border-radius: 0 0 6px 6px;
    -webkit-border-radius: 0 0 6px 6px
    border-radius: 0 0 6px 6px
}*/
  
</style>
   
</head>
<body>
    <form id="form1" runat="server">
         <div id="div1" runat="server">
             <asp:Button ID="Button1" runat="server" Text="导出汇总统计表到excel" OnClick="Button1_Click" />
             <asp:HyperLink ID="HyperLink1" runat="server" ></asp:HyperLink>
    </div><br />
  <div id="divTb" runat="server">
       
    </div>
       
    </form>
     <script type="text/javascript">
         function show(a, b) {
             var tb="数据获取中，请稍后。。。"
             var d = dialog({
                 title: a + "→" + b,
                 //content: '欢迎使用 artDialog 对话框组件！'
                 content: tb,
                 onshow: function () {
                     this.content(tb);
                 }
             });
             d.showModal();
             $.ajax({
                 type: "GET",
                 dataType: "json",
                 url: encodeURI("Handler.ashx?Method=GetJosn&yjmc=" + a + "&ejmc=" + b),
                 //data: { id: id, name: name },
                 success: function (json) {
                     var typeData = json.Module;
                     tb = "<table class=\"bordered\"><thead><tr><th rowspan=\"2\">工作内容</th><th rowspan=\"2\">责任部门</th><th rowspan=\"2\">负责人</th><th rowspan=\"2\">预算金额(元)</th><th colspan=\"3\">人员经费(元)</th><th rowspan=\"2\">福利费(元)</th><th rowspan=\"2\">设备耗材费(元)</th><th rowspan=\"2\">业务费(元)</th><th rowspan=\"2\">其他(元)</th><th rowspan=\"2\">经费种类</th></tr><tr><th>校内人员</th><th>退休人员</th><th>其他人员</th></tr></thead>";
                     var tbBody = ""
                     $.each(typeData, function (i, n) {
                       
                        
                        
                         tbBody += "<tr><td>" + n.SJMC + "</td>" + "<td>" + n.SBBM + "</td>" + "<td>" + n.XMFZR + "</td>" + "<td>" + n.ysje + "</td>" + "<td>" + n.ZZRYFY + "</td>" + "<td>" + n.TXRYFY + "</td>" + "<td>" + n.QTRYFY + "</td>" + "<td>" + n.FLF + "</td>" + "<td>" + n.SBHCF + "</td>" + "<td>" + n.YWF + "</td>" + "<td>" + n.QT + "</td>" + "<td>" + n.JFZL + "</td></tr>";
                        
                     });
                     tb = tb + tbBody + "</table>";
                     d.content(tb);
                 },
                 error: function (json) {
                   
                     d.content("数据加载失败。。。");
                 }
             });

            
         }
         </script>
</body>
</html>
