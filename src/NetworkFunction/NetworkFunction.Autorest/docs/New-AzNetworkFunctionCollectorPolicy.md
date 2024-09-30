---
external help file:
Module Name: Az.NetworkFunction
online version: https://learn.microsoft.com/powershell/module/az.networkfunction/new-aznetworkfunctioncollectorpolicy
schema: 2.0.0
---

# New-AzNetworkFunctionCollectorPolicy

## SYNOPSIS
Creates or updates a Collector Policy resource

## SYNTAX

```
New-AzNetworkFunctionCollectorPolicy -AzureTrafficCollectorName <String> -Name <String>
 -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-EmissionPolicy <IEmissionPoliciesPropertiesFormat[]>]
 [-IngestionPolicyIngestionSource <IIngestionSourcesPropertiesFormat[]>]
 [-IngestionPolicyIngestionType <IngestionType>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Collector Policy resource

## EXAMPLES

### Example 1: Create a new traffic collector policy
```powershell
New-AzNetworkFunctionCollectorPolicy -collectorpolicyname cp1 -azuretrafficcollectorname atc -resourcegroupname rg1 -location eastus | Format-List
```

```output
Name              : cp1
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc/collectorPolicies/cp1
Type              : Microsoft.NetworkFunction/azureTrafficCollectors/collectorPolicies
Properties        : {
                    "ingestionPolicy": {
                        "ingestionType": "IPFIX",
                        "ingestionSources": [
                            {
                            "resourceId": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/expressRouteCircuits/circuitName",
                            "sourceType": "Resource"
                            }
                        ]
                        },
                        "emissionPolicies": [
                        {
                            "emissionType": "IPFIX",
                            "emissionDestinations": [
                            {
                                "destinationType": "AzureMonitor"
                            }
                            ]
                        }
                        ],
                        "provisioningState": "Succeeded"
                    }
```

This cmdlet creates a new traffic collector policy.

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

### -EmissionPolicy
Emission policies.
To construct, see NOTES section for EMISSIONPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.IEmissionPoliciesPropertiesFormat[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngestionPolicyIngestionSource
Ingestion Sources.
To construct, see NOTES section for INGESTIONPOLICYINGESTIONSOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.IIngestionSourcesPropertiesFormat[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Support.IngestionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

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

### -Name
Collector Policy Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CollectorPolicyName

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

### -ResourceGroupName
The name of the resource group.

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
Azure Subscription ID.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.ICollectorPolicy

## NOTES

## RELATED LINKS

