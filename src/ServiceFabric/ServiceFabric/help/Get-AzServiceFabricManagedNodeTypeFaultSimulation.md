---
external help file: Az.ServiceFabric-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/get-azservicefabricmanagednodetypefaultsimulation
schema: 2.0.0
---

# Get-AzServiceFabricManagedNodeTypeFaultSimulation

## SYNOPSIS
Gets a fault simulation by the simulationId.

## SYNTAX

### List (Default)
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -ClusterName <String> -NodeTypeName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -ClusterName <String> -NodeTypeName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -ClusterName <String> -NodeTypeName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetExpanded
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -ClusterName <String> -NodeTypeName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -SimulationId <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -ClusterName <String> -NodeTypeName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -Parameter <IFaultSimulationIdContent>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentityManagedClusterExpanded
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -NodeTypeName <String>
 -ManagedClusterInputObject <IServiceFabricIdentity> -SimulationId <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentityManagedCluster
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -NodeTypeName <String>
 -ManagedClusterInputObject <IServiceFabricIdentity> -Parameter <IFaultSimulationIdContent>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -InputObject <IServiceFabricIdentity> -SimulationId <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceFabricManagedNodeTypeFaultSimulation -InputObject <IServiceFabricIdentity>
 -Parameter <IFaultSimulationIdContent> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets a fault simulation by the simulationId.

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

### -ClusterName
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: List, GetViaJsonString, GetViaJsonFilePath, GetExpanded, Get
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: GetViaIdentityExpanded, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: GetViaIdentityManagedClusterExpanded, GetViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NodeTypeName
The name of the node type.

```yaml
Type: System.String
Parameter Sets: List, GetViaJsonString, GetViaJsonFilePath, GetExpanded, Get, GetViaIdentityManagedClusterExpanded, GetViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters for Fault Simulation id.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IFaultSimulationIdContent
Parameter Sets: Get, GetViaIdentityManagedCluster, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, GetViaJsonString, GetViaJsonFilePath, GetExpanded, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SimulationId
unique identifier for the fault simulation.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityManagedClusterExpanded, GetViaIdentityExpanded
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
Type: System.String[]
Parameter Sets: List, GetViaJsonString, GetViaJsonFilePath, GetExpanded, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IFaultSimulationIdContent

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IFaultSimulation

## NOTES

## RELATED LINKS
