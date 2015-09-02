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
    public partial class jfsymx_xm_up : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userid = pb.GetIdentityId();
                string sqlstr = "select zrbm,ActualName from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string zrbm = "";
                if (sdr.Read())
                {
                    zrbm = sdr["zrbm"].ToString().Trim();
                    ViewState["zrbm"] = zrbm;
                  

                }
                sdr.Dispose();
                DropDownList_yj_databind();
                //DropDownList_sj_databind();
                databind();
            }
        }

        protected void databind()
        {

            if (Session["dt_jfmx"] != null)
            {
                Grid2.DataSource = Session["dt_jfmx"] as DataTable; ;
                Grid2.DataBind();
            }
        }

        protected void DropDownList_yj_databind()
        {
            DropDownList_yj.Items.Clear();
            //DataTable dt = DbHelperSQL.Query("SELECT distinct [YJMC]  FROM [GZJBMC] where [ZRBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%'  order by [YJMC]").Tables[0];
            DataTable dt = DbHelperSQL.Query("SELECT distinct [YJMC]  FROM [JFYSSBB] where  [SBBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%' and ZT=3 and SFSC!=1 and JFZL='项目经费' and USERUID='" + pb.GetIdentityId() + "'  order by [YJMC]").Tables[0];
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
            //DataTable dt = DbHelperSQL.Query("SELECT distinct [EJMC]  FROM [GZJBMC] where [YJMC]='" + yjmc + "'  order by [EJMC]").Tables[0];
            DataTable dt = DbHelperSQL.Query("SELECT distinct [EJMC]  FROM [JFYSSBB] where [SBBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%' and [YJMC]='" + yjmc + "' and ZT=3 and SFSC!=1 and JFZL='项目经费' and USERUID='" + pb.GetIdentityId() + "'  order by [EJMC]").Tables[0];
            DropDownList_ej.DataSource = dt;
            DropDownList_ej.DataTextField = "EJMC";
            DropDownList_ej.DataValueField = "EJMC";
            DropDownList_ej.DataBind();
            DropDownList_ej.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_ej, "请选择");
        }

        protected void DropDownList_sj_databind(string EJMC)
        {
            DropDownList_sj.Items.Clear();
            //DataTable dt = DbHelperSQL.Query("SELECT distinct [SJMC]  FROM [JFYSSBB] where [USERUID]='" + pb.GetIdentityId() + "' and JFZL='项目经费'  order by [SJMC]").Tables[0];
            DataTable dt = DbHelperSQL.Query("SELECT distinct [SJMC]  FROM [JFYSSBB] where [SBBM] like '%" + ViewState["zrbm"].ToString().Trim() + "%' and EJMC='" + EJMC + "' and ZT=3 and SFSC!=1 and JFZL='项目经费' and USERUID='" + pb.GetIdentityId() + "'  order by [SJMC]").Tables[0];
            DropDownList_sj.DataSource = dt;
            DropDownList_sj.DataTextField = "SJMC";
            DropDownList_sj.DataValueField = "SJMC";
            DropDownList_sj.DataBind();
            DropDownList_sj.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_sj, "请选择");
        }
        protected void DropDownList_yj_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yjmc = DropDownList_yj.SelectedText.Trim();
            if (yjmc != "请选择")
                DropDownList_ej_databind(yjmc);
        }

        protected void DropDownList_ej_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ejmc = DropDownList_ej.SelectedText.Trim();
            if (ejmc != "请选择")
                DropDownList_sj_databind(ejmc);
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


        protected void NumberBox_zz_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            HJ(nb);
        }

        public void HJ(NumberBox nb)
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
                if (hj >= 1000000)
                {
                    NumberBox_syje.Text = String.Format("{0:0.00}", hj - float.Parse(nb.Text.Trim()));
                    nb.Text = "0";
                    Alert.Show("使用金额不能大于或等于1000000");
                    return;
                }
                NumberBox_syje.Text = String.Format("{0:0.00}", hj);
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                Alert.Show("经费使用合计错误：" + ex.Message);
            }
        }
        protected double sum_je()
        {
            DataTable dt = null;
            //string syjf = "0";
            double syjf = 0;
            if (Session["dt_jfmx"] != null)
            {
                dt = Session["dt_jfmx"] as DataTable;


                foreach (DataRow row in dt.Rows)
                {

                    syjf += double.Parse(row["JE"].ToString());
                }



            }

            return syjf;
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
                Alert.Show("请选择项目名称");
                return;
            }
            if (sum_je() + double.Parse(NumberBox_syje.Text.Trim()) >= 1000000)
            {
                Alert.Show("每次报销费用不能等于或超过1000000");
                return;
            }
            DataTable dt1 = null;
            DataRow dr1 = null;
            //DataTable dt2 = null;
            //DataRow dr2 = null;
            try
            {
                if (Session["dt_jfmx"] == null)
                {
                    dt1 = new DataTable();
                    dt1.Columns.Add("id");
                    dt1.Columns.Add("YJMC");
                    dt1.Columns.Add("EJMC");
                    dt1.Columns.Add("SJMC");
                    dt1.Columns.Add("JE");
                    dt1.Columns.Add("BZ");
                    dt1.Columns.Add("DJZS");

                    dt1.Columns.Add("ZZRYFY");
                    dt1.Columns.Add("TXRYFY");
                    dt1.Columns.Add("QTRYFY");
                    dt1.Columns.Add("FLF");
                    dt1.Columns.Add("SBHCF");
                    dt1.Columns.Add("YWF");
                    dt1.Columns.Add("QT");
                    dt1.Columns.Add("JFZL");

                    dr1 = dt1.NewRow();
                    dr1["id"] = Guid.NewGuid().ToString();
                    dr1["YJMC"] = DropDownList_yj.SelectedText.Trim();
                    dr1["EJMC"] = DropDownList_ej.SelectedText.Trim();
                    dr1["SJMC"] = DropDownList_sj.SelectedText.Trim();
                    dr1["JE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_syje.Text.Trim()));
                    dr1["BZ"] = TextArea_bz.Text.Trim();
                    dr1["DJZS"] = int.Parse(NumberBox_djzs.Text.Trim());

                    dr1["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
                    dr1["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
                    dr1["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
                    dr1["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
                    dr1["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
                    dr1["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
                    dr1["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
                    dr1["JFZL"] = "项目经费";

                    dt1.Rows.Add(dr1);
                }
                else
                {

                    dt1 = Session["dt_jfmx"] as DataTable;
                    dr1 = dt1.NewRow();
                    dr1["id"] = Guid.NewGuid().ToString();
                    dr1["YJMC"] = DropDownList_yj.SelectedText.Trim();
                    dr1["EJMC"] = DropDownList_ej.SelectedText.Trim();
                    dr1["SJMC"] = DropDownList_sj.SelectedText.Trim();
                    dr1["JE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_syje.Text.Trim()));
                    dr1["BZ"] = TextArea_bz.Text.Trim();
                    dr1["DJZS"] = int.Parse(NumberBox_djzs.Text.Trim());


                    dr1["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
                    dr1["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
                    dr1["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
                    dr1["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
                    dr1["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
                    dr1["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
                    dr1["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
                    dr1["JFZL"] = "项目经费";
                    dt1.Rows.Add(dr1);

                }
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                Alert.Show("错误：" + ex.Message);
                return;
            }


            //try
            //{
            //    if (ViewState["dt2"] == null)
            //    {
            //        dt2 = new DataTable();
            //        dt2.Columns.Add("id");
            //        dt2.Columns.Add("YJMC");
            //        dt2.Columns.Add("EJMC");
            //        dt2.Columns.Add("SJMC");
            //        dt2.Columns.Add("ZZRYFY");
            //        dt2.Columns.Add("TXRYFY");
            //        dt2.Columns.Add("QTRYFY");
            //        dt2.Columns.Add("FLF");
            //        dt2.Columns.Add("SBHCF");
            //        dt2.Columns.Add("YWF");
            //        dt2.Columns.Add("QT");
            //        dt2.Columns.Add("YSJE");
            //        dt2.Columns.Add("BZ");

            //        dr2 = dt2.NewRow();
            //        dr2["id"] = Guid.NewGuid().ToString();
            //        dr2["YJMC"] = DropDownList_yj.SelectedText.Trim();
            //        dr2["EJMC"] = DropDownList_ej.SelectedText.Trim();
            //        dr2["SJMC"] = DropDownList_sj.SelectedText.Trim();
            //        dr2["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
            //        dr2["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
            //        dr2["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
            //        dr2["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
            //        dr2["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
            //        dr2["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
            //        dr2["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
            //        dr2["JE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_syje.Text.Trim()));
            //        dr2["BZ"] = TextArea_bz.Text.Trim();
            //        dt2.Rows.Add(dr2);
            //    }
            //    else
            //    {
            //        //string nf = DropDownList_nf.SelectedValue.Trim();
            //        dt2 = ViewState["dt2"] as DataTable;
            //        dr2 = dt2.NewRow();
            //        dr2["id"] = Guid.NewGuid().ToString();
            //        dr2["YJMC"] = DropDownList_yj.SelectedText.Trim();
            //        dr2["EJMC"] = DropDownList_ej.SelectedText.Trim();
            //        dr2["SJMC"] = DropDownList_sj.SelectedText.Trim();
            //        dr2["ZZRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_zz.Text.Trim()));
            //        dr2["TXRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_txry.Text.Trim()));
            //        dr2["QTRYFY"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qtry.Text.Trim()));
            //        dr2["FLF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_flf.Text.Trim()));
            //        dr2["SBHCF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_sbhc.Text.Trim()));
            //        dr2["YWF"] = String.Format("{0:N2}", decimal.Parse(NumberBox_ywf.Text.Trim()));
            //        dr2["QT"] = String.Format("{0:N2}", decimal.Parse(NumberBox_qt.Text.Trim()));
            //        dr2["JE"] = String.Format("{0:N2}", decimal.Parse(NumberBox_syje.Text.Trim()));
            //        dr2["BZ"] = TextArea_bz.Text.Trim();
            //        dt2.Rows.Add(dr2);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    //NumberBox_sqzxjfhj.Text = "0";
            //    Alert.Show("错误：" + ex.Message);
            //    return;
            //}
            Grid2.DataSource = dt1;
            Grid2.DataBind();
            Session["dt_jfmx"] = dt1;
            //ViewState["dt2"] = dt2;
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

                if (Session["dt_jfmx"] != null)
                {
                    DataTable dt1 = (DataTable)Session["dt_jfmx"];
                    //DataRow[] dr = dt1.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt1.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i][0].ToString() == selectedID)
                        {

                            dt1.Rows.Remove(dt1.Rows[i]);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt1);
                    //dv.Sort = "nf asc";
                    Grid2.DataSource = dt1;
                    Grid2.DataBind();
                    Session["dt_jfmx"] = dt1;
                }

                //if (ViewState["dt2"] != null)
                //{
                //    DataTable dt2 = (DataTable)ViewState["dt2"];
                //    //DataRow[] dr = dt2.Select("id in(" + selectedID + ")");
                //    //foreach (DataRow d in dr)
                //    //{
                //    //    dt2.Rows.Remove(d);
                //    //}
                //    for (int i = 0; i < dt2.Rows.Count; i++)
                //    {
                //        if (dt2.Rows[i][0].ToString() == selectedID)
                //        {

                //            dt2.Rows.Remove(dt2.Rows[i]);
                //            break;
                //        }
                //    }
                //    //DataView dv = new DataView(dt2);
                //    //dv.Sort = "nf asc";
                //    Grid2.DataSource = dt2;
                //    Grid2.DataBind();
                //    ViewState["dt2"] = dt2;
                //}


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid2.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void DropDownList_jfzl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_jfzl.SelectedText.Trim() == "工作经费")
            {
                Response.Redirect("jfsymx_gz_Add.aspx");
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}