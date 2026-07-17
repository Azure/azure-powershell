### Example 1: Link a pending connection by ID

```powershell
$sendSideConnection = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -ConnectionName SendConnection01
Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName ResourceGroup02 -ConnectionName ReceiveConnection01 -PendingConnectionId $sendSideConnection.Id -StatusReason "Linking approved" -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/ReceiveConnection01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Linking approved
LinkStatus                   : Linked
LinkedConnectionId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/SendConnection01
Location                     : eastus
Name                         : ReceiveConnection01
Pin                          : abcdefg
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : test@microsoft.com
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 00000000-0000-0000-0000-000000000000
RequirementId                : 0
ResourceGroupName            : ResourceGroup02
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : Approved
StatusReason                 : Approving for PS testing
SystemDataCreatedAt          : 5/30/2099 10:03:41 AM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/30/2099 10:04:57 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "creationTime": "2099-05-30T10:03:39.0878436Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example links a pending send side connection with the name `SendConnection01` to the receive side connection `ReceiveConnection01` within the resource group `ResourceGroup02` and provides a status reason.
