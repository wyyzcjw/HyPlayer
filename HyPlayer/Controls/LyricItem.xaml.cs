﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HyPlayer.Classes;
using Microsoft.UI.Xaml.Media;
using AcrylicBackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource;
using AcrylicBrush = Microsoft.UI.Xaml.Media.AcrylicBrush;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace HyPlayer.Controls
{
    
    public sealed partial class LyricItem : UserControl
    {
        public readonly SongLyric Lrc;
        public double showsize => Common.PageExpandedPlayer.showsize;
        public double hidsize => Common.PageExpandedPlayer.hidsize;

        public double actualsize => showing ? showsize : hidsize;

        public bool showing = false;
        public LyricItem(SongLyric lrc)
        {

            this.InitializeComponent();
            Lrc = lrc;
            TextBoxPureLyric.Text = Lrc.PureLyric;
            if (Lrc.HaveTranslation)
            {
                TextBoxTranslation.Text = Lrc.Translation;
            }
            else
            {
                TextBoxTranslation.Visibility = Visibility.Collapsed;
            }
        }

        public async void Invoke(Action action, Windows.UI.Core.CoreDispatcherPriority Priority = Windows.UI.Core.CoreDispatcherPriority.Normal)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Priority, () => { action(); });
        }

        public void OnShow()
        {
            showing = true;
            TextBoxPureLyric.FontWeight = FontWeights.ExtraBold;
            TextBoxTranslation.FontWeight = FontWeights.ExtraBold;
            TextBoxPureLyric.FontSize = showsize;
            TextBoxTranslation.FontSize = showsize;
        }

        public void OnHind()
        {
            showing = false;
            TextBoxPureLyric.FontWeight = FontWeights.Normal;
            TextBoxTranslation.FontWeight = FontWeights.Normal;
            TextBoxPureLyric.FontSize = hidsize;
            TextBoxTranslation.FontSize = hidsize;
        }
    }
}
