---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatreport
schema: 2.0.0
---

# New-AzAcatReport

## SYNOPSIS
Create a new AppComplianceAutomation report or update an exiting AppComplianceAutomation report.

## SYNTAX

### CreateExpanded (Default)
```
New-AzAcatReport -Name <String> -Resource <IResourceMetadata[]> [-OfferGuid <String>] [-TimeZone <String>]
 [-TriggerTime <DateTime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzAcatReport -Name <String> -Parameter <IReportResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new AppComplianceAutomation report or update an exiting AppComplianceAutomation report.

## EXAMPLES

### Example 1: Create a report with default values.
```powershell
New-AzAcatReport -Name "test-report" -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report with default values.

### Example 2: Create a report.
```powershell
New-AzAcatReport -Name "test-report" -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report.

### Example 3: Create a report use parameter object.
```powershell
$param = New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
$param | New-AzAcatReport -Name "test-report"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report use parameter object.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Name
Report Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ReportName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferGuid
Report offer Guid.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
A class represent an AppComplianceAutomation report resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Resource
List of resource data.
To construct, see NOTES section for RESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.An example of valid timezone id is "Pacific Standard Time".

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PARAMETER <IReportResource>: A class represent an AppComplianceAutomation report resource.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[M365FailedCount <Int32?>]`: The count of all failed control.
  - `[M365ManualCount <Int32?>]`: The count of all manual control.
  - `[M365NotApplicableCount <Int32?>]`: The count of all not applicable control.
  - `[M365PassedCount <Int32?>]`: The count of all passed control.
  - `[M365PendingCount <Int32?>]`: The count of all pending for approval control.
  - `[OfferGuid <String>]`: A list of comma-separated offerGuids indicates a series of offerGuids that map to the report. For example, "00000000-0000-0000-0000-000000000001,00000000-0000-0000-0000-000000000002" and "00000000-0000-0000-0000-000000000003".
  - `[Resource <IResourceMetadata[]>]`: List of resource data.
    - `ResourceId <String>`: Resource Id - e.g. "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/virtualMachines/vm1".
    - `[AccountId <String>]`: Account Id. For example - the AWS account id.
    - `[ResourceKind <String>]`: Resource kind.
    - `[ResourceOrigin <ResourceOrigin?>]`: Resource Origin.
    - `[ResourceType <String>]`: Resource type. e.g. "Microsoft.Compute/virtualMachines"
  - `[StorageInfoAccountName <String>]`: 'bring your own storage' account name
  - `[StorageInfoLocation <String>]`: The region of 'bring your own storage' account
  - `[StorageInfoResourceGroup <String>]`: The resourceGroup which 'bring your own storage' account belongs to
  - `[StorageInfoSubscriptionId <String>]`: The subscription id which 'bring your own storage' account belongs to
  - `[TimeZone <String>]`: Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.         An example of valid timezone id is "Pacific Standard Time".
  - `[TriggerTime <DateTime?>]`: Report collection trigger time.

RESOURCE <IResourceMetadata[]>: List of resource data.
  - `ResourceId <String>`: Resource Id - e.g. "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/virtualMachines/vm1".
  - `[AccountId <String>]`: Account Id. For example - the AWS account id.
  - `[ResourceKind <String>]`: Resource kind.
  - `[ResourceOrigin <ResourceOrigin?>]`: Resource Origin.
  - `[ResourceType <String>]`: Resource type. e.g. "Microsoft.Compute/virtualMachines"

## RELATED LINKS

