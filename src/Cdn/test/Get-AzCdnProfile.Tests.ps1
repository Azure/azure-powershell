if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnProfile'  {
    It 'List' {
        $cdnProfiles = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName

        $cdnProfiles.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $cdnProfile = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $env.ClassicCdnProfileName

        $cdnProfile.Name | Should -Be $env.ClassicCdnProfileName
        $cdnProfile.SkuName | Should -Be "Standard_Microsoft"
        $cdnProfile.Location | Should -Be "Global"
    }

    It 'List1' {
        $cdnProfiles = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName

        $cdnProfiles.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $cdnProfile = Get-AzCdnProfile -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.ClassicCdnProfileName | Get-AzCdnProfile

        $cdnProfile.Name | Should -Be $env.ClassicCdnProfileName
        $cdnProfile.SkuName | Should -Be "Standard_Microsoft"
        $cdnProfile.Location | Should -Be "Global"
    }
}
