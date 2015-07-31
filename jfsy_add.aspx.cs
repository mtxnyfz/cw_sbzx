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
using System.Web.UI.HtmlControls;
namespace EmptyProjectNet40_FineUI.admin
{
    
    public partial class jfsy_add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        string user_uid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                user_uid = pb.GetIdentityId();
                ViewState["zt"] = "0";
                if (Session["dt_jfmx"] != null)
                    Session.Remove("dt_jfmx");
               
            }
        }

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    databind1();
        //}
        protected void databind1()
        {
            if (Session["dt_jfmx"] != null)
            {
                double je = 0.0;
                string zs = "", xs = "", temp_je = "";
                int zslength = 0, xslength = 0;
                char[] arr1 = null, arr2 = null;

                DataTable dt = Session["dt_jfmx"] as DataTable;


                HtmlTableRow htr = null;
                HtmlTableCell htc = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    htr = new HtmlTableRow();
                    htc = new HtmlTableCell();
                    htc.InnerText = dt.Rows[i]["YJMC"].ToString();
                    htr.Cells.Add(htc);
                    htc.ColSpan = 1;

                    htc = new HtmlTableCell();
                    htc.InnerText = dt.Rows[i]["EJMC"].ToString();
                    htr.Cells.Add(htc);
                    htc = new HtmlTableCell();
                    htc.InnerText = dt.Rows[i]["SJMC"].ToString();
                    htr.Cells.Add(htc);

                    je = Convert.ToDouble(dt.Rows[i]["JE"].ToString());
                    temp_je = je.ToString().Trim();

                    arr1 = null;
                    arr2 = null;
                    if (temp_je.Contains('.'))
                    {
                        zs = temp_je.Substring(0, temp_je.IndexOf('.'));
                        xs = temp_je.Substring(temp_je.IndexOf('.') + 1);
                        arr1 = zs.ToCharArray();
                        arr2 = xs.ToCharArray();

                    }
                    else
                    {
                        zs = temp_je;
                        arr1 = zs.ToCharArray();
                    }
                    int start = 6 - arr1.Length, start2 = 0;
                    int index1 = 0, index2 = 0;
                    if (arr2 != null)
                    {
                        start2 = arr2.Length;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        if (j >= start && j < 6)
                        {
                            htc = new HtmlTableCell();
                            htc.Attributes.Add("class", "stylenew5");
                            htc.Align = "center";
                            htc.InnerText = arr1[index1].ToString();
                            htr.Cells.Add(htc);
                            if (index1 < arr1.Length - 1)
                                index1++;
                        }
                        if (j >= 6)
                        {
                            if (arr2 != null)
                            {
                                if (arr2.Length - 1 >= j - 6)
                                {
                                    htc = new HtmlTableCell();
                                    htc.Attributes.Add("class", "stylenew5");
                                    htc.Align = "center";
                                    htc.InnerText = arr2[index2].ToString();
                                    htr.Cells.Add(htc);
                                    index2++;
                                }
                                else
                                {
                                    htc = new HtmlTableCell();
                                    htc.Attributes.Add("class", "stylenew5");
                                    htc.Align = "center";
                                    htc.InnerText = "0";
                                    htr.Cells.Add(htc);
                                }
                            }
                            else
                            {
                                htc = new HtmlTableCell();
                                htc.Attributes.Add("class", "stylenew5");
                                htc.Align = "center";
                                htc.InnerText = "0";
                                htr.Cells.Add(htc);
                            }
                        }
                        if (j < start)
                        {
                            htc = new HtmlTableCell();
                            htc.Attributes.Add("class", "stylenew5");
                            htc.Align = "center";
                            htc.InnerText = "0";
                            htr.Cells.Add(htc);
                        }
                    }
                    //htc = new HtmlTableCell();
                    //htc.InnerText ="0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);
                    //htc = new HtmlTableCell();
                    //htc.InnerText = "0";
                    //htr.Cells.Add(htc);

                    htc = new HtmlTableCell();
                    htc.InnerText = dt.Rows[i]["BZ"].ToString();
                    htr.Cells.Add(htc);
                    htc = new HtmlTableCell();
                    htc.InnerText = dt.Rows[i]["DJZS"].ToString();
                    htr.Cells.Add(htc);

                    tb1.Rows.Add(htr);

                }
                //Label5.Text = String.Format("{0:N2}", sum_je());
                je = sum_je();
                htr = new HtmlTableRow();
                htc = new HtmlTableCell();
                htc.InnerText = "合计：" + Money2ChineseHelper.MoneyToChinese(String.Format("{0:N2}", je));
                htr.Cells.Add(htc);
                htc.ColSpan = 3;
               
                temp_je = je.ToString().Trim();

                arr1 = null;
                arr2 = null;
                if (temp_je.Contains('.'))
                {
                    zs = temp_je.Substring(0, temp_je.IndexOf('.'));
                    xs = temp_je.Substring(temp_je.IndexOf('.') + 1);
                    arr1 = zs.ToCharArray();
                    arr2 = xs.ToCharArray();

                }
                else
                {
                    zs = temp_je;
                    arr1 = zs.ToCharArray();
                }
                int start1 = 6 - arr1.Length, start12 = 0;
                int index11 = 0, index22 = 0;
                if (arr2 != null)
                {
                    start12 = arr2.Length;
                }
                for (int j = 0; j < 8; j++)
                {
                    if (j >= start1 && j < 6)
                    {
                        htc = new HtmlTableCell();
                        htc.Attributes.Add("class", "stylenew5");
                        htc.Align = "center";
                        htc.InnerText = arr1[index11].ToString();
                        htr.Cells.Add(htc);
                        if (index11 < arr1.Length - 1)
                            index11++;
                    }
                    if (j >= 6)
                    {
                        if (arr2 != null)
                        {
                            if (arr2.Length - 1 >= j - 6)
                            {
                                htc = new HtmlTableCell();
                                htc.Attributes.Add("class", "stylenew5");
                                htc.Align = "center";
                                htc.InnerText = arr2[index22].ToString();
                                htr.Cells.Add(htc);
                                index22++;
                            }
                            else
                            {
                                htc = new HtmlTableCell();
                                htc.Attributes.Add("class", "stylenew5");
                                htc.Align = "center";
                                htc.InnerText = "0";
                                htr.Cells.Add(htc);
                            }
                        }
                        else
                        {
                            htc = new HtmlTableCell();
                            htc.Attributes.Add("class", "stylenew5");
                            htc.Align = "center";
                            htc.InnerText = "0";
                            htr.Cells.Add(htc);
                        }
                    }
                    if (j < start1)
                    {
                        htc = new HtmlTableCell();
                        htc.Attributes.Add("class", "stylenew5");
                        htc.Align = "center";
                        htc.InnerText = "0";
                        htr.Cells.Add(htc);
                    }
                }


                htc = new HtmlTableCell();
                htc.InnerText = "";
                htr.Cells.Add(htc);
                htc = new HtmlTableCell();
                htc.InnerText = "";
                htr.Cells.Add(htc);

                tb1.Rows.Add(htr);

              

                //Label3.Text = String.Format("{0:N2}", Convert.ToDouble(Label3.Text) + Convert.ToDouble(Label5.Text));

               

            }
        }


        protected double sum_je()
        {
            DataTable dt = null;
            //string syjf = "0";
            double syjf_d = 0;
            if (Session["dt_jfmx"] != null)
            {
                dt = Session["dt_jfmx"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        syjf_d = syjf_d + Convert.ToDouble(dt.Rows[i]["JE"].ToString());
                    }
                    catch { }
                }
            }

            return syjf_d;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            cw_sbzx.Model.JFSY JFSY_Model = new cw_sbzx.Model.JFSY();
            cw_sbzx.Model.JFSYMX JFSYMX_Model = new cw_sbzx.Model.JFSYMX();
            cw_sbzx.BLL.JFSY JFSY_Bll = new cw_sbzx.BLL.JFSY();
            cw_sbzx.BLL.JFSYMX JFSYMX_Bll = new cw_sbzx.BLL.JFSYMX();

            if (TextBox1.Text.Trim() == "")
            {
                Alert.Show("本次经费具体用途为必填项", "提示", Alert.DefaultMessageBoxIcon);
                databind1();
                return;
            }
            if (Session["dt_jfmx"] != null)
            {
                DataTable dt = Session["dt_jfmx"] as DataTable;
                string jfsylsh = Guid.NewGuid().ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JFSYMX_Model.LSH = jfsylsh;
                    JFSYMX_Model.YJMC = dt.Rows[i]["YJMC"].ToString();
                    JFSYMX_Model.EJMC = dt.Rows[i]["EJMC"].ToString();
                    JFSYMX_Model.SJMC = dt.Rows[i]["SJMC"].ToString();
                    JFSYMX_Model.BZ = dt.Rows[i]["BZ"].ToString();
                    JFSYMX_Model.ZZRYFY = Convert.ToDecimal(dt.Rows[i]["ZZRYFY"].ToString().Trim());
                    JFSYMX_Model.TXRYFY = Convert.ToDecimal(dt.Rows[i]["TXRYFY"].ToString().Trim());
                    JFSYMX_Model.QTRYFY = Convert.ToDecimal(dt.Rows[i]["QTRYFY"].ToString().Trim());
                    JFSYMX_Model.FLF = Convert.ToDecimal(dt.Rows[i]["FLF"].ToString().Trim());
                    JFSYMX_Model.SBHCF = Convert.ToDecimal(dt.Rows[i]["SBHCF"].ToString().Trim());
                    JFSYMX_Model.YWF = Convert.ToDecimal(dt.Rows[i]["YWF"].ToString().Trim());
                    JFSYMX_Model.QT = Convert.ToDecimal(dt.Rows[i]["QT"].ToString().Trim());
                    JFSYMX_Model.JFZL = dt.Rows[i]["JFZL"].ToString();


                    JFSYMX_Model.JE = Convert.ToDecimal(dt.Rows[i]["JE"].ToString().Trim());
                    JFSYMX_Model.DJZS = Convert.ToInt32(dt.Rows[i]["DJZS"].ToString().Trim());
                    JFSYMX_Model.ZT = 0;
                    JFSYMX_Model.SFSC = 0;
                    JFSYMX_Model.BXRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    JFSYMX_Model.CZSJ = DateTime.Now.ToString();
                    JFSYMX_Model.CZRID = pb.GetIdentityId();
                    
                    result=JFSYMX_Bll.Add(JFSYMX_Model);
                    if (result == 0)
                    {
                        Alert.Show("数据保存失败", "提示", Alert.DefaultMessageBoxIcon);
                        return;
                    }
                }
                JFSY_Model.LSH = jfsylsh;
                JFSY_Model.BCJFJTYT = TextBox1.Text.Trim();
                JFSY_Model.JE =Convert.ToDecimal(sum_je());
                JFSY_Model.JFZL = JFSYMX_Model.JFZL;
                JFSY_Model.BXRQ = DateTime.Now.ToString("yyyy-MM-dd");
                JFSY_Model.ZT = 0;
                JFSY_Model.SFSC = 0;
                JFSY_Model.CZRID = pb.GetIdentityId();
                JFSY_Model.CZSJ = DateTime.Now.ToString();
                result = JFSY_Bll.Add(JFSY_Model);
                if (result == 0)
                {
                    Alert.Show("数据保存失败", "提示", Alert.DefaultMessageBoxIcon);
                    return;
                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());

            }
            else
            {
                Alert.Show("操作时间过长，页面已失效或没有数据可保存", "提示", Alert.DefaultMessageBoxIcon);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() == "")
            {
                Alert.Show("请先填写本次经费具体用途", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            string addUrl = "~/admin/jfsymx_gz_Add.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加经费支出明细"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            databind1();
        }
    }
}