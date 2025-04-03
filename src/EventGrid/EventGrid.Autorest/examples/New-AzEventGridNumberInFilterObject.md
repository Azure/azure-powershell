### Example 1: Create an in-memory object for NumberInFilter.
```powershell
New-AzEventGridNumberInFilterObject -Key "testKey" -Value 11.22,22.33
```

```output
Key     OperatorType
---     ------------
testKey NumberIn
```

Create an in-memory object for NumberInFilter.