### Example 1: Get ImportExport job with default context
```powershell
PS C:\> Get-AzImportExport
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job with default context.

### Example 2: Get ImportExport job by resource group and job name
```powershell
PS C:\> Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job by resource group and job name.

### Example 3: Lists all the ImportExport jobs in specified resource group
```powershell
PS C:\> Get-AzImportExport -ResourceGroupName ImportTestRG
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists all the ImportExport jobs in specified resource group.

### Example 4: Get ImportExport job by identity
```powershell
PS C:\> $Id = "/subscriptions/<SubscriptionId>/resourceGroups/ImportTestRG/providers/Microsoft.ImportExport/jobs/test-job"
PS C:\> Get-AzImportExport -InputObject $Id
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists gets ImportExport job by identity.