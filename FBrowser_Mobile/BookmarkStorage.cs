using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FBrowser_Mobile
{
    public static class BookmarkStorage
    {
        const string Key = "Bookmarks";

        public static List<Bookmark> LoadBookmarks()
        {
            var json = Preferences.Get(Key, "[]");
            return JsonSerializer.Deserialize<List<Bookmark>>(json) ?? new();
        }

        public static void SaveBookmarks(List<Bookmark> bookmarks)
        {
            var json = JsonSerializer.Serialize(bookmarks);
            Preferences.Set(Key, json);
        }

        public static void AddBookmark(string url)
        {
            var list = LoadBookmarks();
            if (!list.Any(b => b.Url == url))
            {
                list.Add(new Bookmark { Url = url });
                SaveBookmarks(list);
            }
        }

        public static void RemoveBookmark(Bookmark bookmark)
        {
            var list = LoadBookmarks();
            list.RemoveAll(b => b.Url == bookmark.Url);
            SaveBookmarks(list);
        }
    }
}
