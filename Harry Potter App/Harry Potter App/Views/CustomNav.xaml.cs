﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HarryPotter_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNav : NavigationPage
    {
        public CustomNav()
        {
            InitializeComponent();
        }

        public CustomNav(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}