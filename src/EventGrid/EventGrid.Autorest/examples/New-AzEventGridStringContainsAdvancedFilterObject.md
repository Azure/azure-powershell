### Example 1: Create an in-memory object for StringContainsAdvancedFilter.
```powershell
New-AzEventGridStringContainsAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringContains
```

Create an in-memory object for StringContainsAdvancedFilter.