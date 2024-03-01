### Example 1: Create new DefenderCspmGcpOffering object
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderCspmGcpOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationExclusionTag @{key="value"} `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix" -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryServiceAccountEmailAddress "mdc-data-sec-posture-storage@$emailSuffix" -DataSensitivityDiscoveryWorkloadIdentityProviderId "data-security-posture-storage" `
    -CiemDiscoveryServiceAccountEmailAddress "microsoft-defender-ciem@$emailSuffix" -CiemDiscoveryAzureActiveDirectoryAppName "mciem-gcp-oidc-app" -CiemDiscoveryWorkloadIdentityProviderId "ciem-discovery"
```

```output
CiemDiscoveryAzureActiveDirectoryAppName                    : mciem-gcp-oidc-app
CiemDiscoveryServiceAccountEmailAddress                     : microsoft-defender-ciem@myproject.iam.gserviceaccount.com
CiemDiscoveryWorkloadIdentityProviderId                     : ciem-discovery
ConfigurationExclusionTag                                   : {
                                                                "key": "value"
                                                              }
ConfigurationScanningMode                                   : Default
DataSensitivityDiscoveryEnabled                             : True
DataSensitivityDiscoveryServiceAccountEmailAddress          : mdc-data-sec-posture-storage@myproject.iam.gserviceaccount.com
DataSensitivityDiscoveryWorkloadIdentityProviderId          : data-security-posture-storage
Description                                                 : 
MdcContainerAgentlessDiscoveryK8SEnabled                    : True
MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress : mdc-containers-k8s-operator@myproject.iam.gserviceaccount.com
MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId : containers
MdcContainerImageAssessmentEnabled                          : True
MdcContainerImageAssessmentServiceAccountEmailAddress       : mdc-containers-artifact-assess@myproject.iam.gserviceaccount.com
MdcContainerImageAssessmentWorkloadIdentityProviderId       : containers
OfferingType                                                : DefenderCspmGcp
VMScannerEnabled                                            : True
```

