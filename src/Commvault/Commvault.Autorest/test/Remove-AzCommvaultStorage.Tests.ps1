if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCommvaultStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCommvaultStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# The service provisions a storage together with a compliance lock, so only the main delete path creates a storage. The
# tests that delete by identity are skipped to avoid provisioning more storages than needed.
Describe 'Remove-AzCommvaultStorage' {
    It 'Delete' {
        $storageName = 'azps-stg-del'
        $null = New-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -Location $env.Location -StorageClassType 'HOT'
        Remove-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -PassThru | Should -BeTrue
        { Get-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityCloudAccount' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
