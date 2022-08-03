---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
ms.assetid: 3992E6B5-F794-4C7A-BB59-C8D60E2CD7BC
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/set-azoperationalinsightsdatasource
schema: 2.0.0
---

# Set-AzOperationalInsightsDataSource

## SYNOPSIS
Updates a data source.

## SYNTAX

```
Set-AzOperationalInsightsDataSource [-DataSource] <PSDataSource> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzOperationalInsightsDataSource** cmdlet updates a data source.

## EXAMPLES

### Example 1
```powershell
$datasource = Get-AzOperationalInsightsDataSource -Kind CustomLog -ResourceGroupName testrg -WorkspaceName LogAnalyticsWorkspace
Set-AzOperationalInsightsDataSource -DataSource $datasource
```

```output
Name              : DataSource_CustomLog_Customlog_CL
ResourceGroupName : testrg
WorkspaceName     : LogAnalyticsWorkspace
ResourceId        : /subscriptions/xxxx-xxxx-xxxx-xxxx-xxxx/resourceGroups/testrg/providers/Microsoft.Ope
                    rationalInsights/workspaces/LogAnalyticsWorkspace/datasources/DataSource_CustomLog_Customlog_
                    CL
Kind              : CustomLog
Properties        : {"customLogName":"Customlog_CL","description":"","extractions":[{"extractionName":"TimeGenerated","
                    extractionProperties":{"dateTimeExtraction":{"joinStringRegex":null,"regex":null,"formatString":nul
                    l}},"extractionType":"DateTime"}],"inputs":[{"location":{"fileSystemLocations":{"linuxFileTypeLogPa
                    ths":null,"windowsFileTypeLogPaths":["D:\\logs.txt"]}},"recordDelimiter":{"regexDelimiter":{"matchI
                    ndex":0,"numberdGroup":null,"pattern":"\\n"}}}]}
```

Update a data source.

## PARAMETERS

### -DataSource
Specifies the data source that this cmdlet updates.

```yaml
Type: Microsoft.Azure.Commands.OperationalInsights.Models.PSDataSource
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### Microsoft.Azure.Commands.OperationalInsights.Models.PSDataSource

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSDataSource

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, operational, insights

## RELATED LINKS

[Get-AzOperationalInsightsDataSource](./Get-AzOperationalInsightsDataSource.md)

[Remove-AzOperationalInsightsDataSource](./Remove-AzOperationalInsightsDataSource.md)


