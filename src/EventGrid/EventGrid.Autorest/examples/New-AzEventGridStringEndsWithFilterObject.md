### Example 1: Create an in-memory object for StringEndsWithFilter.
```powershell
New-AzEventGridStringEndsWithFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringEndsWith
```

Create an in-memory object for StringEndsWithFilter.