### Example 1: Synchronously Create a partner configuration with the specified parameters.
```powershell
$partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -Name "Auth0" -RegistrationImmutableId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10 -PartnerAuthorizationAuthorizedPartnersList $partner
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously Create a partner configuration with the specified parameters.

### Example 2: Synchronously Create a partner configuration with the specified parameters.
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
$partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -RegistrationImmutableId $partnerRegistration.ImmutableId
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10 -PartnerAuthorizationAuthorizedPartnersList $partner
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously Create a partner configuration with the specified parameters.