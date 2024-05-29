### Example 1: Updates a NetworkSecurityPerimeterAccessAssociation

```powershell

 Update-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1 -AccessMode Enforced

```

```output
Location Name
-------- ----
         association1


```
Updates a NetworkSecurityPerimeterAccessAssociation

### Example 2: Updates a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)

```powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1
 Update-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj -AccessMode Learning

```

```output
Location Name
-------- ----
         association1

```
Updates a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
