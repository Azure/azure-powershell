---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelthreatintelligenceindicator
schema: 2.0.0
---

# New-AzSentinelThreatIntelligenceIndicator

## SYNOPSIS
Create a new threat intelligence indicator.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelThreatIntelligenceIndicator -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Confidence <Int32>] [-Created <String>] [-CreatedByRef <String>] [-Defanged]
 [-Description <String>] [-DisplayName <String>] [-Extension <Hashtable>] [-ExternalId <String>]
 [-ExternalLastUpdatedTimeUtc <String>] [-ExternalReference <IThreatIntelligenceExternalReference[]>]
 [-GranularMarking <IThreatIntelligenceGranularMarkingModel[]>] [-IndicatorType <String[]>]
 [-KillChainPhase <IThreatIntelligenceKillChainPhase[]>] [-Label <String[]>] [-Language <String>]
 [-LastUpdatedTimeUtc <String>] [-Modified <String>] [-ObjectMarkingRef <String[]>]
 [-ParsedPattern <IThreatIntelligenceParsedPattern[]>] [-Pattern <String>] [-PatternType <String>]
 [-PatternVersion <String>] [-Revoked] [-Source <String>] [-ThreatIntelligenceTag <String[]>]
 [-ThreatType <String[]>] [-ValidFrom <String>] [-ValidUntil <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzSentinelThreatIntelligenceIndicator -ResourceGroupName <String> -WorkspaceName <String>
 -ThreatIntelligenceProperty <IThreatIntelligenceIndicatorModelForRequestBody> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzSentinelThreatIntelligenceIndicator -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -ThreatIntelligenceProperty <IThreatIntelligenceIndicatorModelForRequestBody> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new threat intelligence indicator.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Confidence
Confidence of threat intelligence entity

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Created
Created by

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

### -CreatedByRef
Created by reference of threat intelligence entity

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

### -Defanged
Is threat intelligence entity defanged

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
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
Description of a threat intelligence entity

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

### -DisplayName
Display name of a threat intelligence entity

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

### -Extension
Extensions map

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalId
External ID of threat intelligence entity

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

### -ExternalLastUpdatedTimeUtc
External last updated time in UTC

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

### -ExternalReference
External References
To construct, see NOTES section for EXTERNALREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceExternalReference[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GranularMarking
Granular Markings
To construct, see NOTES section for GRANULARMARKING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceGranularMarkingModel[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IndicatorType
Indicator types of threat intelligence entities

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KillChainPhase
Kill chain phases
To construct, see NOTES section for KILLCHAINPHASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceKillChainPhase[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
Labels of threat intelligence entity

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Language
Language of threat intelligence entity

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

### -LastUpdatedTimeUtc
Last updated time in UTC

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

### -Modified
Modified by

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

### -Name
Threat intelligence indicator name field.

```yaml
Type: System.String
Parameter Sets: Create1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectMarkingRef
Threat intelligence entity object marking references

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParsedPattern
Parsed patterns
To construct, see NOTES section for PARSEDPATTERN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceParsedPattern[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pattern
Pattern of a threat intelligence entity

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

### -PatternType
Pattern type of a threat intelligence entity

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

### -PatternVersion
Pattern version of a threat intelligence entity

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

### -Revoked
Is threat intelligence entity revoked

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Source of a threat intelligence entity

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

### -ThreatIntelligenceProperty
Threat intelligence indicator entity used in request body.
To construct, see NOTES section for THREATINTELLIGENCEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceIndicatorModelForRequestBody
Parameter Sets: Create, Create1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ThreatIntelligenceTag
List of tags

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatType
Threat types

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidFrom
Valid from

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

### -ValidUntil
Valid until

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

### -WorkspaceName
The name of the workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceIndicatorModelForRequestBody

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceInformation

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


EXTERNALREFERENCE <IThreatIntelligenceExternalReference[]>: External References
  - `[Description <String>]`: External reference description
  - `[ExternalId <String>]`: External reference ID
  - `[Hash <IThreatIntelligenceExternalReferenceHashes>]`: External reference hashes
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[SourceName <String>]`: External reference source name
  - `[Url <String>]`: External reference URL

GRANULARMARKING <IThreatIntelligenceGranularMarkingModel[]>: Granular Markings
  - `[Language <String>]`: Language granular marking model
  - `[MarkingRef <Int32?>]`: marking reference granular marking model
  - `[Selector <String[]>]`: granular marking model selectors

KILLCHAINPHASE <IThreatIntelligenceKillChainPhase[]>: Kill chain phases
  - `[KillChainName <String>]`: Kill chainName name
  - `[PhaseName <String>]`: Phase name

PARSEDPATTERN <IThreatIntelligenceParsedPattern[]>: Parsed patterns
  - `[PatternTypeKey <String>]`: Pattern type key
  - `[PatternTypeValue <IThreatIntelligenceParsedPatternTypeValue[]>]`: Pattern type keys
    - `[Value <String>]`: Value of parsed pattern
    - `[ValueType <String>]`: Type of the value

THREATINTELLIGENCEPROPERTY <IThreatIntelligenceIndicatorModelForRequestBody>: Threat intelligence indicator entity used in request body.
  - `[Confidence <Int32?>]`: Confidence of threat intelligence entity
  - `[Created <String>]`: Created by
  - `[CreatedByRef <String>]`: Created by reference of threat intelligence entity
  - `[Defanged <Boolean?>]`: Is threat intelligence entity defanged
  - `[Description <String>]`: Description of a threat intelligence entity
  - `[DisplayName <String>]`: Display name of a threat intelligence entity
  - `[Etag <String>]`: Etag of the azure resource
  - `[Extension <IThreatIntelligenceIndicatorPropertiesExtensions>]`: Extensions map
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ExternalId <String>]`: External ID of threat intelligence entity
  - `[ExternalLastUpdatedTimeUtc <String>]`: External last updated time in UTC
  - `[ExternalReference <IThreatIntelligenceExternalReference[]>]`: External References
    - `[Description <String>]`: External reference description
    - `[ExternalId <String>]`: External reference ID
    - `[Hash <IThreatIntelligenceExternalReferenceHashes>]`: External reference hashes
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[SourceName <String>]`: External reference source name
    - `[Url <String>]`: External reference URL
  - `[GranularMarking <IThreatIntelligenceGranularMarkingModel[]>]`: Granular Markings
    - `[Language <String>]`: Language granular marking model
    - `[MarkingRef <Int32?>]`: marking reference granular marking model
    - `[Selector <String[]>]`: granular marking model selectors
  - `[IndicatorType <String[]>]`: Indicator types of threat intelligence entities
  - `[KillChainPhase <IThreatIntelligenceKillChainPhase[]>]`: Kill chain phases
    - `[KillChainName <String>]`: Kill chainName name
    - `[PhaseName <String>]`: Phase name
  - `[Label <String[]>]`: Labels  of threat intelligence entity
  - `[Language <String>]`: Language of threat intelligence entity
  - `[LastUpdatedTimeUtc <String>]`: Last updated time in UTC
  - `[Modified <String>]`: Modified by
  - `[ObjectMarkingRef <String[]>]`: Threat intelligence entity object marking references
  - `[ParsedPattern <IThreatIntelligenceParsedPattern[]>]`: Parsed patterns
    - `[PatternTypeKey <String>]`: Pattern type key
    - `[PatternTypeValue <IThreatIntelligenceParsedPatternTypeValue[]>]`: Pattern type keys
      - `[Value <String>]`: Value of parsed pattern
      - `[ValueType <String>]`: Type of the value
  - `[Pattern <String>]`: Pattern of a threat intelligence entity
  - `[PatternType <String>]`: Pattern type of a threat intelligence entity
  - `[PatternVersion <String>]`: Pattern version of a threat intelligence entity
  - `[Revoked <Boolean?>]`: Is threat intelligence entity revoked
  - `[Source <String>]`: Source of a threat intelligence entity
  - `[ThreatIntelligenceTag <String[]>]`: List of tags
  - `[ThreatType <String[]>]`: Threat types
  - `[ValidFrom <String>]`: Valid from
  - `[ValidUntil <String>]`: Valid until

## RELATED LINKS

