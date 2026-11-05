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

    It 'UpdateExpandedCrossTenantRequest' {
        # The service does not accept cross-tenant settings on Azure SMB file share endpoints yet, so this checks the request offline.
        Mock -CommandName Update-AzStorageMoverEndpoint -ModuleName Az.StorageMover.custom -MockWith { [pscustomobject]@{ Property = $Property; InputObject = $InputObject } }
        $endpoint = Update-AzStorageMoverAzSmbFileShareEndpoint -Name "smbsharexto" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId, $env.CrossTenantStorageAccountId
        $request = $endpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.enableCrossTenantTransfer | Should -Be $true
        @($request.allowedStorageAccounts).Count | Should -Be 2

        $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.StorageMoverIdentity]::New()
        $identity.Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.StorageMover/storageMovers/$($env.EndpointStoMoverName)/endpoints/smbsharexto"
        $endpoint = $identity | Update-AzStorageMoverAzSmbFileShareEndpoint -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
        $request = $endpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.enableCrossTenantTransfer | Should -Be $false
        $request.PSObject.Properties.Name | Should -Contain "allowedStorageAccounts"
        @($request.allowedStorageAccounts).Count | Should -Be 0
        $endpoint.InputObject.Id | Should -Be $identity.Id

        $endpoint = Update-AzStorageMoverAzSmbFileShareEndpoint -Name "smbsharexto" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -Description "description only"
        $request = $endpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.PSObject.Properties.Name | Should -Not -Contain "enableCrossTenantTransfer"
        $request.PSObject.Properties.Name | Should -Not -Contain "allowedStorageAccounts"
    }
}
