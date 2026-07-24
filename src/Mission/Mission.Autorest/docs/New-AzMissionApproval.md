---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/new-azmissionapproval
schema: 2.0.0
---

# New-AzMissionApproval

## SYNOPSIS
Create a ApprovalResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzMissionApproval -Name <String> -ResourceUri <String> [-Approver <IApprover[]>] [-CreatedAt <DateTime>]
 [-GrandparentResourceId <String>] [-ParentResourceId <String>]
 [-RequestMetadataApprovalCallbackPayload <String>] [-RequestMetadataApprovalCallbackRoute <String>]
 [-RequestMetadataApprovalStatus <String>] [-RequestMetadataResourceAction <String>]
 [-StateChangedAt <DateTime>] [-TicketId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMissionApproval -Name <String> -ResourceUri <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMissionApproval -Name <String> -ResourceUri <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a ApprovalResource

## EXAMPLES

### Example 1: Create an approval on a resource
```powershell
New-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection' -RequestMetadataApprovalStatus 'Pending' -RequestMetadataResourceAction 'Create' -TicketId 'INC0012345'
```

```output
Name             RequestMetadataApprovalStatus RequestMetadataResourceAction
----             ----------------------------- -----------------------------
contoso-approval Pending                       Create
```

Creates an approval named `contoso-approval` on the `contoso-connection` enclave connection, tracking a pending `Create` request under ticket `INC0012345`.

## PARAMETERS

### -Approver
List of approvers for the approval request

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprover[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -CreatedAt
Approval request creation time

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -GrandparentResourceId
Parameter for optimizing query results

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the approvals resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApprovalName

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

### -ParentResourceId
Parameter for optimizing query results

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMetadataApprovalCallbackPayload
Payload to be sent upon any action on approval request

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMetadataApprovalCallbackRoute
Route name for the approval callback

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMetadataApprovalStatus
Status of the approval.
Uses ApprovalStatus enum.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMetadataResourceAction
Resource Action of the item being approved or declined.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StateChangedAt
Approval request state change time, time at which approval request state changed from pending to approved or rejected.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TicketId
Ticket ID for the approval request

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalResource

## NOTES

## RELATED LINKS

