---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistrynamespace
schema: 2.0.0
---

# Get-AzDeviceRegistryNamespace

## SYNOPSIS
Get a Namespace

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistryNamespace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistryNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistryNamespace -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDeviceRegistryNamespace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Namespace

## EXAMPLES

### Example 1: List Namespaces in a resource group
```powershell
Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group"
```

```output
Location Name                                     SystemDataCreatedAt  SystemDataCreatedBy                  SystemDataCreatedByType
-------- ----                                     -------------------  -------------------                  -----------------------
eastus2  adr-namespace                            7/22/2025 5:15:28 AM user@outlook.com Application
eastus2  test-ns-create                           7/22/2025 7:31:54 AM user@outlook.com                   User
```

Lists the Device Registry Namespaces in a resource group.

### Example 2: List Namespaces in a subscription.
```powershell
Get-AzDeviceRegistryNamespace -SubscriptionId my-subscription-id
```

```output
Location Name                                     SystemDataCreatedAt  SystemDataCreatedBy                  SystemDataCreatedByType
-------- ----                                     -------------------  -------------------                  -----------------------
eastus2  adr-namespace                            7/22/2025 5:15:28 AM user@outlook.com Application
eastus2  test-ns-create                           7/22/2025 7:31:54 AM user@outlook.com                   User
```

Lists the Device Registry Namespaces in a subscription.

### Example 3: Get a Namespace
```powershell
Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Gets the details of the Namespace.

### Example 4: Get Namespace Via Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "my-subscription"
  ResourceGroup = "my-resource-group"
  Name = "my-namespace"
}
Get-AzDeviceRegistryNamespace -InputObject $namespaceIdentity
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Gets the details of the Device Registry Namespace resource via Identity object.

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
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NamespaceName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespace

## NOTES

## RELATED LINKS

