using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;
namespace CGTry2.Form.CodeGenerator
{
    public partial class Android : System.Web.UI.Page
    {
        [WebMethod]
        public static string Hi()
        {
            return "{response:'Hi'}";
        }
    }
}
