---
external help file: Az.DataTransfer-help.xml
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferflowprofile
schema: 2.0.0
---

# Get-AzDataTransferFlowProfile

## SYNOPSIS
Retrieves the specified FlowProfile resource.

## SYNTAX

### ListExpanded (Default)
```
Get-AzDataTransferFlowProfile [-PipelineName <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentityPipeline
```
Get-AzDataTransferFlowProfile -Name <String> -PipelineInputObject <IDataTransferIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get
```
Get-AzDataTransferFlowProfile -Name <String> -PipelineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### List1
```
Get-AzDataTransferFlowProfile -PipelineName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataTransferFlowProfile -InputObject <IDataTransferIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzDataTransferFlowProfile -Body <IListFlowProfilesRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzDataTransferFlowProfile -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzDataTransferFlowProfile -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Retrieves the specified FlowProfile resource.

## EXAMPLES

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

## PARAMETERS

### -Body
Defines the required request body for retrieving FlowProfile information for a provided pipeline.

```yaml
Type: ADT.Models.IListFlowProfilesRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the FlowProfile resource to operate on.
Must be 3 to 64 characters long and contain only alphanumeric characters or hyphens.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPipeline, Get
Aliases: FlowProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PipelineInputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: GetViaIdentityPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PipelineName
The name of the pipeline on which to operate.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ADT.Models.IDataTransferIdentity

### ADT.Models.IListFlowProfilesRequest

## OUTPUTS

### ADT.Models.IFlowProfile

### ADT.Models.IFlowProfileMetadata

## NOTES

## RELATED LINKS
