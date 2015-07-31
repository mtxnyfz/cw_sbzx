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

    public partial class jfsy_sh : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string userid = pb.GetIdentityId();
                //string sqlstr = "select zrbm from Users where user_uid='" + userid + "'";
                //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                //string zrbm = "";
                //if (sdr.Read())
                //{
                //    zrbm = sdr["zrbm"].ToString().Trim();
                //    ViewState["zrbm"] = zrbm;

                //}
                //sdr.Dispose();
                ViewState["key"] = "";
                ViewState["sbbm"] = "all";
                databind_DropDownList();
                databind();
                dp_setvalue(DropDownList_xb, "all");
            }
        }
        protected void databind()
        {
            string sqlstr = "";
            DataTable dt = null;

            if (ViewState["sbbm"].ToString() == "all")
            {
                sqlstr = "select zrbm,BXRQ,BCJFJTYT,JE,ZT,LSH from JFSY,Users where jfsy.CZRID=users.user_uid and  JFSY.SFSC!=1  order by JFSY.BXRQ desc";
            }
            else
            {
                sqlstr = "select zrbm,BXRQ,BCJFJTYT,JE,ZT,LSH from JFSY,Users where jfsy.CZRID=users.user_uid and  JFSY.SFSC!=1 and users.zrbm='" + ViewState["sbbm"].ToString() + "'  order by JFSY.BXRQ desc";
            }
               
           
           
           
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["CZSJ"] =Convert.ToDateTime(dt.Rows[i]["CZSJ"]).ToString("yyyy-MM-dd ");
            //}
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            Grid1.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS1, Grid1);
        }

        protected void databind_DropDownList()
        {
            DropDownList_xb.Items.Clear();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
            DataTable dt = DbHelperSQL.Query("select distinct zrbm from JFSY,Users where jfsy.CZRID=users.user_uid and  JFSY.SFSC!=1  ").Tables[0];
            DropDownList_xb.DataSource = dt;
            DropDownList_xb.DataTextField = "zrbm";
            DropDownList_xb.DataValueField = "zrbm";
            DropDownList_xb.DataBind();
            DropDownList_xb.Items.Add("所有部门", "all");           
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
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            Grid1.PageIndex = e.NewPageIndex;
            //Grid1.DataBind();
            databind();
        }

       

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind();
            Alert.Show("操作成功");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS1);
            string sqlstr = "";
            SqlDataReader sdr = null;
            int flag = 1,ysh=0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        //str = str + ids[i]+",";
                        sqlstr = "select ID from JFSY where ZT<=2 and LSH='" + ids[i]+"'";
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
                            sqlstr = "update JFSY set ZT=3 where LSH='" + ids[i] + "'";
                            if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                            {

                                sqlstr = "update JFSYMX set ZT=3 where LSH='" + ids[i] + "'";
                                if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                                {


                                }
                                else
                                {
                                    databind();
                                    Alert.Show("操作失败");
                                    return;
                                }
                            }
                            else
                            {
                                databind();
                                Alert.Show("操作失败");
                                return;
                            }
                        }

                    }
                    databind();
                    if (ysh == 0)
                        Alert.Show("操作成功");
                    else
                    {
                        Alert.Show("操作成功,但已审核的经费已被忽略此操作");
                    }

                }
                else
                {
                    Alert.Show("没有选择数据");
                }
               
            }
            else
            {
                Alert.Show("没有选择数据");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS1);
            string sqlstr = "";
            SqlDataReader sdr = null;
            int flag = 1, ysh = 0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        sqlstr = "select ID from JFSY where ZT<=2 and LSH='" + ids[i] + "'";
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
                            sqlstr = "update JFSY set ZT=4 where LSH='" + ids[i] + "'";
                            if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                            {
                                sqlstr = "update JFSYMX set ZT=4 where LSH='" + ids[i] + "'";
                                if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                                {


                                }
                                else
                                {
                                    databind();
                                    Alert.Show("操作失败");
                                    return;
                                }

                            }
                            else
                            {
                                databind();
                                Alert.Show("操作失败");
                                return;
                            }
                        }
                    }
                    databind();
                    if (ysh == 0)
                        Alert.Show("操作成功");
                    else
                    {
                        Alert.Show("操作成功,但已审核的经费已被忽略此操作");
                    }

                }
                else
                {
                    Alert.Show("没有选择数据");
                }
               
            }
            else
            {
                Alert.Show("没有选择数据");
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

        //protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        //{
        //    DataRowView row = e.DataItem as DataRowView;
        //    //GridRow gr = Grid1.Rows[e.RowIndex];
        //    WindowField xq = Grid1.FindColumn("xq") as WindowField;
        //    if (row != null)
        //    {
        //        if (row["JFZL"].ToString().Trim() == "项目经费")
        //        {
        //            xq.Enabled = true;
        //        }
        //        else
        //        {
        //            xq.Enabled = false;
        //        }
        //    }
        //}
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

        protected void DropDownList_xb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["sbbm"] = DropDownList_xb.SelectedValue.Trim();
            databind();
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

       
    }
}