### Example 1: Filterable property object 
```powershell
PS C:\> $filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
PS C:\> $filterableProperty | fl

SupportedValue : {US}
Type           : ShipToCountries
```

ShipToCountries is mandatory filterable type, SupportedValue can be list of 2 letter valid ISO country codes.