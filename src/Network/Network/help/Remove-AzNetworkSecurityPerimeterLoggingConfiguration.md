---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-aznetworksecurityperimeterloggingconfiguration
schema: 2.0.0
---

# Remove-AzNetworkSecurityPerimeterLoggingConfiguration

## SYNOPSIS
Deletes an NSP Logging configuration.

## SYNTAX

### Delete (Default)
```
Remove-AzNetworkSecurityPerimeterLoggingConfiguration [-Name <String>] -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityNetworkSecurityPerimeter
```
Remove-AzNetworkSecurityPerimeterLoggingConfiguration [-Name <String>]
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Deletes an NSP Logging configuration.

## EXAMPLES

### Example 1: Remove the Network security perimeter logging configuration
```powershell
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3
```

Get the Network security perimeter logging configuration

### Example 2: Remove a network security perimeter logging configuration via identity
```powershell
$configObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_Ex -SecurityPerimeterName ext-nsp11
 Remove-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $configObj
```

Remove a network security perimeter logging configuration via identity

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the NSP logging configuration.
Accepts 'instance' as name.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityNetworkSecurityPerimeter
Aliases: LoggingConfigurationName

Required: False
Position: Named
Default value: "instance"
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityPerimeterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: DeleteViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityPerimeterName
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: NetworkSecurityPerimeterName, NSPName

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
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
