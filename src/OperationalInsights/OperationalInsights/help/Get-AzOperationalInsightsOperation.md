---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightsoperation
schema: 2.0.0
---

# Get-AzOperationalInsightsOperation

## SYNOPSIS
Lists all of the available OperationalInsights Rest API operations.

## SYNTAX

```
Get-AzOperationalInsightsOperation [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the available OperationalInsights Rest API operations.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsOperation
```

```output
Name        : microsoft.operationalinsights/workspaces/features/{resource_name0}/read
Provider    : MicrosoftOperationalInsights
Resource    : {resource_name0}
Operation   : 
Description : 

Name        : microsoft.operationalinsights/workspaces/features/{resource_name0}/read
Provider    : MicrosoftOperationalInsights
Resource    : {resource_name1}
Operation   : 
Description :
```

This command gets all available OperationalInsights Rest API operations by tenant.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSOperation

## NOTES

## RELATED LINKS
