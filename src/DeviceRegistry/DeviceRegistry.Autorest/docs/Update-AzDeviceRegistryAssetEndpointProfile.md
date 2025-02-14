---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistryassetendpointprofile
schema: 2.0.0
---

# Update-AzDeviceRegistryAssetEndpointProfile

## SYNOPSIS
update a AssetEndpointProfile

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AdditionalConfiguration <String>] [-AuthenticationMethod <String>]
 [-EndpointProfileType <String>] [-Tag <Hashtable>] [-TargetAddress <String>]
 [-UsernamePasswordCredentialsPasswordSecretName <String>]
 [-UsernamePasswordCredentialsUsernameSecretName <String>] [-X509CredentialsCertificateSecretName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryAssetEndpointProfile -InputObject <IDeviceRegistryIdentity>
 [-AdditionalConfiguration <String>] [-AuthenticationMethod <String>] [-EndpointProfileType <String>]
 [-Tag <Hashtable>] [-TargetAddress <String>] [-UsernamePasswordCredentialsPasswordSecretName <String>]
 [-UsernamePasswordCredentialsUsernameSecretName <String>] [-X509CredentialsCertificateSecretName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryAssetEndpointProfile -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
update a AssetEndpointProfile

## EXAMPLES

### Example 1: Update an asset endpoint profile by name and resource group.
```powershell
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -TargetAddress "opc.tcp://bar"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with value `opc.tcp://bar`.
Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 2: UpdateViaIdentity for asset endpoint profile.
```powershell
$assetEndpointProfile = @{ "ResourceGroupName" = "test-rg"; "AssetEndpointProfileName" = "test-assetendpointprofile"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Update-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile -TargetAddress "opc.tcp://bar"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with value `opc.tcp://bar` via Identity input object.
Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 3: Update an asset endpoint profile from a JSON file path
```powershell
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetEndpointProfilePatch.json"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's property(ies) with new value(s) by specifying a JSON file path containing the patch body.
Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 4: Update an asset endpoint profile from a stringified JSON
```powershell
$jsonStr = '{
    "properties": {
        "targetAddress": "opc.tcp://bar"
    }
}'
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with new value `opc.tcp://bar` by specifying the patch as a stringified JSON body.
Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

## PARAMETERS

### -AdditionalConfiguration
Stringified JSON that contains connectivity type specific further configuration (e.g.
OPC UA, Modbus, ONVIF).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -EndpointProfileType
Defines the configuration for the connector type that is being used with the endpoint profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IAssetEndpointProfile

## NOTES

## RELATED LINKS

