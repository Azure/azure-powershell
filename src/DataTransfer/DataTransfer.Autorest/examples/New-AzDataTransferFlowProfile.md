### Example 1: Create a basic FlowProfile for file transfers
```powershell
New-AzDataTransferFlowProfile -Name "files-flowprofile" -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Location "EastUS" -ReplicationScenario "Files" -Status "Enabled" -Description "Basic FlowProfile for standard file transfers"
```


```output
AntivirusAvSolution                 : {}
ArchiveMaximumCompressionRatioLimit : 
ArchiveMaximumDepthLimit            : 
ArchiveMaximumExpansionSizeLimit    : 
ArchiveMinimumSizeForExpansion      : 
DataSizeMaximum                     : 
DataSizeMinimum                     : 
Description                         : Basic FlowProfile for standard file transfers
FlowProfileId                       : 12345678-1234-1234-1234-123456789012
Id                                  : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : None
IdentityUserAssignedIdentity        : {}
Location                            : EastUS
MimeFilter                          : 
MimeFilterType                      : 
Name                                : files-flowprofile
ProvisioningState                   : Succeeded
ReplicationScenario                 : Files
ResourceGroupName                   : ResourceGroup01
Status                              : Enabled
SystemDataCreatedAt                 : 1/15/2024 10:30:00 AM
SystemDataCreatedBy                 : user@example.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 1/15/2024 10:30:00 AM
SystemDataLastModifiedBy            : user@example.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "environment": "production",
                                        "department": "IT"
                                      }
TextMatchingDeny                    : 
Type                                : microsoft.azuredatatransfer/pipelines/flowprofiles
XmlFilterDefaultNamespace           : 
XmlFilterReference                  : 
XmlFilterSchema                     : 
```

Creates a basic FlowProfile for file transfers with enabled status. This is the most common scenario for setting up file-based data transfer workflows.

### Example 2: Create a messaging FlowProfile with antivirus protection
```powershell
New-AzDataTransferFlowProfile -Name "messaging-flowprofile" -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Location "EastUS" -ReplicationScenario "Messaging" -Status "Enabled" -Description "Messaging FlowProfile with antivirus scanning" -AntivirusAvSolution @("Defender")
```


```output
AntivirusAvSolution                 : {Defender}
ArchiveMaximumCompressionRatioLimit : 
ArchiveMaximumDepthLimit            : 
ArchiveMaximumExpansionSizeLimit    : 
ArchiveMinimumSizeForExpansion      : 
DataSizeMaximum                     : 
DataSizeMinimum                     : 
Description                         : Messaging FlowProfile with antivirus scanning
FlowProfileId                       : 12345678-1234-1234-1234-123456789abc
Id                                  : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/messaging-flowprofile
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : None
IdentityUserAssignedIdentity        : {}
Location                            : EastUS
MimeFilter                          : 
MimeFilterType                      : 
Name                                : messaging-flowprofile
ProvisioningState                   : Succeeded
ReplicationScenario                 : Messaging
ResourceGroupName                   : ResourceGroup01
Status                              : Enabled
SystemDataCreatedAt                 : 1/15/2024 10:30:00 AM
SystemDataCreatedBy                 : user@example.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 1/15/2024 10:30:00 AM
SystemDataLastModifiedBy            : user@example.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "environment": "production",
                                        "department": "IT"
                                      }
TextMatchingDeny                    : 
Type                                : microsoft.azuredatatransfer/pipelines/flowprofiles
XmlFilterDefaultNamespace           : 
XmlFilterReference                  : 
XmlFilterSchema                     : 
```

Creates a FlowProfile for messaging scenarios with Microsoft Defender antivirus protection enabled. This ensures secure data transfer for message-based workflows.
