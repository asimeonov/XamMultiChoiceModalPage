using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamMultiChoiceModalPage
{
    public class MultiChoiceDialogBuilder<T>
    {
        private bool autoDismiss;
        private string title;
        private ICollection<SelectListItem<T>> items;
        private string positiveButtonText;
        private EventHandler<SelectedItemsEventArgs<T>> positiveButtonClickedEventHandler;
        private Style positiveButtonStyle;
        private string negativeButtonText;
        private EventHandler<EventArgs> negativeButtonClickedEventHandler;
        private Style negativeButtonStyle;
        private Color modalPageBackgroundColor;
        private Color itemsListBackgroundColor;

        public MultiChoiceDialogBuilder(bool autoDismiss)
        {
            positiveButtonText = "OK";
            this.autoDismiss = autoDismiss;
        }

        public MultiChoiceDialogBuilder<T> SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public MultiChoiceDialogBuilder<T> SetMultiChoiceItems(ICollection<SelectListItem<T>> items)
        {
            this.items = items;
            return this;
        }

        public MultiChoiceDialogBuilder<T> SetPositiveButton(string text, 
            EventHandler<SelectedItemsEventArgs<T>> clickedEventHandler = null,
            Style style = null)
        {
            positiveButtonText = text;
            positiveButtonClickedEventHandler = clickedEventHandler;
            positiveButtonStyle = style;

            return this;
        }

        public MultiChoiceDialogBuilder<T> SetNegativeButton(string text,
            EventHandler<EventArgs> clickedEventHandler = null,
            Style style = null)
        {
            negativeButtonText = text;
            negativeButtonClickedEventHandler = clickedEventHandler;
            negativeButtonStyle = style;

            return this;
        }

        public MultiChoiceDialogBuilder<T> SetModalPageBackgroundColor(Color color, double? opacity = null)
        {
            if(opacity.HasValue)
            {
                modalPageBackgroundColor = new Color(color.R, color.G, color.B, opacity.Value);
            }
            else
            {
                modalPageBackgroundColor = color;
            }

            return this;
        }

        public MultiChoiceDialogBuilder<T> SetItemsListBackgroundColor(Color color, double? opacity = null)
        {
            if (opacity.HasValue)
            {
                itemsListBackgroundColor = new Color(color.R, color.G, color.B, opacity.Value);
            }
            else
            {
                itemsListBackgroundColor = color;
            }

            return this;
        }

        public MultiChoiceDialogPage Build()
        {
            return new MultiChoiceDialogPage()
                .Create(autoDismiss,
                title, 
                items, 
                positiveButtonText,
                positiveButtonClickedEventHandler,
                positiveButtonStyle,
                negativeButtonText,
                negativeButtonClickedEventHandler,
                negativeButtonStyle,
                modalPageBackgroundColor,
                itemsListBackgroundColor);
        }
    }
}
