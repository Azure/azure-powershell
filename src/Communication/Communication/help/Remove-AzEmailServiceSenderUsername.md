---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/remove-azemailservicesenderusername
schema: 2.0.0
---

# Remove-AzEmailServiceSenderUsername

## SYNOPSIS
Operation to delete a SenderUsernames resource.

## SYNTAX

### Delete (Default)
```
Remove-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 -SenderUsername <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityEmailService
```
Remove-AzEmailServiceSenderUsername -DomainName <String> -SenderUsername <String>
 -EmailServiceInputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityDomain
```
Remove-AzEmailServiceSenderUsername -SenderUsername <String> -DomainInputObject <IEmailServiceIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzEmailServiceSenderUsername -InputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Operation to delete a SenderUsernames resource.

## EXAMPLES

### EXAMPLE 1
```
Remove-AzEmailServiceSenderUsername -SenderUsername test -DomainName testcustomdomain1.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

### EXAMPLE 2
```
Remove-AzEmailServiceSenderUsername -SenderUsername test -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
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
Parameter Sets: DeleteViaIdentityDomain
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
Parameter Sets: Delete, DeleteViaIdentityEmailService
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
Parameter Sets: DeleteViaIdentityEmailService
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
Parameter Sets: Delete
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
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: Delete
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
Parameter Sets: Delete, DeleteViaIdentityEmailService, DeleteViaIdentityDomain
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
Parameter Sets: Delete
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
## OUTPUTS

### System.Boolean
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

[https://learn.microsoft.com/powershell/module/az.communication/remove-azemailservicesenderusername](https://learn.microsoft.com/powershell/module/az.communication/remove-azemailservicesenderusername)

