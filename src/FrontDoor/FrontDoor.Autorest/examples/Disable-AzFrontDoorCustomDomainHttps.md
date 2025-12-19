### Example 1: Disable HTTPS for a custom domain with FrontDoorName and ResourceGroupName.
```powershell
Disable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz"
```

```output
$true
```

Disable HTTPS for a custom domain "frontendpointname1-custom-xyz" with FrontDoorName as "frontdoor1" and ResourceGroupName as "resourcegroup1".

### Example 2: Disable HTTPS for a custom domain with PSFrontendEndpoint object.
```powershell
Get-AzFrontDoorFrontendEndpoint -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -Name "frontendpointname1-custom-xyz" | Disable-AzFrontDoorCustomDomainHttps -InputObject $frontendEndpointObj 
```

```output
$true
```

Disable HTTPS for a custom domain with PSFrontendEndpoint object.