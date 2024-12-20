### Example 1: Create an in-memory object for NumberLessThanAdvancedFilter.
```powershell
New-AzEventGridNumberLessThanAdvancedFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType   Value
---     ------------   -----
testKey NumberLessThan 11.22
```

Create an in-memory object for NumberLessThanAdvancedFilter.