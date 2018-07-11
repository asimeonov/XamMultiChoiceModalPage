using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.AlertDialogModal;

namespace XamMultiChoiceModalPage
{
    public partial class MainPage : ContentPage
	{
        AlertDialogPage messageDialogPageManualDismiss;
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnShowAlert_Clicked(object s, EventArgs e)
        {
            var messageDialogPage = new AlertDialogBuilder()
                .SetAutoDismiss(true)
                .SetTitle("Message title")
                .SetMessage("Lorem ipsum dolor sit amet, nec ne wisi timeam, verterem eleifend cu duo, an perfecto instructior eos. " +
                    "Tale hinc vide mei eu, pri ei vide nominavi insolens. Ex omnium delenit eam, eu nisl persequeris nec. At impedit imperdiet mel, " +
                    "autem perfecto ius te, ornatus constituto cu pro. Minimum facilisis honestatis nec id, duis posse eripuit vel no.")
                .SetIcon("icon.png")
                .SetPositiveButton("Ok", async () =>
                {
                    await DisplayAlert("Clicked", "OK button was clicked", "Close");
                })
                .SetNegativeButton("Cancel")
                .SetNeutralButton("Later")
                .Build();

            await messageDialogPage.Show(this);
        }

        public async void OnShowCustom_Clicked(object s, EventArgs e)
        {
            Label customTitle = new Label()
            {
                Text = "Custom title view"
            };

            StackLayout customContentView = new StackLayout();
            customContentView.Children.Add(new Image()
            {
                Source = "icon.png"
            });
            customContentView.Children.Add(new Label()
            {
                Text = "This is a custom content view displayed."
            });

            messageDialogPageManualDismiss = new AlertDialogBuilder()
                .SetCustomTitle(customTitle)
                .SetView(customContentView)
                .SetPositiveButton("Close", async () =>
                {
                    await messageDialogPageManualDismiss.Dismiss();
                })
                .Build();

            await messageDialogPageManualDismiss.Show(this);
        }

        public async void OnShowSingleChoice_Clicked(object s, EventArgs e)
        {
            List<SelectListItem<int>> items = new List<SelectListItem<int>>()
            {
                new SelectListItem<int>()
                {
                    Text = "Option 1",
                    Value = 1
                },
                new SelectListItem<int>()
                {
                    Text = "Option 2",
                    Value = 2
                },
                new SelectListItem<int>()
                {
                    Text = "Option 3",
                    Value = 3
                },
            };

            var singleChoiceDialogPage = new AlertDialogBuilder<int>()
                .SetAutoDismiss(true)
                .SetTitle("Choose Single Option")
                .SetSingleChoiceItems(items, 2)
                .SetPositiveButton("Ok", async (args) =>
                {
                    await DisplayAlert("You have selected", string.Join(", ", args.SelectedValues), "OK");
                })
                .SetNegativeButton("Cancel")
                .Build();

            await singleChoiceDialogPage.Show(this);
        }

        public async void OnShowMultiChoice_Clicked(object s, EventArgs e)
        {
            List<MultiSelectListItem<int>> items = new List<MultiSelectListItem<int>>()
            {
                new MultiSelectListItem<int>()
                {
                    Text = "Option 1",
                    Value = 1,
                    Selected = true
                },
                new MultiSelectListItem<int>()
                {
                    Text = "Option 2",
                    Value = 2
                },
                new MultiSelectListItem<int>()
                {
                    Text = "Option 3",
                    Value = 3,
                    Selected = true
                },
            };

            var multiChoiceDialogPage = new AlertDialogBuilder<int>()
                .SetAutoDismiss(true)
                .SetTitle("Choose Multiple Options")
                .SetMultiChoiceItems(items)
                .SetPositiveButton("Ok", OnPositiveButtonClicked)
                .SetNegativeButton("Cancel")
                .Build();

            await multiChoiceDialogPage.Show(this);
        }

        private async void OnPositiveButtonClicked(SelectedItemsEventArgs<int> e)
        {
            await DisplayAlert("You have selected", string.Join(", ", e.SelectedValues), "OK");
        }
    }
}
