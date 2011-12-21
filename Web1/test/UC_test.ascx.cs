using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web1.Classes;

namespace Web1.test
{

    public partial class WebUserControl1 : System.Web.UI.UserControl
    
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBUtil DB = new DBUtil();
            _gridview.DataSource = DB.GetAlunos();
            _gridview.DataBind();
        }
    }
}