---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/new-azcustomerinsightslink
schema: 2.0.0
---

# New-AzCustomerInsightsLink

## SYNOPSIS
Creates a link or updates an existing link in the hub.

## SYNTAX

```
New-AzCustomerInsightsLink -HubName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <Hashtable>] [-DisplayName <Hashtable>]
 [-Mapping <ITypePropertiesMapping[]>] [-OperationType <InstanceOperationType>]
 [-ParticipantPropertyReference <IParticipantPropertyReference[]>] [-ReferenceOnly]
 [-SourceEntityType <EntityType>] [-SourceEntityTypeName <String>] [-TargetEntityType <EntityType>]
 [-TargetEntityTypeName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a link or updates an existing link in the hub.

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

### -Description
Localized descriptions for the Link.

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

### -DisplayName
Localized display name for the Link.

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

### -Mapping
The set of properties mappings between the source and target Types.
To construct, see NOTES section for MAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.ITypePropertiesMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LinkName

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

### -OperationType
Determines whether this link is supposed to create or delete instances if Link is NOT Reference Only.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.InstanceOperationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParticipantPropertyReference
The properties that represent the participating profile.
To construct, see NOTES section for PARTICIPANTPROPERTYREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IParticipantPropertyReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReferenceOnly
Indicating whether the link is reference only link.
This flag is ignored if the Mappings are defined.
If the mappings are not defined and it is set to true, links processing will not create or update profiles.

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

### -SourceEntityType
Type of source entity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.EntityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceEntityTypeName
Name of the source Entity Type.

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

### -TargetEntityType
Type of target entity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Support.EntityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetEntityTypeName
Name of the target Entity Type.

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

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.ILinkResourceFormat

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


MAPPING <ITypePropertiesMapping[]>: The set of properties mappings between the source and target Types.
  - `SourcePropertyName <String>`:  Property name on the source Entity Type.
  - `TargetPropertyName <String>`: Property name on the target Entity Type.
  - `[LinkType <LinkTypes?>]`: Link type.

PARTICIPANTPROPERTYREFERENCE <IParticipantPropertyReference[]>: The properties that represent the participating profile.
  - `SourcePropertyName <String>`: The source property that maps to the target property.
  - `TargetPropertyName <String>`: The target property that maps to the source property.

## RELATED LINKS

