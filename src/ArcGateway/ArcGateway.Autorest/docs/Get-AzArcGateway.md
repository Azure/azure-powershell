---
external help file:
Module Name: Az.ArcGateway
online version: https://learn.microsoft.com/powershell/module/az.arcgateway/get-azarcgateway
schema: 2.0.0
---

# Get-AzArcGateway

## SYNOPSIS
Retrieves information about the view of a gateway.

## SYNTAX

### List1 (Default)
```
Get-AzArcGateway [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzArcGateway -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcGateway -InputObject <IArcGatewayIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzArcGateway -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about the view of a gateway.

## EXAMPLES

### Example 1: Get a list of gateway under a subscription
```powershell
Get-AzArcGateway -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Location      Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDat
                                                                                                  aLastModi
                                                                                                  fiedAt
--------      ----                ------------------- ------------------- ----------------------- ---------
eastus2euap   adrielk_gateway
centraluseuap dakirby_gatewayTest
eastus        MyArcgateway2
eastus        myArcGateway
centralus     hcrp_synthetics_gw
```

Get a list of gateway under a subscription

### Example 2: Get a list of gateway under a resource group
```powershell
 Get-AzArcGateway -Name "myArcGateway" -ResourceGroupName "ytongtest"
```

```output
AllowedFeature               : {*}
Endpoint                     : 00000000-0000-0000-0000-000000000000.gw.arc.azure.com
GatewayId                    : 00000000-0000-0000-0000-000000000000
GatewayType                  : Public
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest
                               /providers/Microsoft.HybridCompute/gateways/myArcGateway
Location                     : eastus
Name                         : myArcGateway
ProvisioningState            : Succeeded
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/gateways
```

Get a list of gateway under a resource group

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Gateway.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: GatewayName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IGateway

## NOTES

## RELATED LINKS

