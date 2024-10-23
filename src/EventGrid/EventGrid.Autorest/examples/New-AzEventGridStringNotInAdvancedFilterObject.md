### Example 1: Create an in-memory object for StringNotInAdvancedFilter.
```powershell
New-AzEventGridStringNotInAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotIn
```

Create an in-memory object for StringNotInAdvancedFilter.