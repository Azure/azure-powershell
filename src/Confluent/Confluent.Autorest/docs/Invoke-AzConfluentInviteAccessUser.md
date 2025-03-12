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

## DESCRIPTION
Invite user to the organization

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Invite User Account model
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IAccessInviteUserAccountModel
Parameter Sets: Invite, InviteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
Parameter Sets: Invite, InviteExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name

```yaml
Type: System.String
Parameter Sets: Invite, InviteExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Microsoft Azure subscription id

```yaml
Type: System.String
Parameter Sets: Invite, InviteExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IAccessInviteUserAccountModel

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IInvitationRecord

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IAccessInviteUserAccountModel>: Invite User Account model
  - `[Email <String>]`: Email of the logged in user
  - `[InvitedUserDetailAuthType <String>]`: Auth type of the user
  - `[InvitedUserDetailInvitedEmail <String>]`: UPN/Email of the user who is being invited
  - `[OrganizationId <String>]`: Id of the organization
  - `[Upn <String>]`: Upn of the logged in user

INPUTOBJECT <IConfluentIdentity>: Identity Parameter
  - `[ApiKeyId <String>]`: Confluent API Key id
  - `[ClusterId <String>]`: Confluent kafka or schema registry cluster id
  - `[ConnectorName <String>]`: Confluent connector name
  - `[EnvironmentId <String>]`: Confluent environment id
  - `[Id <String>]`: Resource identity path
  - `[OrganizationName <String>]`: Organization resource name
  - `[ResourceGroupName <String>]`: Resource group name
  - `[RoleBindingId <String>]`: Confluent Role binding id
  - `[SubscriptionId <String>]`: Microsoft Azure subscription id
  - `[TopicName <String>]`: Confluent kafka or schema registry topic name

## RELATED LINKS

