---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecircuitconnection
schema: 2.0.0
---

# Set-AzExpressRouteCircuitConnection

## SYNOPSIS
Creates or updates a Express Route Circuit Connection in the specified express route circuits.

## SYNTAX

### Update (Default)
```
Set-AzExpressRouteCircuitConnection -CircuitName <String> -ConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-Parameter <IExpressRouteCircuitConnection>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzExpressRouteCircuitConnection -CircuitName <String> -ConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-AddressPrefix <String>] [-AuthorizationKey <String>]
 [-ExpressRouteCircuitPeeringId <String>] [-Id <String>] [-Name <String>]
 [-PeerExpressRouteCircuitPeeringId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzExpressRouteCircuitConnection -InputObject <INetworkIdentity> [-AddressPrefix <String>]
 [-AuthorizationKey <String>] [-ExpressRouteCircuitPeeringId <String>] [-Id <String>] [-Name <String>]
 [-PeerExpressRouteCircuitPeeringId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzExpressRouteCircuitConnection -InputObject <INetworkIdentity>
 [-Parameter <IExpressRouteCircuitConnection>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Express Route Circuit Connection in the specified express route circuits.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AddressPrefix
/29 IP address space to carve out Customer addresses for tunnels.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
The authorization key.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CircuitName
The name of the express route circuit.

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

### -ConnectionName
The name of the express route circuit connection.

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
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection
Parameter Sets: Update, UpdateViaIdentity
Aliases: ExpressRouteCircuitConnectionParameter

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeerExpressRouteCircuitPeeringId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
The name of the peering.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecircuitconnection](https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecircuitconnection)

