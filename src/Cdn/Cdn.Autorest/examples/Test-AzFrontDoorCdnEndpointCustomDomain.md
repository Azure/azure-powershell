### Example 1: Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint
```powershell
Test-AzFrontDoorCdnEndpointCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -HostName "pstest001.dev.cdn.azure.cn"
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint


### Example 2: Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint via identity 
```powershell
Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 | Test-AzFrontDoorCdnEndpointCustomDomain -HostName "pstest001.dev.cdn.azure.cn"
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint via identity 
