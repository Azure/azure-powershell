if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderCspmGcpOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderCspmGcpOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderCspmGcpOfferingObject' {
    It '__AllParameterSets' {
        $emailSuffix = "myproject.iam.gserviceaccount.com"
        $offering = New-AzSecurityDefenderCspmGcpOfferingObject `
            -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationExclusionTag @{key="value"} `
            -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" `
            -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix" -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" `
            -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryServiceAccountEmailAddress "mdc-data-sec-posture-storage@$emailSuffix" -DataSensitivityDiscoveryWorkloadIdentityProviderId "data-security-posture-storage" `
            -CiemDiscoveryServiceAccountEmailAddress "microsoft-defender-ciem@$emailSuffix" -CiemDiscoveryAzureActiveDirectoryAppName "mciem-gcp-oidc-app" -CiemDiscoveryWorkloadIdentityProviderId "ciem-discovery"
        $offering.OfferingType | Should -Be "DefenderCspmGcp"
    }
}
