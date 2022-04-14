using System.Windows.Forms;
using System.Drawing;

namespace sCommonLib
{
    public class LanguageSettings
    {

        #region ReadMe
        /*
        // This code block is required if i want to take textboxes from a container like groupbox or panel

        Dim allTxt As New List(Of Control)
                For Each txt As TextBox In FindControlRecursive(allTxt, Me, GetType(TextBox))
                    txt.Font = New Font("Arial", 18, FontStyle.Bold)
                Next

        Public Sub SetToAllTextBoxes()
            Dim AllControls As New List(Of Control)
            For Each txt As TextBox In FindControlRecursive(AllControls, MyForm, GetType(TextBox))
                txt.Font = New Font("Arial", 18, FontStyle.Bold)
            Next
        End Sub

        Public Shared Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
            If parent Is Nothing Then Return list
            If parent.GetType Is ctrlType Then
                list.Add(parent)
            End If
            For Each child As Control In parent.Controls
                FindControlRecursive(list, child, ctrlType)
            Next
            Return list
        End Function
        \\ end code block



        // This is old code for future reference. Dont delete it. If the above code generates error then consult this code block.
        Public Sub SelectComboInputMethod(ByVal CurrentForm As Form, ByVal InputMethod As String, ByVal mFontSize As Single, ByVal mFontName As String)

            Dim MyFont As Font

            Select Case InputMethod
                Case "Unicode"
                    For Each MyControl As Control In CurrentForm.Controls
                        If TypeOf MyControl Is ComboBox Then
                            MyFont = MyControl.Font
                            MyControl.Font = New Font(MyFont.Name, mFontSize, FontStyle.Regular)
                        End If
                    Next
                Case "NonUnicode"
                    For Each MyControl As Control In CurrentForm.Controls
                        If TypeOf MyControl Is ComboBox Then
                            MyControl.Font = New Font(mFontName, mFontSize, FontStyle.Regular)
                        End If
                    Next
            End Select
        End Sub

        */
        #endregion

        #region Private Variables

        private Form mForm;
        private string mInputMethod;
        private float mFontSize;
        private string mFontName;

        #endregion

        #region Constructors

        public LanguageSettings()
        {
        }

        public LanguageSettings(Form FormName, string InputMethod, float FontSize, string FontName)
        {
            mForm = FormName;
            mInputMethod = InputMethod;
            mFontSize = FontSize;
            mFontName = FontName;
        }

        #endregion

        #region Publice Methods

        public void SetToIndividualTextBox(TextBox TextBoxName)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    MyFont = TextBoxName.Font;
                    TextBoxName.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    break;
                case "NonUnicode":
                    TextBoxName.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    break;
            }
        }

        public void SetToTextBoxes(TextBox[] TextBoxes)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    for (int i = 0; i < TextBoxes.Length; i++)
                    {
                        MyFont = TextBoxes[i].Font;
                        TextBoxes[i].Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    }

                    break;
                case "NonUnicode":
                    for (int i = 0; i < TextBoxes.Length; i++)
                    {
                        TextBoxes[i].Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    }

                    break;
            }
        }

        public void SetToAllTextBoxes()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is TextBox)
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is TextBox)
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        public void SetToIndividualLabel(Label LabelName)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    MyFont = LabelName.Font;
                    LabelName.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    break;
                case "NonUnicode":
                    LabelName.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    break;
            }
        }

        public void SetToLabels(Label[] Labels)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    for (int i = 0; i < Labels.Length; i++)
                    {
                        MyFont = Labels[i].Font;
                        Labels[i].Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    }
                    break;
                case "NonUnicode":
                    for (int i = 0; i < Labels.Length; i++)
                    {
                        Labels[i].Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    }

                    break;
            }
        }

        public void SetToAllLabels()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is Label)
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is Label)
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        public void SetToIndividualComboBox(ComboBox ComboBoxName)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    MyFont = ComboBoxName.Font;
                    ComboBoxName.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    break;
                case "NonUnicode":
                    ComboBoxName.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    break;
            }
        }

        public void SetToComboBoxes(ComboBox[] ComboBoxes)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    for (int i = 0; i < ComboBoxes.Length; i++)
                    {
                        MyFont = ComboBoxes[i].Font;
                        ComboBoxes[i].Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    }

                    break;
                case "NonUnicode":
                    for (int i = 0; i < ComboBoxes.Length; i++)
                    {
                        ComboBoxes[i].Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    }

                    break;
            }
        }

        public void SetToAllComboBoxes()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is ComboBox)
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is ComboBox)
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        public void SetToIndividualDataGridView(DataGridView DataGridViewName)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    MyFont = DataGridViewName.Font;
                    ((DataGridView)DataGridViewName).DefaultCellStyle.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    break;
                case "NonUnicode":
                    ((DataGridView)DataGridViewName).DefaultCellStyle.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    break;
            }
        }

        public void SetToAllDataGridView()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is DataGridView)
                        {
                            MyFont = MyControl.Font;
                            ((DataGridView)MyControl).DefaultCellStyle.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                            //MyControl.DefaultCellStyle.Font = New Font(MyFont.Name, mFontSize, FontStyle.Regular)
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is DataGridView)
                        {
                            ((DataGridView)MyControl).DefaultCellStyle.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                            //CurrentDataGridView.DefaultCellStyle.Font = New Font(mFontName, mFontSize, FontStyle.Regular)
                        }
                    }

                    break;
            }
        }

        public void SetToAllTreeView()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is TreeView)
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is TreeView)
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        public void SetToAllButtons()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is Button)
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is Button)
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        public void SetToIndividualButton(Button ButtonName)
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    MyFont = ButtonName.Font;
                    ButtonName.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                    break;
                case "NonUnicode":
                    ButtonName.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                    break;
            }
        }

        public void SetToAllControls()
        {
            Font MyFont;
            switch (mInputMethod)
            {
                case "Unicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is DataGridView)
                        {
                            MyFont = MyControl.Font;
                            ((DataGridView)MyControl).DefaultCellStyle.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                        else
                        {
                            MyFont = MyControl.Font;
                            MyControl.Font = new Font(MyFont.Name, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
                case "NonUnicode":
                    foreach (Control MyControl in mForm.Controls)
                    {
                        if (MyControl is DataGridView)
                        {
                            ((DataGridView)MyControl).DefaultCellStyle.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                        else
                        {
                            MyControl.Font = new Font(mFontName, mFontSize, FontStyle.Regular);
                        }
                    }

                    break;
            }
        }

        #endregion

    }
}
