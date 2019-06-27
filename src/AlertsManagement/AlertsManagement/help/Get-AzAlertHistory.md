---
external help file: Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.dll-Help.xml
Module Name: Az.AlertsManagement
online version: https://docs.microsoft.com/en-us/powershell/module/az.alertsmanagement/get-azalerthistory
schema: 2.0.0
---

# Get-AzAlertHistory

## SYNOPSIS
Gets Alert History information

## SYNTAX

```
Get-AzAlertHistory -AlertId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**Get-AzAlertHistory** cmdlet gets history of alert.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzAlertHistory -AlertId "afbf1b3a-0a6c-4f19-9c9b-644ccd7b1529"
```

Gets alert history details. 

## PARAMETERS

### -AlertId
Unique Identifier of Alert / ResourceId of alert.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSAlertModification

## NOTES

## RELATED LINKS
