### Example 1: Create an HTTP Header object
```powershell
New-AzContainerInstanceHttpHeaderObject -name foo -value bar
```

```output
Name Value
---- -----
foo  bar
```

Create an HTTP Header object to be used in liveness or readiness probes.
