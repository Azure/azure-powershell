---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/Get-AzOperationalInsightsOperationStatus
schema: 2.0.0
---

# Get-AzOperationalInsightsOperationStatus

## SYNOPSIS
Get the status of a long running azure asynchronous operation.

## SYNTAX

```
Get-AzOperationalInsightsOperationStatus -Location <String> -OperationId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get the status of a long running azure asynchronous operation.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsOperationStatus -Location "location" -OperationId "op_id"
```

gets a long running azure asynchronous operation

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

### -Location
The region name of operation.

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

### -OperationId
The Id (Guid) of the operation.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSOperationStatus

## NOTES

## RELATED LINKS
