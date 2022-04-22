---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/new-azcustomerinsightsprofile
schema: 2.0.0
---

# New-AzCustomerInsightsProfile

## SYNOPSIS
Creates a profile within a Hub, or updates an existing profile.

## SYNTAX

```
New-AzCustomerInsightsProfile -HubName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ApiEntitySetName <String>] [-Attribute <Hashtable>] [-Description <Hashtable>]
 [-DisplayName <Hashtable>] [-EntityType <EntityTypes>] [-Field <IPropertyDefinition[]>]
 [-InstancesCount <Int32>] [-LargeImage <String>] [-LocalizedAttribute <Hashtable>] [-MediumImage <String>]
 [-SchemaItemTypeLink <String>] [-SmallImage <String>] [-StrongId <IStrongId[]>]
 [-TimestampFieldName <String>] [-TypeName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a profile within a Hub, or updates an existing profile.

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

### -ApiEntitySetName
The api entity set name.
This becomes the odata entity set name for the entity Type being referred in this object.

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

### -Attribute
The attributes for the Type.

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
Localized descriptions for the property.

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
Localized display names for the property.

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

### -EntityType
Type of entity.

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

### -Field
The properties of the Profile.
To construct, see NOTES section for FIELD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IPropertyDefinition[]
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

### -InstancesCount
The instance count.

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

### -LargeImage
Large Image associated with the Property or EntityType.

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

### -LocalizedAttribute
Any custom localized attributes for the Type.

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

### -MediumImage
Medium Image associated with the Property or EntityType.

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
The name of the profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ProfileName

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

### -SchemaItemTypeLink
The schema org link.
This helps ACI identify and suggest semantic models.

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

### -SmallImage
Small Image associated with the Property or EntityType.

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

### -StrongId
The strong IDs.
To construct, see NOTES section for STRONGID properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IStrongId[]
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

### -TimestampFieldName
The timestamp property name.
Represents the time when the interaction or profile update happened.

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

### -TypeName
The name of the entity.

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

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IProfileResourceFormat

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FIELD <IPropertyDefinition[]>: The properties of the Profile.
  - `FieldName <String>`: Name of the property.
  - `FieldType <String>`: Type of the property.
  - `[ArrayValueSeparator <String>]`: Array value separator for properties with isArray set.
  - `[EnumValidValue <IProfileEnumValidValuesFormat[]>]`: Describes valid values for an enum property.
    - `[LocalizedValueName <IProfileEnumValidValuesFormatLocalizedValueNames>]`: Localized names of the enum member.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Value <Int32?>]`: The integer value of the enum member.
  - `[IsArray <Boolean?>]`: Indicates if the property is actually an array of the fieldType above on the data api.
  - `[IsAvailableInGraph <Boolean?>]`: Whether property is available in graph or not.
  - `[IsEnum <Boolean?>]`: Indicates if the property is an enum.
  - `[IsFlagEnum <Boolean?>]`: Indicates if the property is an flag enum.
  - `[IsImage <Boolean?>]`: Whether the property is an Image.
  - `[IsLocalizedString <Boolean?>]`: Whether the property is a localized string.
  - `[IsName <Boolean?>]`: Whether the property is a name or a part of name.
  - `[IsRequired <Boolean?>]`: Whether property value is required on instances, IsRequired field only for Interaction. Profile Instance will not check for required field.
  - `[MaxLength <Int32?>]`: Max length of string. Used only if type is string.
  - `[PropertyId <String>]`: The ID associated with the property.
  - `[SchemaItemPropLink <String>]`: URL encoded schema.org item prop link for the property.

STRONGID <IStrongId[]>: The strong IDs.
  - `KeyPropertyName <String[]>`: The properties which make up the unique ID.
  - `Name <String>`: The Name identifying the strong ID.
  - `[Description <IStrongIdDescription>]`: Localized descriptions.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[DisplayName <IStrongIdDisplayName>]`: Localized display name.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

