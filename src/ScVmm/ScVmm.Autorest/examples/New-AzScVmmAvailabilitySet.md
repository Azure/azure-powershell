### Example 1: Create Availability Set resource
```powershell
New-AzScVmmAvailabilitySet -Name "test-avset" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -AvailabilitySetName "test-av-01" -Location "eastus" -VmmServerName "test-vmmserver-01"
```

```output
AvailabilitySetName          : test-avset
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset
Location                     : eastus
Name                         : test-avset
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/availabilitysets
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command creates a Availability Set resource named `test-avset` in the resource group named `test-rg-01`.

To enable resource in the same Resource Group as VMM Sever resource resides execute the command with `-VmmServerName`.

To enable resource in a different Resource Group than the one where VMM Server resource resides execute the command with `-VmmServerId` and `-CustomLocationId` in place of `-VmmServerName`.
`VmmServerId` can be retrieved using `Get-AzScVmmServer` (check for `Id` property in the response).
`CustomLocationId` can be retrieved using `Get-AzScVmmServer` (check for `ExtendedLocationName` property in the response).
