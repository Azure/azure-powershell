function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.Add("resourceGroup", "adr-pwsh-test-rg")
    $env.Add("location", "eastus2")
    $env.Add("extendedLocationName", "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq")
    $env.Add("extendedLocationType", "CustomLocation")

    $jsonStringConfig = '{"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}'
    $env.Add("assetTests", @{
        assetEndpointProfileRef = "myAssetEndpointProfile"
        createTests = @{
            commonAssetProperties = @{
                externalAssetId = "test-asset-externalAssetId"
                displayName = "test-asset-displayName"
                manufacturer = "Contoso123"
                manufacturerUri = "https://contoso.com"
                model = "ContosoModel"
                productCode = "SA34VDG"
                softwareRevision = "2.0"
                hardwareRevision = "1.0"
                serialNumber = "64-103816-519918-8"
                documentationUri = "https://www.example.com/manual"
                defaultTopicPath = "/path/defaultTopic"
                defaultTopicRetain = "Keep"
                defaultDatasetsConfiguration = $jsonStringConfig
                defaultEventsConfiguration = $jsonStringConfig
            }
            CreateExpanded = @{
                name = "test-asset-create-expanded"
            }
            CreateViaJsonFilePath = @{
                name = "test-asset-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateAsset.json"
                datasetName = "dataset1Foo"
                datasetConfiguration = $jsonStringConfig
                datasetTopicPath = "/path/dataset1"
                datasetTopicRetain = "Keep"
                dataPoint1 = @{
                    name = "dataPoint1"
                    dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1"
                    dataPointConfiguration = $jsonStringConfig
                }
                dataPoint2 = @{
                    name = "dataPoint2"
                    dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt2"
                    dataPointConfiguration = $jsonStringConfig
                }
                event1 = @{
                    name = "event1"
                    eventNotifier = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt3"
                    eventConfiguration = $jsonStringConfig
                }
                event2 = @{
                    name = "event2"
                    eventNotifier = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt4"
                    eventConfiguration = $jsonStringConfig
                }
            }
            CreateViaJsonString = @{
                name = "test-asset-create-json-string"
                jsonStringFilePath = "./jsonFiles/CreateAsset.json"
            }
        }
        getTests = @{
            List = @{
                name1 = "test-asset-list1"
                name2 = "test-asset-list2"
            }
            Get = @{
                name = "test-asset-get"
            }
            GetViaIdentity = @{
                name = "test-asset-get-via-identity"
            }
        }
        deleteTests = @{
            Delete = @{
                name = "test-asset-delete"
            }
            DeleteViaIdentity = @{
                name = "test-asset-delete-via-identity"
            }
        }
        updateTests = @{
            commonPatchConfig = @{
                documentationUri = "https://www.example.com/foo"
                displayName = "foo-asset-displayName"
            }
            UpdateExpanded = @{
                name = "test-asset-update"
            }
            UpdateViaJsonString = @{
                name = "test-asset-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateAsset.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-asset-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateAsset.json"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-asset-update-via-identity-expanded"
            }
        }
    })
    $env.Add("assetEndpointProfileTests", @{
        commonProperties = @{
            targetAddress = "opc.tcp://foo"
            authenticationMethod = "Certificate"
            x509CredentialsCertificateSecretName = "myCertSecretRef"
            endpointProfileType = "OpcUa"
            discoveredAssetEndpointProfileRef = "myDiscoveredAssetEndpointProfile"
            additionalConfiguration = '{"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}'
        }
        createTests = @{
            CreateExpanded = @{
                name = "test-aep-create-expanded"
                anonymousAuthentication = "Anonymous"
                usernameAuthentication = "UsernamePassword"
                usernameSecretName = "myUsernameSecretRef"
                passwordSecretName = "myPasswordSecretRef"
            }
            CreateViaJsonFilePath = @{
                name = "test-aep-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
            CreateViaJsonString = @{
                name = "test-aep-create-json-string"
                jsonStringFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
        }
        getTests = @{
            List = @{
                names = @(
                    "test-aep-list1"
                    "test-aep-list2"
                )
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
            Get = @{
                name = "test-aep-get"
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
            GetViaIdentity = @{
                name = "test-aep-get-via-identity"
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
        }
        deleteTests = @{
            Delete = @{
                name = "test-aep-delete"
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
            DeleteViaIdentity = @{
                name = "test-aep-delete-via-identity"
                jsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
            }
        }
        updateTests = @{
            commonPatchConfig = @{
                createJsonFilePath = "./jsonFiles/CreateAssetEndpointProfile.json"
                updateJsonFilePath = "./jsonFiles/UpdateAssetEndpointProfile.json"
                targetAddress = "opc.tcp://bar"
                additionalConfiguration = '{"foo": "bar"}'
            }
            UpdateExpanded = @{
                name = "test-aep-update"
            }
            UpdateViaJsonString = @{
                name = "test-aep-update-via-json-string"
            }
            UpdateViaJsonFilePath = @{
                name = "test-aep-update-via-json-file-path"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-aep-update-via-identity-expanded"
            }
        }
    })
    $env.Add("billingContainerName", "adr-billing")
    $env.Add("namespaceTests", @{
        createTests = @{
            key1 = "myendpoint1"
            key2 = "myendpoint2"
            endpoints = @{
                "myendpoint1" = @{
                    "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                    "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                    "endpointType" = "Microsoft.Devices/IotHubs"
                }
                "myendpoint2" = @{
                    "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace2"
                    "address" = "https://myendpoint2.westeurope-1.iothub.azure.net"
                    "endpointType" = "Microsoft.Devices/IotHubs"
                }
            }
            CreateExpanded = @{
                name = "test-namespace-create-expanded1"
            }
            CreateViaJsonFilePath = @{
                name = "test-namespace-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
            CreateViaJsonString = @{
                name = "test-namespace-create-json-string"
                jsonStringFilePath = "./jsonFiles/CreateNamespace.json"
            }
        }
        getTests = @{
            List = @{
                names = @(
                    "test-namespace-list1"
                    "test-namespace-list2"
                )
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
            Get = @{
                name = "test-namespace-get"
                key1 = "myendpoint1"
                key2 = "myendpoint2"
                endpoints = @{
                    "myendpoint1" = @{
                        "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                        "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                        "endpointType" = "Microsoft.Devices/IotHubs"
                    }
                    "myendpoint2" = @{
                        "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace2"
                        "address" = "https://myendpoint2.westeurope-1.iothub.azure.net"
                        "endpointType" = "Microsoft.Devices/IotHubs"
                    }
                }
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
            GetViaIdentity = @{
                name = "test-namespace-get-via-identity"
                key1 = "myendpoint1"
                key2 = "myendpoint2"
                endpoints = @{
                    "myendpoint1" = @{
                        "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                        "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                        "endpointType" = "Microsoft.Devices/IotHubs"
                    }
                    "myendpoint2" = @{
                        "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace2"
                        "address" = "https://myendpoint2.westeurope-1.iothub.azure.net"
                        "endpointType" = "Microsoft.Devices/IotHubs"
                    }
                }
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
        }
        deleteTests = @{
            Delete = @{
                name = "test-namespace-delete"
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
            DeleteViaIdentity = @{
                name = "test-namespace-delete-via-identity"
                jsonFilePath = "./jsonFiles/CreateNamespace.json"
            }
        }
        updateTests = @{
            key1 = "myendpoint1"
            endpoints = @{
                "myendpoint1" = @{
                    "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                    "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                    "endpointType" = "Microsoft.Devices/IotHubs"
                }
            }
            createJsonFilePath = "./jsonFiles/CreateNamespace.json"
            UpdateExpanded = @{
                name = "test-namespace-update"
            }
            UpdateViaJsonString = @{
                name = "test-namespace-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateNamespace.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-namespace-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateNamespace.json"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-namespace-update-via-identity-expanded"
            }
        }
        migrateTests = @{
            commonProperties = @{
                namespace = "adr-namespace"
                resourceIdPrefix = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.DeviceRegistry/assets/"
                targetAddress = "https://myendpoint1.westeurope-1.iothub.azure.net"
                endpointProfileType = "Microsoft.IotHub"
            }
            
            MigrateExpanded = @{
                assetEndpointProfileName = "myassetendpointprofile1"
                assetName = "test-asset1"
            }
            Migrate = @{
                assetEndpointProfileName = "myassetendpointprofile2"
                assetName = "test-asset2"
            }
            MigrateViaIdentity = @{
                assetEndpointProfileName = "myassetendpointprofile3"
                assetName = "test-asset3"
            }
            MigrateViaIdentityExpanded = @{
                assetEndpointProfileName = "myassetendpointprofile4"
                assetName = "test-asset4"
            }
            MigrateViaJsonFilePath = @{
                assetEndpointProfileName = "myassetendpointprofile5"
                assetName = "test-asset5"
                jsonFilePath = "./jsonFiles/MoveNamespace.json"
            }
            MigrateViaJsonString = @{
                assetEndpointProfileName = "myassetendpointprofile6"
                assetName = "test-asset6"
            }
        }
    })

    $env.Add("namespaceAssetTests", @{
        namespaceName = "adr-namespace"
        resourceGroupName = "adr-canary-test-ga-2510"
        extendedLocationName = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-canary-test-ga-2510/providers/Microsoft.ExtendedLocation/customLocations/adr-canary-test-ga-2510-cl"
        createTests = @{
            CreateExpanded = @{
                name = "test-ns-asset-create-expanded"
                properties = @{
                    deviceRef = @{
                        deviceName = "myDeviceName"
                        endpointName = "myEndpointName"
                    }
                    externalAssetId = "test-ns-asset-externalAssetId"
                    displayName = "test-ns-asset-displayName"
                    manufacturer = "Contoso123"
                    manufacturerUri = "https://contoso.com"
                    model = "ContosoModel"
                    productCode = "SA34VDG"
                    softwareRevision = "2.0"
                    hardwareRevision = "1.0"
                    serialNumber = "64-103816-519918-8"
                    documentationUri = "https://www.example.com/manual"
                }
            }
            CreateViaJsonFilePath = @{
                name = "test-ns-asset-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateNamespaceAsset.json"
            }
            CreateViaJsonString = @{
                name = "test-ns-asset-create-json-string"
                jsonFilePath = "./jsonFiles/CreateNamespaceAsset.json"
            }
        }
        getTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceAsset.json"
            List = @{
                name1 = "test-ns-asset-list1"
                name2 = "test-ns-asset-list2"
            }
            GetViaIdentityNamespace = @{
                name = "test-ns-asset-get-via-identity-ns"
            }
            Get = @{
                name = "test-ns-asset-get"
            }
            GetViaIdentity = @{
                name = "test-ns-asset-get-via-identity"
            }
        }
        deleteTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceAsset.json"
            Delete = @{
                name = "test-ns-asset-delete"
            }
            DeleteViaIdentityNamespace = @{
                name = "test-ns-asset-delete-via-identity-ns"
            }
            DeleteViaIdentity = @{
                name = "test-ns-asset-delete-via-identity"
            }
        }
        updateTests = @{
            createJsonFilePath = "./jsonFiles/CreateNamespaceAsset.json"
            commonPatchConfig = @{
                documentationUri = "https://www.example.com/foo"
                displayName = "foo-asset-displayName"
            }
            commonProperties = @{
                deviceRef = @{
                    deviceName = "myDeviceName"
                    endpointName = "myEndpointName"
                }
                externalAssetId = "test-asset-externalAssetId"
                displayName = "test-ns-asset-displayName"
                manufacturer = "Contoso123"
                manufacturerUri = "https://www.contoso.com/manufacturerUri"
                model = "ContosoModel"
                productCode = "SA34VDG"
                softwareRevision = "2.0"
                serialNumber = "64-103816-519918-8"
                documentationUri = "https://www.example.com/manual"
            }
            UpdateExpanded = @{
                name = "test-ns-asset-update"
            }
            UpdateViaJsonString = @{
                name = "test-ns-asset-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceAsset.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-ns-asset-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceAsset.json"
            }
            UpdateViaIdentityNamespaceExpanded = @{
                name = "test-ns-asset-update-via-identity-ns-expanded"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-ns-asset-update-via-identity-expanded"
            }
        }
    })

    $env.Add("namespaceDiscoveredAssetTests", @{
        namespaceName = "adr-namespace"
        createTests = @{
            CreateExpanded = @{
                name = "test-ns-dasset-create-expanded"
                properties = @{
                    deviceRef = @{
                        deviceName = "myDeviceName"
                        endpointName = "myEndpointName"
                    }
                    discoveryId = "myDiscoveryId"
                    version = 1
                    displayName = "test-ns-dasset-displayName"
                    description = "my test discovered asset"
                    externalAssetId = "test-dasset-externalAssetId"
                    manufacturer = "Contoso123"
                    manufacturerUri = "https://contoso.com"
                    model = "ContosoModel"
                    productCode = "SA34VDG"
                    softwareRevision = "2.0"
                    hardwareRevision = "1.0"
                    serialNumber = "64-103816-519918-8"
                    documentationUri = "https://www.example.com/manual"
                }
            }
            CreateViaJsonFilePath = @{
                name = "test-ns-dasset-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredAsset.json"
            }
            CreateViaJsonString = @{
                name = "test-ns-dasset-create-json-string"
                jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredAsset.json"
            }
        }
        getTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredAsset.json"
            List = @{
                name1 = "test-ns-dasset-list1"
                name2 = "test-ns-dasset-list2"
            }
            GetViaIdentityNamespace = @{
                name = "test-ns-dasset-get-via-identity-ns"
            }
            Get = @{
                name = "test-ns-dasset-get"
            }
            GetViaIdentity = @{
                name = "test-ns-dasset-get-via-identity"
            }
        }
        deleteTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredAsset.json"
            Delete = @{
                name = "test-ns-dasset-delete"
            }
            DeleteViaIdentityNamespace = @{
                name = "test-ns-dasset-delete-via-identity-ns"
            }
            DeleteViaIdentity = @{
                name = "test-ns-dasset-delete-via-identity"
            }
        }
        updateTests = @{
            createJsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredAsset.json"
            commonPatchConfig = @{
                documentationUri = "https://www.example.com/foo"
                serialNumber = "123-456789-012345-6"
            }
            commonProperties = @{
                deviceRef = @{
                    deviceName = "myDeviceName"
                    endpointName = "myEndpointName"
                }
                discoveryId = "myDiscoveryId"
                version = 1
                displayName = "test-ns-dasset-displayName"
                description = "my test discovered asset"
                externalAssetId = "test-dasset-externalAssetId"
                manufacturer = "Contoso123"
                manufacturerUri = "https://www.contoso.com/manufacturerUri"
                model = "ContosoModel"
                productCode = "SA34VDG"
                softwareRevision = "2.0"
                hardwareRevision = "1.0"
                serialNumber = "64-103816-519918-8"
                documentationUri = "https://www.example.com/manual"
            }
            UpdateExpanded = @{
                name = "test-ns-dasset-update"
            }
            UpdateViaJsonString = @{
                name = "test-ns-dasset-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDiscoveredAsset.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-ns-dasset-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDiscoveredAsset.json"
            }
            UpdateViaIdentityNamespaceExpanded = @{
                name = "test-ns-dasset-update-via-identity-ns-expanded"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-ns-dasset-update-via-identity-expanded"
            }
        }
    })

    $env.Add("namespaceDeviceTests", @{
        namespaceName = "adr-namespace"
        resourceGroupName = "adr-canary-test-ga-2510"
        extendedLocationName = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-canary-test-ga-2510/providers/Microsoft.ExtendedLocation/customLocations/adr-canary-test-ga-2510-cl"
        location = "eastus2euap"
        createTests = @{
            commonProperties = @{
                enabled = $true
                manufacturer = "Contoso"
                model = "foo123"
                operatingSystem = "Linux"
                operatingSystemVersion = "1000"
                outboundEndpointName = "endpoint2"
                outboundAddress = "https://myendpoint2.westeurope-1.iothub.azure.net"
                outboundEndpointType = "Microsoft.Devices/IotHubs"
                inboundEndpointName1 = "endpoint1"
                inboundEndpointName2 = "endpoint2"
                inboundAddress1 = "https://myendpoint1.westeurope-1.iothub.azure.net"
                inboundEndpointType1 = "Microsoft.Devices/IotHubs"
                inboundAddress2 = "https://myendpoint2.westeurope-1.iothub.azure.net"
                inboundEndpointType2 = "Microsoft.Devices/IotHubs"
                authenticationMethod1 = "Certificate"
                authenticationMethod2 = "UsernamePassword"
                certificateSecretName = "mycertificate"
                keySecretName = "mykeysecret"
                intermediateCertificatesSecretName = "myintermediatecerts"
                usernameSecretName = "myUsernameSecretRef"
                passwordSecretName = "myPasswordSecretRef"
            }
            CreateExpanded = @{
                name = "test-ns-device-create-expanded"
            }
            CreateViaJsonFilePath = @{
                name = "test-ns-device-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateNamespaceDevice.json"
            }
            CreateViaJsonString = @{
                name = "test-ns-device-create-json-string"
                jsonFilePath = "./jsonFiles/CreateNamespaceDevice.json"
            }
        }
        getTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDevice.json"
            List = @{
                name1 = "test-ns-device-list1"
                name2 = "test-ns-device-list2"
            }
            GetViaIdentityNamespace = @{
                name = "test-ns-device-get-via-identity-ns"
            }
            Get = @{
                name = "test-ns-device-get"
            }
            GetViaIdentity = @{
                name = "test-ns-device-get-via-identity"
            }
        }
        deleteTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDevice.json"
            Delete = @{
                name = "test-ns-device-delete"
            }
            DeleteViaIdentityNamespace = @{
                name = "test-ns-device-delete-via-identity"
            }
            DeleteViaIdentity = @{
                name = "test-ns-device-delete-via-identity"
            }
        }
        updateTests = @{
            createJsonFilePath = "./jsonFiles/CreateNamespaceDevice.json"
            commonPatchConfig = @{
                operatingSystemVersion = "2000"
                authenticationMethod1 = "Anonymous"
            }
            commonProperties = @{
                enabled = $true
                manufacturer = "Contoso"
                model = "foo123"
                operatingSystem = "Linux"
                operatingSystemVersion = "1000"
                outboundEndpointName = "endpoint2"
                outboundAddress = "https://myendpoint2.westeurope-1.iothub.azure.net"
                outboundEndpointType = "Microsoft.Devices/IotHubs"
                inboundEndpointName1 = "endpoint1"
                inboundEndpointName2 = "endpoint2"
                inboundAddress1 = "https://myendpoint1.westeurope-1.iothub.azure.net"
                inboundEndpointType1 = "Microsoft.Devices/IotHubs"
                inboundAddress2 = "https://myendpoint2.westeurope-1.iothub.azure.net"
                inboundEndpointType2 = "Microsoft.Devices/IotHubs"
                authenticationMethod1 = "Certificate"
                authenticationMethod2 = "UsernamePassword"
                certificateSecretName = "mycertificate"
                keySecretName = "mykeysecret"
                intermediateCertificatesSecretName = "myintermediatecerts"
                usernameSecretName = "myusername"
                passwordSecretName = "mypassword"
            }
            UpdateExpanded = @{
                name = "test-ns-device-update"
            }
            UpdateViaJsonString = @{
                name = "test-ns-device-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDevice.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-ns-device-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDevice.json"
            }
            UpdateViaIdentityNamespaceExpanded = @{
                name = "test-ns-device-update-via-identity-ns-expanded"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-ns-device-update-via-identity-expanded"
            }
        }
    })

    $env.Add("namespaceDiscoveredDeviceTests", @{
        namespaceName = "adr-namespace"
        createTests = @{
            commonProperties = @{
                discoveryId = "myDiscoveryId"
                version = 1
                manufacturer = "Contoso"
                model = "foo123"
                operatingSystem = "Linux"
                operatingSystemVersion = "1000"
                outboundEndpointName = "myendpoint2"
                outboundAddress = "https://myendpoint2.westeurope-1.iothub.azure.net"
                outboundEndpointType = "Microsoft.Devices/IoTHubs"
                inboundEndpointName1 = "endpoint1"
                inboundEndpointName2 = "endpoint2"
                inboundAddress1 = "https://myendpoint1.westeurope-1.iothub.azure.net"
                inboundEndpointType1 = "Microsoft.IotHub"
                inboundAddress2 = "https://myendpoint2.westeurope-1.iothub.azure.net"
                inboundEndpointType2 = "Microsoft.IotHub"
                inboundVersion1 = "1.0"
                inboundVersion2 = "2.0"
            }
            CreateExpanded = @{
                name = "test-ns-ddevice-create-expanded"
            }
            CreateViaJsonFilePath = @{
                name = "test-ns-ddevice-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredDevice.json"
            }
            CreateViaJsonString = @{
                name = "test-ns-ddevice-create-json-string"
                jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredDevice.json"
            }
        }
        getTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredDevice.json"
            List = @{
                name1 = "test-ns-ddevice-list1"
                name2 = "test-ns-ddevice-list2"
            }
            GetViaIdentityNamespace = @{
                name = "test-ns-ddevice-get-via-identity-ns"
            }
            Get = @{
                name = "test-ns-ddevice-get"
            }
            GetViaIdentity = @{
                name = "test-ns-ddevice-get-via-identity"
            }
        }
        deleteTests = @{
            jsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredDevice.json"
            Delete = @{
                name = "test-ns-ddevice-delete"
            }
            DeleteViaIdentityNamespace = @{
                name = "test-ns-ddevice-delete-via-identity"
            }
            DeleteViaIdentity = @{
                name = "test-ns-ddevice-delete-via-identity"
            }
        }
        updateTests = @{
            createJsonFilePath = "./jsonFiles/CreateNamespaceDiscoveredDevice.json"
            commonPatchConfig = @{
                operatingSystemVersion = "2000"
                inboundVersion1 = "1.1"
            }
            commonProperties = @{
                discoveryId = "myDiscoveryId"
                version = 1
                manufacturer = "Contoso"
                model = "foo123"
                operatingSystem = "Linux"
                operatingSystemVersion = "1000"
                outboundEndpointName = "myendpoint2"
                outboundAddress = "https://myendpoint2.westeurope-1.iothub.azure.net"
                outboundEndpointType = "Microsoft.Devices/IoTHubs"
                inboundEndpointName1 = "endpoint1"
                inboundEndpointName2 = "endpoint2"
                inboundAddress1 = "https://myendpoint1.westeurope-1.iothub.azure.net"
                inboundEndpointType1 = "Microsoft.IotHub"
                inboundAddress2 = "https://myendpoint2.westeurope-1.iothub.azure.net"
                inboundEndpointType2 = "Microsoft.IotHub"
                inboundVersion1 = "1.0"
                inboundVersion2 = "2.0"
            }
            UpdateExpanded = @{
                name = "test-ns-ddevice-update"
            }
            UpdateViaJsonString = @{
                name = "test-ns-ddevice-update-via-json-string"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDiscoveredDevice.json"
            }
            UpdateViaJsonFilePath = @{
                name = "test-ns-ddevice-update-via-json-file-path"
                updateJsonFilePath = "./jsonFiles/UpdateNamespaceDiscoveredDevice.json"
            }
            UpdateViaIdentityNamespaceExpanded = @{
                name = "test-ns-ddevice-update-via-identity-ns-expanded"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-ns-ddevice-update-via-identity-expanded"
            }
        }
    })

    $env.Add("schemaRegistryTests", @{
        createTests = @{
            commonProperties = @{
                displayName = "Schema Registry namespace 001"
                description = "This is a sample Schema Registry"
                storageAccountContainerUrl = "https://mystorageacc.blob.core.windows.net/mycontainer"
            }
            CreateExpanded = @{
                name = "test-sr-create-expanded"
                namespace = "sr-namespace-001"
            }
            CreateViaJsonFilePath = @{
                name = "test-sr-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateSchemaRegistry.json"
                namespace = "sr-namespace-002"
            }
            CreateViaJsonString = @{
                name = "test-sr-create-json-string"
                namespace = "sr-namespace-003"
            }
        }
        getTests = @{
            commonProperties = @{
                displayName = "Schema Registry namespace 001"
                description = "This is a sample Schema Registry"
                storageAccountContainerUrl = "https://mystorageacc.blob.core.windows.net/mycontainer"
            }
            List = @{
                names = @(
                    "test-sr-list1"
                    "test-sr-list2"
                )
                namespaces = @(
                    "sr-get-namespace-001"
                    "sr-get-namespace-002"
                )
            }
            Get = @{
                name = "test-sr-get"
                namespace = "sr-get-namespace-003"
            }
            GetViaIdentity = @{
                name = "test-sr-get-via-identity"
                namespace = "sr-get-namespace-004"
            }
        }
        deleteTests = @{
            commonProperties = @{
                displayName = "Schema Registry namespace 001"
                description = "This is a sample Schema Registry"
                storageAccountContainerUrl = "https://mystorageacc.blob.core.windows.net/mycontainer"
            }
            Delete = @{
                name = "test-sr-delete"
                namespace = "sr-delete-ns-001"
            }
            DeleteViaIdentity = @{
                name = "test-sr-delete-via-identity"
                namespace = "sr-delete-ns-002"
            }
        }
        updateTests = @{
            commonProperties = @{
                displayName = "Schema Registry namespace 001"
                description = "This is a sample Schema Registry"
                storageAccountContainerUrl = "https://mystorageacc.blob.core.windows.net/mycontainer"
            }
            commonPatchConfig = @{
                displayName = "Updated schema registry display name"
                description = "Updated schema registry description"
            }
            UpdateExpanded = @{
                name = "test-schema-registry-update"
                namespace = "sr-update-ns-001"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-schema-registry-update-via-identity-expanded"
                namespace = "sr-update-ns-002"
            }
        }
    })

    $env.Add("schemaTests", @{
        schemaRegistryName = "aio-sr-06f973e875"
        commonProperties = @{
            displayName = "My schema"
            description = "This is a sample schema"
            format = "JsonSchema/draft-07"
            schemaType = "MessageSchema"
            tagsKey = "sampleKey"
            tagsValue = "sampleValue"
        }
        createTests = @{
            CreateExpanded = @{
                name = "test-schema-create-expanded"
            }
            CreateViaJsonFilePath = @{
                name = "test-schema-create-json-file-path"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            CreateViaJsonString = @{
                name = "test-schema-create-json-string"
                jsonStringFilePath = "./jsonFiles/CreateSchema.json"
            }
        }
        getTests = @{
            List = @{
                names = @(
                    "test-schema-list1"
                    "test-schema-list2"
                )
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            Get = @{
                name = "test-schema-get"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            GetViaIdentitySchemaRegistry = @{
                name = "test-schema-get-via-identity-sr"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            GetViaIdentity = @{
                name = "test-schema-get-via-identity"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
        }
        deleteTests = @{
            Delete = @{
                name = "test-schema-delete"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            DeleteViaIdentitySchemaRegistry = @{
                name = "test-schema-delete-via-identity-sr"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            DeleteViaIdentity = @{
                name = "test-schema-delete-via-identity"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
        }
        updateTests = @{
            commonPatchConfig = @{
                displayName = "Updated schema display name"
                description = "Updated schema description"
                tagsKey = "updatedKey"
                tagsValue = "updatedValue"
            }
            UpdateExpanded = @{
                name = "test-schema-update"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            UpdateViaIdentitySchemaRegistryExpanded = @{
                name = "test-schema-update-via-identity-sr-expanded"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
            UpdateViaIdentityExpanded = @{
                name = "test-schema-update-via-identity-expanded"
                jsonFilePath = "./jsonFiles/CreateSchema.json"
            }
        }
    })

    $env.Add("schemaVersionTests", @{
        schemaRegistryName = "aio-sr-06f973e875"
        schemaName = "myschema"
        commonProperties = @{
            description = "Schema version 1"
            schemaContent = '{"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity": {"type": "string"},"temperature": {"type":"number"}}}'
        }
        createTests = @{
            CreateExpanded = @{
                name = "1"
            }
            CreateViaJsonFilePath = @{
                name = "2"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            CreateViaJsonString = @{
                name = "3"
                jsonStringFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
        }
        getTests = @{
            List = @{
                names = @(
                    "4"
                    "5"
                )
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            Get = @{
                name = "6"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            GetViaIdentitySchemaRegistry = @{
                name = "7"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            GetViaIdentitySchema = @{
                name = "8"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            GetViaIdentity = @{
                name = "9"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
        }
        deleteTests = @{
            Delete = @{
                name = "10"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            DeleteViaIdentitySchemaRegistry = @{
                name = "11"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            DeleteViaIdentitySchema = @{
                name = "12"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            DeleteViaIdentity = @{
                name = "13"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
        }
        updateTests = @{
            commonPatchConfig = @{
                description = "Updated schema version description"
            }
            UpdateExpanded = @{
                name = "14"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            UpdateViaIdentitySchemaRegistryExpanded = @{
                name = "15"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            UpdateViaIdentitySchemaExpanded = @{
                name = "16"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
            UpdateViaIdentityExpanded = @{
                name = "17"
                jsonFilePath = "./jsonFiles/CreateSchemaVersion.json"
            }
        }
    })

    # Save the $env to a file
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 10)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

