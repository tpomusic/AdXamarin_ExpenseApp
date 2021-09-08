using Android.Graphics.Drawables;
using ExpensesApplication.Droid.Effects;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Pluss")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApplication.Droid.Effects 
{
    public class SelectedEffect : PlatformEffect
    {
        Android.Graphics.Color selectedColor;
        Android.Graphics.Color originalColor;
        protected override void OnAttached()
        {
            selectedColor = new Android.Graphics.Color(229, 235, 235);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable)Control.Background).Color != selectedColor)
                    {
                        Control.SetBackgroundColor(selectedColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.White);   // Would normally set this to what is available in the App resources list of colors, attributes, etc.
                    }
                }
            }
            catch (InvalidCastException)
            {
                Control.SetBackgroundColor(selectedColor);
            }

        }
        protected override void OnDetached()
        {
            
        }
    }
}