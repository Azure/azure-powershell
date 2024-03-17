---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/update-azvmwareplacementpolicy
schema: 2.0.0
---

# Update-AzVMwarePlacementPolicy

## SYNOPSIS
Update a placement policy in a private cloud cluster

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzVMwarePlacementPolicy -ClusterName <String> -Name <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AffinityStrength <String>]
 [-AzureHybridBenefitType <String>] [-HostMember <String[]>] [-State <String>] [-VMMember <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityPrivateCloudExpanded
```
Update-AzVMwarePlacementPolicy -ClusterName <String> -Name <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-AffinityStrength <String>] [-AzureHybridBenefitType <String>] [-HostMember <String[]>] [-State <String>]
 [-VMMember <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzVMwarePlacementPolicy -Name <String> -ClusterInputObject <IVMwareIdentity>
 [-AffinityStrength <String>] [-AzureHybridBenefitType <String>] [-HostMember <String[]>] [-State <String>]
 [-VMMember <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVMwarePlacementPolicy -InputObject <IVMwareIdentity> [-AffinityStrength <String>]
 [-AzureHybridBenefitType <String>] [-HostMember <String[]>] [-State <String>] [-VMMember <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a placement policy in a private cloud cluster

## EXAMPLES

### Example 1: Update a placement policy in a private cloud cluster
```powershell
Update-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -State 'Enabled'
```

```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Update a placement policy in a private cloud cluster

### Example 2: Update a placement policy in a private cloud cluster
```powershell
Get-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 | Update-AzVMwarePlacementPolicy -State 'Enabled'
```

```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Update a placement policy in a private cloud cluster

## PARAMETERS

### -AffinityStrength
vm-hostplacementpolicyaffinitystrength(should/must)

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

### -AsJob
Runthecommandasajob

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

### -AzureHybridBenefitType
placementpolicyazurehybridbenefitopt-intype

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

### -ClusterInputObject
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: UpdateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
Nameoftheclusterintheprivatecloud

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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

### -HostMember
Hostmemberslist

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
NameoftheVMwarevSphereDistributedResourceScheduler(DRS)placementpolicy

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateCloudExpanded, UpdateViaIdentityClusterExpanded
Aliases: PlacementPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Runthecommandasynchronously

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

### -PrivateCloudInputObject
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: UpdateViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Nameoftheprivatecloud

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Whethertheplacementpolicyisenabledordisabled

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

### -SubscriptionId
TheIDofthetargetsubscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMMember
Virtualmachinememberslist

```yaml
Type: System.String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IPlacementPolicy

## NOTES

## RELATED LINKS
