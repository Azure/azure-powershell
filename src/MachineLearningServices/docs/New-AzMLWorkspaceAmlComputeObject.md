---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceAmlComputeObject
schema: 2.0.0
---

# New-AzMLWorkspaceAmlComputeObject

## SYNOPSIS
Create an in-memory object for AmlCompute.

## SYNTAX

```
New-AzMLWorkspaceAmlComputeObject [-AdminUserName <String>] [-AdminUserPassword <String>]
 [-AdminUserSshPublicKey <String>] [-Description <String>] [-DisableLocalAuth <Boolean>]
 [-EnableNodePublicIP <Boolean>] [-IsolatedNetwork <Boolean>] [-OSType <OSType>] [-PropertyBag <IAny>]
 [-RemoteLoginPortPublicAccess <RemoteLoginPortPublicAccess>] [-ResourceId <String>]
 [-ScaleMaxNodeCount <Int32>] [-ScaleMinNodeCount <Int32>] [-ScaleNodeIdleTimeBeforeScaleDown <TimeSpan>]
 [-SubnetId <String>] [-VirtualMachineImageId <String>] [-VMPriority <VMPriority>] [-VMSize <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmlCompute.

## EXAMPLES

### Example 1: Create an in-memory object for AmlCompute
```powershell
New-AzMLWorkspaceAmlComputeObject
```

Create an in-memory object for AmlCompute

## PARAMETERS

### -AdminUserName
Name of the administrator user account which can be used to SSH to nodes.

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

### -AdminUserPassword
Password of the administrator user account.

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

### -AdminUserSshPublicKey
SSH public key of the administrator user account.

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

### -IsolatedNetwork
Network is isolated or not.

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

### -OSType
Compute OS Type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OSType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertyBag
A property bag containing additional properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteLoginPortPublicAccess
State of the public SSH port.
Possible values are: Disabled - Indicates that the public ssh port is closed on all nodes of the cluster.
Enabled - Indicates that the public ssh port is open on all nodes of the cluster.
NotSpecified - Indicates that the public ssh port is closed on all nodes of the cluster if VNet is defined, else is open all public nodes.
It can be default only during cluster creation time, after creation it will be either enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RemoteLoginPortPublicAccess
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

### -ScaleMaxNodeCount
Max number of nodes to use.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMinNodeCount
Min number of nodes to use.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleNodeIdleTimeBeforeScaleDown
Node Idle Time before scaling down amlCompute.
This string needs to be in the RFC Format.

```yaml
Type: System.TimeSpan
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

### -VirtualMachineImageId
Virtual Machine image path.

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

### -VMPriority
Virtual Machine priority.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.VMPriority
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.AmlCompute

## NOTES

ALIASES

## RELATED LINKS

