---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-aznetworkwatchernetworkconfigurationdiagnostic
schema: 2.0.0
---

# Get-AzNetworkWatcherNetworkConfigurationDiagnostic

## SYNOPSIS
Get network configuration diagnostic.

## SYNTAX

### Get (Default)
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-Parameter <INetworkConfigurationDiagnosticParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetExpanded
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> -Profile <INetworkConfigurationDiagnosticProfile[]> -TargetResourceId <String>
 [-VerbosityLevel <VerbosityLevel>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -InputObject <INetworkIdentity>
 -Profile <INetworkConfigurationDiagnosticProfile[]> -TargetResourceId <String>
 [-VerbosityLevel <VerbosityLevel>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkWatcherNetworkConfigurationDiagnostic -InputObject <INetworkIdentity>
 [-Parameter <INetworkConfigurationDiagnosticParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get network configuration diagnostic.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GetViaIdentityExpanded, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkWatcherName
The name of the network watcher.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters to get network configuration diagnostic.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticParameters
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Profile
List of network configuration diagnostic profiles.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[]
Parameter Sets: GetExpanded, GetViaIdentityExpanded
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
Parameter Sets: Get, GetExpanded
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
Type: System.String[]
Parameter Sets: Get, GetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/get-aznetworkwatchernetworkconfigurationdiagnostic](https://docs.microsoft.com/en-us/powershell/module/az.network/get-aznetworkwatchernetworkconfigurationdiagnostic)

