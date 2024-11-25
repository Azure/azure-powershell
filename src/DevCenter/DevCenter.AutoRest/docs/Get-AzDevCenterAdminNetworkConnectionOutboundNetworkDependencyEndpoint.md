---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminnetworkconnectionoutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint

## SYNOPSIS
Lists the endpoints that agents may call as part of Dev Box service administration.
These FQDNs should be allowed for outbound access in order for the Dev Box service to function.

## SYNTAX

```
Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint -NetworkConnectionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the endpoints that agents may call as part of Dev Box service administration.
These FQDNs should be allowed for outbound access in order for the Dev Box service to function.

## EXAMPLES

### Example 1: List the outbound network dependency endpoints of a network connection
```powershell
Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint -ResourceGroupName testRg -NetworkConnectionName eastusNetwork
```

This command lists the outbound network dependency endpoints of the network connection "eastusNetwork" under the resource group "testRg".

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

### -NetworkConnectionName
Name of the Network Connection that can be applied to a Pool.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IOutboundEnvironmentEndpoint

## NOTES

## RELATED LINKS

