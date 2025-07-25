---
external help file: Az.FirmwareAnalysis-help.xml
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/get-azfirmwareanalysiscve
schema: 2.0.0
---

# Get-AzFirmwareAnalysisCve

## SYNOPSIS
Lists CVE analysis results of a firmware.

## SYNTAX

```
Get-AzFirmwareAnalysisCve -FirmwareId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists CVE analysis results of a firmware.

## EXAMPLES

### Example 1:  List all the cve analysis results for a firmware.
```powershell
Get-AzFirmwareAnalysisCve -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
  {
    "ComponentId": ,
    "ComponentName": "",
    "ComponentVersion": "",
    "CveId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "CvssScore": "",
    "CvssV2Score": "",
    "CvssV3Score": "",
    "CvssVersion": "",
    "Description": "",
    "Id": "",
    "Link": [
      "",
      ""
    ],
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PropertiesName": "",
    "Severity": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/cves"
  }
]
```

List all the cve analysis results for a firmware.

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

### -FirmwareId
The id of the firmware.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -WorkspaceName
The name of the firmware analysis workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.ICveResource

## NOTES

## RELATED LINKS
