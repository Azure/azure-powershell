### Example 1: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace $env.ProviderNamespace -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"
```



### Example 2: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace $env.ProviderNamespace -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"
```


