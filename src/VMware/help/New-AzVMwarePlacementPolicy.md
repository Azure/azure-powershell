---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.vmware/new-azvmwareplacementpolicy
schema: 2.0.0
---

# New-AzVMwarePlacementPolicy

## SYNOPSIS
Create or update a placement policy in a private cloud cluster

## SYNTAX

```
New-AzVMwarePlacementPolicy -ClusterName <String> -Name <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Property <IPlacementPolicyProperties>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a placement policy in a private cloud cluster

## EXAMPLES

### Example 1: Create or update a placement policy in a private cloud cluster
```powershell
$abc = New-AzVMwareVMPlacementPolicyPropertiesObject -AffinityType 'Affinity' -Type 'VmVm' -VMMember @{"test"="test"}
New-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -Property $abc
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Create or update a placement policy in a private cloud cluster

### Example 2: Create or update a placement policy in a private cloud cluster
```powershell
$abc = New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"}  -Type 'VmHost' -VMMember @{"test"="test"}
New-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -Property $abc
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Create or update a placement policy in a private cloud cluster

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

### -ClusterName
Name of the cluster in the private cloud

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

### -Name
Name of the VMware vSphere Distributed Resource Scheduler (DRS) placement policy

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PlacementPolicyName

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

### -PrivateCloudName
Name of the private cloud

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

### -Property
placement policy properties
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IPlacementPolicyProperties
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IPlacementPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROPERTY `<IPlacementPolicyProperties>`: placement policy properties
  - `Type <PlacementPolicyType>`: placement policy type
  - `[DisplayName <String>]`: Display name of the placement policy
  - `[State <PlacementPolicyState?>]`: Whether the placement policy is enabled or disabled

## RELATED LINKS

