### Example 1: Create an in-memory object for NumberInRangeFilter.
```powershell
$valuesObj = @(11.11, 22.22, 33.33, 44.44)
New-AzEventGridNumberInRangeFilterObject -Key "testKey" -Value @(,$valuesObj)
```

```output
Key     OperatorType
---     ------------
testKey NumberInRange
```

Create an in-memory object for NumberInRangeFilter.