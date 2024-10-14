### Example 1: Create a query object with ARG query
```powershell
 New-AzTerraformExportQueryObject -Query "type =~ `"Microsoft.Compute/virtu
alMachines`""
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
Query          : type =~ "Microsoft.Compute/virtualMachines"
Recursive      :
TargetProvider :
Type           : ExportQuery
```

Create a query object with ARG query