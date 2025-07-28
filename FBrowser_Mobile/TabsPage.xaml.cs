using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace FBrowser_Mobile;

public partial class TabsPage : ContentPage
{
    private MainPage mainPage;
    public TabsPage(MainPage page)
	{
        InitializeComponent();
        mainPage = page;
        tabsListView.ItemsSource = mainPage.GetTabs();
    }

    private void OnNewTabClicked(object sender, EventArgs e)
    {
        mainPage.OpenNewTab("https://www.google.com");
        tabsListView.ItemsSource = null;
        tabsListView.ItemsSource = mainPage.GetTabs();
    }

    private void OnCloseTabClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var tab = (Tabs)button.CommandParameter;
        mainPage.CloseTab(tab);
        tabsListView.ItemsSource = null;
        tabsListView.ItemsSource = mainPage.GetTabs();
    }

    private void OnBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    } 

    private void OnTabSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Tabs selectedTab)
        {
            int index = mainPage.GetTabs().IndexOf(selectedTab);
            mainPage.SwitchToTab(index);
            Navigation.PopAsync();
        }
    }
}