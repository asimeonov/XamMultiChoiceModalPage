# XamMultiChoiceModalPage
A cross-platform modal page showing a frame with list of options same as AlertDialog with MultiChoiceItems.
Extention of https://github.com/xamarin/recipes/tree/master/cross-platform/xamarin-forms/Controls/multiselect and applied style that reminds more on modal dialog rathar then a page.

## Usage
1. Open **Package Manager Console**
2. When the console is opened for **Default project** select your **.NET Standard** shared project from the list of project.
3. Then ```Install-Package Xamarin.Forms.AlertDialogModal``` in PM.

Aftre successful install of the package you can start using the Page by:

Include the namespace 
```csharp 
using XamMultiChoiceModal;
```

Create collection of ***SelectListItem*** that will be shown in the MultiChoice List.
```csharp
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
```
The ***SelectListItem*** is a generic class that allows usage of any ```Type``` as a ***Value*** of the Item and ***Text*** for a representation in the list.

Create instance of ***MultiChoiceDialogBuilder*** note that you will have to use same ```Type``` as the one usef for ***SelectListItem***
```csharp
MultiChoiceDialogBuilder<int> multiChoiceDialogBuilder = new MultiChoiceDialogBuilder<int>(true)
    .SetTitle("Choose Options")
    .SetMultiChoiceItems(items)
    .SetPositiveButton("Ok", clickedEventHandler: async (sender, arts) =>
    {
        await DisplayAlert("You have selected", string.Join(", ", arts.SelectedValues), "OK");
    })
    .SetNegativeButton("Cancel");
```

After builder is configured call the ```.Build()``` method that will return the instance of ```MultiChoiceDialogPage```. Then call the ```.Show()``` method of the instance passing the parent Page.
```csharp
MultiChoiceDialogPage multiChoiceDialogPage = multiChoiceDialogBuilder.Build();

await multiChoiceDialogPage.Show(this);
```
