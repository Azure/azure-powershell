---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/new-azservicefabricmanagedclusterservice
schema: 2.0.0
---

# New-AzServiceFabricManagedClusterService

## SYNOPSIS
Create a Service Fabric managed service resource with the specified name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzServiceFabricManagedClusterService [-Name] <String> [-ApplicationName] <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] [-CorrelationScheme <IServiceCorrelation[]>]
 [-DefaultMoveCost <String>] [-Location <String>] [-PartitionDescriptionPartitionScheme <String>]
 [-PlacementConstraint <String>] [-ScalingPolicy <IScalingPolicy[]>] [-ServiceDnsName <String>]
 [-ServiceKind <String>] [-ServiceLoadMetric <IServiceLoadMetric[]>] [-ServicePackageActivationMode <String>]
 [-ServicePlacementPolicy <IServicePlacementPolicy[]>] [-ServiceTypeName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzServiceFabricManagedClusterService [-Name] <String> [-ApplicationName] <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzServiceFabricManagedClusterService [-Name] <String> [-ApplicationName] <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityManagedClusterExpanded
```
New-AzServiceFabricManagedClusterService [-Name] <String> [-ApplicationName] <String>
 -ManagedClusterInputObject <IServiceFabricIdentity> [-CorrelationScheme <IServiceCorrelation[]>]
 [-DefaultMoveCost <String>] [-Location <String>] [-PartitionDescriptionPartitionScheme <String>]
 [-PlacementConstraint <String>] [-ScalingPolicy <IScalingPolicy[]>] [-ServiceDnsName <String>]
 [-ServiceKind <String>] [-ServiceLoadMetric <IServiceLoadMetric[]>] [-ServicePackageActivationMode <String>]
 [-ServicePlacementPolicy <IServicePlacementPolicy[]>] [-ServiceTypeName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityApplicationExpanded
```
New-AzServiceFabricManagedClusterService [-Name] <String> -ApplicationInputObject <IServiceFabricIdentity>
 [-CorrelationScheme <IServiceCorrelation[]>] [-DefaultMoveCost <String>] [-Location <String>]
 [-PartitionDescriptionPartitionScheme <String>] [-PlacementConstraint <String>]
 [-ScalingPolicy <IScalingPolicy[]>] [-ServiceDnsName <String>] [-ServiceKind <String>]
 [-ServiceLoadMetric <IServiceLoadMetric[]>] [-ServicePackageActivationMode <String>]
 [-ServicePlacementPolicy <IServicePlacementPolicy[]>] [-ServiceTypeName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Service Fabric managed service resource with the specified name.

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

### -ApplicationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: CreateViaIdentityApplicationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApplicationName
The name of the application resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: True
Position: 2
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

### -ClusterName
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationScheme
A list that describes the correlation of the service with other services.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceCorrelation[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultMoveCost
Specifies the move cost for the service.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: CreateViaIdentityManagedClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the service resource in the format of {applicationName}~{serviceName}.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServiceName

Required: True
Position: 3
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

### -PartitionDescriptionPartitionScheme
Enumerates the ways that a service can be partitioned.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementConstraint
The placement constraints as a string.
Placement constraints are boolean expressions on node properties and allow for restricting a service to particular nodes based on the service requirements.
For example, to place a service on nodes where NodeType is blue specify the following: "NodeColor == blue)".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
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
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalingPolicy
Scaling policies for this service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IScalingPolicy[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceDnsName
Dns name used for the service.
If this is specified, then the DNS name can be used to return the IP addresses of service endpoints for application layer protocols (e.g., HTTP).When updating serviceDnsName, old name may be temporarily resolvable.
However, rely on new name.When removing serviceDnsName, removed name may temporarily be resolvable.
Do not rely on the name being unresolvable.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceKind
The kind of service (Stateless or Stateful).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceLoadMetric
The service load metrics is given as an array of ServiceLoadMetric objects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceLoadMetric[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePackageActivationMode
The activation Mode of the service package

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePlacementPolicy
A list that describes the correlation of the service with other services.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServicePlacementPolicy[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTypeName
The name of the service type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded, CreateViaIdentityApplicationExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceResource

## NOTES

## RELATED LINKS
