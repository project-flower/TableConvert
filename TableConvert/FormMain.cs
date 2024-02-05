﻿using System;
using System.Windows.Forms;

namespace TableConvert
{
    public partial class FormMain : Form
    {
        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void DoConvert(Formats format, IWin32Window control)
        {
            try
            {
                Clipboard.SetText(Convertor.Convert(Analyzer.GetTable(textBox.Text.TrimEnd('\r', '\n')), format));
                labelMessage.Visible = true;
                timerMessage.Start();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        // Designer's Methods

        private void buttonCsv_Click(object sender, EventArgs e)
        {
            DoConvert(Formats.Csv, buttonCsv);
        }

        private void buttonMarkdown_Click(object sender, EventArgs e)
        {
            DoConvert(Formats.Markdown, buttonMarkdown);
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            try
            {
                textBox.Text = Clipboard.GetText();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void buttonTsv_Click(object sender, EventArgs e)
        {
            DoConvert(Formats.Tsv, buttonTsv);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerMessage.Stop();
            labelMessage.Visible = false;
        }
    }
}
