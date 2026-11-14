if(($null -eq $TestName) -or ($TestName -contains 'New-AzCommvaultStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCommvaultStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# The service provisions a storage together with a compliance lock, so only the main create path creates one. The tests
# that pass the request as JSON or by identity are skipped to avoid provisioning more storages than needed.
Describe 'New-AzCommvaultStorage' {
    It 'CreateExpanded' {
        $storageName = 'azps-stg-new'
        try {
            $storage = New-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -Location $env.Location -StorageClassType 'HOT'
            $storage.Name | Should -Be $storageName
            $storage.Class | Should -Be 'HOT'
            $storage.ProvisioningState | Should -Be 'Succeeded'
        } finally {
            Remove-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName
        }
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityCloudAccountExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
