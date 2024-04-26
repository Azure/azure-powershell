### Example 1: Get-AzSelfHelpSolution by resource id
```powershell
Get-AzSelfHelpSolution -ResourceName test-resource234 -Scope  /subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/DiagnosticsRp-Ev2AssistId-Public-Dev/providers/Microsoft.KeyVault/vaults/DiagRp-Ev2PublicDev
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
        test-resource234    DiagnosticsRp-Ev2AssistId-Public-Dev
```

Get SelfHelp Solution by resource id