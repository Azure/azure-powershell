---
external help file:
Module Name: Az.ArcResourceBridge
online version: https://learn.microsoft.com/powershell/module/az.arcresourcebridge/get-azarcresourcebridgeappliancecredential
schema: 2.0.0
---

# Get-AzArcResourceBridgeApplianceCredential

## SYNOPSIS
Returns the cluster user credentials for the dedicated appliance.

## SYNTAX

```
Get-AzArcResourceBridgeApplianceCredential -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns the cluster user credentials for the dedicated appliance.

## EXAMPLES

### Example 1: Returns the cluster user credentials for the dedicated appliance.
```powershell
Get-AzArcResourceBridgeApplianceCredential -ResourceGroupName azps_test_group -Name azps-resource-bridge
```

```output
HybridConnectionConfigExpirationTime       : 1678424933
HybridConnectionConfigHybridConnectionName : microsoft.resourceconnector/appliances/bc2***a81fb98c/167***794176
HybridConnectionConfigRelay                : azgnrelay-ph0-l1
HybridConnectionConfigToken                : SharedAccessSignature***30308
Kubeconfig                                 : {{
                                               "name": "clusterUser",
                                               "value": "YXBpV***zZQo="
                                             }}
```

Returns the cluster user credentials for the dedicated appliance.

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

### -Name
Appliances name.

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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IApplianceListCredentialResults

## NOTES

ALIASES

## RELATED LINKS

