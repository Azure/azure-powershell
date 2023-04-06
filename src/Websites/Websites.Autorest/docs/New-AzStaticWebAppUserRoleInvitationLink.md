---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/new-azstaticwebappuserroleinvitationlink
schema: 2.0.0
---

# New-AzStaticWebAppUserRoleInvitationLink

## SYNOPSIS
Description for Creates an invitation link for a user with the role

## SYNTAX

### CreateExpanded (Default)
```
New-AzStaticWebAppUserRoleInvitationLink -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Domain <String>] [-Kind <String>] [-NumHoursToExpiration <Int32>] [-Provider <String>] [-Role <String>]
 [-UserDetail <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStaticWebAppUserRoleInvitationLink -InputObject <IWebsitesIdentity> [-Domain <String>] [-Kind <String>]
 [-NumHoursToExpiration <Int32>] [-Provider <String>] [-Role <String>] [-UserDetail <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Description for Creates an invitation link for a user with the role

## EXAMPLES

### Example 1: Create an invitation link for a user with the role
```powershell
New-AzStaticWebAppUserRoleInvitationLink -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -Domain 'xxxxxxxxx.azurestaticapps.net' -Provider 'github' -UserDetail 'UserName' -Role 'reader' -NumHoursToExpiration 1
```

```output
Kind Name                                 Type
---- ----                                 ----
     078284a9-ce47-4aa5-b54c-2e55a67dd53c Microsoft.Web/staticSites/invitations
```

This command creates an invitation link for a user with the role.

### Example 2: Create an invitation link for a user with the role by pipeline
```powershell
$web = Get-AzStaticWebApp -ResourceGroupName resourceGroup -Name staticweb00
New-AzStaticWebAppUserRoleInvitationLink -InputObject $web -Domain 'Hostname' -Provider 'github' -UserDetail 'UserName' -Role 'admin,contributor' -NumHoursToExpiration 1

```

This command creates an invitation link for a user with the role by pipeline.

## PARAMETERS

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

### -Domain
The domain name for the static site custom domain.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of resource.

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

### -Name
Name of the static site.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumHoursToExpiration
The number of hours the sas token stays valid

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Provider
The identity provider for the static site user.

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

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
The roles for the static site user, in free-form string format

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

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetail
The user id for the static site user.

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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserInvitationResponseResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IWebsitesIdentity>: Identity Parameter
  - `[Authprovider <String>]`: The auth provider for the users.
  - `[DomainName <String>]`: The custom domain name.
  - `[EnvironmentName <String>]`: The stage site identifier.
  - `[FunctionAppName <String>]`: Name of the function app registered with the static site build.
  - `[Id <String>]`: Resource identity path
  - `[JobHistoryId <String>]`: History ID.
  - `[Location <String>]`: Location where you plan to create the static site.
  - `[Name <String>]`: Name of the static site.
  - `[PrivateEndpointConnectionName <String>]`: Name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[Slot <String>]`: Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Userid <String>]`: The user id of the user.
  - `[WebJobName <String>]`: Name of Web Job.

## RELATED LINKS

