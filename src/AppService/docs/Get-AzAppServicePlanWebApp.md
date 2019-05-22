---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappserviceplanwebapp
schema: 2.0.0
---

# Get-AzAppServicePlanWebApp

## SYNOPSIS
Get all apps that use a Hybrid Connection in an App Service Plan.

## SYNTAX

### List1 (Default)
```
Get-AzAppServicePlanWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Filter <String>] [-SkipToken <String>] [-Top <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzAppServicePlanWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 -NamespaceName <String> -RelayName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get all apps that use a Hybrid Connection in an App Service Plan.

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

### -Filter
Supported filter: $filter=state eq running.
Returns only web apps that are currently running

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the App Service plan.

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

### -NamespaceName
Name of the Hybrid Connection namespace.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelayName
Name of the Hybrid Connection relay.

```yaml
Type: System.String
Parameter Sets: List
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip to a web app in the list of webapps associated with app service plan.
If specified, the resulting list will contain web apps starting from (including) the skipToken.
Otherwise, the resulting list contains web apps from the start of the list

```yaml
Type: System.String
Parameter Sets: List1
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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
List page size.
If specified, results are paged.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

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

### System.String
### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISite
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappserviceplanwebapp](https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappserviceplanwebapp)

