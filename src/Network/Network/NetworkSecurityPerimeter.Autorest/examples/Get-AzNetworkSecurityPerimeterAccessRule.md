### Example 1: List NetworkSecurityPerimeterAccessRule

```powershell

 Get-AzNetworkSecurityPerimeterAccessRule -ProfileName profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         ar4
         ar3


```
List NetworkSecurityPerimeterAccessRule

### Example 2: Gets a NetworkSecurityPerimeterAccessRule by Name
```powershell

 Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ProfileName profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         ar3


```
Gets a NetworkSecurityPerimeterAccessRule by Name

### Example 3: Gets a NetworkSecurityPerimeterAccessRule by identity (using pipe)
```powershell

 Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ProfileName profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj

```

```output

Location Name
-------- ----
         ar3

```
Gets a NetworkSecurityPerimeterAccessRule by identity (using pipe)
