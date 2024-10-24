---
external help file: Az.Resources-help.xml
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
New-AzADAppCredential -ObjectId <String> [-StartDate <DateTime>] [-EndDate <DateTime>]
 [-CustomKeyIdentifier <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ApplicationObjectIdWithCertValueParameterSet
```
New-AzADAppCredential -ObjectId <String> [-StartDate <DateTime>] [-EndDate <DateTime>]
 [-CustomKeyIdentifier <String>] -CertValue <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationObjectIdWithKeyCredentialParameterSet
```
New-AzADAppCredential -ObjectId <String> [-CustomKeyIdentifier <String>]
 -KeyCredentials <MicrosoftGraphKeyCredential[]> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationObjectIdWithPasswordCredentialParameterSet
```
New-AzADAppCredential -ObjectId <String> [-CustomKeyIdentifier <String>]
 -PasswordCredentials <MicrosoftGraphPasswordCredential[]> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationObjectWithPasswordParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -ApplicationObject <IMicrosoftGraphApplication> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationObjectWithCertValueParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -CertValue <String> -ApplicationObject <IMicrosoftGraphApplication> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithPasswordParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -DisplayName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DisplayNameWithCertValueParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -CertValue <String> -DisplayName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationIdWithCertValueParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -CertValue <String> -ApplicationId <Guid> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationIdWithPasswordParameterSet
```
New-AzADAppCredential [-StartDate <DateTime>] [-EndDate <DateTime>] [-CustomKeyIdentifier <String>]
 -ApplicationId <Guid> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ApplicationObjectWithPasswordCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 -ApplicationObject <IMicrosoftGraphApplication> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithPasswordCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 -DisplayName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ApplicationIdWithPasswordCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -PasswordCredentials <MicrosoftGraphPasswordCredential[]>
 -ApplicationId <Guid> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ApplicationObjectWithKeyCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -KeyCredentials <MicrosoftGraphKeyCredential[]>
 -ApplicationObject <IMicrosoftGraphApplication> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisplayNameWithKeyCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -KeyCredentials <MicrosoftGraphKeyCredential[]>
 -DisplayName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ApplicationIdWithKeyCredentialParameterSet
```
New-AzADAppCredential [-CustomKeyIdentifier <String>] -KeyCredentials <MicrosoftGraphKeyCredential[]>
 -ApplicationId <Guid> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
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
Parameter Sets: ApplicationIdWithCertValueParameterSet, ApplicationIdWithPasswordParameterSet, ApplicationIdWithPasswordCredentialParameterSet, ApplicationIdWithKeyCredentialParameterSet
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
Parameter Sets: ApplicationObjectWithPasswordParameterSet, ApplicationObjectWithCertValueParameterSet, ApplicationObjectWithPasswordCredentialParameterSet, ApplicationObjectWithKeyCredentialParameterSet
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
Parameter Sets: ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectWithCertValueParameterSet, DisplayNameWithCertValueParameterSet, ApplicationIdWithCertValueParameterSet
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
Parameter Sets: DisplayNameWithPasswordParameterSet, DisplayNameWithCertValueParameterSet, DisplayNameWithPasswordCredentialParameterSet, DisplayNameWithKeyCredentialParameterSet
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
Parameter Sets: ApplicationObjectIdWithPasswordParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectWithPasswordParameterSet, ApplicationObjectWithCertValueParameterSet, DisplayNameWithPasswordParameterSet, DisplayNameWithCertValueParameterSet, ApplicationIdWithCertValueParameterSet, ApplicationIdWithPasswordParameterSet
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
Parameter Sets: ApplicationObjectIdWithKeyCredentialParameterSet, ApplicationObjectWithKeyCredentialParameterSet, DisplayNameWithKeyCredentialParameterSet, ApplicationIdWithKeyCredentialParameterSet
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
Parameter Sets: ApplicationObjectIdWithPasswordParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectIdWithKeyCredentialParameterSet, ApplicationObjectIdWithPasswordCredentialParameterSet
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
Parameter Sets: ApplicationObjectIdWithPasswordCredentialParameterSet, ApplicationObjectWithPasswordCredentialParameterSet, DisplayNameWithPasswordCredentialParameterSet, ApplicationIdWithPasswordCredentialParameterSet
Aliases:

Required: True
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

### -StartDate
The effective start date of the credential usage.
The default start date value is today.
For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.

```yaml
Type: System.DateTime
Parameter Sets: ApplicationObjectIdWithPasswordParameterSet, ApplicationObjectIdWithCertValueParameterSet, ApplicationObjectWithPasswordParameterSet, ApplicationObjectWithCertValueParameterSet, DisplayNameWithPasswordParameterSet, DisplayNameWithCertValueParameterSet, ApplicationIdWithCertValueParameterSet, ApplicationIdWithPasswordParameterSet
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
