---
external help file:
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/az.nginx/invoke-aznginxanalysisconfiguration
schema: 2.0.0
---

# Invoke-AzNginxAnalysisConfiguration

## SYNOPSIS
Analyze an NGINX configuration without applying it to the NGINXaaS deployment

## SYNTAX

### AnalysisExpanded (Default)
```
Invoke-AzNginxAnalysisConfiguration -ConfigurationName <String> -DeploymentName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ConfigFile <INginxConfigurationFile[]>]
 [-ConfigProtectedFile <INginxConfigurationFile[]>] [-ConfigRootFile <String>] [-PackageData <String>]
 [-PackageProtectedFile <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Analysis
```
Invoke-AzNginxAnalysisConfiguration -ConfigurationName <String> -DeploymentName <String>
 -ResourceGroupName <String> -Body <IAnalysisCreate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AnalysisViaIdentity
```
Invoke-AzNginxAnalysisConfiguration -InputObject <INginxIdentity> -Body <IAnalysisCreate>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AnalysisViaIdentityExpanded
```
Invoke-AzNginxAnalysisConfiguration -InputObject <INginxIdentity> [-ConfigFile <INginxConfigurationFile[]>]
 [-ConfigProtectedFile <INginxConfigurationFile[]>] [-ConfigRootFile <String>] [-PackageData <String>]
 [-PackageProtectedFile <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Analyze an NGINX configuration without applying it to the NGINXaaS deployment

## EXAMPLES

### Example 1: Analyzing nginx configuration before creating the nginx configuration
```powershell
$confFile = New-AzNginxConfigurationFileObject -VirtualPath "nginx.conf" -Content 'xxxx'
        
# configuration analysis
$confAnalysis = Invoke-AzNginxAnalysisConfiguration -ConfigurationName default -DeploymentName xxxx -ResourceGroupName xxxx -ConfigFile $confFile -ConfigRootFile "nginx.conf"
```

```output
Status
------
SUCCEEDED
```

This command analyzes the configuration before you submit to create your configuration for your nginx deployment

## PARAMETERS

### -Body
The request body for creating an analysis for an NGINX configuration.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.IAnalysisCreate
Parameter Sets: Analysis, AnalysisViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConfigFile
.
To construct, see NOTES section for CONFIGFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfigurationFile[]
Parameter Sets: AnalysisExpanded, AnalysisViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigProtectedFile
.
To construct, see NOTES section for CONFIGPROTECTEDFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfigurationFile[]
Parameter Sets: AnalysisExpanded, AnalysisViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigRootFile
The root file of the NGINX config file(s).
It must match one of the files' filepath.

```yaml
Type: System.String
Parameter Sets: AnalysisExpanded, AnalysisViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationName
The name of configuration, only 'default' is supported value due to the singleton of NGINX conf

```yaml
Type: System.String
Parameter Sets: Analysis, AnalysisExpanded
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

### -DeploymentName
The name of targeted NGINX deployment

```yaml
Type: System.String
Parameter Sets: Analysis, AnalysisExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity
Parameter Sets: AnalysisViaIdentity, AnalysisViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PackageData
.

```yaml
Type: System.String
Parameter Sets: AnalysisExpanded, AnalysisViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageProtectedFile
.

```yaml
Type: System.String[]
Parameter Sets: AnalysisExpanded, AnalysisViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Analysis, AnalysisExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Analysis, AnalysisExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.IAnalysisCreate

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.IAnalysisResult

## NOTES

## RELATED LINKS

