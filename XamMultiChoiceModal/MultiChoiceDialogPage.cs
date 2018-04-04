using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamMultiChoiceModal
{
    public class MultiChoiceDialogPage : ContentPage
    {
        private bool isPresented;
        private Frame contentFrame;

        public MultiChoiceDialogPage()
        {
            isPresented = false;
        }

        public MultiChoiceDialogPage Create<T>(bool autoDismiss,
            string title,
            ICollection<SelectListItem<T>> items,
            string positiveButtonText,
            EventHandler<SelectedItemsEventArgs<T>> positiveButtonClickedEventHandler,
            Style positiveButtonStyle,
            string negativeButtonText,
            EventHandler<EventArgs> negativeButtonClickedEventHandler,
            Style negativeButtonStyle,
            Color modalPageBackgroundColor,
            Color itemsListBackgroundColor)
        {
            ListView mainList = new ListView()
            {
                ItemsSource = items,
                ItemTemplate = new DataTemplate(typeof(WrappedItemSelectionTemplate)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            mainList.ItemSelected += (sender, e) => {
                if (e.SelectedItem == null) return;
                var o = (SelectListItem<T>)e.SelectedItem;
                o.Selected = !o.Selected;
                ((ListView)sender).SelectedItem = null;
            };

            double heightRequest = (items.Count + 1) * Cell.DefaultCellHeight;

            if(heightRequest > Application.Current.MainPage.Height)
            {
                heightRequest = Application.Current.MainPage.Height - 200;
            }

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = new GridLength(heightRequest) },
                    new RowDefinition { Height = GridLength.Star },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                }
            };

            Label titleLabel = new Label()
            {
                Text = title,
                Margin = new Thickness(10, 0, 0, 0),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Grid.SetRow(titleLabel, 0);
            Grid.SetColumnSpan(titleLabel, 2);
            grid.Children.Add(titleLabel);

            Grid.SetRow(mainList, 1);
            Grid.SetColumnSpan(mainList, 2);
            grid.Children.Add(mainList);

            Button positiveButton = new Button();
            positiveButton.Text = positiveButtonText;
            positiveButton.Clicked += async (sender, args) =>
            {
                if (autoDismiss)
                {
                    await Dismiss();
                }

                positiveButtonClickedEventHandler?.Invoke(sender, new SelectedItemsEventArgs<T>()
                {
                    SelectedValues = items.Where(item => item.Selected).Select(item => item.Value).ToArray()
                });
            };
            if (positiveButtonStyle != null)
            {
                positiveButton.Style = positiveButtonStyle;
            }

            Grid.SetRow(positiveButton, 2);
            Grid.SetColumn(positiveButton, 1);
            grid.Children.Add(positiveButton);

            if (!string.IsNullOrWhiteSpace(negativeButtonText))
            {
                Button negativeButton = new Button();
                negativeButton.Text = negativeButtonText;
                negativeButton.Clicked += async (sender, e) =>
                {
                    if (autoDismiss)
                    {
                        await Dismiss();
                    }

                    negativeButtonClickedEventHandler?.Invoke(sender, e);
                };

                if (negativeButtonStyle != null)
                {
                    negativeButton.Style = negativeButtonStyle;
                }

                Grid.SetRow(negativeButton, 2);
                Grid.SetColumn(negativeButton, 0);
                grid.Children.Add(negativeButton);
            }

            contentFrame = new Frame
            {
                Content = grid,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                Padding = new Thickness(5)
            };

            if(itemsListBackgroundColor != null)
            {
                contentFrame.BackgroundColor = itemsListBackgroundColor;
            }

            Content = contentFrame;

            if(modalPageBackgroundColor != null)
            {
                BackgroundColor = modalPageBackgroundColor;
            }

            return this;
        }

        public async Task Show(Page onPage)
        {
            if (!isPresented)
            {
                isPresented = true;
                await onPage.Navigation.PushModalAsync(this);
            }
        }

        public async Task Dismiss()
        {
            if (isPresented)
            {
                isPresented = false;
                await Navigation.PopModalAsync();
                contentFrame = null;
            }
        }
    }
}