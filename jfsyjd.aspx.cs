using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FineUI;
using Maticsoft.DBUtility;
using AppBox;
using System.Text;
namespace EmptyProjectNet40_FineUI.admin
{
    public partial class jfsyjd : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userid = pb.GetIdentityId();
                string sqlstr = "select zrbm from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string zrbm = "";
                if (sdr.Read())
                {
                    zrbm = sdr["zrbm"].ToString().Trim();
                    ViewState["zrbm"] = zrbm;

                }
                sdr.Dispose();
                databind();
                databind1();
               
            }
        }
        protected void databind()
        {
            string sqlstr = "SELECT [YJMC] ,[EJMC] ,[SJMC],SBBM,(SUM(ZZRYFY)+SUM(TXRYFY)+SUM(QTRYFY)) as ryfy, SUM(FLF) as flf,SUM(SBHCF) as SBHCF,SUM(YWF) as YWF,SUM(QT)as QT FROM [cw_sbzx].[dbo].[JFYSSBB] where  SFSC!=1 and ZT=3 and SBBM='" + ViewState["zrbm"].ToString().Trim()+ "'   group by  [YJMC],[EJMC] ,[SJMC],SBBM";
            DataTable dt1 = DbHelperSQL.Query(sqlstr).Tables[0];
            sqlstr = "SELECT [YJMC] ,[EJMC] ,[SJMC],zrbm,(SUM(ZZRYFY)+SUM(TXRYFY)+SUM(QTRYFY)) as ryfy, SUM(FLF) as flf,SUM(SBHCF) as SBHCF,SUM(YWF) as YWF,SUM(QT)as QT,0.00 as  ryfyjd,0.00 as  FLFJD,0.00 as  SBHCFJD,0.00 as  YWFJD,0.00 as  QTJD,0.00 as  ryfyye,0.00 as  FLFYE,0.00 as  SBHCFYE,0.00 as  YWFYE,0.00 as  QTYE FROM (select [YJMC],[EJMC] ,[SJMC],zrbm,ZZRYFY,TXRYFY,QTRYFY,FLF,SBHCF,YWF,QT from [JFSYMX],Users where Users.user_uid=[JFSYMX].CZRID and   SFSC!=1 and ZT=3 and zrbm='" + ViewState["zrbm"].ToString().Trim() + "')  as a group by  [YJMC],[EJMC] ,[SJMC],zrbm";
            DataTable dt2 = DbHelperSQL.Query(sqlstr).Tables[0];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    if (dt2.Rows[i]["YJMC"].ToString().Trim() == dt1.Rows[j]["YJMC"].ToString().Trim() && dt2.Rows[i]["EJMC"].ToString().Trim() == dt1.Rows[j]["EJMC"].ToString().Trim() && dt2.Rows[i]["SJMC"].ToString().Trim() == dt1.Rows[j]["SJMC"].ToString().Trim() && dt2.Rows[i]["zrbm"].ToString().Trim() == dt1.Rows[j]["SBBM"].ToString().Trim())
                    {
                        dt2.Rows[i]["ryfyjd"] =Convert.ToInt32(double.Parse(dt2.Rows[i]["ryfy"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["ryfy"].ToString().Trim()));
                        dt2.Rows[i]["ryfyye"] = double.Parse(dt1.Rows[j]["ryfy"].ToString().Trim()) - double.Parse(dt2.Rows[i]["ryfy"].ToString().Trim());

                        dt2.Rows[i]["FLFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["FLF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["FLF"].ToString().Trim()));
                        dt2.Rows[i]["FLFYE"] = double.Parse(dt1.Rows[j]["FLF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["FLF"].ToString().Trim());

                        dt2.Rows[i]["SBHCFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["SBHCF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["SBHCF"].ToString().Trim()));
                        dt2.Rows[i]["SBHCFYE"] = double.Parse(dt1.Rows[j]["SBHCF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["SBHCF"].ToString().Trim());

                        dt2.Rows[i]["YWFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["YWF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["YWF"].ToString().Trim()));
                        dt2.Rows[i]["YWFYE"] = double.Parse(dt1.Rows[j]["YWF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["YWF"].ToString().Trim());

                        dt2.Rows[i]["QTJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["QT"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["QT"].ToString().Trim()));
                        dt2.Rows[i]["QTYE"] = double.Parse(dt1.Rows[j]["QT"].ToString().Trim()) - double.Parse(dt2.Rows[i]["QT"].ToString().Trim());
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"bordered\"><thead><tr><th>一级</th><th rowspan=\"2\">二级</th><th rowspan=\"2\">三级</th><th>人员经费</th><th>福利费</th><th>设备耗材费</th><th>业务费</th><th>其他费用</th></tr></thead>");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dt2.Rows[i]["YJMC"] + "</td><td>" + dt2.Rows[i]["EJMC"] + "</td><td>" + dt2.Rows[i]["SJMC"] + "</td><td><div nowrap>进度：<span id=\"element" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["ryfyye"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element'+" + i + "), " + dt2.Rows[i]["ryfyjd"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element1" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["FLFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element1'+" + i + "), " + dt2.Rows[i]["FLFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element2" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["SBHCFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element2'+" + i + "), " + dt2.Rows[i]["SBHCFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element3" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["YWFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element3'+" + i + "), " + dt2.Rows[i]["YWFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element4" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["QTYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element4'+" + i + "), " + dt2.Rows[i]["QTJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            divTb.InnerHtml = sb.ToString();
            //Grid1.DataSource = dt2;
            //Grid1.DataBind();
        }

        protected void databind1()
        {
            string sqlstr = "SELECT (SUM(ZZRYFY)+SUM(TXRYFY)+SUM(QTRYFY)) as ryfy, SUM(FLF) as flf,SUM(SBHCF) as SBHCF,SUM(YWF) as YWF,SUM(QT)as QT FROM [cw_sbzx].[dbo].[JFYSSBB] where  SFSC!=1 and ZT=3 and SBBM='" + ViewState["zrbm"].ToString().Trim() + "'";
            DataTable dt1 = DbHelperSQL.Query(sqlstr).Tables[0];
            sqlstr = "SELECT (SUM(ZZRYFY)+SUM(TXRYFY)+SUM(QTRYFY)) as ryfy, SUM(FLF) as flf,SUM(SBHCF) as SBHCF,SUM(YWF) as YWF,SUM(QT)as QT,0.00 as  ryfyjd,0.00 as  FLFJD,0.00 as  SBHCFJD,0.00 as  YWFJD,0.00 as  QTJD,0.00 as  ryfyye,0.00 as  FLFYE,0.00 as  SBHCFYE,0.00 as  YWFYE,0.00 as  QTYE FROM (select ZZRYFY,TXRYFY,QTRYFY,FLF,SBHCF,YWF,QT from [JFSYMX],Users where Users.user_uid=[JFSYMX].CZRID and   SFSC!=1 and ZT=3 and zrbm='" + ViewState["zrbm"].ToString().Trim() + "')  as a";
            DataTable dt2 = DbHelperSQL.Query(sqlstr).Tables[0];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    //if (dt2.Rows[i]["YJMC"].ToString().Trim() == dt1.Rows[j]["YJMC"].ToString().Trim() && dt2.Rows[i]["EJMC"].ToString().Trim() == dt1.Rows[j]["EJMC"].ToString().Trim() && dt2.Rows[i]["SJMC"].ToString().Trim() == dt1.Rows[j]["SJMC"].ToString().Trim() && dt2.Rows[i]["zrbm"].ToString().Trim() == dt1.Rows[j]["SBBM"].ToString().Trim())
                    //{
                        dt2.Rows[i]["ryfyjd"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["ryfy"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["ryfy"].ToString().Trim()));
                        dt2.Rows[i]["ryfyye"] = double.Parse(dt1.Rows[j]["ryfy"].ToString().Trim()) - double.Parse(dt2.Rows[i]["ryfy"].ToString().Trim());

                        dt2.Rows[i]["FLFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["FLF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["FLF"].ToString().Trim()));
                        dt2.Rows[i]["FLFYE"] = double.Parse(dt1.Rows[j]["FLF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["FLF"].ToString().Trim());

                        dt2.Rows[i]["SBHCFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["SBHCF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["SBHCF"].ToString().Trim()));
                        dt2.Rows[i]["SBHCFYE"] = double.Parse(dt1.Rows[j]["SBHCF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["SBHCF"].ToString().Trim());

                        dt2.Rows[i]["YWFJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["YWF"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["YWF"].ToString().Trim()));
                        dt2.Rows[i]["YWFYE"] = double.Parse(dt1.Rows[j]["YWF"].ToString().Trim()) - double.Parse(dt2.Rows[i]["YWF"].ToString().Trim());

                        dt2.Rows[i]["QTJD"] = Convert.ToInt32(double.Parse(dt2.Rows[i]["QT"].ToString().Trim()) * 100.00 / double.Parse(dt1.Rows[j]["QT"].ToString().Trim()));
                        dt2.Rows[i]["QTYE"] = double.Parse(dt1.Rows[j]["QT"].ToString().Trim()) - double.Parse(dt2.Rows[i]["QT"].ToString().Trim());
                    //}
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"bordered\"><thead><tr><th>人员经费</th><th>福利费</th><th>设备耗材费</th><th>业务费</th><th>其他费用</th></tr></thead>");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td><div nowrap>进度：<span id=\"element01" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["ryfyye"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element01'+" + i + "),133, { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element11" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["FLFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element11'+" + i + "), " + dt2.Rows[i]["FLFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element12" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["SBHCFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element12'+" + i + "), " + dt2.Rows[i]["SBHCFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element13" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["YWFYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element13'+" + i + "), " + dt2.Rows[i]["YWFJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>  <td><div>进度：<span id=\"element14" + i + "\">Loading</span><br/>余额(元)：" + dt2.Rows[i]["QTYE"] + "<script type=\"text/javascript\">document.observe('dom:loaded', function () { manualPB2 = new JS_BRAMUS.jsProgressBar($('element14'+" + i + "), " + dt2.Rows[i]["QTJD"] + ", { barImage: Array('images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back1.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back2.png', 'images/bramus/percentImage_back3.png') }); }, false);</script></div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            divTb1.InnerHtml = sb.ToString();
            //Grid1.DataSource = dt2;
            //Grid1.DataBind();
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {

            //Grid1.PageIndex = e.NewPageIndex;
            //Grid1.DataBind();

        }
    }
}