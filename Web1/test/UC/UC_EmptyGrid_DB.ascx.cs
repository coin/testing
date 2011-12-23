using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web1.test.UC
{
    public partial class WebUserControl3 : System.Web.UI.UserControl
    {
        ObjectDataSource _alunosDataSource = new ObjectDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            
     

        }

        protected void ASPxGridLookup1_TextChanged(object sender, EventArgs e)
        {

            /*
            _alunosDataSource.TypeName = "Web1.Classes.AlunosDB.cs";
            _alunosDataSource.SelectMethod = "GetAlunosFromTurma";
            _alunosDataSource.SelectParameters = 
            _alunosDataSource.FilterExpression = _GridLookupTurma.

            _alu = _alunosDataSource.FilterExpression;
             */
        }
    }
}