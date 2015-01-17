﻿using LiveSplit.UI;
using LiveSplit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LiveSplit.Model.RunImporters
{
    public class SplitsIORunImporter : IRunImporter
    {
        public IRun Import(Form form = null)
        {
            var dialog = new BrowseSplitsIODialog(false);
            var result = dialog.ShowDialog(form);
            if (result == DialogResult.OK)
                return dialog.Run;
            return null;
        }

        public void ImportAsComparison(IRun run, Form form = null)
        {
            var dialog = new BrowseSplitsIODialog(true);
            var result = dialog.ShowDialog(form);
            var name = dialog.RunName;
            if (result == DialogResult.OK)
            {
                result = InputBox.Show(form, "Enter Comparison Name", "Name:", ref name);
            }
            if (result == DialogResult.OK)
            {
                run.AddComparisonWithNameInput(dialog.Run, name, form);
            }
        }
    }
}