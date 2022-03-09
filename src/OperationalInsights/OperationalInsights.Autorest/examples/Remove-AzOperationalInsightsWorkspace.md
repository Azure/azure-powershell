### Example 1: Remove a workapce by resource group name and workspace name
```powershell
Remove-AzOperationalInsightsWorkspace -ResourceGroupName {RG-Name} -Name {WS-Name}

Confirm
Are you sure you want to remove workspace '{WS-Name}' in resource group '{RG-Name}'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): y
```
Removes a Log-Analytics workspace.