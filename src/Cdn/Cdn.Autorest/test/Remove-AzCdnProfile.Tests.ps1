if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadCdnEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadCdnEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnProfile' {
    It 'RejectsMissingProfile' {
        $missingProfileName = 'cdnpps01-rm'
        Get-AzCdnProfile -Name $missingProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction SilentlyContinue | Should -BeNullOrEmpty
        {
            Remove-AzCdnProfile -Name $missingProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction Stop
        } | Should -Throw "The Resource 'Microsoft.Cdn/profiles/$missingProfileName' under resource group '$($env.ClassicCdnResourceGroupName)' was not found."
    }

    # New disposable profiles cannot be provisioned; never delete the configured existing profile.
    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
