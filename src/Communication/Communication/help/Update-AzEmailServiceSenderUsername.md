---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/update-azemailservicesenderusername
schema: 2.0.0
---

# Update-AzEmailServiceSenderUsername

## SYNOPSIS
Add a new SenderUsername resource under the parent Domains resource or update an existing SenderUsername resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 -SenderUsername <String> [-SubscriptionId <String>] [-DisplayName <String>] [-Username <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEmailServiceExpanded
```
Update-AzEmailServiceSenderUsername -DomainName <String> -SenderUsername <String>
 -EmailServiceInputObject <IEmailServiceIdentity> [-DisplayName <String>] [-Username <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEmailService
```
Update-AzEmailServiceSenderUsername -DomainName <String> -SenderUsername <String>
 -EmailServiceInputObject <IEmailServiceIdentity> -Parameter <ISenderUsernameResource>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityDomainExpanded
```
Update-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 [-DisplayName <String>] [-Username <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityDomain
```
Update-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 -Parameter <ISenderUsernameResource> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEmailServiceSenderUsername -InputObject <IEmailServiceIdentity> [-DisplayName <String>]
 [-Username <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Add a new SenderUsername resource under the parent Domains resource or update an existing SenderUsername resource.

## EXAMPLES

### EXAMPLE 1
```
Update-AzEmailServiceSenderUsername -SenderUsername test -Username test -DisplayName testdisplayname -DomainName testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

### EXAMPLE 2
```
Update-AzEmailServiceSenderUsername -SenderUsername test -Username test -DisplayName testAzureDomaindisplayname -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityDomainExpanded, UpdateViaIdentityDomain
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityEmailService
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
Parameter Sets: UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityEmailService
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: IEmailServiceIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
A class representing a SenderUsername resource.

```yaml
Type: ISenderUsernameResource
Parameter Sets: UpdateViaIdentityEmailService, UpdateViaIdentityDomain
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityEmailService, UpdateViaIdentityDomainExpanded, UpdateViaIdentityDomain
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
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

INPUTOBJECT \<IEmailServiceIdentity\>: Identity Parameter
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

[https://learn.microsoft.com/powershell/module/az.communication/update-azemailservicesenderusername](https://learn.microsoft.com/powershell/module/az.communication/update-azemailservicesenderusername)

