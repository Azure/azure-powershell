### Example 1: Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation
```powershell
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
```

```output
PatternsToMatch
---------------
{/*}
```

Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation
