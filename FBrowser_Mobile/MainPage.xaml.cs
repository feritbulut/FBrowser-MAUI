
using Microsoft.Maui.Controls.Embedding;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Extensions;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace FBrowser_Mobile
{
    // Mevcut kodlar devam eder...

    public partial class MainPage : ContentPage
    {
        List<Tabs> tabs = new();
        int activeTabIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            OpenNewTab("https://www.google.com");
            
            webView.Navigated += (s, e) =>
            {
                if (activeTabIndex >= 0 && tabs.Count > activeTabIndex)
                {
                    tabs[activeTabIndex].Url = e.Url;
                    urlEntry.Text = e.Url;
                }
            };
        }


        public void SwitchToTabWithUrl(string url)
        {
            OpenNewTab(url);
        }




        private async void OnButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Options", "Close", null,
                "Add Bookmark", "Bookmarks");

            // Doğru şekilde instance üzerinden Source'a erişiyoruz
            
                switch (action)
                {
                    case "Add Bookmark":
                       
                        BookmarkStorage.AddBookmark(urlEntry.Text);

                        break;
                    case "Bookmarks":
                        await Navigation.PushAsync(new BookmarksPage(this));
                        break;
                    
                }
            
        }





        private void OnGoClicked(object sender, EventArgs e)
        {
            string query = urlEntry.Text;

#if !MACCATALYST
        urlEntry.HideKeyboardAsync(CancellationToken.None);
#endif

            if (!string.IsNullOrWhiteSpace(query))
            {
                if (query.StartsWith("https://"))
                {
                    webView.Source = query;
                }
                else
                {
                    string googleUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(query)}";
                    webView.Source = googleUrl;
                }

                if (webView.Source is UrlWebViewSource urlSource)
                {
                    tabs[activeTabIndex].Url = urlSource.Url;
                }
            }
        }

        public void OpenNewTab(string url)
        {
            var newTab = new Tabs { Url = url };
            tabs.Add(newTab);
            SwitchToTab(tabs.Count - 1);
        }

        public void CloseTab(Tabs tab)
        {
            int index = tabs.IndexOf(tab);
            if (index >= 0)
            {
                tabs.RemoveAt(index);
                if (tabs.Count == 0)
                {
                    OpenNewTab("https://www.google.com");
                }
                else
                {
                    int newIndex = Math.Min(index, tabs.Count - 1);
                    SwitchToTab(newIndex);
                }
            }
        }

        private void OnTabsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabsPage(this));
        }

        public void SwitchToTab(int index)
        {
            if (index >= 0 && index < tabs.Count)
            {
                activeTabIndex = index;
                urlEntry.Text = tabs[index].Url;
                webView.Source = tabs[index].Url;
            }
        }

        public List<Tabs> GetTabs()
        {
            return tabs;
        }

        protected override bool OnBackButtonPressed()
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }


}
