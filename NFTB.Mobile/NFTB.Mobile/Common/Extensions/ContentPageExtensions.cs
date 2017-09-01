using System;
using System.Threading.Tasks;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Models;
using Xamarin.Forms;

namespace NFTB.Mobile.Common.Extensions
{
    public static class ContentPageExtensions
    {
        public static T Model<T>(this IContentPage<T> page) where T : BaseModel
        {
            return page.BindingContext as T;
        }

        public static async Task Try(this BaseModel model, Func<Task> action)
        {
            try
            {
                //await model.SetWorking(true);
                await action();
            }
            catch (Exception ex)
            {
                //model.OnError(ex);
            }
            finally
            {
                //await model.SetWorking(false);
            }
        }

        /// <summary>
        /// Pushes the page onto the given navigation stack
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="isBusy"></param>
        public static void SetIsBusy(this IContentPage navigation, bool isBusy)
        {
            if (navigation is Page)
            {
                var page = ((Page)navigation);
                page.IsBusy = isBusy;
            }
        }


        /// <summary>
        /// Displays an alert
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="accept"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public static Task<bool> DisplayAlert(this IContentPage navigation, string title, string message, string accept, string cancel)
        {
            if (navigation is Page)
            {
                var p = (Page)navigation;
                return p.DisplayAlert(title, message, accept, cancel);
            }
            return null;
        }

        /// <summary>
        /// Displays an alert
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="accept"></param>
        /// <returns></returns>
        public static Task DisplayAlert(this IContentPage navigation, string title, string message, string accept)
        {
            if (navigation is Page)
            {
                var p = (Page)navigation;
                return p.DisplayAlert(title, message, accept);
            }
            return null;
        }

        /// <summary>
        /// Displays an actionsheet
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="accept"></param>
        /// <returns></returns>
        public static Task<string> DisplayActionSheet(this IContentPage navigation, string title, string cancelString, string destructString, string[] stringParameters)
        {
            if (navigation is Page)
            {
                var p = (Page)navigation;
                return p.DisplayActionSheet(title, cancelString, destructString, stringParameters);
            }
            return null;
        }
    }
}
