---
external help file:
Module Name: Az.ChangeAnalysis
online version: https://docs.microsoft.com/en-us/powershell/module/az.changeanalysis/get-azchangeanalysischange
schema: 2.0.0
---

# Get-AzChangeAnalysisChange

## SYNOPSIS
List the changes of a resource group within the specified time range.
Customer data will always be masked.

## SYNTAX

### List1 (Default)
```
Get-AzChangeAnalysisChange -EndTime <DateTime> -StartTime <DateTime> [-SubscriptionId <String[]>]
 [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzChangeAnalysisChange -ResourceGroupName <String> -EndTime <DateTime> -StartTime <DateTime>
 [-SubscriptionId <String[]>] [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List the changes of a resource group within the specified time range.
Customer data will always be masked.

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

### -EndTime
Specifies the end time of the changes request.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
A skip token is used to continue retrieving items after an operation returns a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls.

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

### -StartTime
Specifies the start time of the changes request.

```yaml
Type: System.DateTime
Parameter Sets: (All)
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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange

## NOTES

ALIASES

## RELATED LINKS

