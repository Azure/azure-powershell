---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azstaticwebappuserprovidedfunctionapp
schema: 2.0.0
---

# Get-AzStaticWebAppUserProvidedFunctionApp

## SYNOPSIS
Description for Gets the details of the user provided function app registered with a static site build

## SYNTAX

### List1 (Default)
```
Get-AzStaticWebAppUserProvidedFunctionApp -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStaticWebAppUserProvidedFunctionApp -EnvironmentName <String> -FunctionAppName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStaticWebAppUserProvidedFunctionApp -InputObject <IWebsitesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzStaticWebAppUserProvidedFunctionApp -EnvironmentName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzStaticWebAppUserProvidedFunctionApp -FunctionAppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Description for Gets the details of the user provided function app registered with a static site build

## EXAMPLES

### Example 1: List the details of the user provided function apps registered with a static site
```powershell
Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00
```

```output
Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered with a static site

### Example 2: List the details of the user provided function apps registered with a static site build
```powershell
Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -EnvironmentName 'default'
```

```output
Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered with a static site build.

### Example 3: List the details of the user provided function apps registered
```powershell
Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -FunctionAppName $env.functionAppName01
```

```output
Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered.

### Example 4: Get the details of the user provided function app registered with a static site build
```powershell
Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -EnvironmentName 'default' -FunctionAppName $env.functionAppName01
```

```output
Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command gets the details of the user provided function app registered with a static site build.

### Example 5: Get the details of the user provided function apps registered with a static site build by pipeline
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/xxxxxx-xx-xxx-xxxx-xxxxx/resourcegroups/xxx-xx-xxxx/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5 | Get-AzStaticWebAppUserProvidedFunctionApp 
```

```output
Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command gets the details of the user provided function app registered with a static site build by pipeline.

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

### -EnvironmentName
The stage site identifier.

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

### -FunctionAppName
Name of the function app registered with the static site build.

```yaml
Type: System.String
Parameter Sets: Get, List2
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
Parameter Sets: Get, List, List1, List2
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
Parameter Sets: Get, List, List1, List2
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
Parameter Sets: Get, List, List1, List2
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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppArmResource

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

