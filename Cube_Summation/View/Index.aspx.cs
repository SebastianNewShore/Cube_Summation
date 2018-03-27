using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Index : System.Web.UI.Page
{
    ValidatorBusiness Validator = new ValidatorBusiness();
    DataTable _dtFile = new DataTable();
    bool _LoadFile = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["dtFile"] = null;
        }
    }

    protected void btnLoadFile_Click(object sender, EventArgs e)
    {
        if (flUpload.HasFile)
        {
            if (!_LoadFile)
            {
                var ext = Path.GetExtension(flUpload.FileName);

                if (ext.ToLower() == ".txt")
                {
                    var route = string.Concat((Server.MapPath("~/temp/" + flUpload.FileName)));

                    var blResponse = Validator.ConsultFileExistence(route);

                    if (!blResponse)
                        flUpload.PostedFile.SaveAs(route);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "This file has already been loaded, so it will only be replaced" + "');", true);

                        try
                        {
                            _dtFile = Validator.ConsultRoute(route);
                            

                            lblResponse.ForeColor = Color.Green;
                            lblResponse.Text = "the file with the queries were loaded correctly";

                            _LoadFile = true;
                        }
                        catch
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Sorry," +
                                "There were problems with the loading of the file" + "');", true);
                        }
                }
                else
                {
                    lblResponse.ForeColor = Color.Red;
                    lblResponse.Text = "Please select a valid file";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Can not be attached more than 1 file" + "');", true);
            }
        }
        else
        {
            lblResponse.ForeColor = Color.Red;
            lblResponse.Text = "Please select a file";
        }
    }

    protected void btnResult_Click(object sender, EventArgs e)
    {
    }
}