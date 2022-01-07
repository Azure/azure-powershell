### Example 1: Create an HTTP Header object
```powershell
PS C:\> New-AzContainerInstanceHttpHeaderObject -name foo -value bar

Name Value
---- -----
foo  bar
```

Create an HTTP Header object to be used in liveness or readiness probes.
