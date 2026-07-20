### Example 1: Update a dataflow endpoint
```powershell
Update-AzIoTOperationsServiceDataflowEndpoint  -InstanceName  "aio-instance-name"   -Name "local-storage-endpoint"  -ResourceGroupName "aio-validation-116116143"  -EndpointType "LocalStorage"  -LocalStorageSettingPersistentVolumeClaimRef "myPersistentVolumeClaim" 
```

```output
AccessTokenSettingSecretRef                                                        :
DataExplorerSettingDatabase                                                        :
DataExplorerSettingHost                                                            :
DataExplorerSettingsAuthenticationMethod                                           :
DataExplorerSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience    :
DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId      :
DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsScope         :
DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId      :
DataExplorerSettingsBatchingLatencySecond                                          :
DataExplorerSettingsBatchingMaxMessage                                             :
DataLakeStorageSettingHost                                                         :
DataLakeStorageSettingsAuthenticationMethod                                        :
DataLakeStorageSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience :
DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId   :
DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsScope      :
DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId   :
DataLakeStorageSettingsBatchingLatencySecond                                       :
DataLakeStorageSettingsBatchingMaxMessage                                          :
EndpointType                                                                       : LocalStorage
ExtendedLocationName                                                               :  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143" 
ExtendedLocationType                                                               : CustomLocation
FabricOneLakeSettingHost                                                           :
FabricOneLakeSettingOneLakePathType                                                :
FabricOneLakeSettingsAuthenticationMethod                                          :
FabricOneLakeSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience   :
FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId     :
FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsScope        :
FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId     :
FabricOneLakeSettingsBatchingLatencySecond                                         :
FabricOneLakeSettingsBatchingMaxMessage                                            :
Id                                                                                 : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.IoTOperations/instances/aio-instance-name/dataflowEndpoints/local-storage-endpoint
KafkaSetting                                                                       : {
                                                                                     }
LocalStorageSettingPersistentVolumeClaimRef                                        : myPersistentVolumeClaim
MqttSetting                                                                        : {
                                                                                     }
Name                                                                               : local-storage-endpoint
NameLakehouseName                                                                  :
NameWorkspaceName                                                                  :
ProvisioningState                                                                  : Succeeded
ResourceGroupName                                                                  : aio-validation-116116143
SystemDataCreatedAt                                                                : 3/5/2025 10:28:13 PM
SystemDataCreatedBy                                                                : henrymorales@microsoft.com
SystemDataCreatedByType                                                            : User
SystemDataLastModifiedAt                                                           : 3/5/2025 10:29:15 PM
SystemDataLastModifiedBy                                                           : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                                                       : Application
Type                                                                               : microsoft.iotoperations/instances/dataflowendpoints
```

Updates a dataflow endpoint

