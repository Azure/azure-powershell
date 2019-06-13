---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/test-aznetworkwatcheripflow
schema: 2.0.0
---

# Test-AzNetworkWatcherIPFlow

## SYNOPSIS
Verify IP flow from the specified VM to a location given the currently configured NSG rules.

## SYNTAX

### Verify (Default)
```
Test-AzNetworkWatcherIPFlow -NetworkWatcherName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IVerificationIPFlowParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### VerifyExpanded
```
Test-AzNetworkWatcherIPFlow -NetworkWatcherName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Direction <Direction> -LocalIPAddress <String> -LocalPort <String> -Protocol <IPFlowProtocol>
 -RemoteIPAddress <String> -RemotePort <String> -TargetResourceId <String> [-TargetNicResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### VerifyViaIdentityExpanded
```
Test-AzNetworkWatcherIPFlow -InputObject <INetworkIdentity> -Direction <Direction> -LocalIPAddress <String>
 -LocalPort <String> -Protocol <IPFlowProtocol> -RemoteIPAddress <String> -RemotePort <String>
 -TargetResourceId <String> [-TargetNicResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### VerifyViaIdentity
```
Test-AzNetworkWatcherIPFlow -InputObject <INetworkIdentity> [-Parameter <IVerificationIPFlowParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Verify IP flow from the specified VM to a location given the currently configured NSG rules.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
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
Dynamic: False
```

### -Direction
The direction of the packet represented as a 5-tuple.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: VerifyViaIdentityExpanded, VerifyViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -LocalIPAddress
The local IP address.
Acceptable values are valid IPv4 addresses.

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalPort
The local port.
Acceptable values are a single integer in the range (0-65535).
Support for * for the source port, which depends on the direction.

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherName
The name of the network watcher.

```yaml
Type: System.String
Parameter Sets: Verify, VerifyExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Parameters that define the IP flow to be verified.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters
Parameter Sets: Verify, VerifyViaIdentity
Aliases: NetworkWatcher

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
Protocol to be verified on.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RemoteIPAddress
The remote IP address.
Acceptable values are valid IPv4 addresses.

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RemotePort
The remote port.
Acceptable values are a single integer in the range (0-65535).
Support for * for the source port, which depends on the direction.

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Verify, VerifyExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Verify, VerifyExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetNicResourceId
The NIC ID.
(If VM has multiple NICs and IP forwarding is enabled on any of them, then this parameter must be specified.
Otherwise optional).

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
The ID of the target resource to perform next-hop on.

```yaml
Type: System.String
Parameter Sets: VerifyExpanded, VerifyViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowResult

## ALIASES

## RELATED LINKS

