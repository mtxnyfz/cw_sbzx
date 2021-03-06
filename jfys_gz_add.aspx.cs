﻿using System;
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
    public partial class jfys_gz_add : System.Web.UI.Page
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
                DropDownList_yj_databind();
            }
        }


        protected void DropDownList_yj_databind()
        {
            DropDownList_yj.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [YJMC]  FROM [GZJBMC] where [ZRBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%'  order by [YJMC]").Tables[0];
            DropDownList_yj.DataSource = dt;
            DropDownList_yj.DataTextField = "YJMC";
            DropDownList_yj.DataValueField = "YJMC";
            DropDownList_yj.DataBind();
           
            //DropDownList_yj.Items.Add("其他", "其他");
            DropDownList_yj.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_yj, "请选择");
        }

        protected void DropDownList_ej_databind(string yjmc)
        {
            DropDownList_ej.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [EJMC]  FROM [GZJBMC] where [YJMC]='" + yjmc + "' and [ZRBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%'   order by [EJMC]").Tables[0];
            DropDownList_ej.DataSource = dt;
            DropDownList_ej.DataTextField = "EJMC";
            DropDownList_ej.DataValueField = "EJMC";
            DropDownList_ej.DataBind();
            DropDownList_ej.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_ej, "请选择");
        }

        protected void DropDownList_sj_databind(string EJMC)
        {
            string yjmc = DropDownList_yj.SelectedText.Trim();
            DropDownList_sj.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [SJMC]  FROM [GZJBMC] where [YJMC]='" + yjmc + "' and EJMC='" + EJMC + "' and [ZRBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%'  order by [sjmc]").Tables[0];
            DropDownList_sj.DataSource = dt;
            DropDownList_sj.DataTextField = "SJMC";
            DropDownList_sj.DataValueField = "SJMC";
            DropDownList_sj.DataBind();
            DropDownList_sj.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_sj, "请选择");
        }

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

        protected void DropDownList_ej_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ejmc = DropDownList_ej.SelectedText.Trim();
            if (ejmc != "请选择")
                DropDownList_sj_databind(ejmc);
        }

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

        protected void Button_add_Click(object sender, EventArgs e)
        {
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
            if (DropDownList_sj.SelectedText.Trim() == "请选择")
            {
                Alert.Show("请选择三级");
                return;
            }
            DataTable dt = null;
            try
            {
                if (ViewState["dt"] == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("id");
                    dt.Columns.Add("YJMC");
                    dt.Columns.Add("EJMC");
                    dt.Columns.Add("SJMC");
                    dt.Columns.Add("ZZRYFY");
                    dt.Columns.Add("TXRYFY");
                    dt.Columns.Add("QTRYFY");
                    dt.Columns.Add("FLF");
                    dt.Columns.Add("SBHCF");
                    dt.Columns.Add("YWF");
                    dt.Columns.Add("QT");
                    dt.Columns.Add("YSJE");
                    dt.Columns.Add("BZ");

                    DataRow dr = dt.NewRow();
                    dr["id"] = Guid.NewGuid().ToString();
                    dr["YJMC"] = DropDownList_yj.SelectedText.Trim();
                    dr["EJMC"] = DropDownList_ej.SelectedText.Trim();
                    dr["SJMC"] = DropDownList_sj.SelectedText.Trim();
                    dr["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
                    dr["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
                    dr["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
                    dr["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
                    dr["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
                    dr["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
                    dr["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
                    dr["YSJE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ysje.Text.Trim()));
                    dr["BZ"] = TextArea_bz.Text.Trim();
                    dt.Rows.Add(dr);
                }
                else
                {
                    //string nf = DropDownList_nf.SelectedValue.Trim();
                    dt = ViewState["dt"] as DataTable;
                    DataRow dr = dt.NewRow();
                    dr["id"] = Guid.NewGuid().ToString();
                    dr["YJMC"] = DropDownList_yj.SelectedText.Trim();
                    dr["EJMC"] = DropDownList_ej.SelectedText.Trim();
                    dr["SJMC"] = DropDownList_sj.SelectedText.Trim();
                    dr["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
                    dr["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
                    dr["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
                    dr["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
                    dr["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
                    dr["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
                    dr["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
                    dr["YSJE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ysje.Text.Trim()));
                    dr["BZ"] = TextArea_bz.Text.Trim();
                    dt.Rows.Add(dr);

                }
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                Alert.Show("错误：" + ex.Message);
                return;
            }
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt"] = dt;
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            cw_sbzx.Model.JFYSSBB JFYSSBB_model = new cw_sbzx.Model.JFYSSBB();
            cw_sbzx.BLL.JFYSSBB JFYSSBB_bll = new cw_sbzx.BLL.JFYSSBB();
            JFYSSBB_model.JFZL = DropDownList_jfzl.SelectedText.Trim();
            JFYSSBB_model.USERUID = pb.GetIdentityId();
            JFYSSBB_model.SBBM = ViewState["zrbm"].ToString().Trim();
            if (ViewState["dt"] != null)
            {
                DataTable dt = ViewState["dt"] as DataTable;
                if (dt.Rows.Count == 0)
                {
                    Alert.Show("工作经费预算列表中没有添加数据，请先添加");
                    return;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        JFYSSBB_model.YJMC = dt.Rows[i]["YJMC"].ToString().Trim();
                        JFYSSBB_model.EJMC = dt.Rows[i]["EJMC"].ToString().Trim();
                        JFYSSBB_model.SJMC = dt.Rows[i]["SJMC"].ToString().Trim();
                        JFYSSBB_model.ZZRYFY = decimal.Parse(dt.Rows[i]["ZZRYFY"].ToString().Trim());
                        JFYSSBB_model.TXRYFY = decimal.Parse(dt.Rows[i]["TXRYFY"].ToString().Trim());
                        JFYSSBB_model.QTRYFY = decimal.Parse(dt.Rows[i]["QTRYFY"].ToString().Trim());
                        JFYSSBB_model.FLF = decimal.Parse(dt.Rows[i]["FLF"].ToString().Trim());
                        JFYSSBB_model.SBHCF = decimal.Parse(dt.Rows[i]["SBHCF"].ToString().Trim());
                        JFYSSBB_model.YWF = decimal.Parse(dt.Rows[i]["YWF"].ToString().Trim());
                        JFYSSBB_model.QT = decimal.Parse(dt.Rows[i]["QT"].ToString().Trim());
                        JFYSSBB_model.YSJE = decimal.Parse(dt.Rows[i]["YSJE"].ToString().Trim());
                        JFYSSBB_model.BZ = dt.Rows[i]["BZ"].ToString().Trim();
                        JFYSSBB_model.SFSC = 0;
                        JFYSSBB_model.CZSJ = DateTime.Now.ToString();
                        JFYSSBB_model.ZT = 0;
                        string year= DateTime.Now.ToString("yyyy");
                        string date1 = year+"-01-01";
                        string date2 = year + "-06-30";
                        DateTime nowdate = Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd"));
                        if (DateTime.Compare(nowdate, Convert.ToDateTime(date2)) > 0)
                        {
                            JFYSSBB_model.NDXH = year + "02";
                        }
                        else
                        {
                            JFYSSBB_model.NDXH = year + "01";
                        }
                        //DateTime dt1 = Convert.ToDateTime(date1);
                    }
                    catch (Exception ex)
                    {
                        //NumberBox_sqzxjfhj.Text = "0";
                        Alert.Show("错误：" + ex.Message);
                        return;
                    }
                    JFYSSBB_bll.Add(JFYSSBB_model);

                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("工作经费预算列表中没有添加数据，请先添加");
                return;
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = Grid2.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid2.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid2.AllowPaging && !Grid2.IsDatabasePaging)
                    {
                        rowIndex = Grid2.PageIndex * Grid2.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid2.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["dt"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                           
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid2.DataSource = dt;
                    Grid2.DataBind();
                    ViewState["dt"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid2.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void DropDownList_jfzl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_jfzl.SelectedText.Trim() == "项目经费")
            {
                Response.Redirect("jfys_xm_add.aspx");
            }
        }
    }
}