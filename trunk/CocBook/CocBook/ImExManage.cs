﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CocBook
{
    public partial class ImExManage : Form
    {
        public ImExManage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddImport addImport = new AddImport();
            addImport.Show();
            this.Close();
        }

    }
}
