### Example 1: Create an in-memory object for StringNotContainsAdvancedFilter.
```powershell
New-AzEventGridStringNotContainsAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotContains
```

Create an in-memory object for StringNotContainsAdvancedFilter.