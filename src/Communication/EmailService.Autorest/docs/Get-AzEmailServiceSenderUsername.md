---
external help file:
Module Name: Az.EmailService
online version: https://learn.microsoft.com/powershell/module/az.emailservice/get-azemailservicesenderusername
schema: 2.0.0
---

# Get-AzEmailServiceSenderUsername

## SYNOPSIS
Get a valid sender username for a domains resource.

## SYNTAX

### List (Default)
```
Get-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceName <String> -ResourceGroupName <String>
 -SenderUsername <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEmailServiceSenderUsername -InputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityDomain
```
Get-AzEmailServiceSenderUsername -DomainInputObject <IEmailServiceIdentity> -SenderUsername <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityEmailService
```
Get-AzEmailServiceSenderUsername -DomainName <String> -EmailServiceInputObject <IEmailServiceIdentity>
 -SenderUsername <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a valid sender username for a domains resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -DomainInputObject
Identity Parameter
To construct, see NOTES section for DOMAININPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
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
Type: System.String
Parameter Sets: Get, GetViaIdentityEmailService, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailServiceInputObject
Identity Parameter
To construct, see NOTES section for EMAILSERVICEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
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
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, GetViaIdentityDomain, GetViaIdentityEmailService
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## RELATED LINKS

