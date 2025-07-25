### Example 1: Create an in-memory object for StringNotBeginsWithFilter.
```powershell
New-AzEventGridStringNotBeginsWithFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotBeginsWith
```

Create an in-memory object for StringNotBeginsWithFilter.