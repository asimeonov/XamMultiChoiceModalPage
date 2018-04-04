using System;

namespace XamMultiChoiceModalPage
{
    public class SelectedItemsEventArgs<T> : EventArgs
    {
        public T[] SelectedValues { get; set; }
    }
}
