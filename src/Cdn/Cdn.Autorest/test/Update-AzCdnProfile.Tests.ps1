if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnProfile' {
    BeforeAll {
        $script:profileName = 'cdnpps01-upd'
        New-AzCdnProfile -SkuName 'Standard_Microsoft' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    AfterAll {
        Remove-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        Update-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11; Tag2 = 22 }
        $u = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        $u.Tag['Tag1'] | Should -Be '11'
        $u.Tag['Tag2'] | Should -Be '22'
    }

    It 'UpdateViaIdentityExpanded' {
        $p = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        Update-AzCdnProfile -Tag @{ Tag1 = 33 } -InputObject $p
        $u = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        $u.Tag['Tag1'] | Should -Be '33'
    }
}
