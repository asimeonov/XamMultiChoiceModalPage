using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamMultiChoiceModal;

namespace XamMultiChoiceModalPage
{
    public partial class MainPage : ContentPage
	{
        MultiChoiceDialogPage multiChoiceDialogPage;
		public MainPage()
		{
			InitializeComponent();
		}

        public async void OnShowMultichoice_Clicked(object s, EventArgs e)
        {
            List<SelectListItem<int>> items = new List<SelectListItem<int>>()
            {
                new SelectListItem<int>()
                {
                    Text = "Option 1",
                    Value = 1,
                    Selected = false
                },
                new SelectListItem<int>()
                {
                    Text = "Option 2",
                    Value = 2,
                    Selected = true
                },
                new SelectListItem<int>()
                {
                    Text = "Option 3",
                    Value = 1,
                    Selected = false
                },
                new SelectListItem<int>()
                {
                    Text = "Option 4",
                    Value = 4,
                    Selected = false
                },
                new SelectListItem<int>()
                {
                    Text = "Option 5",
                    Value = 5,
                    Selected = true
                },
            };

            multiChoiceDialogPage = new MultiChoiceDialogBuilder<int>(false)
                .SetTitle("Choose Options")
                .SetMultiChoiceItems(items)
                .SetPositiveButton("Ok", clickedEventHandler: async (sender, arts) =>
                {
                    await DisplayAlert("You have selected", string.Join(", ", arts.SelectedValues), "OK");
                    await multiChoiceDialogPage.Dismiss();
                })
                .SetNegativeButton("Cancel", clickedEventHandler: async (sender, args) =>
                {
                    await multiChoiceDialogPage.Dismiss();
                })
                .Build();

            await multiChoiceDialogPage.Show(this);
        }
        public async void OnShowMultichoiceAutoDismiss_Clicked(object s, EventArgs e)
        {
            List<SelectListItem<int>> items = new List<SelectListItem<int>>()
            {
                new SelectListItem<int>()
                {
                    Text = "Option 1",
                    Value = 1,
                    Selected = false
                },
                new SelectListItem<int>()
                {
                    Text = "Option 2",
                    Value = 2,
                    Selected = true
                },
                new SelectListItem<int>()
                {
                    Text = "Option 3",
                    Value = 1,
                    Selected = false
                },
            };

            var autoDismissMultiChoiceDialogPage = new MultiChoiceDialogBuilder<int>(true)
                .SetTitle("Choose Options")
                .SetMultiChoiceItems(items)
                .SetPositiveButton("Ok", clickedEventHandler: async (sender, arts) =>
                {
                    await DisplayAlert("You have selected", string.Join(", ", arts.SelectedValues), "OK");
                })
                .SetNegativeButton("Cancel")
                .Build();

            await autoDismissMultiChoiceDialogPage.Show(this);
        }
    }
}
