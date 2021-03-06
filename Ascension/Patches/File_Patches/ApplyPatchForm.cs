﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ascension.Patches.File_Patches
{
    public partial class ApplyPatchForm : Form
    {
        public ApplyPatchForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Halo Map Files(.map)|*.map"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Halo Map Files(.map)|*.map"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Ascension Patch File(.ascpatch)|*.ascpatch"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((textBox1.Text == "") | (textBox2.Text == "")) | (textBox3.Text == ""))
            {
                MessageBox.Show("One of the fields were not entered correctly. Please enter them before continuing.");
            }
            else
            {
                if (File.Exists(textBox2.Text))
                {
                    File.Delete(textBox2.Text);
                }
                File.Copy(textBox1.Text, textBox2.Text);
                AscendedPatch.ApplyPatchData(textBox2.Text, textBox3.Text);
                MessageBox.Show("Patch successfully applied!");
            }
        }
    }
}
