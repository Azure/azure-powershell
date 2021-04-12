---
external help file:
Module Name: Az.Websites
online version: https://docs.microsoft.com/en-us/powershell/module/az.websites/register-azstaticwebappuserprovidedfunctionapp
schema: 2.0.0
---

# Register-AzStaticWebAppUserProvidedFunctionApp

## SYNOPSIS
Description for Register a user provided function app with a static site build

## SYNTAX

### RegisterExpanded1 (Default)
```
Register-AzStaticWebAppUserProvidedFunctionApp -FunctionAppName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IsForced] [-FunctionAppRegion <String>]
 [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Register
```
Register-AzStaticWebAppUserProvidedFunctionApp -EnvironmentName <String> -FunctionAppName <String>
 -Name <String> -ResourceGroupName <String>
 -StaticSiteUserProvidedFunctionEnvelope <IStaticSiteUserProvidedFunctionAppArmResource>
 [-SubscriptionId <String>] [-IsForced] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Register1
```
Register-AzStaticWebAppUserProvidedFunctionApp -FunctionAppName <String> -Name <String>
 -ResourceGroupName <String>
 -StaticSiteUserProvidedFunctionEnvelope <IStaticSiteUserProvidedFunctionAppArmResource>
 [-SubscriptionId <String>] [-IsForced] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegisterExpanded
```
Register-AzStaticWebAppUserProvidedFunctionApp -EnvironmentName <String> -FunctionAppName <String>
 -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IsForced]
 [-FunctionAppRegion <String>] [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentity
```
Register-AzStaticWebAppUserProvidedFunctionApp -InputObject <IWebsitesIdentity>
 -StaticSiteUserProvidedFunctionEnvelope <IStaticSiteUserProvidedFunctionAppArmResource> [-IsForced]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentity1
```
Register-AzStaticWebAppUserProvidedFunctionApp -InputObject <IWebsitesIdentity>
 -StaticSiteUserProvidedFunctionEnvelope <IStaticSiteUserProvidedFunctionAppArmResource> [-IsForced]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentityExpanded
```
Register-AzStaticWebAppUserProvidedFunctionApp -InputObject <IWebsitesIdentity> [-IsForced]
 [-FunctionAppRegion <String>] [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentityExpanded1
```
Register-AzStaticWebAppUserProvidedFunctionApp -InputObject <IWebsitesIdentity> [-IsForced]
 [-FunctionAppRegion <String>] [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Description for Register a user provided function app with a static site build

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

### -AsJob
Run the command as a job

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
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FunctionAppName
Name of the function app to register with the static site build.

```yaml
Type: System.String
Parameter Sets: Register, Register1, RegisterExpanded, RegisterExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FunctionAppRegion
The region of the function app registered with the static site

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterExpanded1, RegisterViaIdentityExpanded, RegisterViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FunctionAppResourceId
The resource id of the function app registered with the static site

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterExpanded1, RegisterViaIdentityExpanded, RegisterViaIdentityExpanded1
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
Parameter Sets: RegisterViaIdentity, RegisterViaIdentity1, RegisterViaIdentityExpanded, RegisterViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsForced
Specify \<code\>true\</code\> to force the update of the auth configuration on the function app even if an AzureStaticWebApps provider is already configured on the function app.
The default is \<code\>false\</code\>.

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

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterExpanded1, RegisterViaIdentityExpanded, RegisterViaIdentityExpanded1
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
Parameter Sets: Register, Register1, RegisterExpanded, RegisterExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Register, Register1, RegisterExpanded, RegisterExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticSiteUserProvidedFunctionEnvelope
Static Site User Provided Function App ARM resource.
To construct, see NOTES section for STATICSITEUSERPROVIDEDFUNCTIONENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppArmResource
Parameter Sets: Register, Register1, RegisterViaIdentity, RegisterViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Register, Register1, RegisterExpanded, RegisterExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppArmResource

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
  - `[Location <String>]`: Location where you plan to create the static site.
  - `[Name <String>]`: Name of the static site.
  - `[PrivateEndpointConnectionName <String>]`: Name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Userid <String>]`: The user id of the user.

STATICSITEUSERPROVIDEDFUNCTIONENVELOPE <IStaticSiteUserProvidedFunctionAppArmResource>: Static Site User Provided Function App ARM resource.
  - `[Kind <String>]`: Kind of resource.
  - `[FunctionAppRegion <String>]`: The region of the function app registered with the static site
  - `[FunctionAppResourceId <String>]`: The resource id of the function app registered with the static site

## RELATED LINKS

