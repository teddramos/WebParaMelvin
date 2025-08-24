<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="WebParaMelvin.Reportes.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report viewer</title>
</head>
<body>
    <p>Report viewer</p>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                Height="800px" 
                ProcessingMode="Remote"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
