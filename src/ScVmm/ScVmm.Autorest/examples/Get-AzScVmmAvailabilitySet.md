### Example 1: Get Availability Set By Subscription Id
```powershell
Get-AzScVmmAvailabilitySet -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName ProvisioningState
----            ----------------- -----------------
test-avset      test-rg-01        Succeeded
test-avset-02   test-rg-01        Succeeded
test-avset-03   test-rg-01        Succeeded
test-avset-04   test-rg-02        Succeeded
test-avset-05   test-rg-02        Succeeded
test-avset-06   test-rg-03        Succeeded
```

This command list Availability Sets in provided subscription.

### Example 2: Get Availability Set By Resource Group
```powershell
Get-AzScVmmAvailabilitySet -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName ProvisioningState
----            ----------------- -----------------
test-avset      test-rg-01        Succeeded
test-avset-02   test-rg-01        Succeeded
test-avset-03   test-rg-01        Succeeded
```

This command list Availability Sets in provided Resource Group.

### Example 3: Get Availability Set
```powershell
Get-AzScVmmAvailabilitySet -Name "test-avset" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
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

This command gets the Availability Set named `test-avset` in the resource group named `test-rg-01`.