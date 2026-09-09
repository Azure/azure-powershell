if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnEndpoint' {
    BeforeAll {
        $script:endpointName = 'e-clipstest310-update'
        $script:origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $script:origin | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        Update-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11; Tag2 = 22 }
        $updated = Get-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updated.Tag['Tag1'] | Should -Be '11'
    }

    It 'UpdateViaIdentityExpanded' {
        $endpoint = Get-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Update-AzCdnEndpoint -Tag @{ Tag1 = 33 } -InputObject $endpoint
        $updated = Get-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updated.Tag['Tag1'] | Should -Be '33'
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
