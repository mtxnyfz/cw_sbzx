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
    public partial class jfsymx_look : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LSH"] != null)
            {
                string lsh=Request.QueryString["LSH"].ToString().Trim();
                ViewState["lsh"] = lsh;
                databind(lsh);
                SqlDataReader sdr = DbHelperSQL.ExecuteReader("select BCJFJTYT from JFSY where LSH='" + lsh + "' and SFSC!=1");
                if (sdr.Read())
                {
                    Label1.Text = sdr["BCJFJTYT"].ToString();
                }
                sdr.Dispose();
            }
        }
        protected void databind(string lsh)
        {
           
                double je = 0.0;
                string zs = "", xs = "", temp_je = "";
                int zslength = 0, xslength = 0;
                char[] arr1 = null, arr2 = null;

                DataTable dt = DbHelperSQL.Query("select * from JFSYMX where LSH='" + lsh + "' and SFSC!=1").Tables[0];


                HtmlTableRow htr = null;
                HtmlTableCell htc = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    htr = new HtmlTableRow();
                    htc = new HtmlTableCell();
                    htc.Attributes.Add("class", "style7");
                    htc.InnerText = dt.Rows[i]["YJMC"].ToString();
                    htr.Cells.Add(htc);
                    htc.ColSpan = 1;

                    htc = new HtmlTableCell();
                    htc.Attributes.Add("class", "style7");
                    htc.InnerText = dt.Rows[i]["EJMC"].ToString();
                    htr.Cells.Add(htc);
                    htc = new HtmlTableCell();
                    htc.Attributes.Add("class", "style7");
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
                    htc.Attributes.Add("class", "style7");
                    htc.InnerText = dt.Rows[i]["BZ"].ToString();
                    htr.Cells.Add(htc);
                    htc = new HtmlTableCell();
                    htc.Attributes.Add("class", "style7");
                    htc.InnerText = dt.Rows[i]["DJZS"].ToString();
                    htr.Cells.Add(htc);

                    tb1.Rows.Add(htr);

                }
                //Label5.Text = String.Format("{0:N2}", sum_je());
                je = sum_je(dt);
                htr = new HtmlTableRow();
                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "border77");
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
                htc.Attributes.Add("class", "style7");
                htc.InnerText = "";
                htr.Cells.Add(htc);
                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "style7");
                htc.InnerText = "";
                htr.Cells.Add(htc);

                tb1.Rows.Add(htr);



                htr = new HtmlTableRow();
                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "border08");
                htc.Attributes.Add("height", "35");
                htc.Align = "left";
                htc.BgColor = "#FFFFFF";
                htc.InnerText = "经办人：";
                htr.Cells.Add(htc);
                htc.ColSpan = 2;


                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "border08");
                htc.Attributes.Add("height", "35");
                htc.Align = "left";
                htc.BgColor = "#FFFFFF";
                htc.InnerText = "部门审批：";
                htr.Cells.Add(htc);
                htc.ColSpan = 4;


                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "border08");
                htc.Attributes.Add("height", "35");
                htc.Align = "left";
                htc.BgColor = "#FFFFFF";
                htc.InnerText = "稽核：";
                htr.Cells.Add(htc);
                htc.ColSpan = 5;


                htc = new HtmlTableCell();
                htc.Attributes.Add("class", "border08");
                htc.Attributes.Add("height", "35");
                htc.Align = "left";
                htc.BgColor = "#FFFFFF";
                htc.InnerText = "校长审批：";
                htr.Cells.Add(htc);
                htc.ColSpan = 2;
                tb1.Rows.Add(htr);



                //Label3.Text = String.Format("{0:N2}", Convert.ToDouble(Label3.Text) + Convert.ToDouble(Label5.Text));



            
        }


        protected double sum_je(DataTable dt)
        {
           
            //string syjf = "0";
            double syjf_d = 0;
            
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        syjf_d = syjf_d + Convert.ToDouble(dt.Rows[i]["JE"].ToString());
                    }
                    catch { }
                }
            

            return syjf_d;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
    }
}