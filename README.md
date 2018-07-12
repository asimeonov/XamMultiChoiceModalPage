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
using Xamarin.Forms.AlertDialogModal;
```
### Usage as alert dialog with Positive, Negavive and Neutral Buttons:
Create instance of ***AlertDialogBuilder*** with default implementing class.
Then call the ```.Show()``` method of the instance passing the parent Page.
```csharp
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
```
### Usage as alert dialog with custom views for title and content:
Sample also shows that if the ***SetAutoDismiss(true)*** is not used the page should be dismissed manually.
```csharp
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
```

### Usage as single select dialog:
Create collection of ***SelectListItem*** that will be shown in the SingleChoice List.
```csharp
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
        Value = 1
    },
};
```
The ***SelectListItem*** is a generic class that allows usage of any ```Type``` as a ***Value*** of the Item and ***Text*** for a representation in the list.

Create instance of ***AlertDialogBuilder*** note that you will have to use same ```Type``` as the one usef for ***SelectListItem***
Then call the ```.Show()``` method of the instance passing the parent Page.
If you want to select specific item pass its index as a second parameter of ***SetSingleChoiceItems*** or ```-1``` for no selection.
```csharp
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
```

### Usage as multichoise select dialog:
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

Create instance of ***AlertDialogBuilder*** note that you will have to use same ```Type``` as the one usef for ***SelectListItem***
Then call the ```.Show()``` method of the instance passing the parent Page.
```csharp
var multiChoiceDialogPage = new AlertDialogBuilder<int>()
    .SetAutoDismiss(true)
    .SetTitle("Choose Multiple Options")
    .SetMultiChoiceItems(items)
    .SetPositiveButton("Ok", OnPositiveButtonClicked)
    .SetNegativeButton("Cancel")
    .Build();

await multiChoiceDialogPage.Show(this);
```
