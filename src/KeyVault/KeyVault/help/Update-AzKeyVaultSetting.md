---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Update-AzKeyVaultSetting

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

###  UpdateSettingViaFlattenValues
```
Update-AzKeyVaultSetting [-HsmName] <String> [-Name] <String> [-Value] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### UpdateSettingViaHsmObject
```
Update-AzKeyVaultSetting [-Name] <String> [-Value] <String> [-DefaultProfile <IAzureContextContainer>]
 [-HsmObject] <PSManagedHsm> [<CommonParameters>]
```

### UpdateSettingViaHsmId
```
Update-AzKeyVaultSetting [-Name] <String> [-Value] <String> [-DefaultProfile <IAzureContextContainer>]
 [-HsmId] <String> [<CommonParameters>]
```

### UpdateSettingViaInputObject
```
Update-AzKeyVaultSetting [[-Value] <String>] [-InputObject] <PSKeyVaultSetting>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Parameter Sets:  UpdateSettingViaFlattenValues
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
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the setting.

```yaml
Type: System.String
Parameter Sets:  UpdateSettingViaFlattenValues, UpdateSettingViaHsmObject, UpdateSettingViaHsmId
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Value of the setting.

```yaml
Type: System.String
Parameter Sets:  UpdateSettingViaFlattenValues, UpdateSettingViaHsmObject, UpdateSettingViaHsmId
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSetting

## NOTES

## RELATED LINKS
