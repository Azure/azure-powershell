### Example 1: Get a specified connection
```powershell
Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01
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
Location                     : EastUS
Name                         : Connection01
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 0
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : InReview
StatusReason                 : 
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

This example retrieves a specific connection named `Connection01` within the resource group `ResourceGroup01`.

### Example 2: Get a list of connections in a resource group
```powershell
$connectionsInResourceGroup = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01
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
Location                     : EastUS
Name                         : Connection01
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 0
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : InReview
StatusReason                 : 
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

This example retrieves all connections in the resource group `ResourceGroup01`.

### Example 3: Get a list of connections in a subscription
```powershell
$connectionsInSubscription = Get-AzDataTransferConnection -SubscriptionId "00000000-0000-0000-0000-000000000000"
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
Location                     : EastUS
Name                         : Connection01
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 0
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : InReview
StatusReason                 : 
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

This example retrieves all connections in the subscription with the ID `00000000-0000-0000-0000-000000000000`.
