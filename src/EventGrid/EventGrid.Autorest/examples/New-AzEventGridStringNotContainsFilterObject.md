### Example 1: Create an in-memory object for StringNotContainsFilter.
```powershell
New-AzEventGridStringNotContainsFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotContains
```

Create an in-memory object for StringNotContainsFilter.