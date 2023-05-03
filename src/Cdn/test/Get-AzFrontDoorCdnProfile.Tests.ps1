if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnProfile'  {
    It 'List' {
        $frontDoorCdnProfiles = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName
        $frontDoorCdnProfiles.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $frontDoorCdnProfile = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $env.FrontDoorCdnProfileName

        $frontDoorCdnProfile.Name | Should -Be $env.FrontDoorCdnProfileName
        $frontDoorCdnProfile.SkuName | Should -Be "Standard_AzureFrontDoor"
        $frontDoorCdnProfile.Location | Should -Be "Global"
    }

    It 'List1' {
        $frontDoorCdnProfiles = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName
        $frontDoorCdnProfiles.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $frontDoorCdnProfile = Get-AzFrontDoorCdnProfile -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.FrontDoorCdnProfileName | Get-AzFrontDoorCdnProfile

        $frontDoorCdnProfile.Name | Should -Be $env.FrontDoorCdnProfileName
        $frontDoorCdnProfile.SkuName | Should -Be "Standard_AzureFrontDoor"
        $frontDoorCdnProfile.Location | Should -Be "Global"
    }
}
