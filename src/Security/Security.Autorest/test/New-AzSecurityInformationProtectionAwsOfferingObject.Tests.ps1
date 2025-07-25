if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityInformationProtectionAwsOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityInformationProtectionAwsOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityInformationProtectionAwsOfferingObject' {
    It '__AllParameterSets' {
        $offering = New-AzSecurityInformationProtectionAwsOfferingObject -InformationProtectionCloudRoleArn "arn:aws:iam::123456789012:role/myRole"
        $offering.OfferingType | Should -Be "InformationProtectionAws"
    }
}
