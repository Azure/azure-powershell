---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-aznetworkwatchernetworkconfigurationdiagnostic
schema: 2.0.0
---

# Get-AzNetworkWatcherNetworkConfigurationDiagnostic

## SYNOPSIS
Get network configuration diagnostic.

## SYNTAX

### GetViaIdentity (Default)
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -InputObject <INetworkIdentity>
 -NetworkConfigurationDiagnostic <INetworkConfigurationDiagnosticParameters> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetExpanded
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> -Profile <INetworkConfigurationDiagnosticProfile[]> -TargetResourceId <String>
 [-VerbosityLevel <VerbosityLevel>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> -NetworkConfigurationDiagnostic <INetworkConfigurationDiagnosticParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -InputObject <INetworkIdentity>
 -Profile <INetworkConfigurationDiagnosticProfile[]> -TargetResourceId <String>
 [-VerbosityLevel <VerbosityLevel>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get network configuration diagnostic.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -NetworkConfigurationDiagnostic
Parameters to get network configuration diagnostic.
To construct, see NOTES section for NETWORKCONFIGURATIONDIAGNOSTIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticParameters
Parameter Sets: GetViaIdentity, Get
Aliases: NetworkWatcher

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherName
The name of the network watcher.

```yaml
Type: System.String
Parameter Sets: GetExpanded, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

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

### -Profile
List of network configuration diagnostic profiles.
To construct, see NOTES section for PROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[]
Parameter Sets: GetExpanded, GetViaIdentityExpanded
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
Parameter Sets: GetExpanded, Get
Aliases: Location

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
Type: System.String[]
Parameter Sets: GetExpanded, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
The ID of the target resource to perform network configuration diagnostic.
Valid options are VM, NetworkInterface, VMSS/NetworkInterface and Application Gateway.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VerbosityLevel
Verbosity level.
Accepted values are 'Normal', 'Minimum', 'Full'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel
Parameter Sets: GetExpanded, GetViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult

## ALIASES

### Invoke-AzNetworkWatcherNetworkConfigurationDiagnostic

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### NETWORKCONFIGURATIONDIAGNOSTIC <INetworkConfigurationDiagnosticParameters>: Parameters to get network configuration diagnostic.
  - `Profile <INetworkConfigurationDiagnosticProfile[]>`: List of network configuration diagnostic profiles.
    - `Destination <String>`: Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.
    - `DestinationPort <String>`: Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
    - `Direction <Direction>`: The direction of the traffic.
    - `Protocol <String>`: Protocol to be verified on. Accepted values are '*', TCP, UDP.
    - `Source <String>`: Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.
  - `TargetResourceId <String>`: The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface and Application Gateway.
  - `[VerbosityLevel <VerbosityLevel?>]`: Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.

#### PROFILE <INetworkConfigurationDiagnosticProfile[]>: List of network configuration diagnostic profiles.
  - `Destination <String>`: Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.
  - `DestinationPort <String>`: Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
  - `Direction <Direction>`: The direction of the traffic.
  - `Protocol <String>`: Protocol to be verified on. Accepted values are '*', TCP, UDP.
  - `Source <String>`: Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.

## RELATED LINKS

