---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatreportresourceobject
schema: 2.0.0
---

# New-AzAcatReportResourceObject

## SYNOPSIS
Create an in-memory object for ReportResource.

## SYNTAX

```
New-AzAcatReportResourceObject [-OfferGuid <String>] [-Resource <IResourceMetadata[]>] [-TimeZone <String>]
 [-TriggerTime <DateTime>] [<CommonParameters>]
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
To construct, see NOTES section for RESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


RESOURCE <IResourceMetadata[]>: List of resource data.
  - `ResourceId <String>`: Resource Id - e.g. "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/virtualMachines/vm1".
  - `[AccountId <String>]`: Account Id. For example - the AWS account id.
  - `[ResourceKind <String>]`: Resource kind.
  - `[ResourceOrigin <ResourceOrigin?>]`: Resource Origin.
  - `[ResourceType <String>]`: Resource type. e.g. "Microsoft.Compute/virtualMachines"

## RELATED LINKS

