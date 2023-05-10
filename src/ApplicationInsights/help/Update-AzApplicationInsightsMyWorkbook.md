---
external help file:
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/update-azapplicationinsightsmyworkbook
schema: 2.0.0
---

# Update-AzApplicationInsightsMyWorkbook

## SYNOPSIS
Updates a private workbook that has already been added.

## SYNTAX

```
Update-AzApplicationInsightsMyWorkbook -Name <String> -ResourceGroupName <String>
 -WorkbookProperty <IMyWorkbook> [-SubscriptionId <String>] [-LinkedSourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a private workbook that has already been added.

## EXAMPLES

### Example 1: Updates a private workbook that has already been added
```powershell
$myWorkbook = Get-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1"
$myWorkbook.DisplayName = "pwsh01"
Update-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1" -WorkbookProperty $myWorkbook
```

```output
ResourceGroupName       Name                                 DisplayName Location Kind Category
-----------------       ----                                 ----------- -------- ---- --------
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 pwsh01      westus2  user workbook
```

Updates a private workbook that has already been added.

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

### -LinkedSourceId
Azure Resource Id that will fetch all linked workbooks.

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

### -Name
The name of the Application Insights component resource.

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

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkbookProperty
An Application Insights private workbook definition.
To construct, see NOTES section for WORKBOOKPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`WORKBOOKPROPERTY <IMyWorkbook>`: An Application Insights private workbook definition.
  - `[Etag <IMyWorkbookResourceEtag>]`: Resource etag
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Azure resource Id
  - `[IdentityType <String>]`: The identity type.
  - `[Location <String>]`: Resource location
  - `[Name <String>]`: Azure resource name
  - `[Tag <IMyWorkbookResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Azure resource type
  - `[Category <String>]`: Workbook category, as defined by the user at creation time.
  - `[DisplayName <String>]`: The user-defined name of the private workbook.
  - `[Kind <Kind?>]`: The kind of workbook. Choices are user and shared.
  - `[PropertiesTag <String[]>]`: A list of 0 or more tags that are associated with this private workbook definition
  - `[SerializedData <String>]`: Configuration of this particular private workbook. Configuration data is a string containing valid JSON
  - `[SourceId <String>]`: Optional resourceId for a source resource.
  - `[StorageUri <String>]`: BYOS Storage Account URI
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Version <String>]`: This instance's version of the data model. This can change as new features are added that can be marked private workbook.

## RELATED LINKS

