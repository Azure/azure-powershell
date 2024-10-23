---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/convert-aznetworkwatcherclassicconnectionmonitor
schema: 2.0.0
---

# Convert-AzNetworkWatcherClassicConnectionMonitor

## SYNOPSIS
Convert a classic connection monitor into connection monitor v2 with specified name. 

## SYNTAX

```
Convert-AzNetworkWatcherClassicConnectionMonitor -NetworkWatcherName <String> -ResourceGroupName <String>
 -Name <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Convert-AzNetworkWatcherClassicConnectionMonitor cmdlet returns the connection monitor V2 with the specified name corresponding to the specified network watcher and resource group.

## EXAMPLES

### Example 1
```powershell
$nw = Get-AzResource | Where-Object {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "centraluseuap" }
Convert-AzNetworkWatcherClassicConnectionMonitor -NetworkWatcherName $nw.Name -ResourceGroupName $nw.ResourceGroupName -Name "classicCm1"
```

```output
Migration is successful.
```

Passing the classic connection monitor name and corresponding network watcher name and its resource group name.

### Example 2
```powershell
$nw = Get-AzResource | Where-Object {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "centraluseuap" }
Convert-AzNetworkWatcherClassicConnectionMonitor -NetworkWatcherName $nw.Name -ResourceGroupName $nw.ResourceGroupName -Name "testCmv2"
```

```output
This Connection Monitor is already V2
```

Passing the V2 connection monitor name and corresponding network watcher name and its resource group name.

## PARAMETERS

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

### -Name
The classic connection monitor name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConnectionMonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -NetworkWatcherName
The name of network watcher.

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
The name of the network watcher resource group.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorResultV1

### Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorResultV2

## NOTES

## RELATED LINKS
