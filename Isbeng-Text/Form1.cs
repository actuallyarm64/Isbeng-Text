using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Isbeng_Text
{
    public partial class Form1 : Form
    {
        private string currentFilePath = "";
        public Form1()
        {
            InitializeComponent();
            InitializeSyntaxHighlighting();
            AttachEventHandlers();
        }

        private void InitializeSyntaxHighlighting()
        {
            FastColoredTextBoxNS.Language languageCSharp = FastColoredTextBoxNS.Language.CSharp;
            fctb.Language = languageCSharp;

            FastColoredTextBoxNS.Language languageJS = FastColoredTextBoxNS.Language.JS;
            fctb.Language = languageJS;

            FastColoredTextBoxNS.Language languageHTML = FastColoredTextBoxNS.Language.HTML;
            fctb.Language = languageHTML;

            FastColoredTextBoxNS.Language languageSQL = FastColoredTextBoxNS.Language.SQL;
            fctb.Language = languageSQL;

            FastColoredTextBoxNS.Language languagePHP = FastColoredTextBoxNS.Language.PHP;
            fctb.Language = languagePHP;

            FastColoredTextBoxNS.Language languageVB = FastColoredTextBoxNS.Language.VB;
            fctb.Language = languageVB;

            FastColoredTextBoxNS.Language languageXML = FastColoredTextBoxNS.Language.XML;
            fctb.Language = languageXML;

            FastColoredTextBoxNS.Language languageLua = FastColoredTextBoxNS.Language.Lua;
            fctb.Language = languageLua;
        }

        private void AttachEventHandlers()
        {
            fctb.CollapseBlock(fctb.Selection.Start.iLine,
               fctb.Selection.End.iLine);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Clear();
            currentFilePath = "";
            this.Text = "New - IsbengText";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Open a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                fctb.Text = File.ReadAllText(currentFilePath);
                this.Text = Path.GetFileName(currentFilePath) + " - IsbengText";
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                File.WriteAllText(currentFilePath, fctb.Text);
                this.Text = Path.GetFileName(currentFilePath) + " - IsbengText";
            }
            else
            {
                saveASToolStripMenuItem_Click(sender, e);
            }
        }
        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog.Title = "Save As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, fctb.Text);
                this.Text = Path.GetFileName(currentFilePath) + " - IsbengText";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Paste();
        }

    }
}
