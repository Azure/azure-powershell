---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressrouteconnection
schema: 2.0.0
---

# New-AzExpressRouteConnection

## SYNOPSIS
Creates a connection between an ExpressRoute gateway and an ExpressRoute circuit.

## SYNTAX

### Create (Default)
```
New-AzExpressRouteConnection -ConnectionName <String> -ExpressRouteGatewayName <String>
 -ResourceGroupName <String> -SubscriptionId <String>
 [-PutExpressRouteConnectionParameter <IExpressRouteConnection>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzExpressRouteConnection -ConnectionName <String> -ExpressRouteGatewayName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-AuthorizationKey <String>]
 [-ExpressRouteCircuitPeeringId <String>] [-Id <String>] -Name <String> [-RoutingWeight <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzExpressRouteConnection -InputObject <INetworkIdentity> [-AuthorizationKey <String>]
 [-ExpressRouteCircuitPeeringId <String>] [-Id <String>] -Name <String> [-RoutingWeight <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzExpressRouteConnection -InputObject <INetworkIdentity>
 [-PutExpressRouteConnectionParameter <IExpressRouteConnection>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a connection between an ExpressRoute gateway and an ExpressRoute circuit.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationKey
Authorization key to establish the connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionName
The name of the connection subresource.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### -ExpressRouteCircuitPeeringId
The ID of the ExpressRoute circuit peering.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteGatewayName
The name of the ExpressRoute gateway.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PutExpressRouteConnectionParameter
ExpressRouteConnection resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingWeight
The routing weight associated to the connection.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressrouteconnection](https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressrouteconnection)

