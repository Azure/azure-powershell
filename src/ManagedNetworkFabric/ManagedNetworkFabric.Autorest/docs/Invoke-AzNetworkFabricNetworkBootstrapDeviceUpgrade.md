---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabricnetworkbootstrapdeviceupgrade
schema: 2.0.0
---

# Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade

## SYNOPSIS
Upgrades the version of the Network Bootstrap Device.

## SYNTAX

### UpgradeExpanded (Default)
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -Name <String> -ResourceGroupName <String>
 -Body <IUpdateVersion> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentity
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -InputObject <IManagedNetworkFabricIdentity>
 -Body <IUpdateVersion> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -InputObject <IManagedNetworkFabricIdentity>
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpgradeViaJsonString
```
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Upgrades the version of the Network Bootstrap Device.

## EXAMPLES

### Example 1: Upgrade a Network Bootstrap Device
```powershell
Invoke-AzNetworkFabricNetworkBootstrapDeviceUpgrade -Name $name -ResourceGroupName $resourceGroupName
```

This command upgrades the given Network Bootstrap Device.

## PARAMETERS

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

### -Body
Update version properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IUpdateVersion
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpgradeViaIdentity, UpgradeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network Bootstrap Device.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases: NetworkBootstrapDeviceName

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
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Specify the version.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IUpdateVersion

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkBootstrapDeviceUpgradeResponse

## NOTES

## RELATED LINKS

