using System;
using Foundation;
using UIKit;

namespace JPushDemo
{
    public static class MsgBoxHelper
    {

        static NSObject nsObject;

        public static void Initialize(NSObject nsObject)
        {
            MsgBoxHelper.nsObject = nsObject;
        }

        public static void ShowMessage(string title, string message, MessageBoxButton buttons, Action positiveCallback, Action negativeCallback)
        {               
            UIAlertView alert = BuildAlert(title, message, buttons);
            alert.Clicked += (sender, buttonArgs) =>
            {
                if (buttonArgs.ButtonIndex == 0)
                {
                    positiveCallback();
                }
                else
                {
                    negativeCallback();
                }
            };      

            nsObject.InvokeOnMainThread(alert.Show);
        }

        public static void ShowMessage(string title, string message)
        {               
            UIAlertView alert = BuildAlert(title, message, MessageBoxButton.OK);
            nsObject.InvokeOnMainThread(alert.Show);
        }

        public static void ShowMessage(string title, string message, MessageBoxButton buttons, Action positiveCallback)
        {               
            UIAlertView alert = BuildAlert(title, message, buttons);
            alert.Clicked += (sender, buttonArgs) =>
            {
                if (buttonArgs.ButtonIndex == 0)
                {
                    positiveCallback();
                }
            };      

            nsObject.InvokeOnMainThread(alert.Show);
        }

        static UIAlertView BuildAlert(string title, string message, MessageBoxButton buttons)
        {
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    return new UIAlertView(title, message, null, "Ok", null);
                case MessageBoxButton.OKCancel:
                    return new UIAlertView(title, message, null, "Ok", "Cancel");
                case MessageBoxButton.YesNo:
                    return new UIAlertView(title, message, null, "Yes", "No");
            }
            throw new NotImplementedException(buttons.ToString());
        }
    }

    public enum MessageBoxButton
    {
        OK,
        OKCancel,
        YesNo,
    }
}

