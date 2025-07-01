---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/approve-azdatatransferconnection
schema: 2.0.0
---

# Approve-AzDataTransferConnection

## SYNOPSIS
Approves the specified connection request in a pipeline.

## SYNTAX

### ApproveExpanded (Default)
```
Approve-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -ConnectionId <String>
 [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Approve
```
Approve-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String>
 -Connection <IResourceBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApproveViaIdentity
```
Approve-AzDataTransferConnection -InputObject <IDataTransferIdentity> -Connection <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApproveViaIdentityExpanded
```
Approve-AzDataTransferConnection -InputObject <IDataTransferIdentity> -ConnectionId <String>
 [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ApproveViaJsonFilePath
```
Approve-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ApproveViaJsonString
```
Approve-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Approves the specified connection request in a pipeline.

## EXAMPLES

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

This example approves a connection request using the ID of `Connection01` in the pipeline `Pipeline01` within the resource group `ResourceGroup01` and provides a status reason.
The approved connection response returns the updated status and the PIN.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
The resource to reference.

```yaml
Type: ADT.Models.IResourceBody
Parameter Sets: Approve, ApproveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectionId
ID of the resource.

```yaml
Type: System.String
Parameter Sets: ApproveExpanded, ApproveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: ApproveViaIdentity, ApproveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Approve operation

```yaml
Type: System.String
Parameter Sets: ApproveViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Approve operation

```yaml
Type: System.String
Parameter Sets: ApproveViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PipelineName
The name for the pipeline to perform the operation on.

```yaml
Type: System.String
Parameter Sets: Approve, ApproveExpanded, ApproveViaJsonFilePath, ApproveViaJsonString
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
Parameter Sets: Approve, ApproveExpanded, ApproveViaJsonFilePath, ApproveViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusReason
Reason for resource operation.

```yaml
Type: System.String
Parameter Sets: ApproveExpanded, ApproveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Approve, ApproveExpanded, ApproveViaJsonFilePath, ApproveViaJsonString
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

### ADT.Models.IResourceBody

## OUTPUTS

### ADT.Models.IConnection

## NOTES

## RELATED LINKS

