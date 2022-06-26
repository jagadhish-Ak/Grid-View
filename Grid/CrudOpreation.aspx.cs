using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grid
{
    public partial class CrudOpreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                
         }
         protected  void lbInsert_Click (object sender,EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TxtName")).Text;
            SqlDataSource1.InsertParameters["Gender"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            SqlDataSource1.InsertParameters["City"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TxtCity")).Text;
            SqlDataSource1.Insert();
        }
    }
}