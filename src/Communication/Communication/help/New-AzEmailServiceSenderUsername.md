---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/new-azemailservicesenderusername
schema: 2.0.0
---

# New-AzEmailServiceSenderUsername

## SYNOPSIS
Add a new SenderUsername resource under the parent Domains resource or update an existing SenderUsername resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DisplayName <String>] [-Username <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEmailServiceExpanded
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainName <String>
 -EmailServiceInputObject <IEmailServiceIdentity> [-DisplayName <String>] [-Username <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEmailService
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainName <String>
 -EmailServiceInputObject <IEmailServiceIdentity> -Parameter <ISenderUsernameResource>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityDomainExpanded
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 [-DisplayName <String>] [-Username <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityDomain
```
New-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 -Parameter <ISenderUsernameResource> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Add a new SenderUsername resource under the parent Domains resource or update an existing SenderUsername resource.

## EXAMPLES

### EXAMPLE 1
```
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

### EXAMPLE 2
```
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name for the senderUsername.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityEmailServiceExpanded, CreateViaIdentityDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainInputObject
Identity Parameter

```yaml
Type: IEmailServiceIdentity
Parameter Sets: CreateViaIdentityDomainExpanded, CreateViaIdentityDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DomainName
The name of the Domains resource.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityEmailServiceExpanded, CreateViaIdentityEmailService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailServiceInputObject
Identity Parameter

```yaml
Type: IEmailServiceIdentity
Parameter Sets: CreateViaIdentityEmailServiceExpanded, CreateViaIdentityEmailService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EmailServiceName
The name of the EmailService resource.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
A class representing a SenderUsername resource.

```yaml
Type: ISenderUsernameResource
Parameter Sets: CreateViaIdentityEmailService, CreateViaIdentityDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SenderUsername
The valid sender Username.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
A sender senderUsername to be used when sending emails.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityEmailServiceExpanded, CreateViaIdentityDomainExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.ISenderUsernameResource
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.ISenderUsernameResource
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

DOMAININPUTOBJECT \<IEmailServiceIdentity\>: Identity Parameter
  \[DomainName \<String\>\]: The name of the Domains resource.
  \[EmailServiceName \<String\>\]: The name of the EmailService resource.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SenderUsername \<String\>\]: The valid sender Username.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
The value must be an UUID.

EMAILSERVICEINPUTOBJECT \<IEmailServiceIdentity\>: Identity Parameter
  \[DomainName \<String\>\]: The name of the Domains resource.
  \[EmailServiceName \<String\>\]: The name of the EmailService resource.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SenderUsername \<String\>\]: The valid sender Username.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
The value must be an UUID.

PARAMETER \<ISenderUsernameResource\>: A class representing a SenderUsername resource.
  \[DisplayName \<String\>\]: The display name for the senderUsername.
  \[Username \<String\>\]: A sender senderUsername to be used when sending emails.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.communication/new-azemailservicesenderusername](https://learn.microsoft.com/powershell/module/az.communication/new-azemailservicesenderusername)

