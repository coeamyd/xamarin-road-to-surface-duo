﻿using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace rTsd.ViewModels
{
    /// <summary>
    /// ViewModel of the AboutPage.
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {
        #region Public member

        /// <summary>
        /// Command to open the GitHub repostiory with the system's browser.
        /// </summary>
        public ICommand OpenGitHubWebCommand { get; }

        /// <summary>
        /// Command to open drwindows.de with the system's browser.
        /// </summary>
        public ICommand OpenDrWindowsWebCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// 
        /// Will setup required fields.
        /// </summary>
        public AboutViewModel()
        {
            // Setup commands.
            OpenGitHubWebCommand = new Command(() => OpenBrowserToUrl("https://www.github.com/tscholze/xamarin-road-to-surface-duo"));
            OpenDrWindowsWebCommand = new Command(() => OpenBrowserToUrl("https://www.drwindows.de/news/"));
        }

        #endregion
    }
}