### Example 1: List available Oracle Database versions in a region
```powershell
Get-AzOracleDbVersion -Location eastus2
```

```output
...
Version                                       : 19c
VersionFull                                   : 19.22.0.0
IsDefault                                     : True
IsPreview                                     : False

Version                                       : 21c
VersionFull                                   : 21.10.0.0
IsDefault                                     : False
IsPreview                                     : True
```

Lists the available Oracle Database versions for **eastus2**. For more information, execute `Get-Help Get-AzOracleDbVersion`.

### Example 2: List versions for a specific shape
```powershell
Get-AzOracleDbVersion -Location eastus2
```

```output
Version                                       : 19c
VersionFull                                   : 19.22.0.0
IsDefault                                     : True
IsPreview                                     : False
```

Filters versions by compute shape. For more information, execute `Get-Help Get-AzOracleDbVersion`.
