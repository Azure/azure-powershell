### Example 1: Create an in-memory object for StringBeginsWithAdvancedFilter.
```powershell
New-AzEventGridStringBeginsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringBeginsWith
```

Create an in-memory object for StringBeginsWithAdvancedFilter.