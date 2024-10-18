### Example 1: Create an in-memory object for StringEndsWithAdvancedFilter.
```powershell
New-AzEventGridStringEndsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringEndsWith
```

Create an in-memory object for StringEndsWithAdvancedFilter.