using System;

namespace XamMultiChoiceModal
{
    public class SelectedItemsEventArgs<T> : EventArgs
    {
        public T[] SelectedValues { get; set; }
    }
}
