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

 New-AzNetworkSecurityPerimeterAccessRule -Name accessRule2 -ProfileName profile2 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location eastus2euap

```

```output

Location Name
-------- ----
         accessRule2


```
Creates a NetworkSecurityPerimeterAccessRule
