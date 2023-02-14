### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
New-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'test' -LogRuleFilteringTag $ftobjArray
```

```output
=======
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> New-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'test' -LogRuleFilteringTag $ftobjArray

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource.

### Example 2: Create or update a tag rule set for a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogTagRule -LogRuleFilteringTag $ftobjArray
```

```output
=======
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogTagRule -LogRuleFilteringTag $ftobjArray

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource by pipeline.

