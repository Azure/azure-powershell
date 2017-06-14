---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: D602F910-B26F-473D-B5B6-C7BDFB0A14CB
online version: 
schema: 2.0.0
---

# New-AzureRmADServicePrincipal

## SYNOPSIS
Creates a new azure active directory service principal.

## SYNTAX

### ApplicationWithoutCredentialParameterSet (Default)
```
New-AzureRmADServicePrincipal -ApplicationId <Guid> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationWithPasswordPlainParameterSet
```
New-AzureRmADServicePrincipal -ApplicationId <Guid> -Password <String> [-StartDate <DateTime>]
 [-EndDate <DateTime>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationWithPasswordCredentialParameterSet
```
New-AzureRmADServicePrincipal -ApplicationId <Guid> -PasswordCredentials <PSADPasswordCredential[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ApplicationWithKeyPlainParameterSet
```
New-AzureRmADServicePrincipal -ApplicationId <Guid> -CertValue <String> [-StartDate <DateTime>]
 [-EndDate <DateTime>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationWithKeyCredentialParameterSet
```
New-AzureRmADServicePrincipal -ApplicationId <Guid> -KeyCredentials <PSADKeyCredential[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DisplayNameWithoutCredentialParameterSet
```
New-AzureRmADServicePrincipal -DisplayName <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithPasswordPlainParameterSet
```
New-AzureRmADServicePrincipal -DisplayName <String> -Password <String> [-StartDate <DateTime>]
 [-EndDate <DateTime>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithPasswordCredentialParameterSet
```
New-AzureRmADServicePrincipal -DisplayName <String> -PasswordCredentials <PSADPasswordCredential[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DisplayNameWithKeyPlainParameterSet
```
New-AzureRmADServicePrincipal -DisplayName <String> -CertValue <String> [-StartDate <DateTime>]
 [-EndDate <DateTime>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithKeyCredentialParameterSet
```
New-AzureRmADServicePrincipal -DisplayName <String> -KeyCredentials <PSADKeyCredential[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new azure active directory service principal.

Note: The cmdlet also implicitly creates an application and sets its properties (if the ApplicationId is not provided).
In order to update the application specific parameters please use Set-AzureRmADApplication cmdlet.

## EXAMPLES

### --------------------------  Example 1  --------------------------
```
New-AzureRmADServicePrincipal -ApplicationId 34a28ad2-dec4-4a41-bc3b-d22ddf90000e
```

Creates a new azure active directory service principal.

DisplayName                    Type                           ObjectId
-----------                    ----                           --------
DemoApp                        ServicePrincipal               f95b6f5c-fc98-4af0-bb8a-34a14ca1dca1

### --------------------------  Example 2  --------------------------
```
New-AzureRmADServicePrincipal -DisplayName SPForNoExistingApp
```

Creates a new service principal.
The cmdlet also implicitly creates an application since one is not provided.

DisplayName                    Type                           ObjectId
-----------                    ----                           --------
SPForNoExistingApp             ServicePrincipal               784136ca-3ae2-4fdd-a388-89d993e7c780

## PARAMETERS

### -ApplicationId
The unique application id for a service principal in a tenant.
Once created this property cannot be changed.
If an application id is not specified, one will be generated.

```yaml
Type: Guid
Parameter Sets: ApplicationWithoutCredentialParameterSet, ApplicationWithPasswordPlainParameterSet, ApplicationWithPasswordCredentialParameterSet, ApplicationWithKeyPlainParameterSet, ApplicationWithKeyCredentialParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertValue
The value of the "asymmetric" credential type.
It represents the base 64 encoded certificate.

```yaml
Type: String
Parameter Sets: ApplicationWithKeyPlainParameterSet, DisplayNameWithKeyPlainParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
The friendly name of the service principal.

```yaml
Type: String
Parameter Sets: DisplayNameWithoutCredentialParameterSet, DisplayNameWithPasswordPlainParameterSet, DisplayNameWithPasswordCredentialParameterSet, DisplayNameWithKeyPlainParameterSet, DisplayNameWithKeyCredentialParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndDate
The effective end date of the credential usage.
The default end date value is one year from today. 
For an "asymmetric" type credential, this must be set to on or before the date that the X509 certificate is valid.

```yaml
Type: DateTime
Parameter Sets: ApplicationWithPasswordPlainParameterSet, ApplicationWithKeyPlainParameterSet, DisplayNameWithPasswordPlainParameterSet, DisplayNameWithKeyPlainParameterSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyCredentials
The list of certificate credentials associated with the service principal.

```yaml
Type: PSADKeyCredential[]
Parameter Sets: ApplicationWithKeyCredentialParameterSet, DisplayNameWithKeyCredentialParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Password
The password to be associated with the service principal.

```yaml
Type: String
Parameter Sets: ApplicationWithPasswordPlainParameterSet, DisplayNameWithPasswordPlainParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PasswordCredentials
The list of password credentials associated with the service principal.

```yaml
Type: PSADPasswordCredential[]
Parameter Sets: ApplicationWithPasswordCredentialParameterSet, DisplayNameWithPasswordCredentialParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartDate
The effective start date of the credential usage.
The default start date value is today. 
For an "asymmetric" type credential, this must be set to on or after the date that the X509 certificate is valid from.

```yaml
Type: DateTime
Parameter Sets: ApplicationWithPasswordPlainParameterSet, ApplicationWithKeyPlainParameterSet, DisplayNameWithPasswordPlainParameterSet, DisplayNameWithKeyPlainParameterSet
Aliases: 

Required: False
Position: Named
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[Remove-AzureRmADServicePrincipal](./Remove-AzureRmADServicePrincipal.md)

[Get-AzureRmADServicePrincipal](./Get-AzureRmADServicePrincipal.md)

[New-AzureRmADApplication](./New-AzureRmADApplication.md)

[Remove-AzureRmADApplication](./Remove-AzureRmADApplication.md)

[Get-AzureRmADSpCredential](./Get-AzureRmADSpCredential.md)

[New-AzureRmADSpCredential](./New-AzureRmADSpCredential.md)

[Remove-AzureRmADSpCredential](./Remove-AzureRmADSpCredential.md)

