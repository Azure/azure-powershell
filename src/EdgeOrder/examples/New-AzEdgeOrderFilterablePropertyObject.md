### Example 1: Filterable property object 
```powershell
<<<<<<< HEAD
$filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
$filterableProperty | Format-List
```

```output
=======
PS C:\> $filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
PS C:\> $filterableProperty | fl

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
SupportedValue : {US}
Type           : ShipToCountries
```

ShipToCountries is mandatory filterable type, SupportedValue can be list of 2 letter valid ISO country codes.