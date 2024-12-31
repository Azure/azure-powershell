---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version:
schema: 2.0.0
---

# New-AzCognitiveServicesAccountEncryptionScope

## SYNOPSIS
Create or update Encryption Scope of a Cognitive Services account

## SYNTAX

### DefaultParameterSet (Default)
```
New-AzCognitiveServicesAccountEncryptionScope [-ResourceGroupName] <String> [-AccountName] <String>
 [-Name] <String> [-CognitiveServicesEncryption] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AccountKeyVaultParameterSet
```
New-AzCognitiveServicesAccountEncryptionScope [-ResourceGroupName] <String> [-AccountName] <String>
 [-Name] <String> [-KeyVaultEncryption] -KeyUri <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update Encryption Scope of a Cognitive Services account

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzCognitiveServicesAccountEncryptionScope -ResourceGroupName "rgname" -AccountName "accountname" -Name "EncryptionScopeName" -KeyUri "newkeyVaultUri" -KeyVaultEncryption
```

Create or update Encryption Scope of a Cognitive Services account


## PARAMETERS

### -AccountName
Cognitive Services Account Name.

```yaml
Type: String
Parameter Sets: DefaultParameterSet
Aliases: CognitiveServicesAccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: AccountKeyVaultParameterSet
Aliases: CognitiveServicesAccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CognitiveServicesEncryption
Create encryption scope with keySource as Microsoft.CognitiveServices.

```yaml
Type: SwitchParameter
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyUri
Create encryption scope with keySource as Microsoft.Keyvault.

```yaml
Type: String
Parameter Sets: AccountKeyVaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultEncryption
Create encryption scope with keySource as Microsoft.CognitiveServices.

```yaml
Type: SwitchParameter
Parameter Sets: AccountKeyVaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Cognitive Services EncryptionScope Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: AccountKeyVaultParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

## OUTPUTS

### Microsoft.Azure.Management.CognitiveServices.Models.EncryptionScope

## NOTES

## RELATED LINKS
