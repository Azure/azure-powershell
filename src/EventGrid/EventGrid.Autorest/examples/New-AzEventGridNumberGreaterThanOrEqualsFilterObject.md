### Example 1: Create an in-memory object for NumberGreaterThanOrEqualsFilter.
```powershell
New-AzEventGridNumberGreaterThanOrEqualsFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType              Value
---     ------------              -----
testKey NumberGreaterThanOrEquals 11.22
```

Create an in-memory object for NumberGreaterThanOrEqualsFilter.