### Example 1: {{ Add title here }}
```powershell
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> New-AzDataDogTagRule -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'test' -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDataDogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> Get-AzDataDogTagRule -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' | New-AzDataDogTagRule -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

{{ Add description here }}

