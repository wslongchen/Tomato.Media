﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace PinkAlert.Areas.MainMenu.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SingleGamePage : Page
    {
        public SingleGamePage()
        {
            this.InitializeComponent();
            Loaded += SingleGamePage_Loaded;
        }

        private void SingleGamePage_Loaded(object sender, RoutedEventArgs e)
        {
            me_logo.MediaOpened += Me_logo_MediaOpened;
        }

        private void Me_logo_MediaOpened(object sender, RoutedEventArgs e)
        {
            me_logo.Visibility = Visibility.Visible;
        }
    }
}
