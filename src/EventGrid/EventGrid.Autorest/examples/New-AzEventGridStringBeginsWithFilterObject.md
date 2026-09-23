### Example 1: Create an in-memory object for StringBeginsWithFilter.
```powershell
New-AzEventGridStringBeginsWithFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringBeginsWith
```

Create an in-memory object for StringBeginsWithFilter.