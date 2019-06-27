---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/move-azresource
schema: 2.0.0
---

# Move-AzResource

## SYNOPSIS
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
When moving resources, both the source group and the target group are locked for the duration of the operation.
Write and delete operations are blocked on the groups until the move completes.

## SYNTAX

### Move (Default)
```
Move-AzResource -SourceResourceGroupName <String> -SubscriptionId <String> [-Parameter <IResourcesMoveInfo>]
 [-PassThru] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MoveByComponents
```
Move-AzResource -SourceResourceGroupName <String> -SubscriptionId <String> -TargetResourceGroupName <String>
 [-PassThru] [-Resource <String[]>] [-TargetSubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MoveExpanded
```
Move-AzResource -SourceResourceGroupName <String> -SubscriptionId <String> [-PassThru] [-Resource <String[]>]
 [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### MoveViaIdentityExpanded
```
Move-AzResource -InputObject <IResourcesIdentity> [-PassThru] [-Resource <String[]>]
 [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### MoveViaIdentity
```
Move-AzResource -InputObject <IResourcesIdentity> [-Parameter <IResourcesMoveInfo>] [-PassThru]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
When moving resources, both the source group and the target group are locked for the duration of the operation.
Write and delete operations are blocked on the groups until the move completes.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: MoveViaIdentityExpanded, MoveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Parameters of move resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourcesMoveInfo
Parameter Sets: Move, MoveViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Resource
The IDs of the resources.

```yaml
Type: System.String[]
Parameter Sets: MoveByComponents, MoveExpanded, MoveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceResourceGroupName
The name of the resource group containing the resources to move.

```yaml
Type: System.String
Parameter Sets: Move, MoveByComponents, MoveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Move, MoveByComponents, MoveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceGroup
The target resource group.

```yaml
Type: System.String
Parameter Sets: MoveExpanded, MoveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceGroupName
The target resource group name.

```yaml
Type: System.String
Parameter Sets: MoveByComponents
Aliases: DestinationResourceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetSubscriptionId
The target subscription id.
If not value is provided, the subscription id of the current context will be used.

```yaml
Type: System.String
Parameter Sets: MoveByComponents
Aliases: DestinationSubscriptionId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourcesMoveInfo

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## RELATED LINKS

