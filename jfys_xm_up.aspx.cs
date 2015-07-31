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
    public partial class jfys_xm_up : System.Web.UI.Page
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
                    TextBox_sbbm.Text = zrbm;
                   
                }
                sdr.Dispose();
                DropDownList_yj_databind();
                if (Request.QueryString["ID"] != null)
                {
                    DataBind(int.Parse(Request.QueryString["ID"].ToString().Trim()));
                }
            }
        }

        protected void DataBind(int ID)
        {
            ViewState["ID"] = ID;
            string sqlstr = "select * from JFYSSBB where ID=" + ID;
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

            if (sdr.Read())
            {



                TextBox_sbbm.Text = sdr["SBBM"].ToString().Trim();
                TextBox_jfzl.Text = sdr["JFZL"].ToString().Trim();
                TextBox_xmmc.Text = sdr["XMMC"].ToString().Trim();
                TextBox_fzr.Text = sdr["XMFZR"].ToString().Trim();
                dp_setvalue(DropDownList_yj, sdr["YJMC"].ToString().Trim());
                DropDownList_ej_databind(sdr["YJMC"].ToString().Trim());
                dp_setvalue(DropDownList_ej, sdr["EJMC"].ToString().Trim());
                TextArea_xmnrms.Text = sdr["XMNRGS"].ToString().Trim();
                DatePicker_zxksrq.Text = sdr["ZXKSRQ"].ToString().Trim();
                DatePicker_zxjsrq.Text = sdr["ZXJSRQ"].ToString().Trim();
              




                NumberBox_ysje.Text = String.Format("{0:0.00}", float.Parse(sdr["YSJE"].ToString().Trim()));
                NumberBox_zz.Text = String.Format("{0:0.00}", float.Parse(sdr["ZZRYFY"].ToString().Trim()));
                NumberBox_txry.Text = String.Format("{0:0.00}", float.Parse(sdr["TXRYFY"].ToString().Trim()));
                NumberBox_qtry.Text = String.Format("{0:0.00}", float.Parse(sdr["QTRYFY"].ToString().Trim()));
                NumberBox_flf.Text = String.Format("{0:0.00}", float.Parse(sdr["FLF"].ToString().Trim()));
                NumberBox_sbhc.Text = String.Format("{0:0.00}", float.Parse(sdr["SBHCF"].ToString().Trim()));
                NumberBox_ywf.Text = String.Format("{0:0.00}", float.Parse(sdr["YWF"].ToString().Trim()));
                NumberBox_qt.Text = String.Format("{0:0.00}", float.Parse(sdr["QT"].ToString().Trim()));

            }
            sdr.Dispose();

        }

        protected void DropDownList_yj_databind()
        {
            DropDownList_yj.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [YJMC]  FROM [GZJBMC] where [ZRBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%'  order by [YJMC]").Tables[0];
            DropDownList_yj.DataSource = dt;
            DropDownList_yj.DataTextField = "YJMC";
            DropDownList_yj.DataValueField = "YJMC";
            DropDownList_yj.DataBind();
            DropDownList_yj.Items.Add("其他", "其他");
            DropDownList_yj.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_yj, "请选择");
        }

        protected void DropDownList_ej_databind(string yjmc)
        {
            DropDownList_ej.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [EJMC]  FROM [GZJBMC] where [YJMC]='" + yjmc + "'  order by [EJMC]").Tables[0];
            DropDownList_ej.DataSource = dt;
            DropDownList_ej.DataTextField = "EJMC";
            DropDownList_ej.DataValueField = "EJMC";
            DropDownList_ej.DataBind();
            DropDownList_ej.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_ej, "请选择");
        }

        //protected void DropDownList_sj_databind(string EJMC)
        //{
        //    DropDownList_sj.Items.Clear();
        //    DataTable dt = DbHelperSQL.Query("SELECT distinct [SJMC]  FROM [GZJBMC] where EJMC='" + EJMC + "'  order by [sjmc]").Tables[0];
        //    DropDownList_sj.DataSource = dt;
        //    DropDownList_sj.DataTextField = "SJMC";
        //    DropDownList_sj.DataValueField = "SJMC";
        //    DropDownList_sj.DataBind();
        //    DropDownList_sj.Items.Add("请选择", "请选择");

        //    dp_setvalue(DropDownList_sj, "请选择");
        //}

        protected void dp_setvalue(FineUI.DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Trim() == value)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.

                    break;        //选中一条后,跳出循环.
                }
            }

        }
        protected void DropDownList_yj_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yjmc=DropDownList_yj.SelectedText.Trim();
            if (yjmc != "请选择")
                DropDownList_ej_databind(yjmc);
        }

        //protected void DropDownList_ej_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string ejmc = DropDownList_ej.SelectedText.Trim();
        //    if (ejmc != "请选择")
        //        DropDownList_sj_databind(ejmc);
        //}

        protected void NumberBox_zz_TextChanged(object sender, EventArgs e)
        {
            HJ();
        }

        public void HJ()
        {
            try
            {
                string ryjf_zz = NumberBox_zz.Text.Trim() == "" ? "0" : NumberBox_zz.Text.ToString().Trim();
                string ryjf_txry = NumberBox_txry.Text.Trim() == "" ? "0" : NumberBox_txry.Text.ToString().Trim();
                string ryjf_qtry = NumberBox_qtry.Text.Trim() == "" ? "0" : NumberBox_qtry.Text.ToString().Trim();
                string flf = NumberBox_flf.Text.Trim() == "" ? "0" : NumberBox_flf.Text.ToString().Trim();
                string sbhc = NumberBox_sbhc.Text.Trim() == "" ? "0" : NumberBox_sbhc.Text.ToString().Trim();
                string ywf = NumberBox_ywf.Text.Trim() == "" ? "0" : NumberBox_ywf.Text.ToString().Trim();
                string qt = NumberBox_qt.Text.Trim() == "" ? "0" : NumberBox_qt.Text.ToString().Trim();
                float hj = (float.Parse(ryjf_zz) + float.Parse(ryjf_txry) + float.Parse(ryjf_qtry) + float.Parse(flf) + float.Parse(sbhc) + float.Parse(ywf) + float.Parse(qt));
                NumberBox_ysje.Text = String.Format("{0:0.00}", hj);
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                Alert.Show("预算合计错误：" + ex.Message);
            }
        }

      

        protected void Button_save_Click(object sender, EventArgs e)
        {
            cw_sbzx.Model.JFYSSBB JFYSSBB_model = null;
            cw_sbzx.BLL.JFYSSBB JFYSSBB_bll = new cw_sbzx.BLL.JFYSSBB();
            JFYSSBB_model = JFYSSBB_bll.GetModel(int.Parse(ViewState["ID"].ToString().Trim()));
            if (JFYSSBB_model.ZT > 2)
            {
                Alert.Show("该预算已审核，无法修改");
                return;
            }
            if (DropDownList_yj.SelectedText.Trim() == "请选择")
            {
                Alert.Show("请选择一级");
                return;
            }
            if (DropDownList_ej.SelectedText.Trim() == "请选择")
            {
                Alert.Show("请选择二级");
                return;
            }
            try
            {
               
                JFYSSBB_model.SBBM = TextBox_sbbm.Text.Trim();
                JFYSSBB_model.XMMC = TextBox_xmmc.Text.Trim();
                JFYSSBB_model.XMFZR = TextBox_fzr.Text.Trim();
                JFYSSBB_model.ZXKSRQ = DatePicker_zxksrq.Text.Trim();
                JFYSSBB_model.ZXJSRQ = DatePicker_zxjsrq.Text.Trim();

                JFYSSBB_model.YJMC = DropDownList_yj.SelectedText.Trim();
                JFYSSBB_model.EJMC = DropDownList_ej.SelectedText.Trim();
                //JFYSSBB_model.SJMC = dt.Rows[i]["SJMC"].ToString().Trim();
                JFYSSBB_model.SJMC = TextBox_xmmc.Text.Trim();
                JFYSSBB_model.XMNRGS = TextArea_xmnrms.Text.Trim();
                JFYSSBB_model.ZZRYFY = decimal.Parse(NumberBox_zz.Text.Trim());
                JFYSSBB_model.TXRYFY = decimal.Parse(NumberBox_txry.Text.Trim());
                JFYSSBB_model.QTRYFY = decimal.Parse(NumberBox_qtry.Text.Trim());
                JFYSSBB_model.FLF = decimal.Parse(NumberBox_flf.Text.Trim());
                JFYSSBB_model.SBHCF = decimal.Parse(NumberBox_sbhc.Text.Trim());
                JFYSSBB_model.YWF = decimal.Parse(NumberBox_ywf.Text.Trim());
                JFYSSBB_model.QT = decimal.Parse(NumberBox_qt.Text.Trim());
                JFYSSBB_model.YSJE = decimal.Parse(NumberBox_ysje.Text.Trim());
                //JFYSSBB_model.BZ = TextArea_bz.Text.Trim();
                JFYSSBB_model.CZSJ = DateTime.Now.ToString();

                //JFYSSBB_model.ZT = 0;
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                Alert.Show("错误：" + ex.Message);
                return;
            }
            JFYSSBB_bll.Update(JFYSSBB_model);

                
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference()); ;
        }

      

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = Grid2.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = Grid2.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (Grid2.AllowPaging && !Grid2.IsDatabasePaging)
        //            {
        //                rowIndex = Grid2.PageIndex * Grid2.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += Grid2.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["dt"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["dt"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
                           
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            Grid2.DataSource = dt;
        //            Grid2.DataBind();
        //            ViewState["dt"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        Grid2.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}
    }
}