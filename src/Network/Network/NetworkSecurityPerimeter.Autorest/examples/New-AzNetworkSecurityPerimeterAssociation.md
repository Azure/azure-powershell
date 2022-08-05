### Example 1: Creates a NetworkSecurityPerimeterAccessAssociation
```powershell

 $profileId = '/subscriptions/3846cb0f-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/kumarkaushal-PS-RG-1/providers/Microsoft.Network/networkSecurityPerimeters/nsp3/profiles/profile2'
 $privateLinkResourceId = '/subscriptions/3846cb0f-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/kumarkaushal-PS-RG-1/providers/Microsoft.KeyVault/vaults/rp4'
 New-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName kumarkaushal-PS-RG-1 -Location eastus2euap -AccessMode Learning -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId

```

```output

Location Name
-------- ----
         association1


```
Creates a NetworkSecurityPerimeterAccessAssociation
