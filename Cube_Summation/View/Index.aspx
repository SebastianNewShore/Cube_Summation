<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="View_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Content/Master.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="form-group">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                <div class="row space">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <strong>Please!</strong> Select the files with the queries.
                    </div>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </ContentTemplate>
          </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <asp:FileUpload ID="flUpload" runat="server" CssClass="space"/>
                    <asp:Button ID="btnLoadFile" runat="server" CssClass="btn btn-primary space" Text="Load file" OnClick="btnLoadFile_Click" />
                    <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>
                    <hr />
                </div>
                <div class="col-md-3"></div>
             </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
           <ContentTemplate>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-5"></div>
                        <div class="col-md-2">
                            <center>
                               <asp:Button ID="btnResult" runat="server" CssClass="btn btn-primary space" Text="Results" OnClick="btnResult_Click"/>
                            </center>
                        </div>
                        <div class="col-md-5"></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
           <ContentTemplate>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <asp:GridView ID="grvResult" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                        </div>
                        <div class="col-md-3"></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
      <script src="../Scripts/jquery-1.10.2.min.js"></script> 
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
