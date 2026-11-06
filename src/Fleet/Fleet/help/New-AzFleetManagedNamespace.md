---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/new-azfleetmanagednamespace
schema: 2.0.0
---

# New-AzFleetManagedNamespace

## SYNOPSIS
Create a FleetManagedNamespace

## SYNTAX

### CreateExpanded (Default)
```
New-AzFleetManagedNamespace -FleetName <String> -ManagedNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -Location <String>
 [-AdoptionPolicy <String>] [-DefaultNetworkPolicyEgress <String>] [-DefaultNetworkPolicyIngress <String>]
 [-DefaultResourceQuotaCpuLimit <String>] [-DefaultResourceQuotaCpuRequest <String>]
 [-DefaultResourceQuotaMemoryLimit <String>] [-DefaultResourceQuotaMemoryRequest <String>]
 [-DeletePolicy <String>] [-ManagedNamespacePropertyAnnotation <Hashtable>]
 [-ManagedNamespacePropertyLabel <Hashtable>] [-PolicyClusterName <String[]>] [-PolicyPlacementType <String>]
 [-PolicyToleration <IToleration[]>]
 [-RequiredDuringSchedulingIgnoredDuringExecutionClusterSelectorTerm <IClusterSelectorTerm[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFleetManagedNamespace -FleetName <String> -ManagedNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFleetManagedNamespace -FleetName <String> -ManagedNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityFleetExpanded
```
New-AzFleetManagedNamespace -ManagedNamespaceName <String> -FleetInputObject <IFleetIdentity>
 [-IfMatch <String>] [-IfNoneMatch <String>] -Location <String> [-AdoptionPolicy <String>]
 [-DefaultNetworkPolicyEgress <String>] [-DefaultNetworkPolicyIngress <String>]
 [-DefaultResourceQuotaCpuLimit <String>] [-DefaultResourceQuotaCpuRequest <String>]
 [-DefaultResourceQuotaMemoryLimit <String>] [-DefaultResourceQuotaMemoryRequest <String>]
 [-DeletePolicy <String>] [-ManagedNamespacePropertyAnnotation <Hashtable>]
 [-ManagedNamespacePropertyLabel <Hashtable>] [-PolicyClusterName <String[]>] [-PolicyPlacementType <String>]
 [-PolicyToleration <IToleration[]>]
 [-RequiredDuringSchedulingIgnoredDuringExecutionClusterSelectorTerm <IClusterSelectorTerm[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzFleetManagedNamespace -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 -Location <String> [-AdoptionPolicy <String>] [-DefaultNetworkPolicyEgress <String>]
 [-DefaultNetworkPolicyIngress <String>] [-DefaultResourceQuotaCpuLimit <String>]
 [-DefaultResourceQuotaCpuRequest <String>] [-DefaultResourceQuotaMemoryLimit <String>]
 [-DefaultResourceQuotaMemoryRequest <String>] [-DeletePolicy <String>]
 [-ManagedNamespacePropertyAnnotation <Hashtable>] [-ManagedNamespacePropertyLabel <Hashtable>]
 [-PolicyClusterName <String[]>] [-PolicyPlacementType <String>] [-PolicyToleration <IToleration[]>]
 [-RequiredDuringSchedulingIgnoredDuringExecutionClusterSelectorTerm <IClusterSelectorTerm[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a FleetManagedNamespace

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AdoptionPolicy
Action if the managed namespace with the same name already exists.
Default is Never.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -DefaultNetworkPolicyEgress
The egress policy for the managed namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultNetworkPolicyIngress
The ingress policy for the managed namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -DefaultResourceQuotaCpuLimit
The CPU limit for the managed namespace.
See more at https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#meaning-of-cpu

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultResourceQuotaCpuRequest
The CPU request for the managed namespace.
See more at https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#meaning-of-cpu

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultResourceQuotaMemoryLimit
The memory limit for the managed namespace.
See more at https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#meaning-of-memory

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultResourceQuotaMemoryRequest
The memory request for the managed namespace.
See more at https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#meaning-of-memory

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletePolicy
Delete options of a fleet managed namespace.
Default is Keep.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FleetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: CreateViaIdentityFleetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FleetName
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The request should only proceed if an entity matches this string.

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

### -IfNoneMatch
The request should only proceed if no entity matches this string.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedNamespaceName
The name of the fleet managed namespace resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityFleetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedNamespacePropertyAnnotation
The annotations for the fleet managed namespace.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedNamespacePropertyLabel
The labels for the fleet managed namespace.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -PolicyClusterName
ClusterNames contains a list of names of MemberCluster to place the selected resources.
Only valid if the placement type is "PickFixed"

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyPlacementType
Type of placement.
Can be "PickAll", "PickN" or "PickFixed".
Default is PickAll.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyToleration
If specified, the ClusterResourcePlacement's Tolerations.
Tolerations cannot be updated or deleted.
This field is beta-level and is for the taints and tolerations feature.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IToleration[]
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiredDuringSchedulingIgnoredDuringExecutionClusterSelectorTerm
ClusterSelectorTerms is a list of cluster selector terms.
The terms are `ORed`.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IClusterSelectorTerm[]
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetManagedNamespace

## NOTES

## RELATED LINKS
