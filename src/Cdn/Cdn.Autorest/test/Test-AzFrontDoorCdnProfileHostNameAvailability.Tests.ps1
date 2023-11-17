if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnProfileHostNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnProfileHostNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnProfileHostNameAvailability'  {
    It 'CheckExpanded' {
        $hostName = "hello1.dev.cdn.azure.cn";
        $result = Test-AzFrontDoorCdnProfileHostNameAvailability -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $hostName
        $result.NameAvailable | Should -Be $true
    }

    It 'CheckViaIdentityExpanded' {
        $hostName = "hello1.dev.cdn.azure.cn";
        $resultObject = Get-AzFrontDoorCdnProfile -Name $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $result = Test-AzFrontDoorCdnProfileHostNameAvailability -HostName $hostName -InputObject $resultObject

        $result.NameAvailable | Should -Be $true
    }
}
