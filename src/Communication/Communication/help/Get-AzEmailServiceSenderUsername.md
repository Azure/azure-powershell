---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azemailservicesenderusername
schema: 2.0.0
---

# Get-AzEmailServiceSenderUsername

## SYNOPSIS
Get a valid sender username for a domains resource.

## SYNTAX

### List (Default)
```
Get-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentityEmailService
```
Get-AzEmailServiceSenderUsername -DomainName <String> -SenderUsername <String>
 -EmailServiceInputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 -SenderUsername <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityDomain
```
Get-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEmailServiceSenderUsername -InputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a valid sender username for a domains resource.

## EXAMPLES

### EXAMPLE 1
```
Get-AzEmailServiceSenderUsername -SenderUsername donotreply -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

### EXAMPLE 2
```
Get-AzEmailServiceSenderUsername -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
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

### -DomainInputObject
Identity Parameter

```yaml
Type: IEmailServiceIdentity
Parameter Sets: GetViaIdentityDomain
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
Parameter Sets: List, GetViaIdentityEmailService, Get
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
Parameter Sets: GetViaIdentityEmailService
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityEmailService, Get, GetViaIdentityDomain
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
Type: String[]
Parameter Sets: List, Get
Aliases:

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

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.communication/get-azemailservicesenderusername](https://learn.microsoft.com/powershell/module/az.communication/get-azemailservicesenderusername)

