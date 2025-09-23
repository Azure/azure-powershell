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

### List (Default)
```
Get-AzDataTransferFlowProfile -PipelineName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityPipeline
```
Get-AzDataTransferFlowProfile -Name <String> -PipelineInputObject <IDataTransferIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataTransferFlowProfile -Name <String> -PipelineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataTransferFlowProfile -InputObject <IDataTransferIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
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
Name                 : api-flowprofile
ResourceGroupName    : ResourceGroup01
Location             : EastUS
Pipeline            : Pipeline01
ReplicationScenario  : Api
Status              : Enabled
Description         : API FlowProfile with advanced security
MimeFilter          : {application/json, application/xml, text/plain}
TextMatchingPattern : {*.log, *.txt, *.json}
FlowProfileId       : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/api-flowprofile
CreatedTime         : 2025-09-23T10:30:15Z
ModifiedTime        : 2025-09-23T10:30:15Z
```

Retrieves detailed information about a specific FlowProfile, including advanced configuration such as MIME filters, text matching patterns, and timestamps.

## PARAMETERS

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ADT.Models.IDataTransferIdentity

## OUTPUTS

### ADT.Models.IFlowProfile

## NOTES

## RELATED LINKS
