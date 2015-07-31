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
using Aspose.Cells;
using ExcelHelp;
namespace EmptyProjectNet40_FineUI.admin
{
    public partial class excelstyle_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            DataTable dt = null,dt_yjmc=null;
            sqlstr = "  select YJMC,EJMC,sum(ISNULL(ZZRYFY,0)) as ZZRYFYHJ,sum(ISNULL(TXRYFY,0)) as TXRYFYHJ,sum(ISNULL(QTRYFY,0)) as QTRYFYHJ,sum(ISNULL(FLF,0)) as FLFHJ,sum(ISNULL(SBHCF,0)) as SBHCFHJ,sum(ISNULL(YWF,0)) as YWFHJ,sum(ISNULL(QT,0)) as QTHJ,(sum(ISNULL(ZZRYFY,0))+sum(ISNULL(TXRYFY,0))+sum(ISNULL(QTRYFY,0))+sum(ISNULL(FLF,0))+sum(ISNULL(SBHCF,0))+sum(ISNULL(YWF,0))+sum(ISNULL(QT,0))) AS HJ from [JFYSSBB] group  by YJMC,EJMC";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            sqlstr = "  select YJMC from [JFYSSBB] group by YJMC";
            dt_yjmc = DbHelperSQL.Query(sqlstr).Tables[0];
            DataRow[] drs = null;
            ReadOrWriteExcel rd = new ReadOrWriteExcel(Server.MapPath(@"..\admin\mb\") + "\\汇总统计表.xls");
            rd.DataWrite_SetSheetStyle(dt, dt_yjmc, "Sheet1");
            string file = Server.MapPath(@"..\admin\mb\") + "\\1.xls";
            rd.SavePath(file);
           
        }
    }
}