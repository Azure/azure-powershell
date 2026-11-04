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
        $script:profileName = $env.ClassicCdnProfileName
        $script:originalTags = $null
        $profile = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $script:originalTags = @{}
        foreach ($key in $profile.Tag.Keys) {
            $script:originalTags[$key] = $profile.Tag[$key]
        }
    }

    AfterAll {
        if ($null -ne $script:originalTags) {
            Update-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName -Tag $script:originalTags | Out-Null
        }
    }

    It 'UpdateExpanded' {
        $tags = $script:originalTags.Clone()
        $tags['AzCdnTestTag'] = '11'
        Update-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName -Tag $tags
        $u = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $u.Tag['AzCdnTestTag'] | Should -Be '11'
    }

    It 'UpdateViaIdentityExpanded' {
        $p = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $tags = $script:originalTags.Clone()
        $tags['AzCdnTestTag'] = '33'
        Update-AzCdnProfile -Tag $tags -InputObject $p
        $u = Get-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $u.Tag['AzCdnTestTag'] | Should -Be '33'
    }
}
