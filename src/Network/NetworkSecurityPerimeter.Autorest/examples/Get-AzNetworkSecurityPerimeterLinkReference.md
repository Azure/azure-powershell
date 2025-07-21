### Example 1: List NetworkSecurityPerimeter LinkReferences
```powershell
Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
Name                                                        ResourceGroupName
----                                                        -----------------
Ref-from-link-test-1-00000000-78f8-4f1b-8f30-ffe0eaa74495   rg-test-1
Ref-from-link-test-2-00000000-78f8-4f1b-8f30-ffe0eaa74496   rg-test-1
```

Lists network security link references

### Example 2: Get NetworkSecurityPerimeter LinkReference by Name
```powershell
Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -Name Ref-from-link-test-1-000000-29bb-4bc4-9297-676b337e6c74
```

```output
Description                  : Auto Approved.
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/linkReferences
                                /Ref-from-link-test-1-000000-29bb-4bc4-9297-676b337e6c74
LocalInboundProfile          : {*}
LocalOutboundProfile         : {*}
Name                         : Ref-from-link-test-1-000000-29bb-4bc4-9297-676b337e6c74
ProvisioningState            : Succeeded
RemoteInboundProfile         : {profile-test-1}
RemoteOutboundProfile        : {*}
RemotePerimeterGuid          : 000000-29bb-4bc4-9297-676b337e6c74
RemotePerimeterLocation      : eastus2euap
RemotePerimeterResourceId    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-2
ResourceGroupName            : rg-test-1
Status                       : Approved
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/linkReferences
```

Get NetworkSecurityPerimeter LinkReference by Name