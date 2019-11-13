---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Set-AzsProductSecret

## SYNOPSIS
Sets product secret value.

## SYNTAX

### AdHoc
```
Set-AzsProductSecret -PackageId <String> -SecretName <String> -Value <SecureString> [-Force]
 [<CommonParameters>]
```

### Certificate
```
Set-AzsProductSecret -PackageId <String> -SecretName <String> -PfxFileName <String> -PfxPassword <SecureString>
 [-Force] [<CommonParameters>]
```

### Password
```
Set-AzsProductSecret -PackageId <String> -SecretName <String> -Password <SecureString> [-Force]
 [<CommonParameters>]
```

### SymmetricKey
```
Set-AzsProductSecret -PackageId <String> -SecretName <String> -Key <SecureString> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Locks the product subscription.

## EXAMPLES

### EXAMPLE 1
```
Set-AzsProductSecret -PackageId $PackageId -SecretName AdHoc -Value $value
```

Sets the product secret value to the given value.

### EXAMPLE 2
```
Set-AzsProductSecret -PackageId $PackageId -SecretName TlsCertificate -PfxFileName .\temp\ExternalCertificate\cert.pfx -PfxPassword $pfxPassword -Force
```

Sets the product secret value to the given value.

### EXAMPLE 3
```
Set-AzsProductSecret -PackageId $PackageId -SecretName ExternalSymmetricKey -Key $key -Force
```

Sets the product secret value to the given value.

## PARAMETERS

### -PackageId
Product package Id to set the product secret for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretName
Name of the secret.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Value of the secret.

```yaml
Type: SecureString
Parameter Sets: AdHoc
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PfxFileName
Location of the pfx file.

```yaml
Type: String
Parameter Sets: Certificate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PfxPassword
PFX file password.

```yaml
Type: SecureString
Parameter Sets: Certificate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
Password Value.

```yaml
Type: SecureString
Parameter Sets: Password
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Key
The symmetric key.

```yaml
Type: SecureString
Parameter Sets: SymmetricKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
