using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace EmptyProjectNet40_FineUI
{
    /// <summary>
    /// search_bykey 的摘要说明
    /// </summary>
    public class search_bykey : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             String term = context.Request.QueryString["term"];
             if (!String.IsNullOrEmpty(term))
             {
                 //term = term.ToLower();

                 string jsonstr = "[";
                 string sqlstr = "select distinct SBBM from JFYSSBB where SFSC!=1 and SBBM like'%" + term + "%'";
                 DataTable dt1 = DbHelperSQL.Query(sqlstr).Tables[0];
                 sqlstr = "select distinct YJMC from JFYSSBB where SFSC!=1 and YJMC like'%" + term + "%'";
                 DataTable dt2 = DbHelperSQL.Query(sqlstr).Tables[0];
                 sqlstr = "select distinct EJMC from JFYSSBB where SFSC!=1 and EJMC like'%" + term + "%'";
                 DataTable dt3 = DbHelperSQL.Query(sqlstr).Tables[0];
                 for (int i = 0;i< dt1.Rows.Count; i++)
                 {
                     jsonstr = jsonstr + "{\"key\":\"" + dt1.Rows[i][0].ToString().Trim() + "\"},";
                 }
                 for (int i = 0; i < dt2.Rows.Count; i++)
                 {
                     jsonstr = jsonstr + "{\"key\":\"" + dt2.Rows[i][0].ToString().Trim() + "\"},";
                 }
                 for (int i = 0; i < dt3.Rows.Count; i++)
                 {
                     jsonstr = jsonstr + "{\"key\":\"" + dt3.Rows[i][0].ToString().Trim() + "\"},";
                 }
                 jsonstr = jsonstr.Trim();
                 jsonstr = jsonstr.Remove(jsonstr.Length - 1, 1);
                 jsonstr = jsonstr + "]";

                 context.Response.ContentType = "text/plain";
                
                 context.Response.Write(jsonstr);
             }
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