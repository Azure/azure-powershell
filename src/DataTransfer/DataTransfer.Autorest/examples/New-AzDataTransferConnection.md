### Example 1: Create a new Receive side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -PipelineName Pipeline01 -Name Connection01 -Location "EastUS" -Direction "Receive" -FlowType "Mission" -RequirementId 123 -Justification "Required for 
data processing" -RemoteSubscriptionId 11111111-1111-1111-1111-111111111111 -Confirm:$false
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
RemoteSubscriptionId         : 11111111-1111-1111-1111-111111111111
RequirementId                : 123
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : InReview
StatusReason                 : 
SystemDataCreatedAt          : 10/10/2099 11:47:31 AM
SystemDataCreatedBy          : tes@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/10/2099 11:47:31 AM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "creationTime": "2099-12-12T12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection01` under the pipeline `Pipeline01`in the resource group `ResourceGroup01` located in the `EastUS` region with basic parameters direction, flow type, and justification.

### Example 2: Create a new Send side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup02 -PipelineName Pipeline01 -Name Connection02 -Location "WestUS" -Direction "Send" -PIN "ABCDEFG" -FlowType "Mission" -Justification "Required for data processing" -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 12/12/2099 12:19:41 PM
Direction                    : Send
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/Connection02
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Required for data processing
LinkStatus                   : 
LinkedConnectionId           : 
Location                     : WestUS
Name                         : Connection02
Pin                          : ABCDEFG
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 
ResourceGroupName            : ResourceGroup02
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : Approved
StatusReason                 : 
SystemDataCreatedAt          : 12/12/2099 12:19:32 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/12/2099 12:19:32 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "creationTime": "2099-12-12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection02` under the pipeline `Pipeline01` in the resource group `ResourceGroup02` located in the `WestUS` region with basic parameters direction, flow type, and justification.

### Example 3: Create a new connection with additional parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection03 -PipelineName Pipeline01 -Location "EastUS" -Direction "Receive" -FlowType "Mission"  -RequirementId 123 -Justification "Required for data export" -PrimaryContact "user@example.com" -SecondaryContact "admin@example.com" -Tag @{Environment="Production"} -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection03
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Required for data export
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : EastUS
Name                         : Connection03
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : user@example.com
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 123
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : {admin@example.com}
Status                       : InReview
StatusReason                 : 
SystemDataCreatedAt          : 12/12/2099 12:29:23 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/12/2099 12:29:23 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "Environment": "Production",
                                 "creationTime": "2099-12-12T12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection03` in the resource group `ResourceGroup01` with additional parameters such as primary and secondary contacts and resource tags.

### Example 4: Create a connection using FlowProfile
```powershell
# First, create or reference existing FlowProfiles
$basicFlowProfile = @{
    Name = "files-flowprofile"
    Pipeline = "Pipeline01"
    FlowProfileId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile"
    ReplicationScenario = "Files"
    Status = "Enabled"
    Description = "Basic FlowProfile for file transfers"
}

$messagingFlowProfile = @{
    Name = "messaging-flowprofile"
    Pipeline = "Pipeline01"
    FlowProfileId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/messaging-flowprofile"
    ReplicationScenario = "Messaging"
    Status = "Enabled"
    Description = "Messaging FlowProfile with antivirus protection"
}

# Create connection with FlowProfiles
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -PipelineName Pipeline01 -Name Connection04 -Location "EastUS" -Direction "Receive" -FlowProfileList @($basicFlowProfile, $messagingFlowProfile) -RequirementId "FP-2025-001" -Justification "Modern connection using FlowProfile architecture for enhanced security and flexibility" -RemoteSubscriptionId "11111111-1111-1111-1111-111111111111" -PrimaryContact "dataowner@company.com" -SecondaryContact @("security@company.com", "operations@company.com") -Tag @{Environment="Production"; DataClassification="Sensitive"} -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowProfileList              : {files-flowprofile, messaging-flowprofile}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection04
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Modern connection using FlowProfile architecture for enhanced security and flexibility
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : EastUS
Name                         : Connection04
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : dataowner@company.com
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 11111111-1111-1111-1111-111111111111
RequirementId                : FP-2025-001
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : {security@company.com, operations@company.com}
Status                       : InReview
StatusReason                 : 
SystemDataCreatedAt          : 9/23/2025 2:15:45 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/23/2025 2:15:45 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "Environment": "Production",
                                 "DataClassification": "Sensitive",
                                 "creationTime": "2025-09-23T14:15:42.1234567Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example demonstrates the modern approach using FlowProfiles instead of the legacy FlowType parameter. It creates a connection named `Connection04` that supports multiple FlowProfiles (`files-flowprofile` and `messaging-flowprofile`), providing enhanced flexibility for different data transfer scenarios. The FlowProfile approach offers better security controls, MIME filtering, and antivirus protection capabilities compared to the traditional FlowType method. Note that FlowProfiles must be created first using `New-AzDataTransferFlowProfile` before they can be referenced in connections.
