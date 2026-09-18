### Example 1: Deny a connection request by ID
```powershell
$connectionToDeny = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01
Deny-AzDataTransferConnection -PipelineName Pipeline01 -ResourceGroupName ResourceGroup01 -ConnectionId $connectionToDeny.Id -StatusReason "Not Authorized for processing" -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Required for data export
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : eastus
Name                         : Connection01
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : user@example.com
ProvisioningState            : Accepted
RemoteSubscriptionId         : 
RequirementId                : 123
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : {admin@example.com}
Status                       : Rejected
StatusReason                 : Not Authorized for processing
SystemDataCreatedAt          : 6/10/2099 12:29:23 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/10/2099 12:29:23 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "Production",
                                 "creationTime": "2099-06-10T12:29:21.4319497Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example denies a connection request using the ID for `Connection01` in the pipeline `Pipeline01` within the resource group `ResourceGroup01` and provides a status reason for the rejection.
