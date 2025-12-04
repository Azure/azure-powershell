---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistryschemaregistry
schema: 2.0.0
---

# Get-AzDeviceRegistrySchemaRegistry

## SYNOPSIS
Get a SchemaRegistry

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistrySchemaRegistry [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistrySchemaRegistry -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistrySchemaRegistry -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a SchemaRegistry

## EXAMPLES

### Example 1: List Schema Registries in a Resource Group
```powershell
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group"
```

```output
Description                  :
DisplayName                  :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/aio-sr-06f973e875
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : aio-sr-06f973e875
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Lists all Schema Registries in a specified Resource Group.

### Example 2: Get Schema Registry
```powershell
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

```output
Description                  :
DisplayName                  :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : my-schema-registry
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Gets a specific Schema Registry from a Resource Group.

### Example 3: Get Schema Registry via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Get-AzDeviceRegistrySchemaRegistry -InputObject $identity
```

```output
Description                  :
DisplayName                  :
Id                           : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : my-schema-registry
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Gets a Schema Registry using the its Identity object.

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
Schema registry name parameter.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.ISchemaRegistry

## NOTES

## RELATED LINKS
