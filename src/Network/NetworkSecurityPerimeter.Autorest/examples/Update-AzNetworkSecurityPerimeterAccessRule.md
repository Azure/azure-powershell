
### Example 1: Updates a NetworkSecurityPerimeterAccessRule

```powershell

 Update-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -ProfileName profile1  -AddressPrefix @('10.10.0.0/17')

```

```output

Location Name
-------- ----
         ar3


```
Updates a NetworkSecurityPerimeterAccessRule

### Example 2: Updates a NetworkSecurityPerimeterAccessRule by identity (using pipe)

```powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -ProfileName profile1
 Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -AddressPrefix @('10.0.0.0/16')

```

```output
Location Name
-------- ----
         ar3


```
Updates a NetworkSecurityPerimeterAccessRule by identity (using pipe)
