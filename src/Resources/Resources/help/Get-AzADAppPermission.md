---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadapppermission
schema: 2.0.0
---

# Get-AzADAppPermission

## SYNOPSIS
Lists API permissions the application has requested.

## SYNTAX

### ObjectIdParameterSet (Default)
```
Get-AzADAppPermission -ObjectId <Guid> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### AppIdParameterSet
```
Get-AzADAppPermission -ApplicationId <Guid> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists API permissions the application has requested.

## EXAMPLES

### Example 1: Get API permission
```powershell
Get-AzADAppPermission -ObjectId 18797549-86a9-4906-b2a9-54f08cd3c427
```

```output
ApiId                                Id                                   Type
-----                                --                                   ----
00000003-0000-0000-c000-000000000000 df021288-bdef-4463-88db-98f22de89214 Scope
00000003-0000-0000-c000-000000000000 5b567255-7703-4780-807c-7be8301ae99b Scope
```

Fetches all API permissions of Microsoft Entra object 18797549-86a9-4906-b2a9-54f08cd3c427

## PARAMETERS

### -ApplicationId
The application Id.

```yaml
Type: System.Guid
Parameter Sets: AppIdParameterSet
Aliases:

Required: True
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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The object Id of application.

```yaml
Type: System.Guid
Parameter Sets: ObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.MicrosoftGraphApplicationApiPermission

## NOTES

ALIASES

## RELATED LINKS
