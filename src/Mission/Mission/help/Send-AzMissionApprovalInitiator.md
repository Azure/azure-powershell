---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/send-azmissionapprovalinitiator
schema: 2.0.0
---

# Send-AzMissionApprovalInitiator

## SYNOPSIS
Upon receiving approval or rejection from approver, this facilitates actions on approval resource

## SYNTAX

### NotifyExpanded (Default)
```
Send-AzMissionApprovalInitiator -ApprovalName <String> -ResourceUri <String> -ApprovalStatus <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### NotifyViaJsonString
```
Send-AzMissionApprovalInitiator -ApprovalName <String> -ResourceUri <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### NotifyViaJsonFilePath
```
Send-AzMissionApprovalInitiator -ApprovalName <String> -ResourceUri <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Notify
```
Send-AzMissionApprovalInitiator -ApprovalName <String> -ResourceUri <String> -Body <IApprovalActionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### NotifyViaIdentityExpanded
```
Send-AzMissionApprovalInitiator -InputObject <IMissionIdentity> -ApprovalStatus <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### NotifyViaIdentity
```
Send-AzMissionApprovalInitiator -InputObject <IMissionIdentity> -Body <IApprovalActionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Upon receiving approval or rejection from approver, this facilitates actions on approval resource

## EXAMPLES

### Example 1: Notify the approval initiator of a decision
```powershell
$resourceUri = 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection'
Send-AzMissionApprovalInitiator -ApprovalName 'contoso-approval' -ResourceUri $resourceUri -ApprovalStatus 'Approved'
```

```output
Message
-------
Approved
```

Notifies the initiator of the `contoso-approval` approval (scoped to the `contoso-connection` enclave connection) that the request has been `Approved`.

## PARAMETERS

### -ApprovalName
The name of the approvals resource.

```yaml
Type: System.String
Parameter Sets: NotifyExpanded, NotifyViaJsonString, NotifyViaJsonFilePath, Notify
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApprovalStatus
Approval status indicating 'Approved' or 'Rejected'

```yaml
Type: System.String
Parameter Sets: NotifyExpanded, NotifyViaIdentityExpanded
Aliases:

Required: True
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

### -Body
Request body for calling post-action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalActionRequest
Parameter Sets: Notify, NotifyViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: NotifyViaIdentityExpanded, NotifyViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Notify operation

```yaml
Type: System.String
Parameter Sets: NotifyViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Notify operation

```yaml
Type: System.String
Parameter Sets: NotifyViaJsonString
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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: NotifyExpanded, NotifyViaJsonString, NotifyViaJsonFilePath, Notify
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalActionRequest

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalActionResponse

## NOTES

## RELATED LINKS
