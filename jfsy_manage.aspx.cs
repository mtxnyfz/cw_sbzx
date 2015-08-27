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

namespace EmptyProjectNet40_FineUI.admin
{
    public partial class jfsy_manage : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["shqk"] = "全部";
                databind();
            }
        }
        protected void databind()
        {
            string useruid = pb.GetIdentityId();
            DataTable dt = null;
            string sqlstr = "";
            if (ViewState["shqk"].ToString() == "全部")
                sqlstr = "select * from JFSY where CZRID='" + useruid + "' and SFSC!=1 order by BXRQ desc";
            else if (ViewState["shqk"].ToString() == "已审核")
                sqlstr = "select * from JFSY where CZRID='" + useruid + "' and SFSC!=1 and ZT>2 order by BXRQ desc";
            else if (ViewState["shqk"].ToString() == "未审核")
                sqlstr = "select * from JFSY where CZRID='" + useruid + "' and SFSC!=1 and ZT<=2 order by BXRQ desc";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            Grid1.DataBind();
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
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
           
            Grid1.PageIndex = e.NewPageIndex;
            Grid1.DataBind();
            
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;

            databind();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string addUrl = "~/admin/jfsy_add.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "经费报销登记"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Alert.Show("功能开发中。。。");

            string lsh = "", zt = "",jfzl="";
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
                    lsh += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][1].ToString().Trim() + ",";
                    jfzl += Grid1.DataKeys[rowIndex][2].ToString().Trim() + ",";
                }
                lsh = lsh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                jfzl = jfzl.TrimEnd(',');//去掉最后一个，号
                if (int.Parse(zt) > 2)
                {
                    Alert.Show("该经费已审核，无法修改");
                    return;
                }


                string addUrl = "~/admin/jfsy_up.aspx?lsh="+lsh+"&jfzl="+jfzl;

                PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "经费报销修改"));
               
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string lsh = "",zt="";
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
                    lsh += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][1].ToString().Trim() + ",";
                }
                lsh = lsh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (int.Parse(zt) > 2)
                {
                    Alert.Show("该经费已审核，无法删除");
                    return;
                }
                string sqlstr = "update JFSY set SFSC=1 where LSH='" + lsh + "'";
                if (DbHelperSQL.ExecuteSql(sqlstr)>0)
                {
                    sqlstr = "update JFSYMX set SFSC=1 where LSH='" + lsh + "'";
                    if (DbHelperSQL.ExecuteSql(sqlstr) > 0)
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
                    Alert.Show("删除失败");
                }
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind();
            Alert.Show("操作成功");
        }

       
    }
}