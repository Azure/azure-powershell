### Example 1: Asynchronously updates a partner topic with the specified parameters.
```powershell
Update-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid -UserAssignedIdentity "/subscriptions/{subId}/resourcegroups/azps_test_group_eventgrid/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami"
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Asynchronously updates a partner topic with the specified parameters.