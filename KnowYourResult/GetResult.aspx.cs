using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KnowYourResult.Classes;
using System.IO;
using iTextSharp.text;

using iTextSharp.text.pdf;
namespace KnowYourResult
{
    public partial class GetResult : System.Web.UI.Page
    {
        FileInfo file1 = new FileInfo(@"D:\result.csv");
        StreamWriter writ;
        
        Result r = new Result();
        int start = 0;
        int end = 0;
        String res;
        int totalpass=0;
        int totalf = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DirectoryInfo info = new DirectoryInfo(Server.MapPath("~/Files/"));
                FileInfo[] files = info.GetFiles("*.pdf");
                foreach (FileInfo file in files)
                {
                    ListBox1.Items.Add(file.Name);
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                start = int.Parse(Starting.Text);
                end = int.Parse(Last.Text);

                r.setSubjects(ListBox1.SelectedItem.Text);
                                
                writ = file1.CreateText();

                writ.Write("," + "," + "," + "," + "," + ",");

                writ.WriteLine("RESULT");

                writ.Write("SEAT NUMBER" + ",");

                writ.Write("NAME OF STUDENT" + ",");

                writ.Write(r.subject1 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject2 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject3 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject4 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject5 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.lab1 + "," + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.lab2);

                writ.WriteLine(",");

                writ.Write("," + ",");

                for (int i = 0; i <= 4; i++)
                {
                    writ.Write("THEORY,");
                    writ.Write("INTERNAL,");
                    writ.Write("TOTAL,");
                    writ.Write("CREDIT,");
                    writ.Write("GRADE,");
                    writ.Write("GP,");
                    writ.Write("C*GP,");
                }
                for (int i = 5; i <= 6; i++)
                {
                    writ.Write("25\'\'11,");
                    writ.Write("25\'\'11,");
                    writ.Write("50\'\'23,");
                    writ.Write("Total,");
                    writ.Write("CREDIT,");
                    writ.Write("GRADE,");
                    writ.Write("GP,");
                    writ.Write("C*GP,");
                }
                writ.Write("G,");
                writ.Write("GPA,");
                writ.Write("Grade,");
                writ.Write("Result,");
                writ.WriteLine(",");
                writ.WriteLine(",");

               if (ListBox1.SelectedIndex != -1 &&
                    ListBox1.SelectedItem.Text.Contains("MCA")
                    || ListBox1.SelectedItem.Text.Contains("M.C.A") && ListBox1.SelectedItem.Text.Contains("CHOICE")
                    || ListBox1.SelectedItem.Text.Contains("CBSGS"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('done!" + ListBox1.SelectedItem.Text + "')", true);


                    r.Extract_Text(Server.MapPath("~/Files/" + ListBox1.SelectedItem.Text));
                    for (int re = start; re <= end; re++)
                    {
                        if (r.FilterDetails(Convert.ToString(re)) == true)
                        {
                            generateFinalResult(r.GenerateMarksheet(), r, ref writ);
                        }
                    }
                    writ.WriteLine("");
                    writ.WriteLine(",Summary of result,");
                    int totalstudent = r.TotalStudent;
                    writ.WriteLine("," + ",");
                    writ.Write(",Total Students," + totalstudent);
                    writ.WriteLine(",");
                                       
                    writ.Write(",Passed," + totalpass + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",Failed," + totalf + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");             
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kindly Select/upload a pdf!')", true);
                }
            }
            catch (Exception es)
            {
                GetErrorMsg("Something went wrong");
            }
            //
            finally
            {
                writ.Close();
                //sumwrite.Close();
            }
        }
        public void GetErrorMsg(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+msg+"')", true);            
        }
        public void generateFinalResult(List<string> detail, Result r,ref StreamWriter writ)
        {
                //writ.WriteLine(",");
                writ.Write(r.SeatNumber + ",");
                writ.Write(r.Name + ",");
               
                int counts = 1;
                for (int i = r.Getpos(); i < detail.Count; i++)
                {
                    if (counts == 47 && detail[i] == "E")
                    { i++; }
                    if (counts == 49 && detail[i] == "F")
                    { i++; }
                    writ.Write(detail[i] + ",");
                    counts++;

                    if (counts == 29)//use regexpattern to match only one element either p or f to file marks or grade
                    {
                        i++;
                        res = detail[i];
                        if (res == "P" || res == "p")
                            totalpass++;
                        else if (res == "F" || res == "f")
                            totalf++;
                    }
                }
                writ.Write(res+",");
                writ.WriteLine(","+",");
        }    
    }  
}