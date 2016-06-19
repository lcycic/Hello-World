/*-------------XMLHttpRequest开始-----------*/
//XMLHttpRequest全局对象
var xhr;//MLHttpRequest全局对象
var obj;
var progressBar = null;//定义全局进度条

function CreateXHR() {
    /// <summary>创建XMLHttpRequest对象,并赋值给全局变量 xhr</summary>

    xhr = null;
    if (window.XMLHttpRequest) {// code for all new browsers
        xhr = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {// code for IE5 and IE6
        xhr = new ActiveXObject("Microsoft.XMLHTTP");
    }
}

function AjaxGetData(method, url, LoadHandler) {
    /// <summary>异步获取指定URL中数据</summary>
    /// <param name="method" type="String">GET或POST</param>
    /// <param name="url" type="String">网址</param>
    /// <param name="LoadHandler2" type="String">onloadend事件委托</param>
    if (xhr == null || xhr == undefined) {
        CreateXHR();
    }

    obj = event.target;
    obj.disabled = true;

    if (xhr != null) {
        xhr.onloadstart = LoadStartHandler;
        xhr.onprogress = ProgressHandler;
        xhr.onload = LoadHandler;
        xhr.onloadend = LoadEndHandler;
        xhr.open(method, url, true);
        xhr.setRequestHeader('If-Modified-Since', '0');
        xhr.send(null);
    }
    else {
        alert("初始化XMLHttpRequest失败.");
    }
}

function LoadStartHandler() {
    if (!progressBar) {
        progressBar = document.createElement("progress");
        progressBar.setAttribute("class", "progress");
        progressBar.setAttribute("style", "height:4px; width:100%; position:absolute; left:-1px; top:-1px; z-index:99999")
        progressBar.setAttribute("value", "0");
        progressBar.setAttribute("max", "100");
        document.body.appendChild(progressBar);
    }
}

function ProgressHandler(event) {
    if (event.lengthComputable) {
        progressBar.value = (event.loaded / event.total) * 100;
    }
}

function LoadEndHandler() {
    setTimeout(function myfunction() {
        if (progressBar != null) {
            progressBar.parentElement.removeChild(progressBar);
            progressBar = null;
            obj.disabled = false;
        }
    }, 1000)
}

/*--------------XMLHttpRequest结束-----------------*/

function GetEById(id) {
    /// <summary>获取指定ID的元素对象</summary>
    /// <returns type="Obejct" />
    return document.getElementById(id)
}

function CheckAll(value, obj, name) {
    /// <summary>checkbox全选</summary>
    /// <param name="value" type="String">value == "selectAll"</param>
    /// <param name="obj" type="String">调用对像</param>
    /// <param name="name" type="String">元素名</param>
    var names = document.getElementsByName(name)
    for (var i = 0; i < names.length; i++) {
        if (names[i].type == "checkbox" && names[i].name == name) {
            var e = names[i];
            if (value == "selectAll") {
                e.checked = obj.checked;
            }
            else {
                e.checked = !e.checked;
            }
        }
    }
}

//复选框判断是否有至少一个被选中
function CheckIsOn(name) {
    var checkflag = "false";
    var name = document.getElementsByName(name)
    if (name.length > 0) {
        for (i = 0; i < name.length; i++) {
            if (name[i].checked == true) {
                checkflag = true;
            }
        }
    }
    if (checkflag == "false") {
        alert("没有被选中的项目。");
        return false;
    }
    else return window.confirm("确定此操作吗？");
}

//判断字符串所占的字节数
function GetCharLength(str) {
    var iLength = 0;  //记录字符的字节数
    for (var i = 0; i < str.length; i++)  //遍历字符串中的每个字符
    {
        if (str.charCodeAt(i) > 255)   //如果当前字符的编码大于255
        {
            iLength += 2;    //所占字节数加2
        }
        else {
            iLength += 1;   //否则所占字节数加1
        }
    }
    return iLength;   //返回字符所占字节数
}
//若字符串长度超过要求，截掉多余部分
function CutStr(obj, len)   //elementID表示要进行处理的对象ID,len表示设置的限制字节数
{
    var str = obj.value;  //获取要处理的字符串
    var curStr = "";  //用于实时存储字符串
    for (var i = 0; i < str.length; i++)   //遍历整个字符串
    {
        curStr += str.charAt(i);  //记录当前遍历过的所有字符
        if (GetCharLength(curStr) > len)  //如果当前字符串超过限制长度
        {
            obj.value = str.substring(0, i);  //截取多余的字符,并把剩余字符串赋给要进行处理的对象
            return;  //结束函数
        }
    }
}