### Example 1: Create an in-memory object for StringNotBeginsWithAdvancedFilter.
```powershell
New-AzEventGridStringNotBeginsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotBeginsWith
```

Create an in-memory object for StringNotBeginsWithAdvancedFilter.