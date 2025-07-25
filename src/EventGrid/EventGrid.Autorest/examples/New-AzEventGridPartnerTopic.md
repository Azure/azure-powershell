### Example 1: Asynchronously creates a new partner topic with the specified parameters.
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
New-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid -Location eastus -partnerRegistrationImmutableId $partnerRegistration.ImmutableId -Source "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc "2023-11-17T11:06:13.109Z" -PartnerTopicFriendlyDescription "Example description" -MessageForActivation "Example message for activation"
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Asynchronously creates a new partner topic with the specified parameters.