### Example 1: Create an in-memory object for NumberInAdvancedFilter.
```powershell
New-AzEventGridNumberInAdvancedFilterObject -Key "testKey" -Value 11.22,22.33
```

```output
Key     OperatorType
---     ------------
testKey NumberIn
```

Create an in-memory object for NumberInAdvancedFilter.