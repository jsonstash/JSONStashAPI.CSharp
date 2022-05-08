# JSONStashAPI.CSharp
This library takes what the JSONStash api returns in JSON, and converts it to C# objects for easy interaction with in C# projects.

### Example

```
JSONStash stash = new JSONStash("YOUR_SERVER_URL");

StashResponse data = await stash.GetStashDataAsync(STASH_API_KEY, STASH_ID);

bool canParseObject = data.TryParseData(out object obj)

await stash.UpdateStashDataAsync(STASH_API_KEY, STASH_ID, "{ <JSON> }");
```
