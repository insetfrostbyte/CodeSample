using CodeSample.Core.NodeList;
using System;

namespace CodeSample.Web
{
    public partial class NodeList : System.Web.UI.Page
    {
        Node originalList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            int listSize;
            int size = (int.TryParse(this.listSizeTextBox.Text, out listSize)) ? listSize : 10;
            this.originalList = Node.CreateList(size, allowSelfLinks:this.allowSelfLinks.Checked);

            this.originalLabel.Text = Node.CreateListString(originalList);

            Application.Lock();
            Application["ListHead"] = this.originalList;
            Application.UnLock();
        }

        protected void CopyButton_Click(object sender, EventArgs e)
        {
            var copiedNode = Node.DuplicateList((Node)Application["ListHead"]);
            this.copyLabel.Text = Node.CreateListString(copiedNode);
        }
    }
}