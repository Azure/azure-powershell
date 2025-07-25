### Example 1: Create new DefenderForContainersGcpOffering object
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForContainersGcpOfferingObject `
    -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-containers@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "containers" `
    -DataPipelineNativeCloudConnectionServiceAccountEmailAddress "ms-defender-containers-stream@$emailSuffix" -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId "containers-streams" `
    -AuditLogsAutoProvisioningFlag $true -DefenderAgentAutoProvisioningFlag $true -PolicyAgentAutoProvisioningFlag $true `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix"
```

```output
AuditLogsAutoProvisioningFlag                               : True
DataPipelineNativeCloudConnectionServiceAccountEmailAddress : ms-defender-containers-stream@myproject.iam.gserviceaccount.com
DataPipelineNativeCloudConnectionWorkloadIdentityProviderId : containers-streams
DefenderAgentAutoProvisioningFlag                           : True
Description                                                 : 
MdcContainerAgentlessDiscoveryK8SEnabled                    : True
MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress : mdc-containers-k8s-operator@myproject.iam.gserviceaccount.com
MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId : containers
MdcContainerImageAssessmentEnabled                          : True
MdcContainerImageAssessmentServiceAccountEmailAddress       : mdc-containers-artifact-assess@myproject.iam.gserviceaccount.com
MdcContainerImageAssessmentWorkloadIdentityProviderId       : containers
NativeCloudConnectionServiceAccountEmailAddress             : microsoft-defender-containers@myproject.iam.gserviceaccount.com
NativeCloudConnectionWorkloadIdentityProviderId             : containers
OfferingType                                                : DefenderForContainersGcp
PolicyAgentAutoProvisioningFlag                             : True
```

