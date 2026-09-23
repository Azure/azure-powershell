---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/move-azdeviceregistrynamespace
schema: 2.0.0
---

# Move-AzDeviceRegistryNamespace

## SYNOPSIS
Migrate the resources into Namespace

## SYNTAX

### MigrateExpanded (Default)
```
Move-AzDeviceRegistryNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ResourceId <String[]>] [-Scope <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MigrateViaJsonString
```
Move-AzDeviceRegistryNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MigrateViaJsonFilePath
```
Move-AzDeviceRegistryNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Migrate
```
Move-AzDeviceRegistryNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Body <INamespaceMigrateRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MigrateViaIdentityExpanded
```
Move-AzDeviceRegistryNamespace -InputObject <IDeviceRegistryIdentity> [-ResourceId <String[]>]
 [-Scope <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MigrateViaIdentity
```
Move-AzDeviceRegistryNamespace -InputObject <IDeviceRegistryIdentity> -Body <INamespaceMigrateRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Migrate the resources into Namespace

## EXAMPLES

### Example 1: Migrate Asset Resource to Namespace with Expanded Parameters
```powershell
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -ResourceId "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset1","/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset2"
```

Migrates list of Device Registry Asset resources to a Namespace using expanded parameters.
The commandlet takes a list of resource IDs of the Asset resource(s) to migrate under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 2: Migrate Resources to Namespace via JSON String
```powershell
$migrateRequest = @{
    resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
}
$jsonString = $migrateRequest | ConvertTo-Json -Depth 10
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -JsonString $jsonString
```

Migrates Device Registry Asset resources to a Namespace using a JSON string containing the migration request.
The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 3: Migrate Resources to Namespace via JSON File Path
```powershell
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -JsonFilePath "C:\path\to\migrate-request.json"
```

Migrates Device Registry Asset resources to a namespace using a JSON file containing the migration request.
The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 4: Migrate Multiple Resources to Namespace
```powershell
$resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -ResourceId $resourceIds
```

Migrates multiple Device Registry Asset resources to a namespace using an array of resource IDs.
The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 5: Migrate Resources to Namespace via Identity with Expanded Parameters
```powershell
$namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset"
```

Migrates Device Registry Asset resources to a namespace using the namespace's Identity object with expanded parameters.
The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 6: Migrate Resources to Namespace via Identity
```powershell
$namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
$resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId $resourceIds
```

Migrates Device Registry Asset resources to a namespace using the namespace's Identity object with multiple resource IDs.
The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

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

### -Body
Request body for the migrate resources operation in to Namespace resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceMigrateRequest
Parameter Sets: Migrate, MigrateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
Parameter Sets: MigrateViaIdentityExpanded, MigrateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Migrate operation

```yaml
Type: System.String
Parameter Sets: MigrateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Migrate operation

```yaml
Type: System.String
Parameter Sets: MigrateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded, MigrateViaJsonString, MigrateViaJsonFilePath, Migrate
Aliases: NamespaceName

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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded, MigrateViaJsonString, MigrateViaJsonFilePath, Migrate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
List of asset resources to be migrated.

```yaml
Type: System.String[]
Parameter Sets: MigrateExpanded, MigrateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the migrate resources operation.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded, MigrateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: MigrateExpanded, MigrateViaJsonString, MigrateViaJsonFilePath, Migrate
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceMigrateRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceMigrateResponse

## NOTES

## RELATED LINKS
