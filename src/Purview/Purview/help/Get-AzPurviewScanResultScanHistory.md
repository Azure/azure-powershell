---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewscanresultscanhistory
schema: 2.0.0
---

# Get-AzPurviewScanResultScanHistory

## SYNOPSIS
Lists the scan history of a scan

## SYNTAX

```
Get-AzPurviewScanResultScanHistory -Endpoint <String> -DataSourceName <String> -ScanName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the scan history of a scan

## EXAMPLES

### Example 1: List all scan runs within a scan instance of a data source
```powershell
Get-AzPurviewScanResultScanHistory -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' | Format-List
```

```output
AssetsClassified            : 62
AssetsDiscovered            : 97
Code                        :
DataSourceType              : AzureStorage
Detail                      :
DiagnosticExceptionCountMap : {
                              }
DiagnosticNotification      : {}
EndTime                     : 2/15/2022 2:42:22 PM
ErrorMessage                :
Id                          : 758a0499-b45e-40e3-9c06-408e2f3ac050
Message                     :
ParentId                    :
PipelineStartTime           : 2/15/2022 2:36:21 PM
QueuedTime                  : 2/15/2022 2:34:06 PM
ResourceId                  : /subscriptions/xxxxxxxx-ffc5-465d-b5dd-xxxxxxxx/resourceGroups/datascan-dev-tests/providers/Microsoft.Storage/storageAccounts/datascan
RunType                     : Manual
ScanLevelType               : Full
ScanRulesetType             : System
ScanRulesetVersion          : 4
StartTime                   : 2/15/2022 2:34:06 PM
Status                      : Succeeded
Target                      :

AssetsClassified            : 62
AssetsDiscovered            : 97
Code                        :
DataSourceType              : AzureStorage
Detail                      :
DiagnosticExceptionCountMap : {
                              }
DiagnosticNotification      : {}
EndTime                     : 2/13/2022 3:23:53 PM
ErrorMessage                :
Id                          : a81d7a0f-149b-4c57-80ae-0f4640ee5a29
Message                     :
ParentId                    :
PipelineStartTime           : 2/13/2022 3:17:02 PM
QueuedTime                  : 2/13/2022 3:16:34 PM
ResourceId                  : /subscriptions/xxxxxxxx-ffc5-465d-b5dd-xxxxxxxx/resourceGroups/datascan-dev-tests/providers/Microsoft.Storage/storageAccounts/datascan
RunType                     : Manual
ScanLevelType               : Full
ScanRulesetType             : System
ScanRulesetVersion          : 4
StartTime                   : 2/13/2022 3:16:34 PM
Status                      : Succeeded
Target                      :
```

List all scan runs within a scan instance of a data source

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IScanResult

## NOTES

## RELATED LINKS
