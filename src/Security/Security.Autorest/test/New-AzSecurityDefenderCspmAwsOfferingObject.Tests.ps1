if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderCspmAwsOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderCspmAwsOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderCspmAwsOfferingObject' {
    It '__AllParameterSets' {
        $arnPrefix = "arn:aws:iam::123456789012:role"
        $offering = New-AzSecurityDefenderCspmAwsOfferingObject `
            -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationExclusionTag @{key="value"} `
            -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" `
            -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" `
            -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" `
            -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
            -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"
            
        $offering.OfferingType | Should -Be "DefenderCspmAws"
    }
}
