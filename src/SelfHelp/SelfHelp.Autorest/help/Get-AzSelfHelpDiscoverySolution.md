---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/get-azselfhelpdiscoverysolution
schema: 2.0.0
---

# Get-AzSelfHelpDiscoverySolution

## SYNOPSIS
Lists the relevant Azure diagnostics and solutions using [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) AND  resourceUri or resourceType.\<br/\> Discovery Solutions is the initial entry point within Help API, which identifies relevant Azure diagnostics and solutions.
We will do our best to return the most effective solutions based on the type of inputs, in the request URL  \<br/\>\<br/\> Mandatory input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) \<br/\>Optional input: resourceUri OR resource Type \<br/\>\<br/\> \<b\>Note: \</b\>  ‘requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics and Solutions API.

## SYNTAX

```
Get-AzSelfHelpDiscoverySolution -Scope <String> [-Filter <String>] [-Skiptoken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the relevant Azure diagnostics and solutions using [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) AND  resourceUri or resourceType.\<br/\> Discovery Solutions is the initial entry point within Help API, which identifies relevant Azure diagnostics and solutions.
We will do our best to return the most effective solutions based on the type of inputs, in the request URL  \<br/\>\<br/\> Mandatory input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) \<br/\>Optional input: resourceUri OR resource Type \<br/\>\<br/\> \<b\>Note: \</b\>  ‘requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics and Solutions API.

## EXAMPLES

### Example 1: Get Solution Metadata by resource id
```powershell
 Get-AzSelfHelpDiscoverySolution -Scope "subscriptions/6bded6d5-a6df-44e1-96d3-bf71f6f5f8ba/resourceGroups/test-rgName/providers/Microsoft.KeyVault/vaults/testKeyVault" -Filter "problemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType 

----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- 

a5db90c3-f147-bce6-83b0-ab5e0aeca1f0 
```

Get Solution Metadata by resource id

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
'ProblemClassificationId' or 'Id' is a mandatory filter to get solutions ids.
It also supports optional 'ResourceType' and 'SolutionType' filters.
The filter supports only 'and', 'or' and 'eq' operators.
Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'

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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISolutionMetadataResource

## NOTES

## RELATED LINKS

