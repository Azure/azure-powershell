---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservicesmtpusername
schema: 2.0.0
---

# New-AzCommunicationServiceSmtpUsername

## SYNOPSIS
create an SmtpUsernameResource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzCommunicationServiceSmtpUsername -CommunicationServiceName <String> -ResourceGroupName <String>
 -SmtpUsername <String> [-SubscriptionId <String>] [-EntraApplicationId <String>] [-TenantId <String>]
 [-Username <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCommunicationServiceSmtpUsername -CommunicationServiceName <String> -ResourceGroupName <String>
 -SmtpUsername <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCommunicationServiceSmtpUsername -CommunicationServiceName <String> -ResourceGroupName <String>
 -SmtpUsername <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create an SmtpUsernameResource.

## EXAMPLES

### Example 1: Create a SMTP Username resource
```powershell
New-AzCommunicationServiceSmtpUsername -SmtpUsername ContosoSmtpUsernameResource1 -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -EntraApplicationId 1ebe1d1a-1111-1111-1c11-11ad111bf111 -TenantId 11f111b1-11f1-11af-11ab-1d1cd111db11 -Username ContosoUsername1
```

```output
EntraApplicationId           : 1ebe1d1a-1111-1111-1c11-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/communicationServices/ContosoAcsResource1/smtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 25-02-2025 11:24:05
SystemDataCreatedBy          : newuser1@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 25-02-2025 11:24:05
SystemDataLastModifiedBy     : newuser1@contoso.com
SystemDataLastModifiedByType : User
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : microsoft.communication/communicationservices/smtpusernames
Username                     : ContosoUsername1
```

Create a SMTP Username resource with the provided parameters.

## PARAMETERS

### -CommunicationServiceName
The name of the CommunicationService resource.

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

### -EntraApplicationId
The application Id for the linked Entra Application.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SmtpUsername
The name of the SmtpUsernameResource.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant of the linked Entra Application.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
The SMTP username.
Could be free form or in the email address format.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ISmtpUsernameResource

## NOTES

## RELATED LINKS

