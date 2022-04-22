---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/new-azcustomerinsightsconnectormapping
schema: 2.0.0
---

# New-AzCustomerInsightsConnectorMapping

## SYNOPSIS
Creates a connector mapping or updates an existing connector mapping in the connector.

## SYNTAX

```
New-AzCustomerInsightsConnectorMapping -ConnectorName <String> -HubName <String> -MappingName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AvailabilityFrequency <FrequencyTypes>]
 [-AvailabilityInterval <Int32>] [-CompleteOperationCompletionOperationType <CompletionOperationTypes>]
 [-CompleteOperationDestinationFolder <String>] [-ConnectorType <ConnectorTypes>] [-Description <String>]
 [-DisplayName <String>] [-EntityType <EntityTypes>] [-EntityTypeName <String>]
 [-ErrorManagementErrorLimit <Int32>] [-ErrorManagementType <ErrorManagementTypes>]
 [-FormatAcceptLanguage <String>] [-FormatArraySeparator <String>] [-FormatColumnDelimiter <String>]
 [-FormatQuoteCharacter <String>] [-FormatQuoteEscapeCharacter <String>] [-MappingPropertyFileFilter <String>]
 [-MappingPropertyFolderPath <String>] [-MappingPropertyHasHeader]
 [-MappingPropertyStructure <IConnectorMappingStructure[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a connector mapping or updates an existing connector mapping in the connector.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AvailabilityFrequency
The frequency to update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.FrequencyTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityInterval
The interval of the given frequency to use.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompleteOperationCompletionOperationType
The type of completion operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.CompletionOperationTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompleteOperationDestinationFolder
The destination folder where files will be moved to once the import is done.

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

### -ConnectorName
The name of the connector.

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

### -ConnectorType
Type of connector.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.ConnectorTypes
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
The description of the connector mapping.

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
Display name for the connector mapping.

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

### -EntityType
Defines which entity type the file should map to.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.EntityTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityTypeName
The mapping entity name.

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

### -ErrorManagementErrorLimit
The error limit allowed while importing data.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorManagementType
The type of error management to use for the mapping.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.ErrorManagementTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FormatAcceptLanguage
The oData language.

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

### -FormatArraySeparator
Character separating array elements.

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

### -FormatColumnDelimiter
The character that signifies a break between columns.

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

### -FormatQuoteCharacter
Quote character, used to indicate enquoted fields.

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

### -FormatQuoteEscapeCharacter
Escape character for quotes, can be the same as the quoteCharacter.

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

### -HubName
The name of the hub.

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

### -MappingName
The name of the connector mapping.

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

### -MappingPropertyFileFilter
The file filter for the mapping.

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

### -MappingPropertyFolderPath
The folder path for the mapping.

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

### -MappingPropertyHasHeader
If the file contains a header or not.

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

### -MappingPropertyStructure
Ingestion mapping information at property level.
To construct, see NOTES section for MAPPINGPROPERTYSTRUCTURE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IConnectorMappingStructure[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IConnectorMappingResourceFormat

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


MAPPINGPROPERTYSTRUCTURE <IConnectorMappingStructure[]>: Ingestion mapping information at property level.
  - `ColumnName <String>`: The column name of the import file.
  - `PropertyName <String>`: The property name of the mapping entity.
  - `[CustomFormatSpecifier <String>]`: Custom format specifier for input parsing.
  - `[IsEncrypted <Boolean?>]`: Indicates if the column is encrypted.

## RELATED LINKS

