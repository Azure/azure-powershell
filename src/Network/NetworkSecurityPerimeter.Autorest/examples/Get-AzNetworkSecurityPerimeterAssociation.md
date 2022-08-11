### Example 1: {{ Add title here }}
```powershell

 Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         association1
         association3


```
List NetworkSecurityPerimeterAccessAssociation

### Example 2: Gets a NetworkSecurityPerimeterAccessAssociation by Name

```powershell

 Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         association3


```
Gets a NetworkSecurityPerimeterAccessAssociation by Name

### Example 3: Gets a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
```powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3     Get-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj

```

```output

Location Name
-------- ----
         association3


```
Gets a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
