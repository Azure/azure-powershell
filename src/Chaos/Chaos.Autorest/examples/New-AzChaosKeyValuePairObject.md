### Example 1: Create a key/value pair
```powershell
New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
```

```output
Key           Value
---           -----
pressureLevel 95
```

Creates an in-memory key/value pair for use as an action parameter or an exclusion tag.

### Example 2: Build a list of key/value pairs
```powershell
$parameters = @(
    New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
    New-AzChaosKeyValuePairObject -Key 'target' -Value 'all'
)
```

```output
Key           Value
---           -----
pressureLevel 95
target        all
```

Builds an array of key/value pairs to pass to a parameter that accepts multiple entries.
