### Example 1: {{ Add title here }}
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid2 -Name azps-registration
New-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid2 -Location eastus -partnerRegistrationImmutableId $partnerRegistration.ImmutableId -Source "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc "2023-11-17T11:06:13.109Z" -PartnerTopicFriendlyDescription "Example description" -MessageForActivation "Example message for activation"
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid2
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

