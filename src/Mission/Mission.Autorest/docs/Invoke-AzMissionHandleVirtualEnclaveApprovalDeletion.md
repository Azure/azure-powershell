---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/invoke-azmissionhandlevirtualenclaveapprovaldeletion
schema: 2.0.0
---

# Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion

## SYNOPSIS
Callback that triggers on approval deletion state change.

## SYNTAX

### HandleExpanded (Default)
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -ResourceGroupName <String> -VirtualEnclaveName <String>
 -ResourceRequestAction <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Handle
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -ResourceGroupName <String> -VirtualEnclaveName <String>
 -Body <IApprovalDeletionCallbackRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### HandleViaIdentity
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -InputObject <IMissionIdentity>
 -Body <IApprovalDeletionCallbackRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### HandleViaIdentityExpanded
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -InputObject <IMissionIdentity>
 -ResourceRequestAction <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### HandleViaJsonFilePath
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -ResourceGroupName <String> -VirtualEnclaveName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### HandleViaJsonString
```
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -ResourceGroupName <String> -VirtualEnclaveName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Callback that triggers on approval deletion state change.

## EXAMPLES

### Example 1: Handle a virtual enclave deletion-approval callback
```powershell
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **delete** request for the `contoso-enclave` virtual enclave has been `Approved`, allowing deletion to proceed.

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

### -Body
Request body for calling post-action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalDeletionCallbackRequest
Parameter Sets: Handle, HandleViaIdentity
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
Parameter Sets: HandleViaIdentity, HandleViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Handle operation

```yaml
Type: System.String
Parameter Sets: HandleViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Handle operation

```yaml
Type: System.String
Parameter Sets: HandleViaJsonString
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Handle, HandleExpanded, HandleViaJsonFilePath, HandleViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestAction
Resource request action indicating action which needed to be performed upon calling approval-deletion-callback post action

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaIdentityExpanded
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
Type: System.String
Parameter Sets: Handle, HandleExpanded, HandleViaJsonFilePath, HandleViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualEnclaveName
The name of the enclaveResource Resource

```yaml
Type: System.String
Parameter Sets: Handle, HandleExpanded, HandleViaJsonFilePath, HandleViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalDeletionCallbackRequest

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalActionResponse

## NOTES

## RELATED LINKS

