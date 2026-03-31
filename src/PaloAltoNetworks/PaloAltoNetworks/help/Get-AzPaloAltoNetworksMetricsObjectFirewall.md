---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworksmetricsobjectfirewall
schema: 2.0.0
---

# Get-AzPaloAltoNetworksMetricsObjectFirewall

## SYNOPSIS
Get a MetricsObjectFirewallResource

## SYNTAX

### Get (Default)
```
Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksMetricsObjectFirewall -InputObject <IPaloAltoNetworksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a MetricsObjectFirewallResource

## EXAMPLES

### Example 1: Get metrics configurations object of a firewall
```powershell
Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg"
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
PanEtag                             : cb064af4-f5b9-48f1-ba5f-0dff41f00fc9
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

Get metrics configurations object of a firewall.

## PARAMETERS

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
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IMetricsObjectFirewallResource

## NOTES

## RELATED LINKS
