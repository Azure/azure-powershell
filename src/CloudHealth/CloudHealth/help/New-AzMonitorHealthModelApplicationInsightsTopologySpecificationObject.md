---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelapplicationinsightstopologyspecificationobject
schema: 2.0.0
---

# New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject

## SYNOPSIS
Create an in-memory object for ApplicationInsightsTopologySpecification.

## SYNTAX

```
New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ApplicationInsightsTopologySpecification.

## EXAMPLES

### Example 1: Build an Application Insights discovery specification
```powershell
# Build an Application Insights specification for use with a discovery rule
New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.Insights/components/contoso-ai'
```

Creates an Application Insights specification for use with a discovery rule.

## PARAMETERS

### -ApplicationInsightsResourceId
Application Insights resource ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ApplicationInsightsTopologySpecification

## NOTES

## RELATED LINKS

