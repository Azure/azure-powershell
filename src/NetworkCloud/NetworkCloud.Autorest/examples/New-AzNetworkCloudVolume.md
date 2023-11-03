### Example 1: Create volume
```powershell
New-AzNetworkCloudVolume -Name volumeName -ResourceGroupName resourceGroupName -ExtendedLocationName extendedLocation -ExtendedLocationType "CustomLocation " -Location location -SizeMiB size -Tag @{ tag = "newTag" }
```

```output
Location  Name           SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>       08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command creates a volume.
