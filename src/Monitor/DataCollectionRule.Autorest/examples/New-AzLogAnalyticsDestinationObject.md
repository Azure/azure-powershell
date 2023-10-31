### Example 1: Create a log analytics destination object
```powershell
New-AzLogAnalyticsDestinationObject -Name centralWorkspace -WorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/sipstestcx9d03/providers/microsoft.operationalinsights/workspaces/asptest4k37qz
```

```output
Name             WorkspaceId WorkspaceResourceId
----             ----------- -------------------
centralWorkspace             /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/sipstestcx9d03/providers/microsoft.operationalinsights/workspaces/asptest4k…
```

This command creates a log analytics destination object.
