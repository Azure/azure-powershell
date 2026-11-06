if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverAzSmbFileShareEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverAzSmbFileShareEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverAzSmbFileShareEndpoint' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}

Describe 'Update-AzStorageMoverAzSmbFileShareEndpoint PythonParity' -Tag @('PythonParity', 'Offline') {
    It 'UpdateExpandedCrossTenantRequest' {
        $response = @{ properties = @{ endpointType = 'AzureStorageSmbFileShare' } }
        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            Update-AzStorageMoverAzSmbFileShareEndpoint -Name 'smbsharexto' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId, $env.CrossTenantStorageAccountId -HttpPipelinePrepend $pipeline
        }
        $capture.Requests[0].Method | Should -Be 'PATCH'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.enableCrossTenantTransfer | Should -Be $true
        @($request.allowedStorageAccounts).Count | Should -Be 2

        $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.StorageMoverIdentity]::New()
        $identity.Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover/endpoints/smbsharexto"
        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            $identity | Update-AzStorageMoverAzSmbFileShareEndpoint -EnableCrossTenantTransfer:$false -AllowedStorageAccount @() -HttpPipelinePrepend $pipeline
        }
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.enableCrossTenantTransfer | Should -Be $false
        $request.PSObject.Properties.Name | Should -Contain "allowedStorageAccounts"
        @($request.allowedStorageAccounts).Count | Should -Be 0
        $capture.Requests[0].Uri.AbsolutePath | Should -Be $identity.Id

        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            Update-AzStorageMoverAzSmbFileShareEndpoint -Name 'smbsharexto' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -Description 'description only' -HttpPipelinePrepend $pipeline
        }
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.description | Should -Be 'description only'
        $request.PSObject.Properties.Name | Should -Not -Contain "enableCrossTenantTransfer"
        $request.PSObject.Properties.Name | Should -Not -Contain "allowedStorageAccounts"
    }
}
