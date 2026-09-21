### Example 1: List private link resources for a bookshelf
```powershell
Get-AzDiscoveryBookshelfPrivateLinkResource -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf"
```

```output
Name            GroupId
----            -------
bookshelf       bookshelf
```

Lists available private link resources for the specified bookshelf.
