### Example 1: Create an in-memory object for StringNotInFilter.
```powershell
New-AzEventGridStringNotInFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotIn
```

Create an in-memory object for StringNotInFilter.