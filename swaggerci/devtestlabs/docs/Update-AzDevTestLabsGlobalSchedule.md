---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/update-azdevtestlabsglobalschedule
schema: 2.0.0
---

# Update-AzDevTestLabsGlobalSchedule

## SYNOPSIS
Updates a schedule's target resource Id.
This operation can take a while to complete.

## SYNTAX

### RetargetExpanded (Default)
```
Update-AzDevTestLabsGlobalSchedule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CurrentResourceId <String>] [-TargetResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Retarget
```
Update-AzDevTestLabsGlobalSchedule -Name <String> -ResourceGroupName <String>
 -RetargetScheduleProperty <IRetargetScheduleProperties> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RetargetViaIdentity
```
Update-AzDevTestLabsGlobalSchedule -InputObject <IDevTestLabsIdentity>
 -RetargetScheduleProperty <IRetargetScheduleProperties> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RetargetViaIdentityExpanded
```
Update-AzDevTestLabsGlobalSchedule -InputObject <IDevTestLabsIdentity> [-CurrentResourceId <String>]
 [-TargetResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzDevTestLabsGlobalSchedule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevTestLabsGlobalSchedule -InputObject <IDevTestLabsIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a schedule's target resource Id.
This operation can take a while to complete.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Retarget, RetargetExpanded, RetargetViaIdentity, RetargetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrentResourceId
The resource Id of the virtual machine on which the schedule operates

```yaml
Type: System.String
Parameter Sets: RetargetExpanded, RetargetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity
Parameter Sets: RetargetViaIdentity, RetargetViaIdentityExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the schedule.

```yaml
Type: System.String
Parameter Sets: Retarget, RetargetExpanded, UpdateExpanded
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
Parameter Sets: Retarget, RetargetExpanded, RetargetViaIdentity, RetargetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Retarget, RetargetExpanded, RetargetViaIdentity, RetargetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Retarget, RetargetExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetargetScheduleProperty
Properties for retargeting a virtual machine schedule.
To construct, see NOTES section for RETARGETSCHEDULEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IRetargetScheduleProperties
Parameter Sets: Retarget, RetargetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: Retarget, RetargetExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The resource Id of the virtual machine that the schedule should be retargeted to

```yaml
Type: System.String
Parameter Sets: RetargetExpanded, RetargetViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IRetargetScheduleProperties

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.ISchedule

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDevTestLabsIdentity>: Identity Parameter
  - `[ArtifactSourceName <String>]`: The name of the artifact source.
  - `[Id <String>]`: Resource identity path
  - `[LabName <String>]`: The name of the lab.
  - `[LocationName <String>]`: The name of the location.
  - `[Name <String>]`: The name of the lab.
  - `[PolicySetName <String>]`: The name of the policy set.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ServiceFabricName <String>]`: The name of the service fabric.
  - `[SubscriptionId <String>]`: The subscription ID.
  - `[UserName <String>]`: The name of the user profile.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.

RETARGETSCHEDULEPROPERTY <IRetargetScheduleProperties>: Properties for retargeting a virtual machine schedule.
  - `[CurrentResourceId <String>]`: The resource Id of the virtual machine on which the schedule operates
  - `[TargetResourceId <String>]`: The resource Id of the virtual machine that the schedule should be retargeted to

## RELATED LINKS

