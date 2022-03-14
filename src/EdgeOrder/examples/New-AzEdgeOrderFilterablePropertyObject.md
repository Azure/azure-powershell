### Example 1: Filterable property object 
```powershell
$filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
$filterableProperty | fl
```

```output
SupportedValue : {US}
Type           : ShipToCountries
```

ShipToCountries is mandatory filterable type, SupportedValue can be list of 2 letter valid ISO country codes.