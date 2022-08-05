### Example 1: Gets a NetworkSecurityPerimeterProfile by Name

```powershell

 Get-AzNetworkSecurityPerimeterProfile -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location    Name
--------    ----
eastus2euap profile1
eastus2euap profile2


```
Lists NetworkSecurityPerimeterProfile


### Example 2: Gets a NetworkSecurityPerimeterProfile by Name

```powershell

 Get-AzNetworkSecurityPerimeterProfile -Name profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location    Name
--------    ----
eastus2euap profile1


```
Gets a NetworkSecurityPerimeterProfile by Name


### Example 3: Gets a NetworkSecurityPerimeterProfile by identity (using pipe)

```powershell

 Get-AzNetworkSecurityPerimeterProfile -Name profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 Get-AzNetworkSecurityPerimeterProfile -InputObject $GETObj

```

```output

Location    Name
--------    ----
eastus2euap profile1


```
Gets a NetworkSecurityPerimeterProfile by identity (using pipe)

