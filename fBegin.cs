﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace GSM
{
    public partial class fBegin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fBegin()
        {
            InitializeComponent();
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Flogin f =new Flogin();
            f.ShowDialog();
        }
    }
}