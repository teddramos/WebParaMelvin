<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenAudiometria.aspx.cs" Inherits="WebParaMelvin.Reportes.ResumenAudiometria" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resumen de Audiometría</title>
</head>
<body>
    <p>Resumen de Audiometría</p>
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
