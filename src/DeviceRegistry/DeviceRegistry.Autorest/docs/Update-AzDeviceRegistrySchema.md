---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistryschema
schema: 2.0.0
---

# Update-AzDeviceRegistrySchema

## SYNOPSIS
Replace a Schema

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistrySchema -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <String>] [-DisplayName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistrySchema -InputObject <IDeviceRegistryIdentity> [-Description <String>]
 [-DisplayName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentitySchemaRegistryExpanded
```
Update-AzDeviceRegistrySchema -Name <String> -SchemaRegistryInputObject <IDeviceRegistryIdentity>
 [-Description <String>] [-DisplayName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Replace a Schema

## EXAMPLES

### Example 1: Update a Device Registry Schema with expanded parameters
```powershell
Update-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Schema using schema registry identity object
```powershell
$registryIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Update-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema using the parent schema registry's identity object.

### Example 3: Update a Device Registry Schema using schema identity object
```powershell
Update-AzDeviceRegistrySchema -InputObject $schemaObject -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema using the schema's identity object.

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

### -Description
Human-readable description of the schema.

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
Human-readable display name.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Schema name parameter.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentitySchemaRegistryExpanded
Aliases: SchemaName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
Schema registry name parameter.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SchemaRegistryName

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

### -SchemaRegistryInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentitySchemaRegistryExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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
Schema tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.ISchema

## NOTES

## RELATED LINKS

