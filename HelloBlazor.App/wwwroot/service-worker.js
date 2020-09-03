// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', () => { });


// Check out The Offline Cookbook by Jake Archibald
// for a variety of service worker samples :b