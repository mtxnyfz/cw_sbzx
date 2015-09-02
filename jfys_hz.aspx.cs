using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using FineUI;
using Maticsoft.DBUtility;
using System.Text;
using ExcelHelp;
namespace EmptyProjectNet40_FineUI.admin
{

    public partial class jfys_hz : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind_DropDownList1();
                databind();
            }

           
        }

        protected void databind_DropDownList1()
        {
            string sqlstr = "SELECT distinct SUBSTRING([CZSJ],1,4) as nf FROM [cw_sbzx].[dbo].[JFYSSBB] where  SFSC!=1 and ZT=3 ";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            DropDownList1.DataTextField = "nf";
            DropDownList1.DataValueField = "nf";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }
        protected void databind()
        {
            string sqlstr = "";
            string nf = DropDownList1.Text.Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"bordered\"><thead><tr><th rowspan=\"2\">一级</th><th rowspan=\"2\">二级</th><th colspan=\"3\">人员经费(元)</th><th rowspan=\"2\">福利费(元)</th><th rowspan=\"2\">设备耗材费(元)</th><th rowspan=\"2\">业务费(元)</th><th rowspan=\"2\">其他(元)</th><th rowspan=\"2\">小计(元)</th><th rowspan=\"2\">详情</th></tr><tr><th>校内人员</th><th>退休人员</th><th>其他人员</th></tr></thead>");
            //sb.Append("</table>");
          
            DataTable dt = null, dt_yjmc = null;
            sqlstr = "  select YJMC,EJMC,sum(ISNULL(ZZRYFY,0)) as ZZRYFYHJ,sum(ISNULL(TXRYFY,0)) as TXRYFYHJ,sum(ISNULL(QTRYFY,0)) as QTRYFYHJ,sum(ISNULL(FLF,0)) as FLFHJ,sum(ISNULL(SBHCF,0)) as SBHCFHJ,sum(ISNULL(YWF,0)) as YWFHJ,sum(ISNULL(QT,0)) as QTHJ,(sum(ISNULL(ZZRYFY,0))+sum(ISNULL(TXRYFY,0))+sum(ISNULL(QTRYFY,0))+sum(ISNULL(FLF,0))+sum(ISNULL(SBHCF,0))+sum(ISNULL(YWF,0))+sum(ISNULL(QT,0))) AS HJ from [JFYSSBB] where  SFSC!=1 and ZT=3 and  SUBSTRING([CZSJ],1,4)='"+nf+"' group  by YJMC,EJMC";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            sqlstr = "select YJMC from [JFYSSBB] where  SFSC!=1 and ZT=3  group by YJMC";
            dt_yjmc = DbHelperSQL.Query(sqlstr).Tables[0];
            DataRow[] drs = null;
            double c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;
            double c1_hj = 0, c2_hj = 0, c3_hj = 0, c4_hj = 0, c5_hj = 0, c6_hj = 0, c7_hj = 0, c8_hj = 0;
            for (int i = 0; i < dt_yjmc.Rows.Count; i++)
            {
                drs = dt.Select("YJMC='" + dt_yjmc.Rows[i]["YJMC"] + "'");

                c1 = 0;
                c2 = 0;
                c3 = 0;
                c4 = 0;
                c5 = 0;
                c6 = 0;
                c7 = 0;
                c8 = 0;
                for (int j = 0; j < drs.Length; j++)
                {
                    sb.Append("<tr>");
                    if(j==0)
                        sb.Append("<td rowspan=\"" + drs.Length + "\">" + drs[0][0].ToString().Trim() + "</td>");
                    for (int k = 1; k < dt.Columns.Count; k++)
                    {
                        sb.Append("<td>" + drs[j][k].ToString().Trim() + "</td>");
                    }
                    sb.Append("<td><a href=\"#\" onclick=\"show('" + drs[j][0].ToString().Trim() + "','" + drs[j][1].ToString().Trim() + "')\">详情</a></td>");
                    sb.Append("</tr>");

                    c1 = c1 + double.Parse(drs[j][2].ToString().Trim());
                    c2 = c2 + double.Parse(drs[j][3].ToString().Trim());
                    c3 = c3 + double.Parse(drs[j][4].ToString().Trim());
                    c4 = c4 + double.Parse(drs[j][5].ToString().Trim());
                    c5 = c5 + double.Parse(drs[j][6].ToString().Trim());
                    c6 = c6 + double.Parse(drs[j][7].ToString().Trim());
                    c7 = c7 + double.Parse(drs[j][8].ToString().Trim());
                    c8 = c8 + double.Parse(drs[j][9].ToString().Trim());
                }
                if (drs.Length != 0)
                {
                    sb.Append("<tr class=\"odd\">");
                    sb.Append("<td colspan=\"2\">小计</td><td>" + c1 + "</td><td>" + c2 + "</td><td>" + c3 + "</td><td>" + c4 + "</td><td>" + c5 + "</td><td>" + c6 + "</td><td>" + c7 + "</td><td>" + c8 + "</td><td></td>");
                    sb.Append("</tr>");
                }
                c1_hj = c1_hj + c1;
                c2_hj = c2_hj + c2;
                c3_hj = c3_hj + c3;
                c4_hj = c4_hj + c4;
                c5_hj = c5_hj + c5;
                c6_hj = c6_hj + c6;
                c7_hj = c7_hj + c7;
                c8_hj = c8_hj + c8;

               
            }
            sb.Append("<tr class=\"odd1\">");
            sb.Append("<td colspan=\"2\">合计</td><td>" + c1_hj + "</td><td>" + c2_hj + "</td><td>" + c3_hj + "</td><td>" + c4_hj + "</td><td>" + c5_hj + "</td><td>" + c6_hj + "</td><td>" + c7_hj + "</td><td>" + c8_hj + "</td><td></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            divTb.InnerHtml = sb.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nf = DropDownList1.Text.Trim();
            string js = "<script language=javascript>alert('{0}');</script>";
            string message = "导出成功，请点击下载文件";
            string sqlstr = "";
            DataTable dt = null, dt_yjmc = null;
            sqlstr = "  select YJMC,EJMC,sum(ISNULL(ZZRYFY,0)) as ZZRYFYHJ,sum(ISNULL(TXRYFY,0)) as TXRYFYHJ,sum(ISNULL(QTRYFY,0)) as QTRYFYHJ,sum(ISNULL(FLF,0)) as FLFHJ,sum(ISNULL(SBHCF,0)) as SBHCFHJ,sum(ISNULL(YWF,0)) as YWFHJ,sum(ISNULL(QT,0)) as QTHJ,(sum(ISNULL(ZZRYFY,0))+sum(ISNULL(TXRYFY,0))+sum(ISNULL(QTRYFY,0))+sum(ISNULL(FLF,0))+sum(ISNULL(SBHCF,0))+sum(ISNULL(YWF,0))+sum(ISNULL(QT,0))) AS HJ from [JFYSSBB] where SFSC!=1 and ZT=3 and  SUBSTRING([CZSJ],1,4)='" + nf + "' group  by YJMC,EJMC";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            sqlstr = "  select YJMC from [JFYSSBB] where  SFSC!=1 and ZT=3 group by YJMC";
            dt_yjmc = DbHelperSQL.Query(sqlstr).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ReadOrWriteExcel rd = new ReadOrWriteExcel(Server.MapPath(@"..\admin\mb\") + "\\汇总统计表.xls");
                rd.DataWrite_SetSheetStyle(dt, dt_yjmc, "Sheet1");
                string file = Server.MapPath(@"..\admin\down\") + "\\汇总统计表.xls";
                rd.SavePath(file);
                HyperLink1.Text = "点击下载：汇总统计表.xls";
                HyperLink1.NavigateUrl = "down/汇总统计表.xls";
               
                message = "导出成功，请点击下载文件";
                HttpContext.Current.Response.Write(string.Format(js, message));
            }
            else
            {
                message = "没有可导出的数据";
                HttpContext.Current.Response.Write(string.Format(js, message));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind();
        }
       
    }
}