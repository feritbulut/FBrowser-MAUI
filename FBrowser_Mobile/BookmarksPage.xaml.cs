namespace FBrowser_Mobile;

public partial class BookmarksPage : ContentPage
{
    private MainPage mainPage;
    public BookmarksPage(MainPage page)
    {
        InitializeComponent();
        mainPage = page;
        bookmarkListView.ItemsSource = BookmarkStorage.LoadBookmarks();
    }

    private void OnBookmarkSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Bookmark selected)
        {
            mainPage.SwitchToTabWithUrl(selected.Url);
            Navigation.PopAsync();
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var bookmark = (Bookmark)button.CommandParameter;
        BookmarkStorage.RemoveBookmark(bookmark);
        bookmarkListView.ItemsSource = BookmarkStorage.LoadBookmarks();
    }
}