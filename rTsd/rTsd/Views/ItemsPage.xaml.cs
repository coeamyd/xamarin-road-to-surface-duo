﻿using System.ComponentModel;
using Xamarin.Forms;
using rTsd.ViewModels;

namespace rTsd.Views
{
    /// <summary>
    /// ItemsPage is responsible for rendering a list of 
    /// items.
    /// 
    /// A tap on an item will lead to a detail page navigation.
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        #region Private member

        /// <summary>
        /// Underlying view model
        /// </summary>
        readonly ItemsViewModel viewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// Will set and load required information.
        /// </summary>
        public ItemsPage()
        {
            // Initialize ui.
            InitializeComponent();

            // Set binding context to the created view model.
            BindingContext = viewModel = new ItemsViewModel();

            // Inital items loading.
            viewModel.LoadItemsCommand.Execute(null);
            viewModel.LoadTweetsCommand.Execute(null);
        }

        #endregion
    }
}