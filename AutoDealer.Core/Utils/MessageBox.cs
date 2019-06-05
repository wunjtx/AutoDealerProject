using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDealer.Core.Utils
{
    public static class MessageBox
    {
        /// <summary>
        /// 警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <returns>警告框JS</returns>
        public static void MsgBox(string _Msg)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        /// <summary>
        /// 一个含有“确定”、“取消”的警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <param name="URL">“确定”以后要转到预设网址</param>
        /// <returns>警告框JS</returns>
        public static void MsgBox1(string _Msg, string URL)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += "var retValue=window.confirm('" + _Msg + "');" + "if(retValue){window.location='" + URL + "';}";
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);

        }
        /// <summary>
        /// 一个含有“确定”，点击以后就转到预设网址的警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <param name="URL">“确定”以后要转到预设网址</param>
        /// <returns>警告框JS</returns>
        public static void MsgBox2(string _Msg, string URL)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("window.location='" + URL + "';");
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }

        /// <summary>
        /// 一个含有“确定”，点击关闭本页的警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <returns>警告框JS</returns>
        public static void MsgBox3(string _Msg)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("window.close();");
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        /// <summary>
        /// 一个含有“确定”，点击返回先前的网页警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <param name="BackLong">要倒退几步</param>
        /// <returns>警告框JS</returns>
        public static void alert_history(string _Msg, int BackLong)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("history.go('" + BackLong + "')");
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }

        /// <summary>
        /// 一个含有“确定”，点击后关闭自己，刷新父窗口警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <returns>警告框JS</returns>
        public static void alert_reloadwin(string _Msg)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("window.opener.location.href=window.opener.location.href;window.close();");
            StrScript += ("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }

        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="content">message信息</param>
        public static void alert(System.Web.UI.Page page, string content)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), " ", "<script language='javascript'>alert('" + content + "');</script>");
        }

        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="content">message信息</param>
        public static void alert(System.Web.UI.Page page, string content, String _daiMa)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), " ", "<script language='javascript'>alert('" + content + "');" + _daiMa.Replace("\"", "'") + "</script>");
        }


        public static void alert(System.Web.UI.Page page, object _code)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "onLoad", "<script language='javascript'>" + _code + "</script>");
        }
    }
}
