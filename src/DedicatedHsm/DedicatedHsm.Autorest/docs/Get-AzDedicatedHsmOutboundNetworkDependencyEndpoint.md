---
external help file:
Module Name: Az.DedicatedHsm
online version: https://learn.microsoft.com/powershell/module/az.dedicatedhsm/get-azdedicatedhsmoutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint

## SYNOPSIS
Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
The operation returns properties of each egress endpoint.

## SYNTAX

```
Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
The operation returns properties of each egress endpoint.

## EXAMPLES

### Example 1: Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
```powershell
Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint -Name dedicatedHsmName01 -ResourceGroupName resourceGroup
```

This command gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
The operation returns properties of each egress endpoint.

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
The name of the dedicated HSM.

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
The name of the Resource Group to which the dedicated hsm belongs.

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
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20211130.IOutboundEnvironmentEndpoint

## NOTES

## RELATED LINKS

