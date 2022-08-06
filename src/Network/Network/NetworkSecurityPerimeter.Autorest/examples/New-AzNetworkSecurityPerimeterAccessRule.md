### Example 1: Creates a NetworkSecurityPerimeterAccessRule
```powershell

 New-AzNetworkSecurityPerimeterAccessRule -Name accessRule1 -ProfileName profile2 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location eastus2euap

```

```output

Location Name
-------- ----
         accessRule1


```
Creates a NetworkSecurityPerimeterAccessRule

### Example 2: Creates a NetworkSecurityPerimeterAccessRule
```powershell

$perimeter1 = @{
  id='/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/kaushal-nsp1'
  perimeterGuid=''
  location='eastus2euap'
}

$perimeter2 = @{
  id='/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/kk-nsp4'
  perimeterGuid='bcf8bf02-8b8a-4bcb-933d-2b575d94ec8f'
  location='eastus2euap'
}

$networkSecurityPerimeters  =  @($perimeter1,$perimeter2)

New-AzNetworkSecurityPerimeterAccessRule -Name 'perimeter-ar' -NetworkSecurityPerimeterName 'testt-nsp1'  -ProfileName = 't-profile2'  -ResourceGroupName = 'ResourceGroup-1'  -Direction 'Inbound' -Location = 'eastus2euap' -NetworkSecurityPerimeters $networkSecurityPerimeters

```

```output

Location Name
-------- ----
         perimeter_ar

```
Creates a NetworkSecurityPerimeterAccessRule