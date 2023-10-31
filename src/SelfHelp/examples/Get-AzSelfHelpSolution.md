### Example 1: Get-AzSelfHelpSolution by resource id
```powershell
Get-AzSelfHelpSolution -ResourceName test-resource -Scope  /subscriptions/<subid>/resourceGroups/testRG/providers/Microsoft.KeyVault/testkv/testDB
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
         test-resource testRG
```

Get SelfHelp Solution by resource id