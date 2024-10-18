---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azadappcredential
schema: 2.0.0
---

# New-AzADAppCredential

## SYNOPSIS
Creates key credentials or password credentials for an application.

## SYNTAX

### ApplicationObjectIdWithPasswordParameterSet (Default)
```
New-AzADAppCredential -ObjectId <String> [-CustomKeyIdentifier <String>] [-EndDate <DateTime>]
 [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationIdWithCertValueParameterSet
```
New-AzADAppCredential -ApplicationId <Guid> -CertValue <String> [-CustomKeyIdentifier <String>]
 [-EndDate <DateTime>] [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ApplicationIdWithKeyCredentialParameterSet
```
New-AzADAppCredential -ApplicationId <Guid> -KeyCredentials <MicrosoftGraphKeyCredential[]>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationIdWithPasswordCredentialParameterSet
```
New-AzADAppCredential -ApplicationId <Guid> -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationIdWithPasswordParameterSet
```
New-AzADAppCredential -ApplicationId <Guid> [-CustomKeyIdentifier <String>] [-EndDate <DateTime>]
 [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectIdWithCertValueParameterSet
```
New-AzADAppCredential -CertValue <String> -ObjectId <String> [-CustomKeyIdentifier <String>]
 [-EndDate <DateTime>] [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ApplicationObjectIdWithKeyCredentialParameterSet
```
New-AzADAppCredential -KeyCredentials <MicrosoftGraphKeyCredential[]> -ObjectId <String>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectIdWithPasswordCredentialParameterSet
```
New-AzADAppCredential -ObjectId <String> -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectWithCertValueParameterSet
```
New-AzADAppCredential -ApplicationObject <IMicrosoftGraphApplication> -CertValue <String>
 [-CustomKeyIdentifier <String>] [-EndDate <DateTime>] [-StartDate <DateTime>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectWithKeyCredentialParameterSet
```
New-AzADAppCredential -ApplicationObject <IMicrosoftGraphApplication>
 -KeyCredentials <MicrosoftGraphKeyCredential[]> [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectWithPasswordCredentialParameterSet
```
New-AzADAppCredential -ApplicationObject <IMicrosoftGraphApplication>
 -PasswordCredentials <MicrosoftGraphPasswordCredential[]> [-CustomKeyIdentifier <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationObjectWithPasswordParameterSet
```
New-AzADAppCredential -ApplicationObject <IMicrosoftGraphApplication> [-CustomKeyIdentifier <String>]
 [-EndDate <DateTime>] [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DisplayNameWithCertValueParameterSet
```
New-AzADAppCredential -CertValue <String> -DisplayName <String> [-CustomKeyIdentifier <String>]
 [-EndDate <DateTime>] [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DisplayNameWithKeyCredentialParameterSet
```
New-AzADAppCredential -DisplayName <String> -KeyCredentials <MicrosoftGraphKeyCredential[]>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DisplayNameWithPasswordCredentialParameterSet
```
New-AzADAppCredential -DisplayName <String> -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DisplayNameWithPasswordParameterSet
```
New-AzADAppCredential -DisplayName <String> [-CustomKeyIdentifier <String>] [-EndDate <DateTime>]
 [-StartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates key credentials or password credentials for an application.

## EXAMPLES

### Example 1: Create key credentials for application
```powershell
# ObjectId is the string representation of a GUID for directory object, application, in Azure AD.
$Id = "00000000-0000-0000-0000-000000000000"
# $cert is Base64 encoded content of certificate
$credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                 -Property @{'Key' = $cert;
                                 'Usage'       = 'Verify';
                                 'Type'        = 'AsymmetricX509Cert'
                                 }
New-AzADAppCredential -ObjectId $Id -KeyCredentials $credential
```

Create key credentials for application with object Id $Id

### Example 2: Create password credentials for application
```powershell
# ApplicationId is AppId of Application object which is different from directory id in Azure AD.
Get-AzADApplication -ApplicationId $appId | New-AzADAppCredential -StartDate $startDate -EndDate $endDate
```

Create password credentials for application

## PARAMETERS

### -ApplicationId
The application Id.

```yaml
Type: System.Guid
Parameter Sets: ApplicationIdWithCertValueParameterSet, ApplicationIdWithKeyCredentialParameterSet, ApplicationIdWithPasswordCredentialParameterSet, ApplicationIdWithPasswordParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationObject
The application object, could be used as pipeline input.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication
Parameter Sets: ApplicationObjectWithCertValueParameterSet, ApplicationObjectWithKeyCredentialParameterSet, ApplicationObjectWithPasswordCredentialParameterSet, ApplicationObjectWithPasswordParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CertValue
The value of the 'asymmetric' credential type.
It represents the base 64 encoded certificate.

```yaml
Type: System.String
Parameter Sets: ApplicationIdWithCertValueParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectWithCertValueParameterSet, DisplayNameWithCertValueParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomKeyIdentifier
Custom Key Identifier.
The format should be base64: `$Bytes=[System.Text.Encoding]::Unicode.GetBytes($key);$key=[Convert]::ToBase64String($Bytes)`

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of application.

```yaml
Type: System.String
Parameter Sets: DisplayNameWithCertValueParameterSet, DisplayNameWithKeyCredentialParameterSet, DisplayNameWithPasswordCredentialParameterSet, DisplayNameWithPasswordParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndDate
The effective end date of the credential usage.
The default end date value is one year from today.
For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.

```yaml
Type: System.DateTime
Parameter Sets: ApplicationIdWithCertValueParameterSet, ApplicationIdWithPasswordParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectIdWithPasswordParameterSet, ApplicationObjectWithCertValueParameterSet, ApplicationObjectWithPasswordParameterSet, DisplayNameWithCertValueParameterSet, DisplayNameWithPasswordParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyCredentials
key credentials associated with the application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential[]
Parameter Sets: ApplicationIdWithKeyCredentialParameterSet, ApplicationObjectIdWithKeyCredentialParameterSet, ApplicationObjectWithKeyCredentialParameterSet, DisplayNameWithKeyCredentialParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The object Id of application.

```yaml
Type: System.String
Parameter Sets: ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectIdWithKeyCredentialParameterSet, ApplicationObjectIdWithPasswordCredentialParameterSet, ApplicationObjectIdWithPasswordParameterSet
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordCredentials
Password credentials associated with the application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential[]
Parameter Sets: ApplicationIdWithPasswordCredentialParameterSet, ApplicationObjectIdWithPasswordCredentialParameterSet, ApplicationObjectWithPasswordCredentialParameterSet, DisplayNameWithPasswordCredentialParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
The effective start date of the credential usage.
The default start date value is today.
For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.

```yaml
Type: System.DateTime
Parameter Sets: ApplicationIdWithCertValueParameterSet, ApplicationIdWithPasswordParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectIdWithPasswordParameterSet, ApplicationObjectWithCertValueParameterSet, ApplicationObjectWithPasswordParameterSet, DisplayNameWithCertValueParameterSet, DisplayNameWithPasswordParameterSet
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential

## NOTES

## RELATED LINKS

