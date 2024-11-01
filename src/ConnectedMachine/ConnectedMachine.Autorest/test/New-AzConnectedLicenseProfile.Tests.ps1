if(($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedLicenseProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedLicenseProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConnectedLicenseProfile' {
    It 'CreateExpanded'  {
        $productfeature = New-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
        $all = @(New-AzConnectedLicenseProfile -MachineName $env.MachineName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -EsuProfileAssignedLicense $env.LicenseResourceId -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled" -ProductProfileProductFeature $productfeature -SoftwareAssuranceCustomer)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
