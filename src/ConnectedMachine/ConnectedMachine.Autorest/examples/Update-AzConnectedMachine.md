### Example 1: Update a hybrid machine
```powershell
Update-AzConnectedMachine -Name $env.MachineName -ResourceGroupName $env.ResourceGroupName -PrivateLinkScopeResourceId $env.PrivateLinkScopeUri
```

```output
AdFqdn                                      : ********
AgentConfigurationConfigMode                : full
AgentConfigurationExtensionsAllowList       : {}
AgentConfigurationExtensionsBlockList       : {}
AgentConfigurationExtensionsEnabled         : true
AgentConfigurationGuestConfigurationEnabled : true
AgentConfigurationIncomingConnectionsPort   : {}
AgentConfigurationProxyBypass               : {}
AgentConfigurationProxyUrl                  :
AgentUpgradeCorrelationId                   :
AgentUpgradeDesiredVersion                  :
AgentUpgradeEnableAutomaticUpgrade          : False
AgentUpgradeLastAttemptDesiredVersion       :
AgentUpgradeLastAttemptMessage              :
AgentUpgradeLastAttemptStatus               :
AgentUpgradeLastAttemptTimestamp            :
AgentVersion                                : *******
ClientPublicKey                             : ********-****-****-****-**********
CloudMetadataProvider                       : N/A
DetectedProperty                            : {
                                                "cloudprovider": "N/A",
                                                "coreCount": "4",
                                                "logicalCoreCount": "8",
                                                "manufacturer": "LENOVO",
                                                "model": "*******",
                                                "mssqldiscovered": "false",
                                                "processorCount": "1",
                                                "processorNames": "11th Gen Intel(R) Core(TM) i7-1185G7 @ 3.00GHz",
                                                "productType": "4",
                                                "serialNumber": "********",
                                                "smbiosAssetTag": "********",
                                                "totalPhysicalMemoryInBytes": "********",
                                                "totalPhysicalMemoryInGigabytes": "32",
                                                "vmuuidEsu2012": "********-****-****-****-**********"
                                              }
DisplayName                                 : ********
DnsFqdn                                     : ********
DomainName                                  : WORKGROUP
ErrorDetail                                 : {}
Extension                                   :
ExtensionServiceStartupType                 : automatic
ExtensionServiceStatus                      : running
Fqdn                                        : ********
GuestConfigurationServiceStartupType        : automatic
GuestConfigurationServiceStatus             : running
Id                                          : /subscriptions/********-****-****-****-**********/resourceGroups/
                                              ********/providers/Microsoft.HybridCompute/machines/********
IdentityPrincipalId                         : ********-****-****-****-**********
IdentityTenantId                            : ********-****-****-****-**********
IdentityType                                : SystemAssigned
Kind                                        :
LastStatusChange                            : 9/20/2024 1:42:35 AM
LicenseProfile                              : {
                                                "esuProfile": {
                                                  "serverType": "Unknown",
                                                  "esuEligibility": "Ineligible",
                                                  "esuKeyState": "Inactive",
                                                  "licenseAssignmentState": "NotAssigned"
                                                },
                                                "licenseStatus": "Licensed",
                                                "licenseChannel": "Retail"
                                              }
Location                                    : centraluseuap
LocationDataCity                            :
LocationDataCountryOrRegion                 :
LocationDataDistrict                        :
LocationDataName                            :
MssqlDiscovered                             : false
Name                                        : testmachine
NetworkProfileNetworkInterface              : {{
                                                "ipAddresses": [
                                                  {
                                                    "subnet": {
                                                      "addressPrefix": "********"
                                                    },
                                                    "address": "********",
                                                    "ipAddressVersion": "IPv4"
                                                  }
                                                ]
                                              }, {
                                                "ipAddresses": [
                                                  {
                                                    "subnet": {
                                                      "addressPrefix": "********"
                                                    },
                                                    "address": "********",
                                                    "ipAddressVersion": "IPv4"
                                                  }
                                                ]
                                              }, {
                                                "ipAddresses": [
                                                  {
                                                    "subnet": {
                                                      "addressPrefix": "********"
                                                    },
                                                    "address": "********",
                                                    "ipAddressVersion": "IPv6"
                                                  }
                                                ]
                                              }}
OSEdition                                   : enterprise
OSName                                      : windows
OSProfile                                   : {
                                                "computerName": "********"
                                              }
OSSku                                       : Windows 10 Enterprise
OSType                                      : windows
OSVersion                                   : ********
ParentClusterResourceId                     :
PrivateLinkScopeResourceId                  :
ProvisioningState                           : Succeeded
Resource                                    :
ResourceGroupName                           : ********
Status                                      : Connected
SystemDataCreatedAt                         :
SystemDataCreatedBy                         :
SystemDataCreatedByType                     :
SystemDataLastModifiedAt                    :
SystemDataLastModifiedBy                    :
SystemDataLastModifiedByType                :
Tags                                        : {
                                              }
Type                                        : Microsoft.HybridCompute/machines
VMId                                        : ********-****-****-****-**********
VMUuid                                      : ********-****-****-****-**********
```

Update a hybrid machine

