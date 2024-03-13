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

### Example 1: Creates a sender username resource for custom domain.
```powershell
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 :
DisplayName                  :
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/testcustomdomain2.net/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 08:46:18
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 08:46:18
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Create a sender username resource for custom domain with the provided parameters.

### Example 2: Creates a sender username resource for Azure managed domain
```powershell
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 :
DisplayName                  :
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/tcsacstest1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/AzureManagedDomain/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 08:47:25
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 08:47:25
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Create a sender username resource for Azure managed domain with the provided parameters.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
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
Type: System.String
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
Type: System.String
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.ISenderUsernameResource
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
Type: System.Management.Automation.ActionPreference
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
Type: System.String
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
Type: System.String
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
A sender senderUsername to be used when sending emails.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.ISenderUsernameResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.ISenderUsernameResource

## NOTES

## RELATED LINKS
