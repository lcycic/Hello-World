<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShuaDanPingTai.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <script src="../Scripts/myjs.js"></script>
    <script>
        //window.onload = test;
        //function test() {
        //    var a = document.getElementById("adminLogin");
        //    a.style.left = (document.body.offsetWidth - a.offsetWidth) / 2 + "px";
        //    a.style.top = (document.body.offsetHeight - a.offsetHeight) / 2 + "px";
        //    a.style.visibility = "visible";
        //}

        function myfunc() {
            //alert(xhr.responseText);
            var d = document.getElementById("sss");
            d.innerHTML = xhr.responseText;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 300px">
            <div id="adminLogin" class="thumbnail">
                <div class="progress active progress-striped">
                    <div class="progress-bar" style="width: 60%">这是进度条</div>
                </div><fieldset><legend contenteditable="true">表单项</legend>
                <p class="input-group-addon">管理员授权登录</p>
                <dl>
                    <dd>
                        <div class="list-group-item"><label>用户名:</label>&nbsp;<span><asp:TextBox ID="tbUserName" runat="server" required="" placeholder="用户名"></asp:TextBox></span></div>
                    </dd>
                    <dd>
                        <div class="list-group-item"><label>私密码:</label>&nbsp;<span><asp:TextBox ID="tbPassWord" runat="server" TextMode="Password" required="" placeholder="密码"></asp:TextBox></span></div>
                    </dd>
                    <dd>
                        <div class="list-group-item"><label>验证码:</label>&nbsp;<asp:TextBox ID="tbValidateCode" runat="server" Width="60px" required="" placeholder="验证码"></asp:TextBox>&nbsp;&nbsp;&nbsp;<img alt="验证码" src="../ValidateCode.ashx" onclick="this.src='../ValidateCode.ashx?'+new Date().getTime()" /></div>
                    </dd>
                </dl>
                <asp:Button ID="btnLogin" runat="server" Text="确定" CssClass="btn-primary" OnClick="btnLogin_Click" />
            </fieldset></div>
            <input id="Button1" type="button" value="异步获取" oncancel="" onclick="AjaxGetData('GET', '../about.aspx', myfunc)" /><div id="sss" class="alert-success">测试用的DIV</div>
        </div>
    </form>
</body>
</html>
