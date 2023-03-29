---
external help file:
Module Name: Az.HelpRp
online version: https://learn.microsoft.com/powershell/module/az.helprp/get-azhelprpdiscoverysolution
schema: 2.0.0
---

# Get-AzHelpRpDiscoverySolution

## SYNOPSIS
Solutions Discovery is the initial point of entry within Help API, which helps you identify the relevant solutions for your Azure issue.\<br/\>\<br/\> You can discover solutions using resourceUri OR resourceUri + problemClassificationId.\<br/\>\<br/\>We will do our best in returning relevant diagnostics for your Azure issue.\<br/\>\<br/\> Get the problemClassificationId(s) using this [reference](https://learn.microsoft.com/en-us/rest/api/support/problem-classifications/list?tabs=HTTP).\<br/\>\<br/\> \<b\>Note: \</b\> ‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API.

## SYNTAX

```
Get-AzHelpRpDiscoverySolution -Scope <String> [-Filter <String>] [-Skiptoken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Solutions Discovery is the initial point of entry within Help API, which helps you identify the relevant solutions for your Azure issue.\<br/\>\<br/\> You can discover solutions using resourceUri OR resourceUri + problemClassificationId.\<br/\>\<br/\>We will do our best in returning relevant diagnostics for your Azure issue.\<br/\>\<br/\> Get the problemClassificationId(s) using this [reference](https://learn.microsoft.com/en-us/rest/api/support/problem-classifications/list?tabs=HTTP).\<br/\>\<br/\> \<b\>Note: \</b\> ‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -Filter
Can be used to filter solutionIds by 'ProblemClassificationId'.
The filter supports only 'and' and 'eq' operators.
Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e' and ProblemClassificationId eq '0a9673c2-7af6-4e19-90d3-4ee2461076d9'.

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

### -Scope
This is an extension resource provider and only resource level extension is supported at the moment.

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

### -Skiptoken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.Api202301Preview.ISolutionMetadata

## NOTES

ALIASES

## RELATED LINKS

