### Example 1: Create an in-memory object for NumberGreaterThanFilter.
```powershell
New-AzEventGridNumberGreaterThanFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType      Value
---     ------------      -----
testKey NumberGreaterThan 11.22
```

Create an in-memory object for NumberGreaterThanFilter.