### Example 1: Create a new Move collection. (RegionToRegion)
```powershell
New-AzResourceMoverMoveCollection -Name "PS-centralus-westcentralus-demoRMS"  -ResourceGroupName "RG-MoveCollection-demoRMS" -SourceRegion "centralus" -TargetRegion "westcentralus" -Location "centraluseuap" -IdentityType "SystemAssigned"
```

```output
Etag                                   Location      Name
----                                   --------      ----
"0200d92f-0000-3300-0000-6021e9ec0000" centraluseuap PS-centralus-westcentralus-demoRMs
```

Create a new Move Collection for moving resources across regions. **Please note that here the moveType is set to its default value 'RegionToRegion' for cross region move scenarios where 'SourceRegion' and 'TargetRegion' are required parameters. Please ensure 'MoveRegion' parameter is not required and should be set to null, as shown in the above example.**

### Example 2: Create a new Move collection. (RegionToZone)
```powershell
New-AzResourceMoverMoveCollection -Name "PS-demo-RegionToZone"  -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveRegion "eastus" -Location "eastus2euap" -IdentityType "SystemAssigned" -MoveType "RegionToZone"
```

```output
Etag                                   Location    Name
----                                   --------    ----
"01000d98-0000-3400-0000-64f707c40000" eastus2euap PS-demo-RegionToZone
```

Create a new Move Collection for moving resources into a zone within the same region.
**Please note that for 'RegionToZone' type move collections 'MoveType' parameter should be set as 'RegionToZone' and 'MoveRegion' should be set as the location where resources undergoing zonal move reside. Please ensure 'SourceRegion' and 'TargetRegion' are not required and should be set to null, as shown in the above example.**