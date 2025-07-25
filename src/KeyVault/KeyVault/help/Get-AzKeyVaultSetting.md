---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultsetting
schema: 2.0.0
---

# Get-AzKeyVaultSetting

## SYNOPSIS
Retrieves a specified key vault account setting or all available key vault account settings that can be configured. 

## SYNTAX

### GetSettingViaFlattenParameters (Default)
```
Get-AzKeyVaultSetting [-DefaultProfile <IAzureContextContainer>] [-HsmName] <String> [[-Name] <String>]
 [<CommonParameters>]
```

### GetSettingViaHsmObject
```
Get-AzKeyVaultSetting [-DefaultProfile <IAzureContextContainer>] [-HsmObject] <PSManagedHsm> [[-Name] <String>]
 [<CommonParameters>]
```

### GetSettingViaHsmId
```
Get-AzKeyVaultSetting [-DefaultProfile <IAzureContextContainer>] [-HsmId] <String> [[-Name] <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzKeyVaultSetting** cmdlet gets key vault account settings.
This cmdlet gets a specific key vault account setting or all key vault account settings.

## EXAMPLES

### Example 1: Get all account settings in a Managed HSM
```powershell
Get-AzKeyVaultSetting -HsmName testmhsm
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets all account settings in a Managed HSM named `testmhsm`.

### Example 2: Get a specific key vault account setting in a Managed HSM
```powershell
Get-AzKeyVaultSetting -HsmName testmhsm -Name AllowKeyManagementOperationsThroughARM
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed HSM named `testmhsm`.

### Example 3: Get a specific key vault account setting in a Managed HSM via HsmObject
```powershell
$hsmObject = Get-AzKeyVaultManagedHsm -Name testmhsm
Get-AzKeyVaultSetting -HsmObject $hsmObject -Name AllowKeyManagementOperationsThroughARM
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed HSM named `testmhsm` via HsmObject.

### Example 4: Get a specific key vault account setting in a Managed HSM by piping HsmObject
```powershell
Get-AzKeyVaultManagedHsm -Name testmhsm | Get-AzKeyVaultSetting -Name AllowKeyManagementOperationsThroughARM
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed HSM named `testmhsm` via HsmObject.

### Example 4: Get a specific key vault account setting in a Managed HSM by piping HsmObject
```powershell
Get-AzKeyVaultManagedHsm -Name testmhsm | Get-AzKeyVaultSetting -Name AllowKeyManagementOperationsThroughARM
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed HSM named `testmhsm` by piping HsmObject.

### Example 5: Get a specific key vault account setting in a Managed HSM via HsmId
```powershell
Get-AzKeyVaultSetting -HsmId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.KeyVault/managedHSMs/testmhsm -Name AllowKeyManagementOperationsThroughARM
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM false boolean testmhsm
```

This cmdlet gets a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed HSM named `testmhsm` via HsmId.

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

### -HsmId
Hsm Resource Id.

```yaml
Type: System.String
Parameter Sets: GetSettingViaHsmId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: GetSettingViaFlattenParameters
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
Hsm Object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: GetSettingViaHsmObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the setting.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting

## NOTES

## RELATED LINKS

[Update-AzKeyVaultSetting](./Update-AzKeyVaultSetting.md)
