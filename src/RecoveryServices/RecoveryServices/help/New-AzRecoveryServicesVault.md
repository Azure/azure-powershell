---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 9591E150-54DA-48B7-8656-3891833FE61E
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesvault
schema: 2.0.0
---

# New-AzRecoveryServicesVault

## SYNOPSIS
Creates a new Recovery Services vault.

## SYNTAX

```
New-AzRecoveryServicesVault -Name <String> -ResourceGroupName <String> -Location <String> [-Tag <Hashtable>]
 [-DisableClassicAlerts <Boolean>] [-DisableAzureMonitorAlertsForJobFailure <Boolean>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-ImmutabilityState <ImmutabilityState>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzRecoveryServicesVault** cmdlet creates a new Recovery Services vault.

## EXAMPLES

### Example 1
```powershell
New-AzRecoveryServicesVault -Name "vaultName" -ResourceGroupName "rg" -Location "eastasia"
```

Create recovery service vault in resource group and given location.

### Example 2: reate recovery service vault with ImmutabilityState, PublicNetworkAccess options
```powershell
$tag= @{"tag1"="value1";"tag2"="value2"}
New-AzRecoveryServicesVault -Name "vaultName" -ResourceGroupName "resourceGroupName" -Location "westus" -Tag $tag -ImmutabilityState "Unlocked" -PublicNetworkAccess "Disabled"
```

Create recovery service vault with options like ImmutabilityState, PublicNetworkAccess. Please note Public Network Access is by default enabled for RS vault (if not specified) and can be updated using Update-AzRecoveryServicesVault cmdlet.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -DisableAzureMonitorAlertsForJobFailure
Boolean paramter to specify whether built-in Azure Monitor alerts should be received for every job failure.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableClassicAlerts
Boolean paramter to specify whether backup alerts from the classic solution should be disabled or enabled.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityState
Immutability State of the vault. Allowed values are "Disabled", "Unlocked", "Locked". 
Unlocked means Enabled and can be changed, Locked means Enabled and can't be changed.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.RecoveryServices.ImmutabilityState]
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Unlocked

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the name of the geographic location of the vault.

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

### -Name
Specifies the name of the vault to create.

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

### -PublicNetworkAccess
Parameter to Enable/Disable public network access of the vault. This setting is useful with Private Endpoints.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.RecoveryServices.PublicNetworkAccess]
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the Azure resource group in which to create or from which to retrieve the specified Recovery Services object.

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

### -Tag

Specifies the Tags to add to the Recovery Services Vault

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.RecoveryServices.ARSVault

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesVault](./Get-AzRecoveryServicesVault.md)

[Get-AzRecoveryServicesVaultSettingsFile](./Get-AzRecoveryServicesVaultSettingsFile.md)

[Remove-AzRecoveryServicesVault](./Remove-AzRecoveryServicesVault.md)


