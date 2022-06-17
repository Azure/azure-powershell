### Example 1: Get ImportExport job with default context
```powershell
Get-AzImportExport
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job with default context.

### Example 2: Get ImportExport job by resource group and job name
```powershell
Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job by resource group and job name.

### Example 3: Lists all the ImportExport jobs in specified resource group
```powershell
Get-AzImportExport -ResourceGroupName ImportTestRG
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists all the ImportExport jobs in specified resource group.

### Example 4: Get ImportExport job by identity
```powershell
$Id = "/subscriptions/<SubscriptionId>/resourceGroups/ImportTestRG/providers/Microsoft.ImportExport/jobs/test-job"
Get-AzImportExport -InputObject $Id
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists gets ImportExport job by identity.