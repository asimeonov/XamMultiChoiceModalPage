using Xamarin.Forms;

namespace XamMultiChoiceModal
{
    internal class WrappedItemSelectionTemplate : ViewCell
    {
        public WrappedItemSelectionTemplate() : base()
        {
            Label name = new Label();
            name.SetBinding(Label.TextProperty, new Binding("Text"));
            name.HorizontalOptions = LayoutOptions.StartAndExpand;
            name.VerticalOptions = LayoutOptions.CenterAndExpand;

            Switch mainSwitch = new Switch();
            mainSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Selected"));
            mainSwitch.HorizontalOptions = LayoutOptions.EndAndExpand;
            mainSwitch.VerticalOptions = LayoutOptions.CenterAndExpand;

            StackLayout layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.Children.Add(name);
            layout.Children.Add(mainSwitch);
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Padding = new Thickness(10, 0, 0, 0);

            View = layout;
        }
    }
}
