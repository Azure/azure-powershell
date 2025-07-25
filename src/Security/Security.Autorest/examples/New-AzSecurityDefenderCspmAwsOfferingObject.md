### Example 1: Create new DefenderCspmAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderCspmAwsOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationExclusionTag @{key="value"} `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" `
    -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"
```

```output
CiemDiscoveryCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-Ciem
CiemOidcAzureActiveDirectoryAppName           : mciem-aws-oidc-connector
CiemOidcCloudRoleArn                          : arn:aws:iam::123456789012:role/DefenderForCloud-OidcCiem
ConfigurationCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-AgentlessScanner
ConfigurationExclusionTag                     : {
                                                  "key": "value"
                                                }
ConfigurationScanningMode                     : Default
DataSensitivityDiscoveryCloudRoleArn          : arn:aws:iam::123456789012:role/SensitiveDataDiscovery
DataSensitivityDiscoveryEnabled               : True
DatabaseDspmCloudRoleArn                      : arn:aws:iam::123456789012:role/DefenderForCloud-DataSecurityPostureDB
DatabaseDspmEnabled                           : True
Description                                   : 
MdcContainerAgentlessDiscoveryK8SCloudRoleArn : arn:aws:iam::123456789012:role/MDCContainersAgentlessDiscoveryK8sRole
MdcContainerAgentlessDiscoveryK8SEnabled      : True
MdcContainerImageAssessmentCloudRoleArn       : arn:aws:iam::123456789012:role/MDCContainersImageAssessmentRole
MdcContainerImageAssessmentEnabled            : True
OfferingType                                  : DefenderCspmAws
VMScannerEnabled                              : True
```



