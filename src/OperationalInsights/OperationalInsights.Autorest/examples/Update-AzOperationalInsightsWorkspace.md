### Example 1: Update an existing Worksapce retrntion
```powershell
PS C:\>$workspace =  Update-AzOperationalInsightsWorkspace -ResourceGroupName {RG-name} -Name {WS-name} -RetentionInDay 42
PS C:\>$workspace
Location Name                   ETag ResourceGroupName
-------- ----                   ---- -----------------
eastus   {WS-name}t

PS C:\> $workspace.RetentionInDay
42
```

Update a custom property - retention for a workspace

### Example 2: Update a workspace that does not exist
```powershell
PS C:\> Update-AzOperationalInsightsWorkspace -ResourceGroupName {RG-name} -Name {WS-name} -RetentionInDay 42

Update-AzOperationalInsightsWorkspace_UpdateExpanded: The Resource 'Microsoft.OperationalInsights/workspaces/{WS-name}' under resource group '{RG-name}' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix
```

Please create a workspace using 'New-AzOperationalInsightsWorkspace' cmdlet before updating it
