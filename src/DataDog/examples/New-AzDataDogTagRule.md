### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> New-AzDataDogTagRule -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'test' -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource.

### Example 2: Create or update a tag rule set for a given monitor resource by pipeline
```powershell
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> Get-AzDataDogTagRule -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'default' | New-AzDataDogTagRule -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource by pipeline.

