<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TestDll.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/index.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width:600px;height:400px;">
        <div id="div_img" style="width:60px;height:50px;float:left;">
        </div>
        <div id="div_des" style="width:540px;height:25px;float:left;">
            
        </div>

        <br />
        <div id="div_array" style="width:540px;height:25px;"></div>
        <br />
        <div id="div_change" style="width:60px;height:25px;cursor:pointer;background-color:Silver;">JS获取</div>
<%--        <asp:Button ID="btnRandom" runat="server" Text="随机" onclick="btnRandom_Click" />
        <asp:Button ID="btnRead" runat="server" Text="读取" />--%>
    </div>
    </form>
</body>
</html>
