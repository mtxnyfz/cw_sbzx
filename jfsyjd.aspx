<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jfsyjd.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.jfsyjd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    
.bordered td,.bordered th {
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
     text-align:center; 
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
    <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />

	<!-- jsProgressBarHandler prerequisites : prototype.js -->
	<script type="text/javascript" src="js/prototype/prototype.js"></script>

	<!-- jsProgressBarHandler core -->
	<script type="text/javascript" src="js/bramus/jsProgressBarHandler.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <%--  <div><span id="element1">Loading Progress Bar</span><script type="text/javascript">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element1'), 32, { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png', 'images/bramus/percentImage_back4.png') }); }, false);</script></div>--%>
        <br />
  <%-- <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
         <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="经费使用进度情况" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" 
                    OnPageIndexChange="Grid1_PageIndexChange"   >
                 
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText="序号" Width="50px" TextAlign="Center"/>
                        
                         <f:BoundField Width="100px" DataField="YJMC"  HeaderText="一级"  ColumnID="Panel7_Grid1_ctl09"  DataToolTipField="YJMC" />
                      
                       <f:BoundField Width="100px" DataField="EJMC"  HeaderText="二级"  ColumnID="Panel7_Grid1_ctl12"  DataToolTipField="EJMC"/>
                        <f:BoundField Width="200px" DataField="SJMC" HeaderText="三级"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="SJMC"/>
                          <f:TemplateField HeaderText="进度" Width="200px" ColumnID="Panel7_Grid1_ctl15">
                            <ItemTemplate>
                              
                                
                                <div><span id="element6">Loading Progress Bar</span><script type="text/javascript"> document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element6'), 81, { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png', 'images/bramus/percentImage_back4.png') }); }, false);</script></div> 
                            </ItemTemplate>

                        </f:TemplateField>
                     
                    </Columns>
                </f:Grid>

               
            </Items>
        </f:Panel>--%>
        <div>经费使用进度</div>
       <div id="divTb" runat="server">
       
    </div>

       <br/>
         <div>部门总经费使用进度</div>
       <div id="divTb1" runat="server">
       
    </div>
    </form>
</body>
</html>
