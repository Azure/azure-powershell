---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/invoke-azmissionhandlecommunityendpointapprovalcreation
schema: 2.0.0
---

# Invoke-AzMissionHandleCommunityEndpointApprovalCreation

## SYNOPSIS
Callback that triggers on approval state change.

## SYNTAX

### HandleExpanded (Default)
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String> -CommunityName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -ApprovalStatus <String>
 -ResourceRequestAction <String> [-ApprovalCallbackPayload <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### HandleViaJsonString
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String> -CommunityName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### HandleViaJsonFilePath
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String> -CommunityName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### HandleViaIdentityCommunityExpanded
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String>
 -CommunityInputObject <IMissionIdentity> -ApprovalStatus <String> -ResourceRequestAction <String>
 [-ApprovalCallbackPayload <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### HandleViaIdentityCommunity
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String>
 -CommunityInputObject <IMissionIdentity> -Body <IApprovalCallbackRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Handle
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName <String> -CommunityName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Body <IApprovalCallbackRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### HandleViaIdentityExpanded
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -InputObject <IMissionIdentity>
 -ApprovalStatus <String> -ResourceRequestAction <String> [-ApprovalCallbackPayload <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### HandleViaIdentity
```
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -InputObject <IMissionIdentity>
 -Body <IApprovalCallbackRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Callback that triggers on approval state change.

## EXAMPLES

### Example 1: Handle a community endpoint creation-approval callback
```powershell
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Create'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **create** request for the `contoso-endpoint` community endpoint has been `Approved`.

## PARAMETERS

### -ApprovalCallbackPayload
Payload requested by client upon approval action

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaIdentityCommunityExpanded, HandleViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApprovalStatus
Approval status indicating 'Approved' or 'Rejected'

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaIdentityCommunityExpanded, HandleViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalCallbackRequest
Parameter Sets: HandleViaIdentityCommunity, Handle, HandleViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CommunityEndpointName
The name of the Community Endpoint Resource

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaJsonString, HandleViaJsonFilePath, HandleViaIdentityCommunityExpanded, HandleViaIdentityCommunity, Handle
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommunityInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: HandleViaIdentityCommunityExpanded, HandleViaIdentityCommunity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CommunityName
The name of the communityResource Resource

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaJsonString, HandleViaJsonFilePath, Handle
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: HandleViaIdentityExpanded, HandleViaIdentity
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
Parameter Sets: HandleExpanded, HandleViaJsonString, HandleViaJsonFilePath, Handle
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestAction
Resource request action indicating action which needed to be performed upon calling approval-callback post action

```yaml
Type: System.String
Parameter Sets: HandleExpanded, HandleViaIdentityCommunityExpanded, HandleViaIdentityExpanded
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
Parameter Sets: HandleExpanded, HandleViaJsonString, HandleViaJsonFilePath, Handle
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalCallbackRequest

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalActionResponse

## NOTES

## RELATED LINKS
