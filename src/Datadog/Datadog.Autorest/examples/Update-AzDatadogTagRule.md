### Example 1: Update a tag rule set for a given monitor resource
```powershell
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
Update-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'test' -LogRuleFilteringTag $ftobjArray
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command updates a tag rule set for a given monitor resource.

### Example 2: Update a tag rule set for a given monitor resource by pipeline
```powershell
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | Update-AzDatadogTagRule -LogRuleFilteringTag $ftobjArray
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command updates a tag rule set for a given monitor resource by pipeline.