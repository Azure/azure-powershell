---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/update-azkeyvaultsetting
schema: 2.0.0
---

# Update-AzKeyVaultSetting

## SYNOPSIS
Update specific setting associated with the managed HSM.

## SYNTAX

### UpdateSettingViaFlattenValues (Default)
```
Update-AzKeyVaultSetting [-HsmName] <String> [-Name] <String> [-Value] <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateSettingViaInputObject
```
Update-AzKeyVaultSetting [[-HsmName] <String>] [[-Value] <String>] [-InputObject] <PSKeyVaultSetting>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateSettingViaHsmObject
```
Update-AzKeyVaultSetting [-Name] <String> [-Value] <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-HsmObject] <PSManagedHsm> [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSettingViaHsmId
```
Update-AzKeyVaultSetting [-Name] <String> [-Value] <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-HsmId] <String> [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzKeyVaultSetting** cmdlet updates key vault account settings.
This cmdlet updates a specific key vault account setting.

## EXAMPLES

### Example 1: Update a specific key vault account setting
```powershell
Update-AzKeyVaultSetting -HsmName testmhsm -Name AllowKeyManagementOperationsThroughARM -Value true -PassThru
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM true  boolean testmhsm
```

Update a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed Hsm named `testmhsm`.

### Example 2: Update a specific key vault account setting same as another account setting
```powershell
$setting = Get-AzKeyVaultSetting -HsmName testmhsm1 -Name AllowKeyManagementOperationsThroughARM
$setting | Update-AzKeyVaultSetting -HsmName testmhsm2 -PassThru
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM true  boolean testmhsm2
```

Update a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed Hsm named `testmhsm2` same with `testmhsm1`.

### Example 3: Update a specific key vault account setting via HsmObject

```powershell
$hsmObject = Get-AzKeyVaultManagedHsm -Name testmhsm
Update-AzKeyVaultSetting -HsmObject $hsmObject -Name AllowKeyManagementOperationsThroughARM -Value true -PassThru
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM true  boolean testmhsm
```

Update a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed Hsm named `testmhsm` via HsmObject.

### Example 4: Update a specific key vault account setting via HsmId

```powershell
$hsmObject = Get-AzKeyVaultManagedHsm -Name testmhsm
Update-AzKeyVaultSetting -HsmId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.KeyVault/managedHSMs/testmhsm-Name AllowKeyManagementOperationsThroughARM -Value true -PassThru
```

```output
Name                                   Value Type    HSM Name
----                                   ----- ----    --------
AllowKeyManagementOperationsThroughARM true  boolean testmhsm
```

Update a specific key vault account setting named `AllowKeyManagementOperationsThroughARM` in a Managed Hsm named `testmhsm` via HsmObject.

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
Parameter Sets: UpdateSettingViaHsmId
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
Parameter Sets: UpdateSettingViaFlattenValues
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UpdateSettingViaInputObject
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
Hsm Object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: UpdateSettingViaHsmObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The location of the deleted vault.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting
Parameter Sets: UpdateSettingViaInputObject
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the setting.

```yaml
Type: System.String
Parameter Sets: UpdateSettingViaFlattenValues, UpdateSettingViaHsmObject, UpdateSettingViaHsmId
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Cmdlet does not return object by default. If this switch is specified, return Secret object.

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

### -Value
Value of the setting.

```yaml
Type: System.String
Parameter Sets: UpdateSettingViaFlattenValues, UpdateSettingViaHsmObject, UpdateSettingViaHsmId
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UpdateSettingViaInputObject
Aliases:

Required: False
Position: 2
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting

## NOTES

## RELATED LINKS

[Get-AzKeyVaultSetting](./Get-AzKeyVaultSetting.md)
