# 🌐 FBrowser Mobile - A Lightweight Tabbed Web Browser Built with .NET MAUI

**FBrowser Mobile** is a clean, minimal, and functional mobile web browser built using **.NET MAUI**, designed for Android and iOS. It includes support for **multi-tab browsing**, **bookmarks**, and a simple yet elegant UI optimized for mobile devices.

---

## 🚀 Features

- 🔖 **Bookmark Management**  
  Save and manage your favorite web pages locally using `Preferences`.

- 🧭 **URL Search & Navigation**  
  Smart URL input with Google search fallback if the input is not a valid URL.

- 📑 **Multiple Tabs**  
  Open, switch, and close multiple tabs with intuitive UI controls.

- 🧭 **WebView Integration**  
  Embedded MAUI `WebView` for seamless browsing experience.

---

## 📱 Screenshots
![WhatsApp Image 2025-07-28 at 05 21 19](https://github.com/user-attachments/assets/dd706cb9-1270-4659-a8c6-e538dca1ffde)

![WhatsApp Image 2025-07-28 at 05 21 18](https://github.com/user-attachments/assets/834004c0-f39a-458c-a4a2-ae5d14ccbc8c)


---

## 🛠️ Built With

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)  
- C# 10  
- XAML  
- CommunityToolkit.Maui (for cross-platform enhancements)

---

## 📦 Project Structure

- `MainPage.xaml` / `.cs` - Main browser interface and navigation
- `BookmarksPage.xaml` / `.cs` - Bookmark listing and deletion
- `TabsPage.xaml` / `.cs` - Tab switching and management
- `BookmarkStorage.cs` - Local bookmark persistence
- `Tabs.cs`, `Bookmark.cs` - Data models

---

## 🔧 How to Run

1. Clone this repository
2. Open with **Visual Studio 2022+**
3. Make sure MAUI workload is installed
4. Run on Android/iOS emulator or real device

```bash
git clone https://github.com/yourusername/FBrowser_Mobile.git
