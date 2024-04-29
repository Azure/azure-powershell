if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityConnector' {
    It 'CreateExpanded' {
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
        
        # $defenderForDatabasesOffering = New-AzSecurityDefenderForDatabasesAwsOfferingObject `
        #     -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
        #     -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB"

        # $defenderForServersOffering = New-AzSecurityDefenderForServersAwsOfferingObject `
        #     -DefenderForServerCloudRoleArn "$arnPrefix/DefenderForCloud-DefenderForServers" `
        #     -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
        #     -MdeAutoProvisioningEnabled $false `
        #     -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
        #     -VMScannerEnabled $true -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationScanningMode Default 
        #     #-SubPlanType P2
        
        $environment = New-AzSecurityAwsEnvironmentObject -ScanInterval 24

        # Tests require complecated environment setup. For now, validating that resource provider is accepting payload and trying to access AWS
        try {
            New-AzSecurityConnector -Name "aws-sdktest01" -ResourceGroupName "securityConnectors-tests" -EnvironmentData $environment -EnvironmentName AWS -HierarchyIdentifier "$account" `
                -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) -Location "CentralUS"
        } catch {
            $Error[0] | Should -Match "BadRequest"
            $Error[0].Exception.ResponseBody | Should -Match "Identity provider is missing from AWS account"
        }
    }

    It 'GCP' {
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

        # $defenderForDatabasesOffering = New-AzSecurityDefenderForDatabasesGcpOfferingObject `
        #     -ArcAutoProvisioningEnabled $true `
        #     -DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress "microsoft-databases-arc-ap@" -DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId "defender-for-databases-arc-ap"

        # $defenderForServersOffering = New-AzSecurityDefenderForServersGcpOfferingObject `
        #     -DefenderForServerServiceAccountEmailAddress "microsoft-defender-for-servers@$emailSuffix" -DefenderForServerWorkloadIdentityProviderId "defender-for-servers" `
        #     -ArcAutoProvisioningEnabled $true -MdeAutoProvisioningEnabled $true -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
        #     -VMScannerEnabled $true -ConfigurationScanningMode Default

        $environment = New-AzSecurityGcpProjectEnvironmentObject -ScanInterval 24 -ProjectDetailProjectId "asc-sdk-samples" -ProjectDetailProjectNumber "$account"

        # Tests require complecated environment setup. For now, validating that resource provider is accepting payload and trying to access GCP
        try {
            New-AzSecurityConnector -Name "gcp-sdktest01" -ResourceGroupName "securityConnectors-tests" -EnvironmentData $environment -EnvironmentName GCP -HierarchyIdentifier "$account" `
                -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) -Location "CentralUS"
        } catch {
            $Error[0] | Should -Match "BadRequest"
            $Error[0].Exception.ResponseBody | Should -Match "There is a problem with authenticating to your GCP project"
        }
    }
    
    It 'AzureDevOps' {
        $rg = "securityConnectors-pwsh-tmp"
        $sid = $env.SubscriptionId
        $connectorName = "ado-pwsh-test01"
        $hierarchyIdentifier = "de659ead-f948-45b3-9a2c-b75e8914c958"
        try {
            $connector = New-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName `
                -EnvironmentName AzureDevOps -EnvironmentData (New-AzSecurityAzureDevOpsScopeEnvironmentObject) `
                -HierarchyIdentifier $hierarchyIdentifier -Location "CentralUS" `
                -Offering @(New-AzSecurityCspmMonitorAzureDevOpsOfferingObject)
        } finally {
            Remove-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName
        }
        
        $connector | Should -Not -Be $null
        $connector.EnvironmentName | Should -Be "AzureDevOps"
    }

    It 'GitHub' {
        $rg = "securityConnectors-pwsh-tmp"
        $sid = $env.SubscriptionId
        $connectorName = "gh-pwsh-test01"
        $hierarchyIdentifier = "2ba1410d-87af-4481-8d45-e9bc26880cec"
        try {
            $connector = New-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName `
                -EnvironmentName Github -EnvironmentData (New-AzSecurityGitHubScopeEnvironmentObject) `
                -HierarchyIdentifier $hierarchyIdentifier -Location "CentralUS" `
                -Offering @(New-AzSecurityCspmMonitorGithubOfferingObject)
        } finally {
            Remove-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName
        }
        
        $connector | Should -Not -Be $null
        $connector.EnvironmentName | Should -Be "GitHub"
    }

    It 'GitLab' {
        $rg = "securityConnectors-pwsh-tmp"
        $sid = $env.SubscriptionId
        $connectorName = "gl-pwsh-test01"
        $hierarchyIdentifier = "15397162-d8b4-44d1-a5c4-024ca4aabd44"
        try {
            $connector = New-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName `
                -EnvironmentName GitLab -EnvironmentData (New-AzSecurityGitLabScopeEnvironmentObject) `
                -HierarchyIdentifier $hierarchyIdentifier -Location "CentralUS" `
                -Offering @(New-AzSecurityCspmMonitorGitLabOfferingObject)
        } finally {
            Remove-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName
        }
        
        $connector | Should -Not -Be $null
        $connector.EnvironmentName | Should -Be "GitLab"
    }
}
