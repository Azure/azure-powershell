### Example 1: Create (Default)
```powershell
PS C:\> $props = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateProjectProperties]::new()
PS C:\> $props.RegisteredTool = {}
PS C:\> New-AzMigrateProject -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName kuchaturimpkocrg1 -Name kuchaturimpkocrg1pwshp14 -Location "centralus" -ETag "*" -Property $props

ETag Location  Name                     Type
---- --------  ----                     ----
     centralus kuchaturimpkocrg1pwshp14 Microsoft.Migrate/MigrateProjects

```

Method to create or update a migrate project.