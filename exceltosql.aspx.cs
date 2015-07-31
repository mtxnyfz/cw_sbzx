using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using System.Data;
using ExcelHelp;
using cw_sbzx.BLL;
using cw_sbzx.Model;
namespace EmptyProjectNet40_FineUI.admin
{
    public partial class exceltosql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cw_sbzx.Model.GZJBMC GZJBMC_model = new cw_sbzx.Model.GZJBMC();
            cw_sbzx.BLL.GZJBMC GZJBMC_bll = new cw_sbzx.BLL.GZJBMC();
            ReadOrWriteExcel rw = new ExcelHelp.ReadOrWriteExcel(@"D:\会议记录\预算模块\工作经费预算申报汇总表和流程表.xlsx");
            DataTable dt = rw.BeginRead("B2", "E63", "经费预算汇总表和审批流程表（含数据）");
            //string aa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GZJBMC_model.YJMC=dt.Rows[i][0].ToString();
                GZJBMC_model.EJMC = dt.Rows[i][1].ToString();
                GZJBMC_model.SJMC = dt.Rows[i][2].ToString();
                GZJBMC_model.ZRBM = dt.Rows[i][3].ToString();
                //GZJBMC_bll.Add(GZJBMC_model);
            }
        }
    }
}