---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/register-azstaticwebappuserprovidedfunctionapp
schema: 2.0.0
---

# Register-AzStaticWebAppUserProvidedFunctionApp

## SYNOPSIS
Description for Register a user provided function app with a static site build

## SYNTAX

### RegisterExpanded1 (Default)
```
Register-AzStaticWebAppUserProvidedFunctionApp -FunctionAppName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Forced] [-FunctionAppRegion <String>]
 [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RegisterExpanded
```
Register-AzStaticWebAppUserProvidedFunctionApp -EnvironmentName <String> -FunctionAppName <String>
 -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Forced] [-FunctionAppRegion <String>]
 [-FunctionAppResourceId <String>] [-Kind <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Description for Register a user provided function app with a static site build

## EXAMPLES

### Example 1: Register a user provided function app with a static site
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -FunctionAppName funcapp-portal01-test -FunctionAppResourceId '/subscriptions/xxxxxxxxxxxxx/resourcegroups/azure-rg-test/providers/Microsoft.Web/sites/funcapp-portal01-test' -FunctionAppRegion 'Central US'
```

```output
Kind Name                  Type
---- ----                  ----
     funcapp-portal01-test Microsoft.Web/staticSites/userProvidedFunctionApps
```

This command registers a user provided function app with a static site.
The -FunctionAppRegion is region of the function app.

### Example 2: Register a user provided function app with a static site build
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/xxxxxxxxx/resourcegroups/azure-rg-test/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5
```

```output
Kind Name                 Type
---- ----                 ----
     functionapp-portal02 Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command registers a user provided function app with a static site build.
The -FunctionAppRegion is region of the function app.

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
Parameter Sets: RegisterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Forced
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

### -FunctionAppName
Name of the function app to register with the static site build.

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

### -FunctionAppRegion
The region of the function app registered with the static site

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

### -FunctionAppResourceId
The resource id of the function app registered with the static site

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppArmResource

## NOTES

ALIASES

## RELATED LINKS

