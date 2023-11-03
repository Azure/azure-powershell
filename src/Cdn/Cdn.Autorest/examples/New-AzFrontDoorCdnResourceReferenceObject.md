### Example 1: Create an in-memory object for AzureCDN ResourceReference
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
```

```output
Id
--
/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/testps-rg-da16jm/providers/Microsoft.Cdn/profiles/fdp-v542q6/secrets/secret001
```

Create an in-memory object for AzureCDN ResourceReference
