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
    public partial class table_test1 : System.Web.UI.Page
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

      

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "c1";
            dc1.DataType = typeof(string);


            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "c2";
            dc2.DataType = typeof(decimal);

            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "c3";
            dc3.DataType = typeof(decimal);

            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "ID";
            dc4.DataType = typeof(int);

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
            dr2[1] = 0;
            dr2[2] = 0;
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

      

      

        protected void tbxEditorName_TextChanged(object sender, EventArgs e)
        {
            //FineUI.NumberBox txt = sender as FineUI.NumberBox;
            //FineUI.RenderField rd = txt.Parent as FineUI.RenderField;
            
            //labResult.Text = txt.Parent.Parent.GetType().ToString();

            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            labResult.Text = Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None);
           
        }

      
        protected void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            Alert.Show(Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None));
        }
       

      
    }
}