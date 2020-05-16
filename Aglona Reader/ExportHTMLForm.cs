﻿using System;
using System.Windows.Forms;

namespace AglonaReader
{
    public partial class ExportHtmlForm : Form
    {

        private readonly ParallelTextControl pTc;

        public ExportHtmlForm(ParallelTextControl pTc)
        {
            InitializeComponent();
            this.pTc = pTc;
        }

        private void selectExportFileButton_Click(object sender, EventArgs e)
        {
            // Ask for the file name
            using (var d = new SaveFileDialog())
            {
                d.Filter = "HTML files|*.html";

                d.RestoreDirectory = true;

                var dialogResult = d.ShowDialog();

                if (dialogResult == DialogResult.OK)
                    exportFileName.Text = d.FileName;

            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            if (exportFileName.Text.Length == 0)
            {
                MessageBox.Show("File name not specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();

            pTc.PText.ExportHtml(exportFileName.Text);

            //MessageBox.Show("Done.");

            System.Diagnostics.Process.Start(exportFileName.Text);

        }
    }
}
