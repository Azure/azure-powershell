### Example 1: Create an in-memory object for NumberNotInRangeAdvancedFilter.
```powershell
$valuesObj = @(11.11, 22.22, 33.33, 44.44)
New-AzEventGridNumberNotInRangeAdvancedFilterObject -Key "testKey" -Value @(,$valuesObj)
```

```output
Key     OperatorType
---     ------------
testKey NumberNotInRange
```

Create an in-memory object for NumberNotInRangeAdvancedFilter.