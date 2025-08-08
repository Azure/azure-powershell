---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistryschema
schema: 2.0.0
---

# Get-AzDeviceRegistrySchema

## SYNOPSIS
Get a Schema

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistrySchema -RegistryName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistrySchema -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistrySchema -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySchemaRegistry
```
Get-AzDeviceRegistrySchema -Name <String> -SchemaRegistryInputObject <IDeviceRegistryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Schema

## EXAMPLES

### Example 1: List Schemas in a Schema Registry
```powershell
Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

```output
Name                                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModified
                                                                                                              At
----                                        -------------------   ------------------- ----------------------- ----------------------
test-schema-create-expanded                 7/25/2025 12:38:28 AM user@outlook.com  User                    7/25/2025 12:38:28 AM
fooschema                                   7/25/2025 12:33:31 AM user@outlook.com  User                    7/25/2025 12:33:31 AM
```

Lists all Schemas in a specified parent Schema Registry.

### Example 2: Get Schema via Schema Registry Identity
```powershell
$schemaRegistryIdentity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Get-AzDeviceRegistrySchema -SchemaRegistryInputObject $schemaRegistryIdentity -SchemaName "my-schema"
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/my-subscription/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a Schema using the parent Schema Registry's Identity object.

### Example 3: Get Schema
```powershell
Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema"
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a specific Schema from its parent Schema Registry.

### Example 4: Get Schema via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
    SchemaName = "my-schema"
}
Get-AzDeviceRegistrySchema -InputObject $identity
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/my-subscription/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a Schema using the schema's Identity object.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, GetViaIdentitySchemaRegistry
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentitySchemaRegistry
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

