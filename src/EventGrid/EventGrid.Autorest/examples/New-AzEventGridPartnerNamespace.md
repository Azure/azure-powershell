### Example 1: Asynchronously creates a new partner namespace with the specified parameters.
```powershell
New-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -PartnerTopicRoutingMode SourceEventAttribute -PartnerRegistrationFullyQualifiedId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/partnerRegistrations/azps-registration"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

Asynchronously creates a new partner namespace with the specified parameters.

### Example 2: Asynchronously creates a new partner namespace with the specified parameters.
```powershell
New-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -PartnerTopicRoutingMode ChannelNameHeader -PartnerRegistrationFullyQualifiedId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/partnerRegistrations/azps-registration"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

Asynchronously creates a new partner namespace with the specified parameters.