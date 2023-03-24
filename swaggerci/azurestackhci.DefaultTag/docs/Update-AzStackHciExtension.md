---
external help file:
Module Name: Az.StackHci
online version: https://learn.microsoft.com/powershell/module/az.stackhci/update-azstackhciextension
schema: 2.0.0
---

# Update-AzStackHciExtension

## SYNOPSIS
Update Extension for HCI cluster.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStackHciExtension -ArcSettingName <String> -ClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ExtensionParameterAutoUpgradeMinorVersion]
 [-ExtensionParameterEnableAutomaticUpgrade] [-ExtensionParameterForceUpdateTag <String>]
 [-ExtensionParameterProtectedSetting <IAny>] [-ExtensionParameterPublisher <String>]
 [-ExtensionParameterSetting <IAny>] [-ExtensionParameterType <String>]
 [-ExtensionParameterTypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStackHciExtension -InputObject <IStackHciIdentity> [-ExtensionParameterAutoUpgradeMinorVersion]
 [-ExtensionParameterEnableAutomaticUpgrade] [-ExtensionParameterForceUpdateTag <String>]
 [-ExtensionParameterProtectedSetting <IAny>] [-ExtensionParameterPublisher <String>]
 [-ExtensionParameterSetting <IAny>] [-ExtensionParameterType <String>]
 [-ExtensionParameterTypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Update-AzStackHciExtension -ArcSettingName <String> -ClusterName <String> -Name <String>
 -ResourceGroupName <String> -ExtensionUpgradeParameter <IExtensionUpgradeParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeExpanded
```
Update-AzStackHciExtension -ArcSettingName <String> -ClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-TargetVersion <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentity
```
Update-AzStackHciExtension -InputObject <IStackHciIdentity>
 -ExtensionUpgradeParameter <IExtensionUpgradeParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Update-AzStackHciExtension -InputObject <IStackHciIdentity> [-TargetVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update Extension for HCI cluster.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ArcSettingName
The name of the proxy resource holding details of HCI ArcSetting information.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Upgrade, UpgradeExpanded
Aliases:

Required: True
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Upgrade, UpgradeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ExtensionParameterAutoUpgradeMinorVersion
Indicates whether the extension should use a newer minor version if one is available at deployment time.
Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterEnableAutomaticUpgrade
Indicates whether the extension should be automatically upgraded by the platform if there is a newer version available.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterForceUpdateTag
How the extension handler should be forced to update even if the extension configuration has not changed.

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

### -ExtensionParameterProtectedSetting
Protected settings (may contain secrets).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.IAny
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterPublisher
The name of the extension handler publisher.

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

### -ExtensionParameterSetting
Json formatted public settings for the extension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.IAny
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterType
Specifies the type of the extension; an example is "CustomScriptExtension".

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

### -ExtensionParameterTypeHandlerVersion
Specifies the version of the script handler.
Latest version would be used if not specified.

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

### -ExtensionUpgradeParameter
Describes the parameters for Extension upgrade.
To construct, see NOTES section for EXTENSIONUPGRADEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.Api20230301.IExtensionUpgradeParameters
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.IStackHciIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpgradeViaIdentity, UpgradeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the machine extension.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Upgrade, UpgradeExpanded
Aliases: ExtensionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Upgrade, UpgradeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Upgrade, UpgradeExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVersion
Extension Upgrade Target Version.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.Api20230301.IExtensionUpgradeParameters

### Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.IStackHciIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHci.Models.Api20230301.IExtension

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`EXTENSIONUPGRADEPARAMETER <IExtensionUpgradeParameters>`: Describes the parameters for Extension upgrade.
  - `[TargetVersion <String>]`: Extension Upgrade Target Version.

`INPUTOBJECT <IStackHciIdentity>`: Identity Parameter
  - `[ArcSettingName <String>]`: The name of the proxy resource holding details of HCI ArcSetting information.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[Id <String>]`: Resource identity path
  - `[OfferName <String>]`: The name of the offer available within HCI cluster.
  - `[PublisherName <String>]`: The name of the publisher available within HCI cluster.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SkuName <String>]`: The name of the SKU available within HCI cluster.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpdateName <String>]`: The name of the Update
  - `[UpdateRunName <String>]`: The name of the Update Run

## RELATED LINKS

