### Example 1: Creates a configuration profile
```powershell
$confprof = @{
          "Antimalware/Enable"='false';
          "Backup/Enable"='false';
          "VMInsights/Enable"= 'true';
          "AzureSecurityCenter/Enable"='true';
          "UpdateManagement/Enable"='true';
          "ChangeTrackingAndInventory/Enable"='true';
          "GuestConfiguration/Enable"='true';
          "LogAnalytics/Enable"='true';
          "BootDiagnostics/Enable"='true'
        }
New-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Location eastus -Configuration $confprof
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command creates a configuration profile.