if(($null -eq $TestName) -or ($TestName -contains 'Test-AzConnectedLicense'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzConnectedLicense.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzConnectedLicense' {
    It 'ValidateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate' -skip{
        $all = @(Test-AzConnectedLicense -Location 'eastus2euap' -LicenseType 'ESU' -LicenseDetailState 'Activated'  -LicenseDetailTarget 'Windows Server 2012' -LicenseDetailEdition 'Datacenter' -LicenseDetailType 'pCore' -LicenseDetailProcessor 16 -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'ValidateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
