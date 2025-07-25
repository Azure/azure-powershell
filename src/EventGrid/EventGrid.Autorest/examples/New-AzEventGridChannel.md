### Example 1: Synchronously Create a new channel with the specified parameters.
```powershell
$dateObj = Get-Date -Year 2023 -Month 11 -Day 10 -Hour 11 -Minute 06 -Second 07
New-AzEventGridChannel -Name azps-channel -PartnerNamespaceName azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -ChannelType PartnerTopic -PartnerTopicInfoAzureSubscriptionId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -PartnerTopicInfoResourceGroupName "azps_test_group_eventgrid2" -PartnerTopicInfoName "default" -PartnerTopicInfoSource "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Synchronously Create a new channel with the specified parameters.