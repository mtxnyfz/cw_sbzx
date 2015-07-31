using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using Maticsoft.DBUtility;
namespace EmptyProjectNet40_FineUI.admin
{
    public partial class jfys_xm_look : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string userid = pb.GetIdentityId();
                //ViewState["userid"] = userid;
                if (Request.QueryString["ID"] != null)
                {
                    DataBind(int.Parse(Request.QueryString["ID"].ToString().Trim()));
                }
                //string sqlstr = "select zrbm from Users where user_uid='" + userid + "'";
                //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                //string zrbm = "";
                //if (sdr.Read())
                //{
                //    zrbm = sdr["zrbm"].ToString().Trim();
                //    ViewState["zrbm"] = zrbm;
                //    TextBox_sbbm.Text = zrbm;
                   
                //}
                //sdr.Dispose();
                //DropDownList_yj_databind();
            }
        }

     


        protected void DataBind(int ID)
        {
            string sqlstr = "select * from JFYSSBB where ID=" + ID;
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
        
            if (sdr.Read())
            {


                TextBox_sbbm.Text = sdr["SBBM"].ToString().Trim();
                TextBox_jfzl.Text = sdr["JFZL"].ToString().Trim();
                TextBox_xmmc.Text = sdr["XMMC"].ToString().Trim();
                TextBox_fzr.Text = sdr["XMFZR"].ToString().Trim();
                TextBox_xmmc.Text = sdr["XMMC"].ToString().Trim();
                TextBox_zxqx.Text = sdr["ZXKSRQ"].ToString().Trim() + "至" + sdr["ZXJSRQ"].ToString().Trim();
                TextBox_yj.Text = sdr["YJMC"].ToString().Trim();
                TextBox_ej.Text = sdr["EJMC"].ToString().Trim();
                //TextArea_gznr.Text = sdr["SJMC"].ToString().Trim();
                TextArea_xmnrms.Text = sdr["XMNRGS"].ToString().Trim();
                NumberBox_ysje.Text = String.Format("{0:0.00}", float.Parse(sdr["YSJE"].ToString().Trim()));
                NumberBox_zz.Text = String.Format("{0:0.00}", float.Parse(sdr["ZZRYFY"].ToString().Trim()));
                NumberBox_txry.Text = String.Format("{0:0.00}", float.Parse(sdr["TXRYFY"].ToString().Trim()));
                NumberBox_qtry.Text = String.Format("{0:0.00}", float.Parse(sdr["QTRYFY"].ToString().Trim()));
                NumberBox_flf.Text = String.Format("{0:0.00}", float.Parse(sdr["FLF"].ToString().Trim()));
                NumberBox_sbhc.Text = String.Format("{0:0.00}", float.Parse(sdr["SBHCF"].ToString().Trim()));
                NumberBox_ywf.Text = String.Format("{0:0.00}", float.Parse(sdr["YWF"].ToString().Trim()));
                NumberBox_qt.Text = String.Format("{0:0.00}", float.Parse(sdr["QT"].ToString().Trim()));
                //TextArea_bz.Text = sdr["BZ"].ToString().Trim();
            }
            sdr.Dispose();

        }
      
    }
}