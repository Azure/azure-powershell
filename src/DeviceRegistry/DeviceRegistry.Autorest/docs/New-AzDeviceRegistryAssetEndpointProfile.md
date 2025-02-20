---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistryassetendpointprofile
schema: 2.0.0
---

# New-AzDeviceRegistryAssetEndpointProfile

## SYNOPSIS
create a AssetEndpointProfile

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String>
 -ExtendedLocationName <String> -ExtendedLocationType <String> -Location <String> [-SubscriptionId <String>]
 [-AdditionalConfiguration <String>] [-AuthenticationMethod <String>]
 [-DiscoveredAssetEndpointProfileRef <String>] [-EndpointProfileType <String>] [-Tag <Hashtable>]
 [-TargetAddress <String>] [-UsernamePasswordCredentialsPasswordSecretName <String>]
 [-UsernamePasswordCredentialsUsernameSecretName <String>] [-X509CredentialsCertificateSecretName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
create a AssetEndpointProfile

## EXAMPLES

### Example 1: Create or update an asset endpoint profile with the specified parameters
```powershell
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -ExtendedLocationName "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-custom-location" -ExtendedLocationType CustomLocation -Location eastus2 -TargetAddress "opc.tcp://foo" -AuthenticationMethod Certificate -X509CredentialsCertificateSecretName myCertificateRef -EndpointProfileType OpcUa -DiscoveredAssetEndpointProfileRef myDiscoveredAssetEndpointProfileRef
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg`

### Example 2: Create or update an asset endpoint profile from a JSON file path
```powershell
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetEndpointProfile.json"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg` from the provided json file at path `C:\Users\abc\Desktop\assetEndpointProfile.json`

### Example 3: Create or update an asset endpoint profile from a stringified JSON
```powershell
$jsonStr = '{
    "location": "eastus2",
    "extendedLocation": {
        "type": "CustomLocation",
        "name": "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-custom-location"
    },
    "tags": {
        "type": "opcua"
    },
    "properties": {
        "targetAddress": "opc.tcp://foo",
        "endpointProfileType": "OpcUa",
        "authentication": {
            "method": "Certificate",
            "x509Credentials": {
                "certificateSecretName": "myCertificateRef"
            }
        },
        "discoveredAssetEndpointProfileRef": "myDiscoveredAssetEndpointProfile",
        "additionalConfiguration": "{\"defaultPublishingInterval\": 200, \"defaultSamplingInterval\": 500, \"defaultQueueSize\": 10}"
    }
}'
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
AdditionalConfiguration                       : "{\"defaultPublishingInterval\": 200, \"defaultSamplingInterval\": 500, \"defaultQueueSize\": 10}"
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg` from the provided stringified JSON.

## PARAMETERS

### -AdditionalConfiguration
Stringified JSON that contains connectivity type specific further configuration (e.g.
OPC UA, Modbus, ONVIF).

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

### -AuthenticationMethod
Defines the method to authenticate the user of the client at the server.

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

### -DiscoveredAssetEndpointProfileRef
Reference to a discovered asset endpoint profile.
Populated only if the asset endpoint profile has been created from discovery flow.
Discovered asset endpoint profile name must be provided.

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

### -EndpointProfileType
Defines the configuration for the connector type that is being used with the endpoint profile.

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

### -ExtendedLocationName
The extended location name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Asset Endpoint Profile name parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AssetEndpointProfileName

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

### -Tag
Resource tags.

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

### -TargetAddress
The local valid URI specifying the network address/DNS name of a southbound device.
The scheme part of the targetAddress URI specifies the type of the device.
The additionalConfiguration field holds further connector type specific configuration.

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

### -UsernamePasswordCredentialsPasswordSecretName
The name of the secret containing the password.

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

### -UsernamePasswordCredentialsUsernameSecretName
The name of the secret containing the username.

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

### -X509CredentialsCertificateSecretName
The name of the secret containing the certificate and private key (e.g.
stored as .der/.pem or .der/.pfx).

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IAssetEndpointProfile

## NOTES

## RELATED LINKS

