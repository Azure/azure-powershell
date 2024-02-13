if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForContainersGcpOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForContainersGcpOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForContainersGcpOfferingObject' {
    It '__AllParameterSets' {
        $emailSuffix = "myproject.iam.gserviceaccount.com"
        $offering = New-AzSecurityDefenderForContainersGcpOfferingObject `
            -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-containers@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "containers" `
            -DataPipelineNativeCloudConnectionServiceAccountEmailAddress "ms-defender-containers-stream@$emailSuffix" -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId "containers-streams" `
            -AuditLogsAutoProvisioningFlag $true -DefenderAgentAutoProvisioningFlag $true -PolicyAgentAutoProvisioningFlag $true `
            -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" `
            -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix"
        $offering.OfferingType | Should -Be "DefenderForContainersGcp"
    }
}
