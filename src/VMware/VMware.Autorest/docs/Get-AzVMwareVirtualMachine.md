---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwarevirtualmachine
schema: 2.0.0
---

# Get-AzVMwareVirtualMachine

## SYNOPSIS
Get a VirtualMachine

## SYNTAX

### List (Default)
```
Get-AzVMwareVirtualMachine -ClusterName <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareVirtualMachine -ClusterName <String> -Id <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareVirtualMachine -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzVMwareVirtualMachine -ClusterInputObject <IVMwareIdentity> -Id <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareVirtualMachine -ClusterName <String> -Id <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a VirtualMachine

## EXAMPLES

### Example 1: List virtual machine in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```

```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
vm-128 group1
```

List virtual machine in a private cloud cluster

### Example 2: Get a virtual machine by id in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -Id vm-209 -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```

```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
```

Get a virtual machine by id in a private cloud cluster

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
Name of the cluster

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityPrivateCloud, List
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

### -Id
ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster, GetViaIdentityPrivateCloud
Aliases: VirtualMachineId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentityPrivateCloud
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVirtualMachine

## NOTES

## RELATED LINKS

