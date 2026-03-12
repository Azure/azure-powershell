---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-azmlworkspacecomputeinstanceobject
schema: 2.0.0
---

# New-AzMLWorkspaceComputeInstanceObject

## SYNOPSIS
Create an in-memory object for ComputeInstance.

## SYNTAX

```
New-AzMLWorkspaceComputeInstanceObject [-Description <String>] [-DisableLocalAuth <Boolean>]
 [-Location <String>] [-ResourceId <String>] [-ApplicationSharingPolicy <String>]
 [-AssignedUserObjectId <String>] [-AssignedUserTenantId <String>] [-AuthorizationType <String>]
 [-CreationScriptArgument <String>] [-CreationScriptData <String>] [-CreationScriptSource <String>]
 [-CreationScriptTimeout <String>] [-CustomService <ICustomService[]>] [-EnableNodePublicIP <Boolean>]
 [-ScheduleComputeStartStop <IComputeStartStopSchedule[]>] [-SshSettingAdminPublicKey <String>]
 [-SshSettingSshPublicAccess <String>] [-StartupScriptArgument <String>] [-StartupScriptData <String>]
 [-StartupScriptSource <String>] [-StartupScriptTimeout <String>] [-SubnetId <String>] [-VMSize <String>]
 [<CommonParameters>]
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedUserObjectId
User's AAD Object Id.

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
User's AAD Tenant Id.

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
Type: System.String
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
The storage source of the script: workspace.

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

### -CustomService
List of Custom Services added to the compute.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.ICustomService[]
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

### -Location
Location for the underlying compute.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IComputeStartStopSchedule[]
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
Type: System.String
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
The storage source of the script: workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.ComputeInstance

## NOTES

## RELATED LINKS
