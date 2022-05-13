---
external help file:
Module Name: TrafficCollector
online version: https://docs.microsoft.com/en-us/powershell/module/trafficcollector/set-aztrafficcollectorpolicy
schema: 2.0.0
---

# Set-AzTrafficCollectorPolicy

## SYNOPSIS
Creates or updates a Collector Policy resource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzTrafficCollectorPolicy -AzureTrafficCollectorName <String> -CollectorPolicyName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EmissionPolicies <IEmissionPoliciesPropertiesFormat[]>]
 [-IngestionPolicyIngestionSources <IIngestionSourcesPropertiesFormat[]>]
 [-IngestionPolicyIngestionType <IngestionType>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzTrafficCollectorPolicy -AzureTrafficCollectorName <String> -CollectorPolicyName <String>
 -ResourceGroupName <String> -Parameters <ICollectorPolicy> [-SubscriptionId <String>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzTrafficCollectorPolicy -InputObject <ITrafficCollectorIdentity> -Parameters <ICollectorPolicy> [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzTrafficCollectorPolicy -InputObject <ITrafficCollectorIdentity>
 [-EmissionPolicies <IEmissionPoliciesPropertiesFormat[]>]
 [-IngestionPolicyIngestionSources <IIngestionSourcesPropertiesFormat[]>]
 [-IngestionPolicyIngestionType <IngestionType>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Collector Policy resource

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

### -AzureTrafficCollectorName
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

### -CollectorPolicyName
Collector Policy Name

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

### -EmissionPolicies
Emission policies.
To construct, see NOTES section for EMISSIONPOLICIES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.IEmissionPoliciesPropertiesFormat[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngestionPolicyIngestionSources
Ingestion Sources.
To construct, see NOTES section for INGESTIONPOLICYINGESTIONSOURCES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.IIngestionSourcesPropertiesFormat[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngestionPolicyIngestionType
The ingestion type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Support.IngestionType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ITrafficCollectorIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Collection policy resource.
To construct, see NOTES section for PARAMETERS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ICollectorPolicy
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

### Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ICollectorPolicy

### Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ITrafficCollectorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ICollectorPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


EMISSIONPOLICIES <IEmissionPoliciesPropertiesFormat[]>: Emission policies.
  - `[EmissionDestinations <IEmissionPolicyDestination[]>]`: Emission policy destinations.
    - `[DestinationType <DestinationType?>]`: Emission destination type.
  - `[EmissionType <EmissionType?>]`: Emission format type.

INGESTIONPOLICYINGESTIONSOURCES <IIngestionSourcesPropertiesFormat[]>: Ingestion Sources.
  - `[ResourceId <String>]`: Resource ID.
  - `[SourceType <SourceType?>]`: Ingestion source type.

INPUTOBJECT <ITrafficCollectorIdentity>: Identity Parameter
  - `[AzureTrafficCollectorName <String>]`: Azure Traffic Collector name
  - `[CollectorPolicyName <String>]`: Collector Policy Name
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

PARAMETERS <ICollectorPolicy>: Collection policy resource.
  - `[EmissionPolicies <IEmissionPoliciesPropertiesFormat[]>]`: Emission policies.
    - `[EmissionDestinations <IEmissionPolicyDestination[]>]`: Emission policy destinations.
      - `[DestinationType <DestinationType?>]`: Emission destination type.
    - `[EmissionType <EmissionType?>]`: Emission format type.
  - `[IngestionPolicyIngestionSources <IIngestionSourcesPropertiesFormat[]>]`: Ingestion Sources.
    - `[ResourceId <String>]`: Resource ID.
    - `[SourceType <SourceType?>]`: Ingestion source type.
  - `[IngestionPolicyIngestionType <IngestionType?>]`: The ingestion type.

## RELATED LINKS

