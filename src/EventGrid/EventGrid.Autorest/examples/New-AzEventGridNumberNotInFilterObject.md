### Example 1: Create an in-memory object for NumberNotInFilter.
```powershell
New-AzEventGridNumberNotInFilterObject -Key "testKey" -Value 11.22,22.33
```

```output
Key     OperatorType
---     ------------
testKey NumberNotIn
```

Create an in-memory object for NumberNotInFilter.