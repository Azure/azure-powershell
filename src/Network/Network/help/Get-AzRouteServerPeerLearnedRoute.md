---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azrouteserverpeerlearnedroute
schema: 2.0.0
---

# Get-AzRouteServerPeerLearnedRoute

## SYNOPSIS
List routes learned by a specific route server peer

## SYNTAX

### RouteServerPeerNameParameterSet (Default)
```
Get-AzRouteServerPeerLearnedRoute -ResourceGroupName <String> -RouteServerName <String> -PeerName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RouteServerPeerObjectParameterSet
```
Get-AzRouteServerPeerLearnedRoute -InputObject <PSRouteServerPeer> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Enumerate routes learned by a route server peer from other sources.

## EXAMPLES

### Example 1
```powershell
Get-AzRouteServerPeerLearnedRoute -ResourceGroupName $resourceGroupName -RouteServerName $routeServerName -PeerName $peerName
```

### Example 2
```powershell
$routerServerPeer = Get-AzRouteServerPeer -ResourceGroupName $resourceGroupName -RouteServerName $routeServerName -PeerName $peerName
Get-AzRouteServerPeerLearnedRoute -InputObject $routerServerPeer
```

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The route server peer input object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteServerPeer
Parameter Sets: RouteServerPeerObjectParameterSet
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeerName
Route server peer name

```yaml
Type: System.String
Parameter Sets: RouteServerPeerNameParameterSet
Aliases: ResourceName
Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Route server peer resource group's name

```yaml
Type: System.String
Parameter Sets: RouteServerPeerNameParameterSet
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RouteServerName
Route server name

```yaml
Type: System.String
Parameter Sets: RouteServerPeerNameParameterSet
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSRouteServerPeer

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPeerRoute

## NOTES

## RELATED LINKS