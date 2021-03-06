﻿<!DOCTYPE html>

<html>
<head>
    @RenderSection("JQUERY", True)
    <link href="../../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../../lib/ligerUI/skins/ligerui-icons.css" rel="stylesheet" type="text/css" />
    @*<link href="../../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />*@
    @*<script src="../../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>*@
    @*<script type="text/javascript" src="../../lib/jquery/jquery-1.4.4.min.js"></script>*@
    <script src="../../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>
    <script src="../../lib/json2.js" type="text/javascript"></script>
    <script src="../../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/LigerUI/AjaxHelper.js"></script>

    <script type="text/javascript">
        $.ligerui.controls.Dialog.prototype._borderX = 2;
        $.ligerui.controls.Dialog.prototype._borderY = 0;
    </script>

    @*<%-- 整个界面满的--%>*@
    <style type="text/css">
        body, iframe, html {
            width: 100%;
            height: 100%;
            /*overflow-x :hidden;
            overflow-y:hidden ;*/
        }
    </style>
    @*<%-- overflow: hidden;overflow-x:hidden;overflow-y:hidnen;--%>*@

    <script type="text/javascript">
        var acrd;

        //初始化版面
        var InitialLayout = function (acrdwidth, title) {
            //初始化标题
            $("#rightInf").attr("title", title);
            //布局
            $("#layoutShow").ligerLayout({ rightWidth: acrdwidth, height: '100%', space: 1, onHeightChanged: f_heightChanged });
            //初始化Accordion高度
            var height = $(".l-layout-center").height();
            acrd = $("#accordioninf").ligerAccordion({ height: height - 24 });
            acrd.setHeight($(".l-layout-center").height() - 24);
            //var acrd = $("#accordioninf").ligerAccordion({ height: height});
            //动态更新Accordion的高度
            function f_heightChanged(options) {
                if (acrd && options.middleHeight - 24 > 0)
                    acrd.setHeight(options.middleHeight - 24);
            };

        };

    </script>
    @*<%-- 核心脚本--%>*@
    @*<asp:ContentPlaceHolder ID="MainContent" runat="server" />*@
    
   @RenderSection("JSCODE", True)

    <title>@*@ViewData("Title")*@</title>
</head>

<body>
    <div id="layoutShow" style="width:99.2%; margin:0 auto; margin-top:1px; ">
        @*style="width:99.2%; margin:0 auto; margin-top:4px;"*@
        <div id="RDContent" position="center" style="overflow-x: auto; overflow-y: auto">
            @*<p id="ptitle" style="position:absolute;left:30%;top:45%;font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 60px">XX</p>*@
            @RenderSection("CONTENT", True)
        </div>

        <div id="rightInf" position="right" title="信息查看">
            <div id="accordioninf" class="liger-accordion">
                @*分支*@
                @RenderBody()
            </div>
        </div>
    </div>
</body>
</html>
