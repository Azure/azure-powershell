---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/invoke-azconfluentinviteaccessuser
schema: 2.0.0
---

# Invoke-AzConfluentInviteAccessUser

## SYNOPSIS
Invite user to the organization

## SYNTAX

### InviteExpanded (Default)
```
Invoke-AzConfluentInviteAccessUser -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Email <String>] [-InvitedUserDetailAuthType <String>]
 [-InvitedUserDetailInvitedEmail <String>] [-OrganizationId <String>] [-Upn <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Invite
```
Invoke-AzConfluentInviteAccessUser -OrganizationName <String> -ResourceGroupName <String>
 -Body <IAccessInviteUserAccountModel> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InviteViaIdentity
```
Invoke-AzConfluentInviteAccessUser -InputObject <IConfluentIdentity> -Body <IAccessInviteUserAccountModel>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InviteViaIdentityExpanded
```
Invoke-AzConfluentInviteAccessUser -InputObject <IConfluentIdentity> [-Email <String>]
 [-InvitedUserDetailAuthType <String>] [-InvitedUserDetailInvitedEmail <String>] [-OrganizationId <String>]
 [-Upn <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InviteViaJsonFilePath
```
Invoke-AzConfluentInviteAccessUser -OrganizationName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InviteViaJsonString
```
Invoke-AzConfluentInviteAccessUser -OrganizationName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Invite user to the organization

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

### -Body
Invite User Account model

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IAccessInviteUserAccountModel
Parameter Sets: Invite, InviteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Email
Email of the logged in user

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: InviteViaIdentity, InviteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InvitedUserDetailAuthType
Auth type of the user

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InvitedUserDetailInvitedEmail
UPN/Email of the user who is being invited

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Invite operation

```yaml
Type: System.String
Parameter Sets: InviteViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Invite operation

```yaml
Type: System.String
Parameter Sets: InviteViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationId
Id of the organization

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: Invite, InviteExpanded, InviteViaJsonFilePath, InviteViaJsonString
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
Parameter Sets: Invite, InviteExpanded, InviteViaJsonFilePath, InviteViaJsonString
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
Parameter Sets: Invite, InviteExpanded, InviteViaJsonFilePath, InviteViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Upn
Upn of the logged in user

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IAccessInviteUserAccountModel

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IInvitationRecord

## NOTES

## RELATED LINKS

