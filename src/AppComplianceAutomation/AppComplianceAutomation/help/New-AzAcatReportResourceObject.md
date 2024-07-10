---
external help file: Az.AppComplianceAutomation-help.xml
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatreportresourceobject
schema: 2.0.0
---

# New-AzAcatReportResourceObject

## SYNOPSIS
Create an in-memory object for ReportResource.

## SYNTAX

```
New-AzAcatReportResourceObject [-Resource <IResourceMetadata[]>] [-TimeZone <String>] [-TriggerTime <DateTime>]
 [-OfferGuid <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ReportResource.

## EXAMPLES

### Example 1: Create a ReportResource object with default values.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object with default values.

### Example 2: Create a ReportResource object.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object.

## PARAMETERS

### -OfferGuid
Report offer Guid.

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

### -Resource
List of resource data.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.IResourceMetadata[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.An example of valid timezone id is "Pacific Standard Time".

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

### -TriggerTime
Report collection trigger time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.IReportResource

## NOTES

## RELATED LINKS
