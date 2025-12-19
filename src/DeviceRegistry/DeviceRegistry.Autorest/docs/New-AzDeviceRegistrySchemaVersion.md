---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistryschemaversion
schema: 2.0.0
---

# New-AzDeviceRegistrySchemaVersion

## SYNOPSIS
Create a SchemaVersion

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistrySchemaVersion -Name <String> -ResourceGroupName <String> -SchemaName <String>
 -SchemaRegistryName <String> [-SubscriptionId <String>] [-Description <String>] [-SchemaContent <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistrySchemaVersion -Name <String> -ResourceGroupName <String> -SchemaName <String>
 -SchemaRegistryName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistrySchemaVersion -Name <String> -ResourceGroupName <String> -SchemaName <String>
 -SchemaRegistryName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a SchemaVersion

## EXAMPLES

### Example 1: Create a schema version with expanded parameters
```powershell
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -Description "Initial version of the device schema" -SchemaContent '{"type":"object","properties":{"deviceId":{"type":"string"},"temperature":{"type":"number"}}}'
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-06f973e875/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version under the specified schema resource (nested under the specified schema registry resource) with expanded parameters.

### Example 2: Create a schema version using a JSON file
```powershell
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -JsonFilePath "C:\path\to\schema-version-config.json"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-06f973e875/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version under the specified schema resource (nested under the specified schema registry resource) using configuration from a JSON file containing the schema version's properties.

### Example 3: Create a schema version using a JSON string
```powershell
$jsonString = Get-Content -Path "C:\path\to\schema-version-config.json" -Raw
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -JsonString $jsonString
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-06f973e875/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version under the specified schema resource (nested under the specified schema registry resource) using a stringified JSON of an object containing the schema version's properties.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Schema version name parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SchemaVersionName

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

### -SchemaContent
Schema content.

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

### -SchemaName
Schema name parameter.

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

### -SchemaRegistryName
Schema registry name parameter.

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.ISchemaVersion

## NOTES

## RELATED LINKS

