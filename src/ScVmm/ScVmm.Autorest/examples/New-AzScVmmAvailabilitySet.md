### Example 1: Create Availability Set resource
```powershell
New-AzScVmmAvailabilitySet -Name "test-avset" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -Location "eastus" -ExtendedLocationType "customLocation" -ExtendedLocationName "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourcegroups/test-rg-01/providers/microsoft.extendedlocation/customlocations/test-cl" -VmmServerId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VMMServers/test-vmmserver-01"
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
