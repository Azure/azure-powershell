### Example 1: List NetworkSecurityPerimeter

```powershell

 Get-AzNetworkSecurityPerimeter -ResourceGroupName ResourceGroup-1

```

```output

Location    Name
--------    ----
eastus2euap nsp4
eastus2euap nsp3
eastus2euap nsp1
eastus2euap nsp6
eastus2euap nsp5


```
List NetworkSecurityPerimeter


### Example 2: Gets a NetworkSecurityPerimeter by Name

```powershell

 Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1

```

```output

Location    Name
--------    ----
eastus2euap nsp3


```
Gets a NetworkSecurityPerimeter by Name


### Example 3: Gets a NetworkSecurityPerimeter by identity (using pipe)

```powershell

 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1
 $GETObjViaIdentity = Get-AzNetworkSecurityPerimeter -InputObject $GETObj

```

```output

Location    Name
--------    ----
eastus2euap nsp3

```
Gets a NetworkSecurityPerimeter by identity (using pipe)