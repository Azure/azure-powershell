---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceComputeInstanceObject
schema: 2.0.0
---

# New-AzMLWorkspaceComputeInstanceObject

## SYNOPSIS
Create an in-memory object for ComputeInstance.

## SYNTAX

```
New-AzMLWorkspaceComputeInstanceObject [-ApplicationSharingPolicy <ApplicationSharingPolicy>]
 [-AssignedUserObjectId <String>] [-AssignedUserTenantId <String>]
 [-AuthorizationType <ComputeInstanceAuthorizationType>] [-CreationScriptArgument <String>]
 [-CreationScriptData <String>] [-CreationScriptSource <String>] [-CreationScriptTimeout <String>]
 [-Description <String>] [-DisableLocalAuth <Boolean>] [-EnableNodePublicIP <Boolean>]
 [-LastOperationName <OperationName>] [-LastOperationStatus <OperationStatus>] [-LastOperationTime <DateTime>]
 [-LastOperationTrigger <OperationTrigger>] [-ResourceId <String>]
 [-ScheduleComputeStartStop <IComputeStartStopSchedule[]>] [-SshSettingAdminPublicKey <String>]
 [-SshSettingSshPublicAccess <SshPublicAccess>] [-StartupScriptArgument <String>]
 [-StartupScriptData <String>] [-StartupScriptSource <String>] [-StartupScriptTimeout <String>]
 [-SubnetId <String>] [-VersionRuntime <String>] [-VMSize <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ComputeInstance.

## EXAMPLES

### Example 1: Create an in-memory object for ComputeInstance
```powershell
New-AzMLWorkspaceComputeInstanceObject
```

Create an in-memory object for ComputeInstance

## PARAMETERS

### -ApplicationSharingPolicy
Policy for sharing applications on this compute instance among users of parent workspace.
If Personal, only the creator can access applications on this compute instance.
When Shared, any workspace user can access applications on this instance depending on his/her assigned role.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ApplicationSharingPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedUserObjectId
User’s AAD Object Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedUserTenantId
User’s AAD Tenant Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationType
The Compute Instance Authorization type.
Available values are personal (default).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputeInstanceAuthorizationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationScriptArgument
Optional command line arguments passed to the script to run.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationScriptData
The location of scripts in the mounted volume.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationScriptSource
The storage source of the script: inline, workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationScriptTimeout
Optional time period passed to timeout command.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description of the Machine Learning compute.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableLocalAuth
Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNodePublicIP
Enable or disable node public IP address provisioning.
Possible values are: Possible values are: true - Indicates that the compute nodes will have public IPs provisioned.
false - Indicates that the compute nodes will have a private endpoint and no public IPs.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastOperationName
Name of the last operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OperationName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastOperationStatus
Operation status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OperationStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastOperationTime
Time of the last operation.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastOperationTrigger
Trigger of operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OperationTrigger
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ARM resource id of the underlying compute.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleComputeStartStop
The list of compute start stop schedules to be applied.
To construct, see NOTES section for SCHEDULECOMPUTESTARTSTOP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeStartStopSchedule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshSettingAdminPublicKey
Specifies the SSH rsa public key file as a string.
Use "ssh-keygen -t rsa -b 2048" to generate your SSH key pairs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshSettingSshPublicAccess
State of the public SSH port.
Possible values are: Disabled - Indicates that the public ssh port is closed on this instance.
Enabled - Indicates that the public ssh port is open and accessible according to the VNet/subnet policy if applicable.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SshPublicAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupScriptArgument
Optional command line arguments passed to the script to run.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupScriptData
The location of scripts in the mounted volume.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupScriptSource
The storage source of the script: inline, workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupScriptTimeout
Optional time period passed to timeout command.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
The ID of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionRuntime
Runtime of compute instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
Virtual Machine Size.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ComputeInstance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`SCHEDULECOMPUTESTARTSTOP <IComputeStartStopSchedule[]>`: The list of compute start stop schedules to be applied.
  - `[Action <ComputePowerAction?>]`: The compute power action.
  - `[ScheduleId <String>]`: 
  - `[ScheduleProvisioningStatus <ScheduleProvisioningState?>]`: 
  - `[ScheduleStatus <ScheduleStatus?>]`: 

## RELATED LINKS

