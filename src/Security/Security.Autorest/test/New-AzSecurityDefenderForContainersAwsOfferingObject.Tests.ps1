if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForContainersAwsOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForContainersAwsOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForContainersAwsOfferingObject' {
    It '__AllParameterSets' {
        $arnPrefix = "arn:aws:iam::123456789012:role"
        $offering = New-AzSecurityDefenderForContainersAwsOfferingObject `
            -AutoProvisioning $true -KuberneteServiceCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s" -KuberneteScubaReaderCloudRoleArn "$arnPrefix/DefenderForCloud-DataCollection" `
            -KinesiToS3CloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-kinesis-to-s3" -CloudWatchToKinesiCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis" `
            -KubeAuditRetentionTime 30 -ScubaExternalId "a47ae0a2-7bf7-482a-897a-7a139d30736c" `
            -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole" `
            -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
            -EnableContainerVulnerabilityAssessment $false

        $offering.OfferingType | Should -Be "DefenderForContainersAws"
    }
}
