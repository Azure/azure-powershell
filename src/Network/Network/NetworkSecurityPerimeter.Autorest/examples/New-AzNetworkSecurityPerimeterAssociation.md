### Example 1: Creates a NetworkSecurityPerimeterAccessAssociation
```powershell

 $profileId = '/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/nsp3/profiles/profile2'
 $privateLinkResourceId = '/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.KeyVault/vaults/rp4'
 New-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1 -Location eastus2euap -AccessMode Learning -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId

```

```output

Location Name
-------- ----
         association1


```
Creates a NetworkSecurityPerimeterAccessAssociation
