### Example 1: Create new DefenderForContainersAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForContainersAwsOfferingObject `
    -AutoProvisioning $true -KuberneteServiceCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s" -KuberneteScubaReaderCloudRoleArn "$arnPrefix/DefenderForCloud-DataCollection" `
    -KinesiToS3CloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-kinesis-to-s3" -CloudWatchToKinesiCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis" `
    -KubeAuditRetentionTime 30 -ScubaExternalId "a47ae0a2-7bf7-482a-897a-7a139d30736c" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -EnableContainerVulnerabilityAssessment $false
```

```output
AutoProvisioning                                 : True
CloudWatchToKinesiCloudRoleArn                   : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis
ContainerVulnerabilityAssessmentCloudRoleArn     : 
ContainerVulnerabilityAssessmentTaskCloudRoleArn : 
Description                                      : 
EnableContainerVulnerabilityAssessment           : False
KinesiToS3CloudRoleArn                           : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s-kinesis-to-s3
KubeAuditRetentionTime                           : 30
KuberneteScubaReaderCloudRoleArn                 : arn:aws:iam::123456789012:role/DefenderForCloud-DataCollection
KuberneteServiceCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s
MdcContainerAgentlessDiscoveryK8SCloudRoleArn    : arn:aws:iam::123456789012:role/MDCContainersAgentlessDiscoveryK8sRole
MdcContainerAgentlessDiscoveryK8SEnabled         : True
MdcContainerImageAssessmentCloudRoleArn          : arn:aws:iam::123456789012:role/MDCContainersImageAssessmentRole
MdcContainerImageAssessmentEnabled               : True
OfferingType                                     : DefenderForContainersAws
ScubaExternalId                                  : a47ae0a2-7bf7-482a-897a-7a139d30736c
```



