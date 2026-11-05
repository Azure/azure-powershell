if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadCdnEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadCdnEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnProfile' {
    BeforeAll {
        $script:cdnProfileName = 'cdnpps01-new'
        $script:profileSku = 'Standard_Microsoft'
        Get-AzCdnProfile -Name $script:cdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction SilentlyContinue | Should -BeNullOrEmpty
    }

    It 'CreateExpanded' {
        {
            New-AzCdnProfile -SkuName $script:profileSku -Name $script:cdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -Location Global -ErrorAction Stop
        } | Should -Throw 'Azure CDN from Microsoft (classic) no longer support new profile creation.'
    }
}
