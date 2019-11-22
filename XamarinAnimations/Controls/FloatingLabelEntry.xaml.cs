using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinAnimations.Controls
{
    public partial class FloatingLabelEntry : ContentView
    {
        const uint animationSpead = 200;

        public FloatingLabelEntry()
        {
            InitializeComponent();
            FloatingText = entSample.Placeholder;
            lblfloatingText.Text = FloatingText;
            lblError.Text = HintText;
        }

        #region BindableProperties

        #region FloatingText
        public static readonly BindableProperty FloatingTextProperty = BindableProperty.Create(nameof(FloatingText), typeof(string),
            typeof(FloatingLabelEntry), defaultValue: default(string), defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnFloatingTextChanged);

        private static void OnFloatingTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null || newValue == null)
                return;

            var sender = bindable as FloatingLabelEntry;
            sender.lblfloatingText.Text = (string)newValue;
        }

        public string FloatingText
        {
            get { return (string)GetValue(FloatingTextProperty); }

            set
            {
                SetValue(FloatingTextProperty, value);
            }

        }
        #endregion

        #region FloatingTextFont
        public static readonly BindableProperty FloatingTextFontAttributesProperty = BindableProperty.Create(nameof(FloatingTextFontAttributes), typeof(FontAttributes), typeof(FloatingLabelEntry),
            defaultValue: default(Font), defaultBindingMode: BindingMode.TwoWay,
            propertyChanged:OnFloatingTextFontChanged);

        private static void OnFloatingTextFontChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null || newValue == null)
                return;

            FloatingLabelEntry labelEntry = bindable as FloatingLabelEntry;

            labelEntry.lblfloatingText.FontAttributes = labelEntry.FloatingTextFontAttributes;
        }

        public FontAttributes FloatingTextFontAttributes
        {
            get { return (FontAttributes)GetValue(FloatingTextFontAttributesProperty); }
            set { SetValue(FloatingTextFontAttributesProperty, value); }
        }

        #endregion

        //public static readonly BindableProperty FloatingTextFontFamilyProperty = BindableProperty.Create(nameof(FloatingTextFontFamily), typeof(FontFamily), typeof(FloatingLabelEntry), defaultValue: default(Font), defaultBindingMode: BindingMode.TwoWay);

        //public FontFamily FloatingTextFontFamily
        //{
        //    get { return (FontFamily)GetValue(FloatingTextFontFamilyProperty); }
        //    set { SetValue(FloatingTextFontFamilyProperty, value); }
        //}

        //public static readonly BindableProperty FloatingTextFontSizeProperty = BindableProperty.Create(nameof(FloatingTextFontSize), typeof(FontSize), typeof(FloatingLabelEntry),
        //    defaultValue: default(FontSize), defaultBindingMode: BindingMode.TwoWay);

        //public FontSize FloatingTextFontSize
        //{
        //    get { return (FontSize)GetValue(FloatingTextFontSizeProperty); }
        //    set { SetValue(FloatingTextFontSizeProperty, value); }
        //}

        #region HasError
        public static readonly BindableProperty HasErrorProperty = BindableProperty.Create(nameof(HasError), typeof(bool), typeof(FloatingLabelEntry),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnHasErrorChanged);

        private static void OnHasErrorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null)
                return;

            FloatingLabelEntry labelEntry = bindable as FloatingLabelEntry;

            if ((bool)newValue)
            {
                labelEntry.lblError.Text = labelEntry.ErrorText;
                labelEntry.lblError.TextColor = labelEntry.ErrorColor;
                labelEntry.lblfloatingText.TextColor = labelEntry.ErrorColor;
                labelEntry.lblError.IsVisible = true;
            }
            else
            {
                labelEntry.lblError.Text = labelEntry.HintText;
                labelEntry.lblError.TextColor = Color.Black;
                labelEntry.lblfloatingText.TextColor = Color.Black;
                labelEntry.lblError.Text = labelEntry.HintText;
            }
        }

        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }
        #endregion

        #region HintText
        public static readonly BindableProperty HintTextProperty = BindableProperty.Create(nameof(HintText), typeof(string), typeof(FloatingLabelEntry),
            defaultValue: default(string), defaultBindingMode: BindingMode.TwoWay,
            propertyChanged:OnHintTextChanged);

        private static void OnHintTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null)
                return;

            FloatingLabelEntry labelEntry = bindable as FloatingLabelEntry;
            labelEntry.lblError.Text = newValue as string;
        }

        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }
        #endregion

        #region ErrorColor
        public static readonly BindableProperty ErrorColorProperty = BindableProperty.Create(nameof(ErrorColor), typeof(Color), typeof(FloatingLabelEntry), defaultValue: Color.Red, defaultBindingMode: BindingMode.TwoWay);

        public Color ErrorColor
        {
            get { return (Color)GetValue(ErrorColorProperty); }
            set { SetValue(ErrorColorProperty, value); }
        }
        #endregion

        #region ErrorText
        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(FloatingLabelEntry), defaultValue: default(string), defaultBindingMode: BindingMode.TwoWay);

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
        #endregion

        #endregion

        #region Events
        private void Entry_Focused(object sender, EventArgs e)
        {

            lblfloatingText.TranslateTo(entSample.Bounds.X, -20, animationSpead);
        }

        private void Entry_Unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entSample.Text))
                lblfloatingText.TranslateTo(entSample.Bounds.X, 5, animationSpead);
        }
        #endregion
    }
}
