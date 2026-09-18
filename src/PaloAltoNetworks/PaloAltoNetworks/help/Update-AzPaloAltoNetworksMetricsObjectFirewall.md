---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworksmetricsobjectfirewall
schema: 2.0.0
---

# Update-AzPaloAltoNetworksMetricsObjectFirewall

## SYNOPSIS
Update a MetricsObjectFirewallResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksMetricsObjectFirewall -InputObject <IPaloAltoNetworksIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a MetricsObjectFirewallResource

## EXAMPLES

### Example 1: Update metrics config object
```powershell
Update-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg"
```

```output
ApplicationInsightsConnectionString : InstrumentationKey=95a645a2-898c-4e40-b285-3f38bbe02e5f;IngestionEndpoint=https:/
                                      /eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagn
                                      ostics.monitor.azure.com/;ApplicationId=b4834f2c-adb3-4319-9e71-0721e949f2df
ApplicationInsightsResourceId       : /subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/06Aug2025/prov
                                      iders/microsoft.insights/components/test-prakgupta3-metrics-ai
Id                                  : /subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/eastus-rg/prov
                                      iders/PaloAltoNetworks.Cloudngfw/firewalls/italynorth-test-fw/metrics/default
Name                                : default
PanEtag                             : eded6ece-5c15-4bac-a720-c06693f5e592
ProvisioningState                   : Succeeded
ResourceGroupName                   : eastus-rg
SystemDataCreatedAt                 :
SystemDataCreatedBy                 :
SystemDataCreatedByType             :
SystemDataLastModifiedAt            :
SystemDataLastModifiedBy            :
SystemDataLastModifiedByType        :
Type                                : firewalls/metrics
```

Update metrics config object.

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

### -FirewallName
Firewall resource name

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: UpdateViaIdentityExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IMetricsObjectFirewallResource

## NOTES

## RELATED LINKS
