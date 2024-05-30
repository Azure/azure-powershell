### Example 1: Authorize a single partner either by partner registration immutable Id or by partner name.
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
Grant-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -AuthorizationExpirationTimeInUtc "2024-01-09T09:31:42.521Z" -PartnerName default -PartnerRegistrationImmutableId $partnerRegistration.ImmutableId
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Authorize a single partner either by partner registration immutable Id or by partner name.