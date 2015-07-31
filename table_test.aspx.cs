using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using FineUI;
namespace EmptyProjectNet40_FineUI.admin
{
    public partial class table_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDropDownList();

                BindGrid();
            }
        }


        #region BindGrid

        //private void BindDropDownList()
        //{
        //    List<string> majors = new List<string>();
        //    majors.Add("材料科学与工程系");
        //    majors.Add("化学系");
        //    majors.Add("数学系");
        //    majors.Add("物理系");
        //    majors.Add("自动化系");
        //    majors.Add("计算机科学与工程系");

        //    ddlMajor.DataSource = majors;
        //    ddlMajor.DataBind();
        //}

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "c1";
            dc1.DataType = typeof(string);


            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "c2";
            dc2.DataType = typeof(float);

            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "c3";
            dc3.DataType = typeof(float);

            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "ID";
            dc4.DataType = typeof(string);

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            DataRow dr1 = dt.NewRow();
            dr1[0] = "AA";
            dr1[1] = 0;
            dr1[2] = 0;
            dr1[3] = 1;

            DataRow dr2 = dt.NewRow();
            dr2[0] = "BB";
            dr2[1] =0;
            dr2[2] =0;
            dr2[3] = 2;

            DataRow dr3 = dt.NewRow();
            dr3[0] = "CC";
            dr3[1] = 0;
            dr3[2] = 0;
            dr3[3] = 3;

            DataRow dr4 = dt.NewRow();
            dr4[0] = "DD";
            dr4[1] = 0;
            dr4[2] = 0;
            dr4[3] = 4;

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }


        #endregion

        #region Events

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();

        //    for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
        //    {
        //        if (modifiedDict.ContainsKey(i))
        //        {
        //            Dictionary<string, object> rowDict = modifiedDict[i];

        //            // 更新数据源
        //            DataTable table = GetSourceData();

        //            DataRow rowData = table.Rows[i];

        //            // 姓名
        //            if (rowDict.ContainsKey("Name"))
        //            {
        //                rowData["Name"] = rowDict["Name"];
        //            }
        //            // 性别
        //            if (rowDict.ContainsKey("Gender"))
        //            {
        //                rowData["Gender"] = rowDict["Gender"];
        //            }
        //            // 入学年份
        //            if (rowDict.ContainsKey("EntranceYear"))
        //            {
        //                rowData["EntranceYear"] = rowDict["EntranceYear"];
        //            }
        //            // 入学日期
        //            if (rowDict.ContainsKey("EntranceDate"))
        //            {
        //                rowData["EntranceDate"] = rowDict["EntranceDate"];
        //            }
        //            // 是否在校
        //            if (rowDict.ContainsKey("AtSchool"))
        //            {
        //                rowData["AtSchool"] = rowDict["AtSchool"];
        //            }
        //            // 所学专业
        //            if (rowDict.ContainsKey("Major"))
        //            {
        //                rowData["Major"] = rowDict["Major"];
        //            }

        //        }
        //    }

        //    labResult.Text = "用户修改的数据：" + Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None);

        //    BindGrid();

        //    Alert.Show("数据保存成功！（表格数据已重新绑定）");
        //}




        #endregion

        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "datatable_for_grid_editor_cell_renderfunction";

        protected void tbxEditorName_TextChanged(object sender, EventArgs e)
        {
            FineUI.TextBox txt = sender as FineUI.TextBox;
            Alert.Show(txt.ID);
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            FineUI.TextBox txt = sender as FineUI.TextBox;
            Alert.Show(txt.ID);
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            //System.Web.UI.WebControls.TextBox txt = sender as System.Web.UI.WebControls.TextBox;
            //Alert.Show(txt.Parent.GetType().ToString());
            //for (int i = 0; i < Grid1.Rows.Count; i++)
            //{
            //    GridRow gr = Grid1.Rows[i];
            //    System.Web.UI.WebControls.TextBox txt1 = gr.FindControl("TextBox55") as System.Web.UI.WebControls.TextBox;
            //    System.Web.UI.WebControls.TextBox txt2 = gr.FindControl("TextBox33") as System.Web.UI.WebControls.TextBox;
              
            //    Alert.Show(txt1.Text + "|" + txt2.Text);
            //}

            
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            Alert.Show(Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None));
            
        }

        protected void Grid1_AfterEdit(object sender, GridAfterEditEventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            Alert.Show("数据保存成功！（表格数据已重新绑定）");
        }

        protected void tbxEditorName_TextChanged1(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            Alert.Show(Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"result\" style=\"width:350px;\"><tr><th>编号</th><th>福利费</th><th>设备耗材费</th><th>合计</th></tr>");
            for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
            {
                sb.Append("<tr>");
                object[] rowDataKeys = Grid1.DataKeys[i];
                sb.AppendFormat("<td>{0}</td>", rowDataKeys[0]);
               

                GridRow row = Grid1.Rows[i];
                System.Web.UI.WebControls.TextBox tbxYuwen = (System.Web.UI.WebControls.TextBox)row.FindControl("TextBox_fl");
                sb.AppendFormat("<td>{0}</td>", tbxYuwen.Text);
                System.Web.UI.WebControls.TextBox tbxShuxue = (System.Web.UI.WebControls.TextBox)row.FindControl("TextBox_sbhc");
                sb.AppendFormat("<td>{0}</td>", tbxShuxue.Text);
                System.Web.UI.HtmlControls.HtmlInputHidden tbxYingyu = (System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("Hidden_hj");
                sb.AppendFormat("<td>{0}</td>", tbxYingyu.Value);

                sb.Append("<tr>");
            }

            sb.Append("</table>");

            labResult.Text = sb.ToString();
        }
        //protected void TextBox33_TextChanged(object sender, EventArgs e)
        //{
        //    System.Web.UI.WebControls.TextBox txt = sender as System.Web.UI.WebControls.TextBox;
        //    Alert.Show(txt.Text);
        //}
        //protected void TextBox55_TextChanged(object sender, EventArgs e)
        //{
        //    System.Web.UI.WebControls.TextBox txt = sender as System.Web.UI.WebControls.TextBox;
        //    Alert.Show(txt.Text);
        //}
        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        //private DataTable GetSourceData()
        //{
        //    if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
        //    {
        //        Session[KEY_FOR_DATASOURCE_SESSION] = GetDataTable();
        //    }
        //    return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        //}

        #endregion
    }
}