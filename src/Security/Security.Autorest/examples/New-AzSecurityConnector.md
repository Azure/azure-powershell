### Example 1: Create AWS security connector
```powershell
$account = "891376984375"
$arnPrefix = "arn:aws:iam::$($account):role"

$cspmMonitorOffering = New-AzSecurityCspmMonitorAwsOfferingObject -NativeCloudConnectionCloudRoleArn "$arnPrefix/CspmMonitorAws"

$dcspmOffering = New-AzSecurityDefenderCspmAwsOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" `
    -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"

$defenderForContainersOffering = New-AzSecurityDefenderForContainersAwsOfferingObject `
    -AutoProvisioning $true -KuberneteServiceCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s" -KuberneteScubaReaderCloudRoleArn "$arnPrefix/DefenderForCloud-DataCollection" `
    -KinesiToS3CloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-kinesis-to-s3" -CloudWatchToKinesiCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis" `
    -KubeAuditRetentionTime 30 -ScubaExternalId "a47ae0a2-7bf7-482a-897a-7a139d30736c" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -EnableContainerVulnerabilityAssessment $false

$environment = New-AzSecurityAwsEnvironmentObject -ScanInterval 24

New-AzSecurityConnector -Name "aws-sdktest01" -ResourceGroupName "securityConnectors-tests" `
        -EnvironmentData $environment -EnvironmentName AWS -HierarchyIdentifier "$account" `
        -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) `
        -Location "CentralUS"
```

```output
EnvironmentData                 : {
                                    "environmentType": "AwsAccount",
                                    "regions": [ ],
                                    "scanInterval": 24
                                  }
EnvironmentName                 : AWS
Etag                            :
HierarchyIdentifier             : 891376984375
HierarchyIdentifierTrialEndDate : 3/24/2024 12:00:00 AM
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-tests/providers/Microsoft.Security/securityConnectors/aws-sdktes
                                  t01
Kind                            :
Location                        : CentralUS
Name                            : aws-sdktest01
Offering                        : {{
                                    "offeringType": "CspmMonitorAws",
                                    "nativeCloudConnection": {
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/CspmMonitorAws"
                                    }
                                  }, {
                                    "offeringType": "DefenderCspmAws",
                                    "vmScanners": {
                                      "configuration": {
                                        "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-AgentlessScanner",
                                        "scanningMode": "Default"
                                      },
                                      "enabled": true
                                    },
                                    "dataSensitivityDiscovery": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/SensitiveDataDiscovery"
                                    },
                                    "databasesDspm": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-DataSecurityPostureDB"
                                    },
                                    "ciem": {
                                      "ciemDiscovery": {
                                        "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-Ciem"
                                      },
                                      "ciemOidc": {
                                        "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-OidcCiem",
                                        "azureActiveDirectoryAppName": "mciem-aws-oidc-connector"
                                      }
                                    },
                                    "mdcContainersImageAssessment": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/MDCContainersImageAssessmentRole"
                                    },
                                    "mdcContainersAgentlessDiscoveryK8s": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/MDCContainersAgentlessDiscoveryK8sRole"
                                    }
                                  }, {
                                    "offeringType": "DefenderForContainersAws",
                                    "kubernetesService": {
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-Containers-K8s"
                                    },
                                    "kubernetesScubaReader": {
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-DataCollection"
                                    },
                                    "cloudWatchToKinesis": {
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis"
                                    },
                                    "kinesisToS3": {
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/DefenderForCloud-Containers-K8s-kinesis-to-s3"
                                    },
                                    "mdcContainersImageAssessment": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/MDCContainersImageAssessmentRole"
                                    },
                                    "mdcContainersAgentlessDiscoveryK8s": {
                                      "enabled": true,
                                      "cloudRoleArn": "arn:aws:iam::891376984375:role/MDCContainersAgentlessDiscoveryK8sRole"
                                    },
                                    "enableContainerVulnerabilityAssessment": false,
                                    "autoProvisioning": true,
                                    "kubeAuditRetentionTime": 30,
                                    "scubaExternalId": "a47ae0a2-7bf7-482a-897a-7a139d30736c"
                                  }}
ResourceGroupName               : securityconnectors-tests
SystemDataCreatedAt             : 2/22/2024 11:45:53 PM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/22/2024 11:45:53 PM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : Microsoft.Security/securityconnectors
```

### Example 2: Create GCP security connector
```powershell
$account = "843025268399"
$emailSuffix = "myproject.iam.gserviceaccount.com"
$cspmMonitorOffering = New-AzSecurityCspmMonitorGcpOfferingObject -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-cspm@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "cspm"

$dcspmOffering = New-AzSecurityDefenderCspmGcpOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationExclusionTag @{key="value"} `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix" -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryServiceAccountEmailAddress "mdc-data-sec-posture-storage@$emailSuffix" -DataSensitivityDiscoveryWorkloadIdentityProviderId "data-security-posture-storage" `
    -CiemDiscoveryServiceAccountEmailAddress "microsoft-defender-ciem@$emailSuffix" -CiemDiscoveryAzureActiveDirectoryAppName "mciem-gcp-oidc-app" -CiemDiscoveryWorkloadIdentityProviderId "ciem-discovery"

$defenderForContainersOffering = New-AzSecurityDefenderForContainersGcpOfferingObject `
    -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-containers@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "containers" `
    -DataPipelineNativeCloudConnectionServiceAccountEmailAddress "ms-defender-containers-stream@$emailSuffix" -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId "containers-streams" `
    -AuditLogsAutoProvisioningFlag $true -DefenderAgentAutoProvisioningFlag $true -PolicyAgentAutoProvisioningFlag $true `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix"

$environment = New-AzSecurityGcpProjectEnvironmentObject -ScanInterval 24 -ProjectDetailProjectId "asc-sdk-samples" -ProjectDetailProjectNumber "$account"

New-AzSecurityConnector -Name "gcp-sdktest01" -ResourceGroupName "securityConnectors-tests" -EnvironmentData $environment -EnvironmentName GCP -HierarchyIdentifier "$account" `
    -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) -Location "CentralUS"
```

```output
EnvironmentData                 : {
                                    "environmentType": "GcpProject",
                                    "projectDetails": {
                                        "projectNumber": "843025268399",
                                        "projectId": "asc-sdk-samples"
                                    },
                                    "scanInterval": 24
                                  }
EnvironmentName                 : GCP
Etag                            :
HierarchyIdentifier             : 843025268399
HierarchyIdentifierTrialEndDate : 3/24/2024 12:00:00 AM
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-tests/providers/Microsoft.Security/securityConnectors/gcp-sdktest01
Kind                            :
Location                        : CentralUS
Name                            : gcp-sdktest01
Offering                        : {{
                                    "offeringType": "CspmMonitorGcp",
                                    "nativeCloudConnection": {
                                        "workloadIdentityProviderId": "cspm",
                                        "serviceAccountEmailAddress": "microsoft-defender-cspm@myproject.iam.gserviceaccount.com"
                                    }
                                  }, {
                                    "offeringType": "DefenderCspmGcp",
                                    "ciemDiscovery": {
                                        "workloadIdentityProviderId": "ciem-discovery",
                                        "serviceAccountEmailAddress": "microsoft-defender-ciem@myproject.iam.gserviceaccount.com",
                                        "azureActiveDirectoryAppName": "mciem-gcp-oidc-app"
                                    },
                                    "vmScanners": {
                                        "configuration": {
                                            "scanningMode": "Default",
                                            "exclusionTags": {
                                                "key": "value"
                                            }
                                        },
                                        "enabled": true
                                    },
                                    "dataSensitivityDiscovery": {
                                        "enabled": true,
                                        "workloadIdentityProviderId": "data-security-posture-storage",
                                        "serviceAccountEmailAddress": "mdc-data-sec-posture-storage@myproject.iam.gserviceaccount.com"
                                    },
                                    "mdcContainersImageAssessment": {
                                        "enabled": true,
                                        "workloadIdentityProviderId": "containers",
                                        "serviceAccountEmailAddress": "mdc-containers-artifact-assess@myproject.iam.gserviceaccount.com"
                                    },
                                    "mdcContainersAgentlessDiscoveryK8s": {
                                        "enabled": true,
                                        "workloadIdentityProviderId": "containers",
                                        "serviceAccountEmailAddress": "mdc-containers-k8s-operator@myproject.iam.gserviceaccount.com"
                                    }
                                  }, {
                                    "offeringType": "DefenderForContainersGcp",
                                    "nativeCloudConnection": {
                                        "serviceAccountEmailAddress": "microsoft-defender-containers@myproject.iam.gserviceaccount.com",
                                        "workloadIdentityProviderId": "containers"
                                    },
                                    "dataPipelineNativeCloudConnection": {
                                        "serviceAccountEmailAddress": "ms-defender-containers-stream@myproject.iam.gserviceaccount.com",
                                        "workloadIdentityProviderId": "containers-streams"
                                    },
                                    "mdcContainersImageAssessment": {
                                        "enabled": true,
                                        "workloadIdentityProviderId": "containers",
                                        "serviceAccountEmailAddress": "mdc-containers-artifact-assess@myproject.iam.gserviceaccount.com"
                                    },
                                    "mdcContainersAgentlessDiscoveryK8s": {
                                        "enabled": true,
                                        "workloadIdentityProviderId": "containers",
                                        "serviceAccountEmailAddress": "mdc-containers-k8s-operator@myproject.iam.gserviceaccount.com"
                                    },
                                    "auditLogsAutoProvisioningFlag": true,
                                    "defenderAgentAutoProvisioningFlag": true,
                                    "policyAgentAutoProvisioningFlag": true
                                  }}
ResourceGroupName               : securityconnectors-tests
SystemDataCreatedAt             : 2/22/2024 11:45:53 PM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/22/2024 11:45:53 PM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {}
Type                            : Microsoft.Security/securityconnectors
```

### Example 3: Create AzureDevOps security connector
```powershell
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "ado-sdk-pwsh-test03" `
    -EnvironmentName AzureDevOps -EnvironmentData (New-AzSecurityAzureDevOpsScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorAzureDevOpsOfferingObject)
```

```output
EnvironmentData                 : {
                                    "environmentType": "AzureDevOpsScope"
                                  }
EnvironmentName                 : AzureDevOps
Etag                            : 
HierarchyIdentifier             : 9dd01e19-8aaf-43a2-8dd4-1c5992f4df35
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03
Kind                            : 
Location                        : CentralUS
Name                            : ado-sdk-pwsh-test03
Offering                        : {{
                                    "offeringType": "CspmMonitorAzureDevOps"
                                  }}
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 2/24/2024 12:13:11 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/24/2024 12:13:11 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : Microsoft.Security/securityconnectors
```

### Example 4: Create GitHub security connector
```powershell
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "gh-sdk-pwsh-test03" `
    -EnvironmentName GitHub -EnvironmentData (New-AzSecurityGitHubScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorGithubOfferingObject)
```

```output
EnvironmentData                 : {
                                    "environmentType": "GithubScope"
                                  }
EnvironmentName                 : Github
Etag                            : 
HierarchyIdentifier             : e8661d05-8003-46ae-b687-fa83746f44f3
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/gh-sdk-pwsh-test03
Kind                            : 
Location                        : CentralUS
Name                            : gh-sdk-pwsh-test03
Offering                        : {{
                                    "offeringType": "CspmMonitorGithub"
                                  }}
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 2/24/2024 12:55:33 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/24/2024 12:55:33 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : Microsoft.Security/securityconnectors
```

### Example 5: Create GitLab security connector
```powershell
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "gl-sdk-pwsh-test03" `
    -EnvironmentName GitLab -EnvironmentData (New-AzSecurityGitLabScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorGitLabOfferingObject)
```

```output
EnvironmentData                 : {
                                    "environmentType": "GitLabScope"
                                  }
EnvironmentName                 : GitLab
Etag                            : 
HierarchyIdentifier             : e8661d05-8003-46ae-b687-fa83746f44f3
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/gl-sdk-pwsh-test03
Kind                            : 
Location                        : CentralUS
Name                            : gl-sdk-pwsh-test03
Offering                        : {{
                                    "offeringType": "CspmMonitorGitLab"
                                  }}
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 2/24/2024 12:55:33 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/24/2024 12:55:33 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : Microsoft.Security/securityconnectors
```


