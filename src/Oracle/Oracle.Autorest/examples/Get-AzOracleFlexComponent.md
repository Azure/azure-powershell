### Example 1: Get Oracle Flex Component
```powershell
Get-AzOracleFlexComponent -Location "eastus"
```

```output
minimumCoreCount           : 16
availableCoreCount         : 11
availableDbStorageInGbs    : 8
runtimeMinimumCoreCount    : 13
shape                      : Exadata.X11M
availableMemoryInGbs       : 15
availableLocalStorageInGbs : 13
computeModel               : ECPU
hardwareType               : COMPUTE
descriptionSummary         : The description summary for this Flex Component
id                         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Oracle.Database/flexComponents/name
name                       : fc
type                       : Oracle.Database/flexComponents
createdBy                  : ilrpjodjmvzhybazxipoplnql
createdByType              : User
createdAt                  : 2024-12-09T21:02:12.592Z
lastModifiedBy             : lhjbxchqkaia
lastModifiedByType         : User
lastModifiedAt             : 2024-12-09T21:02:12.592Z
```

Get a list of flex component by location.
For more information, execute `Get-Help Get-AzOracleFlexComponent`.