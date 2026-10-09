### Example 1: Get a Fabric shortcut on an EventHub entity
```powershell
Get-AzEventHubFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -Name orders-shortcut
```

```output
ConfigurationArtifactId        : 33333333-3333-3333-3333-333333333333
ConfigurationArtifactName      : orders-eventstream
ConfigurationPremiumCapacityId : 44444444-4444-4444-4444-444444444444
ConfigurationTenantId          : 11111111-1111-1111-1111-111111111111
ConfigurationWorkspaceId       : 22222222-2222-2222-2222-222222222222
ConfigurationWorkspaceName     : contoso-workspace
CreatedAt                      : 7/1/2026 12:00:00 PM
Id                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.EventHub/namespaces/contoso-eventhub/eventhubs/orders/fabricShortcuts/orders-shortcut
Location                       : southcentralus
ModifiedAt                     : 7/1/2026 12:05:00 PM
Name                           : orders-shortcut
ShortcutStatus                 : Approved
ShortcutType                   : Entity
StatusDescription              : Approved by the Event Hubs owner
Type                           : Microsoft.EventHub/namespaces/eventhubs/fabricShortcuts
```

Gets the Fabric shortcut `orders-shortcut` on the EventHub entity `orders` in namespace `contoso-eventhub`.

