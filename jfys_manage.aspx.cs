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
using ExcelHelp;
namespace EmptyProjectNet40_FineUI.admin
{
      
    public partial class jfys_manage : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userid = pb.GetIdentityId();
                string sqlstr = "select zrbm,ActualName from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string zrbm = "",name="";
                if (sdr.Read())
                {
                    zrbm = sdr["zrbm"].ToString().Trim();
                    ViewState["zrbm"] = zrbm;
                    name = sdr["ActualName"].ToString().Trim();
                    ViewState["name"] = name;

                }
                sdr.Dispose();
                ViewState["shqk"] = "全部";
                databind();
            }
        }
        protected void databind()
        {
            string sqlstr = "";
            DataTable dt = null;
            if (ViewState["shqk"].ToString() == "全部")
            sqlstr = "select * from JFYSSBB where USERUID='" + pb.GetIdentityId() + "' and SBBM='" + ViewState["zrbm"].ToString().Trim() + "' and SFSC!=1  order by JFZL,CZSJ desc";
            else if (ViewState["shqk"].ToString() == "已审核")
                sqlstr = "select * from JFYSSBB where USERUID='" + pb.GetIdentityId() + "' and SBBM='" + ViewState["zrbm"].ToString().Trim() + "' and SFSC!=1 and ZT>2  order by JFZL,CZSJ desc";
            else if (ViewState["shqk"].ToString() == "未审核")
                sqlstr = "select * from JFYSSBB where USERUID='" + pb.GetIdentityId() + "' and SBBM='" + ViewState["zrbm"].ToString().Trim() + "' and SFSC!=1 and ZT<=2  order by JFZL,CZSJ desc";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["CZSJ"] = Convert.ToDateTime(dt.Rows[i]["CZSJ"]).ToString("yyyy-MM-dd ");
            }
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            Grid1.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS1, Grid1);
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            Grid1.PageIndex = e.NewPageIndex;
            //Grid1.DataBind();
            databind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("jfys_gz_add.aspx", "添加经费预算"));
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind();
            Alert.Show("操作成功");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           string selectedID = "",jfzl="",zt="0";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    jfzl += Grid1.DataKeys[rowIndex][1].ToString().Trim() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString().Trim() + ",";
                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                jfzl = jfzl.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (int.Parse(zt) > 2)
                {
                    Alert.Show("该预算已审核，无法修改");
                    return;
                }
                if (jfzl == "工作经费")
                PageContext.RegisterStartupScript(Window1.GetShowReference("jfys_gz_up.aspx?ID=" + selectedID, "经费预算修改"));
                else  if (jfzl == "项目经费")
                    PageContext.RegisterStartupScript(Window1.GetShowReference("jfys_xm_up.aspx?ID=" + selectedID, "经费预算修改"));
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedID = "", jfzl = "", zt = "0";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    jfzl += Grid1.DataKeys[rowIndex][1].ToString().Trim() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString().Trim() + ",";
                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                jfzl = jfzl.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (int.Parse(zt) > 2)
                {
                    Alert.Show("该预算已审核，无法删除");
                    return;
                }
                cw_sbzx.Model.JFYSSBB JFYSSBB_model = null;
                cw_sbzx.BLL.JFYSSBB JFYSSBB_bll = new cw_sbzx.BLL.JFYSSBB();
                JFYSSBB_model = JFYSSBB_bll.GetModel(int.Parse(selectedID));
                JFYSSBB_model.SFSC = 1;
                if (JFYSSBB_bll.Update(JFYSSBB_model) == true)
                {
                    databind();
                    Alert.Show("操作成功");
                }
                else
                {
                    Alert.Show("删除失败");
                }
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }


        //protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        //{
        //    GridRow gr = Grid1.Rows[e.RowIndex];
        //    System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;



        //    //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
        //    if (lb.Text.Trim() == "至")
        //        lb.Text = "";
           
               

        //}

        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            //GridRow gr = Grid1.Rows[e.RowIndex];
            WindowField xq = Grid1.FindColumn("xq") as WindowField;
            if (row != null)
            {
                if (row["JFZL"].ToString().Trim() == "项目经费")
                {
                    xq.Enabled = true;
                }
                else
                {
                    xq.Enabled = false;
                }
            }
        }
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;




            if (lb.Text.Trim() == "3")
                lb.Text = "通过";
            else if (lb.Text.Trim() == "4")
                lb.Text = "不通过";
            else
                lb.Text = "未审核";



        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS1);
            string sqlstr = "",sqlstr1="select  ROW_NUMBER() OVER(order by JFZL,CZSJ desc) as xh, NDXH,YJMC,EJMC,SJMC,ZZRYFY,TXRYFY,QTRYFY,FLF,SBHCF,YWF,QT,YSJE,JFZL,BZ from JFYSSBB  where ";
            SqlDataReader sdr = null;
            int flag = 1, ysh = 0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        //str = str + ids[i]+",";
                        sqlstr = "select ID from JFYSSBB where ZT<=2 and ID=" + int.Parse(ids[i]);
                        sdr = DbHelperSQL.ExecuteReader(sqlstr);
                        if (sdr.Read())
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                            ysh = 1;
                        }
                        if (flag == 1)
                        {
                            //sqlstr = "update JFYSSBB set ZT=3 where ID=" + int.Parse(ids[i]);
                            sqlstr1 = sqlstr1 + " ID=" + int.Parse(ids[i]) + " or ";

                        }

                    }


                    sqlstr1 = sqlstr1.Trim();
                    sqlstr1 = sqlstr1.Remove(sqlstr1.Length - 2, 2);
                    if (sqlstr1.Contains("where"))
                    {
                        DataTable dt = DbHelperSQL.Query(sqlstr1).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            ReadOrWriteExcel rd = new ReadOrWriteExcel(Server.MapPath(@"..\admin\mb\") + "\\工作经费预算表.xls");
                            rd.DataWrite_SetSheetStyle(dt, "Sheet1", ViewState["zrbm"].ToString(), ViewState["name"].ToString());
                            string file = Server.MapPath(@"..\admin\down\") + "\\工作经费预算表.xls";
                            rd.SavePath(file);
                            if (ysh == 0)
                            {
                                Alert.Show("操作成功,请点击直接下载文件");
                            }
                            else
                            {
                                Alert.Show("操作成功,但已审核的预算不会被导出，请点击直接下载文件");
                            }
                            HyperLink1.Text = "点击下载：工作经费预算表.xls";
                            HyperLink1.NavigateUrl = "down/工作经费预算表.xls";
                        }
                        else
                        {
                            Alert.Show("没有数据可导出");
                        }
                    }
                    else
                    {
                        Alert.Show("没有数据可导出");
                    }
                }
                else
                {
                    Alert.Show("请至少勾选一条数据");
                }
            }
            else
            {
                Alert.Show("请至少勾选一条数据");
            }
        }

        private void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hd, FineUI.Grid grid)
        {
            // 重新绑定表格数据之前，将当前表格页选中行的数据同步到隐藏字段中
            pb.SyncSelectedRowIndexArrayToHiddenField(hd, grid);
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;

            databind();
        }
        protected void DropDownList_xb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_xb.SelectedValue.Trim() == "全部")
                ViewState["shqk"] = "全部";
            else if (DropDownList_xb.SelectedValue.Trim() == "已审核")
                ViewState["shqk"] = "已审核";
            else if (DropDownList_xb.SelectedValue.Trim() == "未审核")
                ViewState["shqk"] = "未审核";
            databind();
        }
    }
}