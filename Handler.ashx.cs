using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using System.Data;
using System.Text;
namespace EmptyProjectNet40_FineUI.admin
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {
        HttpRequest Request;
        HttpResponse Response;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            Request = context.Request;
            Response = context.Response;

            string method = Request["Method"].ToString();
            string yjmc = Request["yjmc"].ToString();
            string ejmc = Request["ejmc"].ToString();
            System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(method);
            methodInfo.Invoke(this, new object[] { yjmc, ejmc });
        }
        public void GetJosn(string yjmc, string ejmc)
        {
            StringBuilder sb = new StringBuilder();
            string jsonData = string.Empty;
            string sqlstr = "select SJMC,SBBM,XMFZR, (ZZRYFY+TXRYFY+QTRYFY+FLF+SBHCF+YWF+QT) as ysje,ZZRYFY,TXRYFY,QTRYFY,FLF,SBHCF,YWF,QT,JFZL from JFYSSBB where YJMC='" + yjmc + "' and EJMC='" + ejmc + "' and SFSC!=1 and ZT=3";
            DataTable dt= DbHelperSQL.Query(sqlstr).Tables[0];
            sb.Append("{\"Module\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonData = "{\"SJMC\":" + "\"" + dt.Rows[i]["SJMC"].ToString().Trim() + "\"" + ",\"SBBM\":" + "\"" + dt.Rows[i]["SBBM"].ToString().Trim() + "\"" + ",\"XMFZR\":" + "\"" + dt.Rows[i]["XMFZR"].ToString().Trim() + "\"" + ",\"ysje\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["ysje"]) + "\"" + ",\"ZZRYFY\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["ZZRYFY"]) + "\"" + ",\"TXRYFY\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["TXRYFY"]) + "\"" + ",\"QTRYFY\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["QTRYFY"]) + "\"" + ",\"FLF\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["FLF"]) + "\"" + ",\"SBHCF\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["SBHCF"]) + "\"" + ",\"YWF\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["YWF"]) + "\"" + ",\"QT\":" + "\"" + String.Format("{0:0.00}", dt.Rows[i]["QT"]) + "\"" + ",\"JFZL\":" + "\"" + dt.Rows[i]["JFZL"].ToString() + "\"" + "},";
                sb.Append(jsonData);
               
            }
            if (dt.Rows.Count> 0)
                sb = sb.Remove(sb.Length - 1, 1);

            sb.Append("]}");
            //System.Threading.Thread.Sleep(1000);
            Response.Write(sb);
            

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}