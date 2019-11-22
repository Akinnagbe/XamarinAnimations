using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinAnimations.Views.Page1
{
    public partial class View1 : ContentPage
    {
        public View1()
        {
            InitializeComponent();
           
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            flbName.HasError = !flbName.HasError;

           
        }
       // const uint animationSpead = 200;

        //private void Entry_Focused(object sender, EventArgs e)
        //{

        //    lblsample.TranslateTo(entSample.Bounds.X, -20,animationSpead);
        //}

        //private void Entry_Unfocused(object sender, EventArgs e)
        //{
        //    if(string.IsNullOrWhiteSpace(entSample.Text))
        //        lblsample.TranslateTo(entSample.Bounds.X, 5,animationSpead);
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    lblsample.TranslationX = entSample.Bounds.X;
        //    lblsample.TranslationY = entSample.Bounds.Y;
        //}
    }
}
