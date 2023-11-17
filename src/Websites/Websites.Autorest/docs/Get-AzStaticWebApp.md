---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azstaticwebapp
schema: 2.0.0
---

# Get-AzStaticWebApp

## SYNOPSIS
Description for Gets the details of a static site.

## SYNTAX

### List (Default)
```
Get-AzStaticWebApp [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStaticWebApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStaticWebApp -InputObject <IWebsitesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzStaticWebApp -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Description for Gets the details of a static site.

## EXAMPLES

### Example 1: List all static web applications under a subscription
```powershell
Get-AzStaticWebApp
```

```output
Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

This commands list all static web applications under a subscription.

### Example 2: List all static web applications under a resource group
```powershell
Get-AzStaticWebApp -ResourceGroupName azure-rg-test
```

```output
Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

This commands list all static web applications under a resource group.

### Example 3: Get a satic web application by name
```powershell
Get-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-portal04
```

```output
Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

This commands gets a satic web application by name.

### Example 4: Get a satic web application by pipline
```powershell
New-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh01 -Location eastus2 -RepositoryUrl 'https://github.com/username/RepoName' -RepositoryToken 'repoToken123' -Branch 'master' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'free' | Get-AzStaticWebApp
```

```output
Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

This commands gets a satic web application by pipline.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the static site.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource

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

