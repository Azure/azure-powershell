---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-aznetworkwatcherconnectionmonitorendpointobject
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorEndpointObject

## SYNOPSIS
Creates connection monitor endpoint.

## SYNTAX

### SetByResourceId
```
New-AzNetworkWatcherConnectionMonitorEndpointObject [-Name <String>] -Type <String> -ResourceId <String>
 [-IncludeItem <PSNetworkWatcherConnectionMonitorEndpointScopeItem[]>]
 [-ExcludeItem <PSNetworkWatcherConnectionMonitorEndpointScopeItem[]>] [-CoverageLevel <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByAddress
```
New-AzNetworkWatcherConnectionMonitorEndpointObject [-Name <String>] -Type <String> [-Address <String>]
 [-CoverageLevel <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
New-AzNetworkWatcherConnectionMonitorEndpointObject cmdlet creates connection monitor endpoint.

## EXAMPLES

### Example 1: Create an endpoint with one included scope item
```
PS C:\>$MySrcResourceId1 = "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourceGroup/providers/Microsoft.OperationalInsights/workspaces/myworkspace"
PS C:\>$SrcEndpointScopeItem1 = New-AzNetworkWatcherConnectionMonitorEndpointScopeItemObject -Address "WIN-P0HGNDO2S1B"
PS C:\>$SourceEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndpointObject -Name "workspaceEndpoint" -Type "MMAWorkspaceMachine" -ResourceId $MySrcResourceId1 -IncludeItem $SrcEndpointScopeItem1
```

Name       : workspaceEndpoint
Type       : MMAWorkspaceMachine
ResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourceGroup/providers/Microsoft.OperationalInsights/workspaces/myworkspace
Address    :
Scope     : {
               "Include": [
                 {
                   "Address": "WIN-P0HGNDO2S1B"
                 }
               ]
             }

## PARAMETERS

### -Address
Address of the connection monitor endpoint (IP or domain name).

```yaml
Type: System.String
Parameter Sets: SetByAddress
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoverageLevel
Test coverage for the endpoint.
Supported values are Default, Low, BelowAverage, Average, AboveAverage, Full.

```yaml
Type: System.String
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

### -ExcludeItem
List of items which need to be excluded from endpoint scope.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointScopeItem[]
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeItem
List of items which need to be included into endpont scope.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointScopeItem[]
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the connection monitor endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource ID of the connection monitor endpoint.

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the connection monitor endpoint.
Supported types are AzureVM, AzureVNet, AzureSubnet, ExternalAddress, MMAWorkspaceMachine, MMAWorkspaceNetwork.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject

## NOTES

## RELATED LINKS
