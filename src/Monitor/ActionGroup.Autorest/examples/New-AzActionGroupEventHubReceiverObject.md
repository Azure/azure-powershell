### Example 1: create action group event hub receiver
```powershell
New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "testEventHubNameSpace" -Name "sample eventhub" -SubscriptionId "187f412d-1758-44d9-b052-169e2564721d" -TenantId "68a4459a-ccb8-493c-b9da-dd30457d1b84"
```

```output
EventHubName         : testEventHub
EventHubNameSpace    : testEventHubNameSpace
Name                 : sample eventhub
SubscriptionId       : 187f412d-1758-44d9-b052-169e2564721d
TenantId             : 68a4459a-ccb8-493c-b9da-dd30457d1b84
UseCommonAlertSchema : 
```

This command creates action group event hub receiver object.

### Example 2: create another action group event hub receiver
```powershell
New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "actiongrouptest" -Name "sample eventhub" -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f
```

```output
EventHubName         : testEventHub
EventHubNameSpace    : actiongrouptest
Name                 : sample eventhub
SubscriptionId       : 9e223dbe-3399-4e19-88eb-0975f02ac87f
TenantId             : 
UseCommonAlertSchema : 
```

This command creates another action group event hub receiver object.

