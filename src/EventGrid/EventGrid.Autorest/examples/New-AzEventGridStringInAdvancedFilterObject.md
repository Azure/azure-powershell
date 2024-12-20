### Example 1: Create an in-memory object for StringInAdvancedFilter.
```powershell
New-AzEventGridStringInAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringIn
```

Create an in-memory object for StringInAdvancedFilter.