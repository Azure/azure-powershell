### Example 1: Create an in-memory object for StringNotEndsWithAdvancedFilter.
```powershell
New-AzEventGridStringNotEndsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotEndsWith
```

Create an in-memory object for StringNotEndsWithAdvancedFilter.