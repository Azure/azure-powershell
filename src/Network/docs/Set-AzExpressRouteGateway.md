---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutegateway
schema: 2.0.0
---

# Set-AzExpressRouteGateway

## SYNOPSIS
Creates or updates a ExpressRoute gateway in a specified resource group.

## SYNTAX

### Update (Default)
```
Set-AzExpressRouteGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-PutExpressRouteGatewayParameter <IExpressRouteGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzExpressRouteGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-BoundMax <Int32>] [-BoundMin <Int32>] [-Id <String>] [-Location <String>] [-Tag <IResourceTags>]
 [-VirtualHubId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzExpressRouteGateway -InputObject <INetworkIdentity> [-BoundMax <Int32>] [-BoundMin <Int32>]
 [-Id <String>] [-Location <String>] [-Tag <IResourceTags>] [-VirtualHubId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzExpressRouteGateway -InputObject <INetworkIdentity>
 [-PutExpressRouteGatewayParameter <IExpressRouteGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a ExpressRoute gateway in a specified resource group.

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

### -BoundMax
Maximum number of scale units deployed for ExpressRoute gateway.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -BoundMin
Minimum number of scale units deployed for ExpressRoute gateway.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -Location
Resource location.

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

### -Name
The name of the ExpressRoute gateway.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ExpressRouteGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PutExpressRouteGatewayParameter
ExpressRoute gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGateway
Parameter Sets: Update, UpdateViaIdentity
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

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubId
The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed.
The Virtual Hub resource and the ExpressRoute gateway resource reside in the same subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGateway
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutegateway](https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutegateway)

