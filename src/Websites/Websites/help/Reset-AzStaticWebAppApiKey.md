---
external help file: Az.Websites-help.xml
Module Name: Az.Websites
online version: https://docs.microsoft.com/powershell/module/az.websites/reset-azstaticwebappapikey
schema: 2.0.0
---

# Reset-AzStaticWebAppApiKey

## SYNOPSIS
Description for Resets the api key for an existing static site.

## SYNTAX

### ResetExpanded (Default)
```
Reset-AzStaticWebAppApiKey -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Kind <String>] [-RepositoryToken <String>] [-ShouldUpdateRepository] [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResetViaIdentityExpanded
```
Reset-AzStaticWebAppApiKey -InputObject <IWebsitesIdentity> [-Kind <String>] [-RepositoryToken <String>]
 [-ShouldUpdateRepository] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Description for Resets the api key for an existing static site.

## EXAMPLES

### Example 1: Reset the api key for an existing static site.
```powershell
Reset-AzStaticWebAppApiKey -ResourceGroupName azure-rg-test -Name staticweb-portal01
```

This command resets the api key for an existing static site.

### Example 2: Reset the api key for an existing static site by pipeline
```powershell
Get-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-portal01 | Reset-AzStaticWebAppApiKey
```

This command resets the api key for an existing static site by pipeline.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: ResetViaIdentityExpanded
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
Parameter Sets: ResetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RepositoryToken
The token which proves admin privileges to the repository.

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
Parameter Sets: ResetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShouldUpdateRepository
Determines whether the repository should be updated with the new properties.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Parameter Sets: ResetExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IWebsitesIdentity>`: Identity Parameter
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
