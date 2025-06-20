### Example 1: Approve a connection request by ID
```powershell
$connectionToApprove = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01
Approve-AzDataTransferConnection -PipelineName Pipeline01 -ResourceGroupName ResourceGroup01 -ConnectionId $connectionToApprove.Id -StatusReason "Approved for processing" -Confirm:$false
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
Justification                : Required for data processing
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : eastus
Name                         : Connection01
Pin                          : ABCDEFG
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Accepted
RemoteSubscriptionId         : 
RequirementId                : 0
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : Approved
StatusReason                 : Approved for processing
SystemDataCreatedAt          : 6/10/2099 11:47:31 AM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/10/2099 11:47:31 AM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "creationTime": "2099-06-10T11:47:28.6330313Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example approves a connection request using the ID of `Connection01` in the pipeline `Pipeline01` within the resource group `ResourceGroup01` and provides a status reason. The approved connection response returns the updated status and the PIN.
