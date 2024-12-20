### Example 1: Create an in-memory object for NumberLessThanOrEqualsFilter.
```powershell
New-AzEventGridNumberLessThanOrEqualsFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType           Value
---     ------------           -----
testKey NumberLessThanOrEquals 11.22
```

Create an in-memory object for NumberLessThanOrEqualsFilter.