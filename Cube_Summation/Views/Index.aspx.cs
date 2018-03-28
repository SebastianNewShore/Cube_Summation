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
    ProcessFile Process = new ProcessFile();
    DataTable _dtFile = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["_dtFile"] = null;
            btnResult.Enabled = false;
        }
    }

    protected void btnLoadFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (flUpload.HasFile)
            {
                if (Session["_dtFile"] == null)
                {
                    var ext = Path.GetExtension(flUpload.FileName);

                    if (ext.ToLower() == RestrictionConstants.ValidExtension)
                    {
                        var route = string.Concat((Server.MapPath("~/temp/" + flUpload.FileName)));

                        var blResponse = Validator.ConsultFileExistence(route);

                        if (!blResponse)
                        {
                            flUpload.PostedFile.SaveAs(route);
                        }
                        else
                        {
                            SendClientMessage(RestrictionConstants.FileExist);
                        }

                        try
                        {
                            _dtFile = Validator.ConsultRoute(route);
                            Session["_dtFile"] = _dtFile;
                            File.Delete(route);
                            btnResult.Enabled = true;
                            lblResponse.ForeColor = Color.Green;
                            lblResponse.Text = RestrictionConstants.FileUpload;
                        }
                        catch
                        {
                            SendClientMessage(RestrictionConstants.ErrorLoad);
                        }
                    }
                    else
                    {
                        lblResponse.ForeColor = Color.Red;
                        lblResponse.Text = RestrictionConstants.ValidFile;
                    }
                }
                else
                {
                    SendClientMessage(RestrictionConstants.NumberOfFiles);
                }
            }
            else
            {
                lblResponse.ForeColor = Color.Red;
                lblResponse.Text = RestrictionConstants.SelectFile;
            }
        }
        catch
        {
            SendClientMessage(RestrictionConstants.GenericError);
        }
    }

    protected void btnResult_Click(object sender, EventArgs e)
    {
        var dtResponse = new DataTable();
        var errorMessage = string.Empty;
        try
        {
            _dtFile = (DataTable)Session["_dtFile"];
            dtResponse = Process.DataDistribution(_dtFile, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                SendClientMessage(errorMessage);
                return;
            }
            grvResult.DataSource = dtResponse;
            grvResult.DataBind();
        }
        catch
        {
            SendClientMessage(RestrictionConstants.GenericError);
        }
    }

    private void SendClientMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + message + "');", true);
    }
}