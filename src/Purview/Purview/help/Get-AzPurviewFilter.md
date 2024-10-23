---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewfilter
schema: 2.0.0
---

# Get-AzPurviewFilter

## SYNOPSIS
Get a filter

## SYNTAX

```
Get-AzPurviewFilter -Endpoint <String> -DataSourceName <String> -ScanName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a filter

## EXAMPLES

### Example 1: Get the scope filters of the scan
```powershell
Get-AzPurviewFilter -Endpoint 'https://brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData' -ScanName 'Scan1ForDemo'
```

```output
ExcludeUriPrefix  : {https://foo.file.core.windows.net/share1/user/temp}
Id                : datasources/DataScanTestData/scans/Scan1ForDemo/filters/custom
IncludeUriPrefix  : {https://foo.file.core.windows.net/share1/user,
                    https://foo.file.core.windows.net/share1/aggregated}
Name              : custom
```

Get the scope filters of the scan named 'Scan1ForDemo' for datasource 'DataScanTestData'

## PARAMETERS

### -DataSourceName
.

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

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

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

### -ScanName
.

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IFilter

## NOTES

## RELATED LINKS
