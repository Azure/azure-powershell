---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/disable-azwebsiterecommendation
schema: 2.0.0
---

# Disable-AzWebSiteRecommendation

## SYNOPSIS
Disables the specified rule so it will not apply to a subscription in the future.

## SYNTAX

### Disable (Default)
```
Disable-AzWebSiteRecommendation -Name <String> -SubscriptionId <String> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Disable4
```
Disable-AzWebSiteRecommendation -Name <String> -SubscriptionId <String> -ResourceGroupName <String>
 -SiteName <String> [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Disable2
```
Disable-AzWebSiteRecommendation -Name <String> -SubscriptionId <String> -HostingEnvironmentName <String>
 -ResourceGroupName <String> -EnvironmentName <String> [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Disable3
```
Disable-AzWebSiteRecommendation -SubscriptionId <String> -ResourceGroupName <String> -SiteName <String>
 [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Disable1
```
Disable-AzWebSiteRecommendation -SubscriptionId <String> -HostingEnvironmentName <String>
 -ResourceGroupName <String> -EnvironmentName <String> [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DisableViaIdentity4
```
Disable-AzWebSiteRecommendation -InputObject <IWebSiteIdentity> [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableViaIdentity3
```
Disable-AzWebSiteRecommendation -InputObject <IWebSiteIdentity> [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableViaIdentity2
```
Disable-AzWebSiteRecommendation -InputObject <IWebSiteIdentity> -EnvironmentName <String> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableViaIdentity1
```
Disable-AzWebSiteRecommendation -InputObject <IWebSiteIdentity> -EnvironmentName <String> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableViaIdentity
```
Disable-AzWebSiteRecommendation -InputObject <IWebSiteIdentity> [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Disables the specified rule so it will not apply to a subscription in the future.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Site name

```yaml
Type: System.String
Parameter Sets: Disable2, Disable1, DisableViaIdentity2, DisableViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostingEnvironmentName
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: Disable2, Disable1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: DisableViaIdentity4, DisableViaIdentity3, DisableViaIdentity2, DisableViaIdentity1, DisableViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Rule name

```yaml
Type: System.String
Parameter Sets: Disable, Disable4, Disable2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Disable4, Disable2, Disable3, Disable1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteName
Site name

```yaml
Type: System.String
Parameter Sets: Disable4, Disable3
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
Parameter Sets: Disable, Disable4, Disable2, Disable3, Disable1
Aliases:

Required: True
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/disable-azwebsiterecommendation](https://docs.microsoft.com/en-us/powershell/module/az.website/disable-azwebsiterecommendation)

