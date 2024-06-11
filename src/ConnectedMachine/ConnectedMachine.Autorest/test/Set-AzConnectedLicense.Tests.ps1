if(($null -eq $TestName) -or ($TestName -contains 'Set-AzConnectedLicense'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzConnectedLicense.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzConnectedLicense' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        $all = @(Set-AzConnectedLicense -Name $env.EsuLicenseName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -LicenseType 'ESU' -LicenseDetailState 'Deactivated'  -LicenseDetailTarget 'Windows Server 2012' -LicenseDetailEdition 'Datacenter' -LicenseDetailType 'pCore' -LicenseDetailProcessor 16 -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
