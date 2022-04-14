using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    public partial class frmChartOfAccount : Form
    {

        #region Private Variables

            private List<SubCategoryNode> SubCategoryNodes;
            private List<AccountNode> AccountNodes;
            private Int32? pNodeIdToSelect = null;

        #endregion

        #region Public Properties

            public Int32 NodeIdToSelect
        {
            set { pNodeIdToSelect = value; }
        }

        #endregion

        #region Constructors

            public frmChartOfAccount()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ChartOfAccountsIco32;
            TreeViewIconList.Images.Add(Properties.Resources.CC1Small);
            TreeViewIconList.Images.Add(Properties.Resources.CC2);
            TreeViewIconList.Images.Add(Properties.Resources.AccountHeadPng16);
            trvChartOfAccount.ImageList = TreeViewIconList;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); 
        }

        #endregion

        #region Add Event Handlers

            private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            trvChartOfAccount.AfterSelect += TreeNodeAfterSelect;
            trvChartOfAccount.DoubleClick += TreeNodeDoubleClick;
            trvChartOfAccount.AfterCollapse += TreeViewAfterCollapsed;
            trvChartOfAccount.AfterExpand += TreeViewAfterExpanded;
            btnNewSubCategory.Click += CreateNewSubCategory;
            btnEditSubCategory.Click += EditSubCategory;
            btnNewAccount.Click += CreateNewAccount;
            btnEditAccount.Click += EditAccount;
            btnPrint.Click += PrintData;
            btnClose.Click += CloseForm;


            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

             this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
             this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);

        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            StartPrimaryWorker();
        }

        #endregion

        #region Button Click Event Handlers

            private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

            private void CreateNewSubCategory(object sender, EventArgs e)
        {
            TreeNode parrentNode = trvChartOfAccount.SelectedNode;

            frmAddEditSubCatNode frm = new frmAddEditSubCatNode(this, parrentNode, null);
            frm.ShowDialog();

            btnNewSubCategory.Visible = false; btnEditSubCategory.Visible = false;
            btnNewAccount.Visible = false; btnEditAccount.Visible = false;
        }

            private void EditSubCategory(object sender, EventArgs e)
        {
            TreeNode currentNode = trvChartOfAccount.SelectedNode;
            TreeNode parentNode = currentNode.Parent;

            frmAddEditSubCatNode frm = new frmAddEditSubCatNode(this, parentNode, currentNode);
            frm.ShowDialog();

            btnNewSubCategory.Visible = false; btnEditSubCategory.Visible = false;
            btnNewAccount.Visible = false; btnEditAccount.Visible = false;


        }

            private void CreateNewAccount(object sender, EventArgs e)
        {
            TreeNode parentNode = trvChartOfAccount.SelectedNode;
            TreeNode rootNode = FindRootNode(parentNode);
            frmAccountHeadDetails frm = new frmAccountHeadDetails(null, parentNode, rootNode,true);

            frm.Show(this.Owner);
            this.Close();
        }

            private void EditAccount(object sender, EventArgs e)
        {
            TreeNode accountNode = trvChartOfAccount.SelectedNode;
            TreeNode rootNode = FindRootNode(accountNode);
            TreeNode parentNode = accountNode.Parent;
            frmAccountHeadDetails frm = new frmAccountHeadDetails(accountNode, parentNode, rootNode,true);
            frm.Show(this.Owner);
            this.Close();
        }

        #endregion

        #region RedToolTip Draw Event Handlers
        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            //Option A (should be the first choice)
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();

            /* Option B
            Font f = new Font("Arial", 10.0f);
            toolTip1.BackColor = System.Drawing.Color.Blue;
           
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, new PointF(2, 2));
            */
        }
        #endregion

        #region BackGroundWorker Event Handlers
         
        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SubCategoryNodes = SubCategoryNode.GetEntityList(GlobalVariables.ConnectionString);
                AccountNodes = AccountNode.GetEntityList(GlobalVariables.ConnectionString);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
         
        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
           // MyProgressBar.Position = e.ProgressPercentage;
        }
         
        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                }
                else if (e.Error != null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                }
                else
                {
                    FillCategoryNode(SubCategoryNodes, null);

                    if (pNodeIdToSelect != null)
                    {
                        TreeNode[] nodes = trvChartOfAccount.Nodes.Find(pNodeIdToSelect.ToString(), true);
                        TreeNode node = nodes[0];
                        trvChartOfAccount.Select();
                        trvChartOfAccount.SelectedNode = node;
                    }
        
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default; MyProgressBar.Visible = false;
            }
        } 
         
        #endregion

        #region TreeGridView Event Handlers

            private void TreeNodeAfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode currentNode = trvChartOfAccount.SelectedNode;

            String currentNodeText = currentNode.Text; String currentNodeName = currentNode.Name; String currentNodeTag = currentNode.Tag.ToString();

            switch (currentNodeTag)
            {
                case "SystemDefinedAccountType":
                    btnNewSubCategory.Visible = true;btnEditSubCategory.Visible=false;
                    btnNewAccount.Visible = true; btnEditAccount.Visible=false;
                    break;

                case "SystemDefinedSubCategoryType":
                    btnNewSubCategory.Visible = true;btnEditSubCategory.Visible=false;
                    btnNewAccount.Visible = true; btnEditAccount.Visible=false;
                    break;

                case "UserDefinedSubCategoryType":
                    btnNewSubCategory.Visible = true;btnEditSubCategory.Visible=true;
                    btnNewAccount.Visible = true; btnEditAccount.Visible=false;
                    break;
              
                case "SystemDefinedAccountHead":
                    btnNewSubCategory.Visible = false; btnEditSubCategory.Visible = false; 
                    btnNewAccount.Visible = false; btnEditAccount.Visible = false; 
                    break;

                case "UserDefinedAccountHead":
                    btnNewSubCategory.Visible = false; btnEditSubCategory.Visible = false; 
                    btnNewAccount.Visible = false; btnEditAccount.Visible = true;
                    break;

                default:
                    break;
            }

        }

            private void TreeNodeDoubleClick(object sender, EventArgs e)
        {
            TreeNode currentNode =trvChartOfAccount.SelectedNode;

            String currentNodeText = currentNode.Text; String currentNodeName = currentNode.Name; String currentNodeTag = currentNode.Tag.ToString();

            TreeNode rootNode = FindRootNode(currentNode);         

            TreeNode parentNode = currentNode.Parent;
           
        }

            private void TreeViewAfterCollapsed(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

            private void TreeViewAfterExpanded(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        #endregion

        #endregion

        #region Helper Methods

        #region Custom Exception Hander

        /*TODO: Uncomment and editing needed at Custom Exception handler
        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control = null;
            switch (strControlName)
            {
                case "TruckNo":
                    control = txtTruckNo;
                    break;
                default:
                    break;
            }
           // CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            RedToolTip.Show(EWC.ErrorDescription, control, 3000);
            //MyErrorProvider.SetError(control, EWC.ErrorDescription); 
            control.Focus();
        }
        */
        #endregion

        #region BackgroundWorker Helper Methods
        
        private int ProgressValue;
        private void StartPrimaryWorker() 
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync();
        }

        private void ReportPrimaryProgress()
        {
            ProgressValue += 1;
            bgwPrimaryWorker.ReportProgress(ProgressValue);
            System.Threading.Thread.Sleep(100);
        }

        private void ReportPostProgress()
        {
            Application.DoEvents();
            //ProgressValue += 1;
            MyProgressBar.Value += 1;
            System.Threading.Thread.Sleep(100);
        }
          

        #endregion

        #region Printing
        private void PrintData(object sender, EventArgs e)
        {
            try
             {
                 btnPrint.Enabled = false;
                 CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                 frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

                 BindingSource bsInvoice = new BindingSource();
                 bsInvoice.DataSource = ChartOfAccounts.GetEntityList(GlobalVariables.ConnectionString);
                 ReportDataSource rds = new ReportDataSource("ChartOfAccountsData", bsInvoice);
                 frm.MsReportViewer.LocalReport.DataSources.Add(rds);

                 //BindingSource bsCompanyInfomation = new BindingSource();
                 //bsCompanyInfomation.DataSource = GlobalVariables.currentUser.CompanyInformation;
                 //ReportDataSource rdsCompanyInfo = new ReportDataSource("CompanyInfoDataset", bsCompanyInfomation);
                 //frm.MsReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);

                 frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.ChartOfAccounts.rdlc";
               //  frm.rvReportViewer.LocalReport.SetParameters(reportParameters);
               
                 frm.Text = "Print Chart of Accounts";
                 frm.Icon = Properties.Resources.ChartOfAccountsIco32;
                 frm.Show(this.Owner);
                 btnPrint.Enabled = true;
             }
             catch (Exception Ex)
             {
                 CustomMessageBox.ShowSystemException(Ex);
                 btnPrint.Enabled = true;
             }
             
        }
        #endregion

        #region TreeView Helper Methods
 
            private void FillCategoryNode(List<SubCategoryNode> items, TreeNode node)
        {
            var parentID = node != null ? Convert.ToInt32(node.Name) : 0;

            var nodesCollection = node != null ? node.Nodes : trvChartOfAccount.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.SubCategoryId.ToString(), item.SubCategoryName);
                newNode.Tag = item.NodeTag;
                newNode.ImageIndex = 0;
                FillAccountNode(AccountNodes, newNode);
                FillCategoryNode(items, newNode);
            }
        }

            private void FillAccountNode(List<AccountNode> items, TreeNode node)
        {
            var parentID = (node != null) ? Convert.ToInt32( node.Name) : 0;

            var nodesCollection = node != null ? node.Nodes : trvChartOfAccount.Nodes;

            foreach (var item in items.Where(i => i.SubCategoryId == parentID))
            {
                var newNode = nodesCollection.Add(item.AccountId.ToString(), item.AccountNameWithCode);
                newNode.Tag = item.NodeTag;
                newNode.ImageIndex = 2;
            }
        }

            private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

            private void GetAllChild(TreeNode node)
            {
                foreach (TreeNode childnode in node.Nodes)
                {
                    MessageBox.Show(childnode.Text);
                    GetAllChild(childnode);
                }
            }

        #endregion



        #endregion

    }
}
