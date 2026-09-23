### Example 1: Create an in-memory object for StringInFilter.
```powershell
New-AzEventGridStringInFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringIn
```

Create an in-memory object for StringInFilter.