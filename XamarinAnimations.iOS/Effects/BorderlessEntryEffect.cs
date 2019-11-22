using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XamarinAnimations.iOS.Effects;
using CoreAnimation;
using CoreGraphics;

[assembly: ResolutionGroupName("XamarinAnimation")]
[assembly: ExportEffect(typeof(BorderlessEntryEffect),nameof(BorderlessEntryEffect))]
namespace XamarinAnimations.iOS.Effects
{

   
    public class BorderlessEntryEffect : PlatformEffect
    {
        CALayer bottomBorder;
        public BorderlessEntryEffect()
        {
        }

        protected override void OnAttached()
        {
            try
            {
                Control.Layer.BorderWidth = 0;
                ((UITextField)Control).BorderStyle = UITextBorderStyle.None;

                bottomBorder = new CALayer();
                bottomBorder.BackgroundColor = Xamarin.Forms.Color.Green.ToCGColor();// CentroColors.GreenButton.ToCGColor();

                Control.Layer.AddSublayer(bottomBorder);

                var formsEditor = Element as Xamarin.Forms.Entry;
                if (formsEditor != null)
                {
                    formsEditor.SizeChanged += ElementSizeChanged;
                    formsEditor.TextChanged += FormsEntry_TextChanged;
                }
            }
            catch (Exception)
            {

            }
        }

        protected override void OnDetached()
        {
            var formsEditor = Element as Xamarin.Forms.Entry;
            if (formsEditor != null)
            {
                formsEditor.SizeChanged -= ElementSizeChanged;
                formsEditor.TextChanged -= FormsEntry_TextChanged;
            }

            bottomBorder.Dispose();
            bottomBorder = null;
        }

        void FormsEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Control.InvalidateIntrinsicContentSize();
        }

        void ElementSizeChanged(object sender, EventArgs e)
        {
            var formsEditor = Element as Xamarin.Forms.InputView;
            bottomBorder.Frame = new CGRect(0, formsEditor.Bounds.Height - 1, formsEditor.Bounds.Width, 1);
        }
    }
}
