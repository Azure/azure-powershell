---
external help file:
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/update-azapplicationinsightsworkbook
schema: 2.0.0
---

# Update-AzApplicationInsightsWorkbook

## SYNOPSIS
Updates a workbook that has already been added.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzApplicationInsightsWorkbook -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LinkedSourceId <String>] [-Category <String>] [-Description <String>] [-DisplayName <String>]
 [-Revision <String>] [-SerializedData <String>] [-SourceTag <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzApplicationInsightsWorkbook -InputObject <IApplicationInsightsIdentity> [-LinkedSourceId <String>]
 [-Category <String>] [-Description <String>] [-DisplayName <String>] [-Revision <String>]
 [-SerializedData <String>] [-SourceTag <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a workbook that has already been added.

## EXAMPLES

### Example 1: Updates a workbook that has already been added
```powershell
Update-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name cc18e5e4-9558-4be1-b333-20b28aaca021 -DisplayName "workbook-portal"
```

```output
ResourceGroupName       Name                                 DisplayName     Location Kind   Category
-----------------       ----                                 -----------     -------- ----   --------
appinsights-hkrs2v-test cc18e5e4-9558-4be1-b333-20b28aaca021 workbook-portal eastus   shared workbook
```

Updates a workbook that has already been added

### Example 2: Updates a workbook that has already been added by pipeline
```powershell
Get-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name cc18e5e4-9558-4be1-b333-20b28aaca021 | Update-AzApplicationInsightsWorkbook -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                                 DisplayName     Location Kind   Category
-----------------       ----                                 -----------     -------- ----   --------
appinsights-hkrs2v-test cc18e5e4-9558-4be1-b333-20b28aaca021 workbook-portal eastus   shared workbook
```

Updates a workbook that has already been added by pipeline.

## PARAMETERS

### -Category
Workbook category, as defined by the user at creation time.

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

### -Description
The description of the workbook.

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

### -DisplayName
The user-defined name (display name) of the workbook.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Revision
The unique revision id for this workbook definition

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

### -SerializedData
Configuration of this particular workbook.
Configuration data is a string containing valid JSON

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

### -SourceTag
A list of 0 or more tags that are associated with this workbook definition

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IApplicationInsightsIdentity>`: Identity Parameter
  - `[AnnotationId <String>]`: The unique annotation ID. This is unique within a Application Insights component.
  - `[ComponentName <String>]`: The name of the Application Insights component resource.
  - `[ExportId <String>]`: The Continuous Export configuration ID. This is unique within a Application Insights component.
  - `[Id <String>]`: Resource identity path
  - `[KeyId <String>]`: The API Key ID. This is unique within a Application Insights component.
  - `[PurgeId <String>]`: In a purge status request, this is the Id of the operation the status of which is returned.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the Application Insights component resource.
  - `[RevisionId <String>]`: The id of the workbook's revision.
  - `[StorageType <StorageType?>]`: The type of the Application Insights component data source for the linked storage account.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WebTestName <String>]`: The name of the Application Insights WebTest resource.

## RELATED LINKS

