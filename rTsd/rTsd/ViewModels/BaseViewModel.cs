﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using rTsd.Models;
using rTsd.Services;

namespace rTsd.ViewModels
{
    /// <summary>
    /// Based on Visual Studio 2019 Xamarin Forms template BaseViewModel class.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Public member

        /// <summary>
        /// Feed service.
        /// 
        /// Injected by the `DependencyService`.
        /// See `App.cs` for the setup process.
        /// </summary>
        public IElementService<Post> FeedService => DependencyService.Get<IElementService<Post>>();

        bool isBusy = false;
        /// <summary>
        /// Determines if the view model does something.
        /// Used to show loading screens or block other commands.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        /// <summary>
        /// Title of the page.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        #endregion

        #region Protected member

        /// <summary>
        /// Helper method to set a vakue and update the related field.
        /// 
        /// Usage:
        ///     `set { SetProperty(ref title, value); }`
        /// </summary>
        /// <typeparam name="T">Name of the property (autofilled).</typeparam>
        /// <param name="backingStore">Backing store / field.</param>
        /// <param name="value">New value.</param>
        /// <param name="propertyName">Name of the property (Optional).</param>
        /// <param name="onChanged">onChanged event blog (Optional(.</param>
        /// <returns>`True` if something changed.</returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            // Check if value changed, if not, no further action required.
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                // Return false, because nothing changed.
                return false;
            }

            // Update value.
            backingStore = value;

            // Call optional event callback.
            onChanged?.Invoke();

            // Trigger ui update.
            OnPropertyChanged(propertyName);

            // Return true, because something changed.
            return true;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // Check if event handler is set.
            var changed = PropertyChanged;
            if (changed == null)
            {
                // If not, no further action is required.
                return;
            }

            // If set, invoke it.
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
