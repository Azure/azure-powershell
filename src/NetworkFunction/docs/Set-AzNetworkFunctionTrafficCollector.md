---
external help file:
Module Name: Az.NetworkFunction
online version: https://docs.microsoft.com/en-us/powershell/module/az.networkfunction/set-aznetworkfunctiontrafficcollector
schema: 2.0.0
---

# Set-AzNetworkFunctionTrafficCollector

## SYNOPSIS
Creates or updates a Azure Traffic Collector resource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzNetworkFunctionTrafficCollector -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CollectorPolicyList <ICollectorPolicy[]>] [-Tags <Hashtable>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzNetworkFunctionTrafficCollector -Name <String> -ResourceGroupName <String>
 -Parameters <IAzureTrafficCollector> [-SubscriptionId <String>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzNetworkFunctionTrafficCollector -InputObject <ITrafficCollectorIdentity>
 -Parameters <IAzureTrafficCollector> [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzNetworkFunctionTrafficCollector -InputObject <ITrafficCollectorIdentity> -Location <String>
 [-CollectorPolicyList <ICollectorPolicy[]>] [-Tags <Hashtable>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Azure Traffic Collector resource

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectorPolicyList
Collector Policies for Azure Traffic Collector.
To construct, see NOTES section for COLLECTORPOLICIES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.ICollectorPolicy[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.ITrafficCollectorIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Azure Traffic Collector name

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Azure Traffic Collector resource.
To construct, see NOTES section for PARAMETERS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.IAzureTrafficCollector
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.IAzureTrafficCollector

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.ITrafficCollectorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.IAzureTrafficCollector

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


COLLECTORPOLICIES <ICollectorPolicy[]>: Collector Policies for Azure Traffic Collector.
  - `[EmissionPolicyList <IEmissionPoliciesPropertiesFormat[]>]`: Emission policies.
    - `[EmissionDestinations <IEmissionPolicyDestination[]>]`: Emission policy destinations.
      - `[DestinationType <DestinationType?>]`: Emission destination type.
    - `[EmissionType <EmissionType?>]`: Emission format type.
  - `[IngestionPolicyIngestionSourceList <IIngestionSourcesPropertiesFormat[]>]`: Ingestion Sources.
    - `[ResourceId <String>]`: Resource ID.
    - `[SourceType <SourceType?>]`: Ingestion source type.
  - `[IngestionPolicyIngestionType <IngestionType?>]`: The ingestion type.

INPUTOBJECT <ITrafficCollectorIdentity>: Identity Parameter
  - `[AzureTrafficCollectorName <String>]`: Azure Traffic Collector name
  - `[CollectorPolicyName <String>]`: Collector Policy Name
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

PARAMETERS <IAzureTrafficCollector>: Azure Traffic Collector resource.
  - `[Location <String>]`: Resource location.
  - `[Tags <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[CollectorPolicyList <ICollectorPolicy[]>]`: Collector Policies for Azure Traffic Collector.
    - `[EmissionPolicyList <IEmissionPoliciesPropertiesFormat[]>]`: Emission policies.
      - `[EmissionDestinations <IEmissionPolicyDestination[]>]`: Emission policy destinations.
        - `[DestinationType <DestinationType?>]`: Emission destination type.
      - `[EmissionType <EmissionType?>]`: Emission format type.
    - `[IngestionPolicyIngestionSourceList <IIngestionSourcesPropertiesFormat[]>]`: Ingestion Sources.
      - `[ResourceId <String>]`: Resource ID.
      - `[SourceType <SourceType?>]`: Ingestion source type.
    - `[IngestionPolicyIngestionType <IngestionType?>]`: The ingestion type.

## RELATED LINKS

