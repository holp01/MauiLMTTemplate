using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MauiLMTTemplate.ViewModels
{
    public class ObservableCollectionViewModel<T> : ObservableCollection<T>
    {
        public ObservableCollectionViewModel() : base()
        {
        }

        public ObservableCollectionViewModel(IEnumerable<T> collection) : base(collection)
        {
        }

        public ObservableCollectionViewModel(List<T> list) : base(list)
        {
        }

        public void ReloadData(IEnumerable<T> items)
        {
            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public async Task ReloadDataAsync(Func<IList<T>, Task> innerListAction)
        {
            Items.Clear();

            await innerListAction(Items);

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
