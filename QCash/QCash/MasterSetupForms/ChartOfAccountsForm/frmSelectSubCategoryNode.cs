using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

//using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    public partial class frmSelectSubCategoryNode : Form
    {

        #region Private Variables

        private List<SubCategoryNode> SubCategoryNodes;
        private Int32 pAccountTypeId;
        private Int32 pParentNodeId;
        private TreeNode pSelectedNode;

        #endregion

        #region Public Properties

        public TreeNode SelectedNode
        {
            get { return pSelectedNode; }
        }
       
        #endregion

        #region Constructors

        public frmSelectSubCategoryNode(Int32 AccountTypeId,Int32 ParentNodeId)
        {
            InitializeComponent();

            TreeViewIconList.Images.Add(Properties.Resources.CC1Small);
            TreeViewIconList.Images.Add(Properties.Resources.CC2);
            TreeViewIconList.Images.Add(Properties.Resources.Page1);
            trvChartOfAccount.ImageList = TreeViewIconList;

            pAccountTypeId = AccountTypeId; pParentNodeId = ParentNodeId;

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

                    switch (pAccountTypeId)
                    {
                        case 1:
                            FillCategoryNodeForOptionA(SubCategoryNodes, null);
                            break;
                        case 2:
                            FillCategoryNodeForOptionB(SubCategoryNodes, null);
                            break;
                        case 3:
                            FillCategoryNodeForOptionC(SubCategoryNodes, null);
                            break;
                        default:
                            break;
                    }

                    if (pParentNodeId>3 )
                    {
                        TreeNode[] nodes = trvChartOfAccount.Nodes.Find(pParentNodeId.ToString(), true);
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
                this.Cursor = Cursors.Default;
            }
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

        private void FillCategoryNodeForOptionA(List<SubCategoryNode> items, TreeNode node)
        {
            var parentID = node != null ? Convert.ToInt32(node.Name) : 1;

            var nodesCollection = node != null ? node.Nodes : trvChartOfAccount.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.SubCategoryId.ToString(), item.SubCategoryName);
                newNode.Tag = item.NodeTag;
                newNode.ImageIndex = 0;

                FillCategoryNodeForOptionA(items, newNode);
            }
        }

        private void FillCategoryNodeForOptionB(List<SubCategoryNode> items, TreeNode node)
        {
            var parentID = node != null ? Convert.ToInt32(node.Name) : 2;

            var nodesCollection = node != null ? node.Nodes : trvChartOfAccount.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.SubCategoryId.ToString(), item.SubCategoryName);
                newNode.Tag = item.NodeTag;
                newNode.ImageIndex = 0;

                FillCategoryNodeForOptionB(items, newNode);
            }
        }

        private void FillCategoryNodeForOptionC(List<SubCategoryNode> items, TreeNode node)
        {
            var parentID = node != null ? Convert.ToInt32(node.Name) : 3;

            var nodesCollection = node != null ? node.Nodes : trvChartOfAccount.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.SubCategoryId.ToString(), item.SubCategoryName);
                newNode.Tag = item.NodeTag;
                newNode.ImageIndex = 0;

                FillCategoryNodeForOptionC(items, newNode);
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

        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (trvChartOfAccount.SelectedNode!=null)
            {
                pSelectedNode = trvChartOfAccount.SelectedNode;
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
