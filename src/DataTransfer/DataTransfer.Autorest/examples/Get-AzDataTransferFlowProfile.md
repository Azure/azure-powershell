### Example 1: List all FlowProfiles in a pipeline
```powershell
Get-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
```

```output
Name                 ResourceGroupName Location Pipeline           ReplicationScenario Status  Description
----                 ----------------- -------- --------           ------------------- ------  -----------
files-flowprofile    ResourceGroup01   EastUS   Pipeline01         Files               Enabled Basic FlowProfile for file transfers
messaging-flowprofile ResourceGroup01  EastUS   Pipeline01         Messaging           Enabled Messaging FlowProfile with antivirus
api-flowprofile      ResourceGroup01   EastUS   Pipeline01         Api                 Enabled API FlowProfile with advanced security
```

Lists all FlowProfiles configured in the specified pipeline, showing their key properties including replication scenario, status, and description.

### Example 2: Get a specific FlowProfile by name
```powershell
Get-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "api-flowprofile"
```

```output
AntivirusAvSolution                 : {Defender}
ArchiveMaximumCompressionRatioLimit : 
ArchiveMaximumDepthLimit            : 
ArchiveMaximumExpansionSizeLimit    : 
ArchiveMinimumSizeForExpansion      : 
DataSizeMaximum                     : 
DataSizeMinimum                     : 
Description                         : API FlowProfile with advanced security
FlowProfileId                       : 12345678-1234-1234-1234-123456789012
Id                                  : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/api-flowprofile
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : None
IdentityUserAssignedIdentity        : {}
Location                            : EastUS
MimeFilter                          : 
MimeFilterType                      : 
Name                                : api-flowprofile
ProvisioningState                   : Succeeded
ReplicationScenario                 : Api
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

Retrieves detailed information about a specific FlowProfile, including advanced configuration such as Antivirus configuration.
