---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/test-aznetworkwatcherconnectivity
schema: 2.0.0
---

# Test-AzNetworkWatcherConnectivity

## SYNOPSIS
Verifies the possibility of establishing a direct TCP connection from a virtual machine to a given endpoint including another VM or an arbitrary remote server.

## SYNTAX

### CheckSubscriptionIdViaHost (Default)
```
Test-AzNetworkWatcherConnectivity -NetworkWatcherName <String> -ResourceGroupName <String>
 [-Parameter <IConnectivityParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckExpanded
```
Test-AzNetworkWatcherConnectivity -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-DestinationAddress <String>] [-DestinationPort <Int32>]
 [-DestinationResourceId <String>] [-HttpConfigurationHeader <IHttpHeader[]>]
 [-HttpConfigurationMethod <HttpMethod>] [-HttpConfigurationValidStatusCode <Int32[]>] [-Protocol <Protocol>]
 [-SourcePort <Int32>] -SourceResourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Check
```
Test-AzNetworkWatcherConnectivity -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Parameter <IConnectivityParameters>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckSubscriptionIdViaHostExpanded
```
Test-AzNetworkWatcherConnectivity -NetworkWatcherName <String> -ResourceGroupName <String>
 [-DestinationAddress <String>] [-DestinationPort <Int32>] [-DestinationResourceId <String>]
 [-HttpConfigurationHeader <IHttpHeader[]>] [-HttpConfigurationMethod <HttpMethod>]
 [-HttpConfigurationValidStatusCode <Int32[]>] [-Protocol <Protocol>] [-SourcePort <Int32>]
 -SourceResourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Verifies the possibility of establishing a direct TCP connection from a virtual machine to a given endpoint including another VM or an arbitrary remote server.

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

### -DestinationAddress
The IP address or URI the resource to which a connection attempt will be made.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPort
Port on which check connectivity will be performed.

```yaml
Type: System.Int32
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationResourceId
The ID of the resource to which a connection attempt will be made.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpConfigurationHeader
List of HTTP headers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[]
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpConfigurationMethod
HTTP method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpConfigurationValidStatusCode
Valid status codes.

```yaml
Type: System.Int32[]
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherName
The name of the network watcher resource.

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

### -Parameter
Parameters that determine how the connectivity check will be performed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters
Parameter Sets: CheckSubscriptionIdViaHost, Check
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Protocol
Network protocol.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
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

### -SourcePort
The source port from which a connectivity check will be performed.

```yaml
Type: System.Int32
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
The ID of the resource from which a connectivity check will be initiated.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckSubscriptionIdViaHostExpanded
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
Parameter Sets: CheckExpanded, Check
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformation
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/test-aznetworkwatcherconnectivity](https://docs.microsoft.com/en-us/powershell/module/az.network/test-aznetworkwatcherconnectivity)

