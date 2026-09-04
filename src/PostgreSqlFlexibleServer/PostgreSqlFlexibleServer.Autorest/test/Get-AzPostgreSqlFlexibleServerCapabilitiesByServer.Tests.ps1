if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerCapabilitiesByServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerCapabilitiesByServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerCapabilitiesByServer' {
    BeforeAll {
        function Get-ExpectedStorageEditionName {
            param(
                [Parameter(Mandatory = $true)]
                [string]$StorageType
            )

            switch ($StorageType.ToLowerInvariant()) {
                'premium_lrs' { return 'ManagedDisk' }
                'premiumv2_lrs' { return 'ManagedDiskV2' }
                'ultradisk' { return 'UltraDisk' }
                default { return $StorageType }
            }
        }

        $targetResourceGroupName = $env.ResourceGroupName4
        $targetServerName = $env.ServerName4

        if (-not $targetResourceGroupName -or -not $targetServerName) {
            throw 'Target resource group and server name from utils.ps1 environment are required for capabilities validation.'
        }

        $targetServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $targetResourceGroupName -Name $targetServerName
        $capabilities = Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName $targetResourceGroupName -ServerName $targetServerName
    }

    It 'ValidateAssignedTierSkuStorageAndVersionAgainstSupportedCapabilities' {
        $targetServer | Should -Not -BeNullOrEmpty
        $capabilities | Should -Not -BeNullOrEmpty

        $assignedTier = $targetServer.SkuTier
        $assignedSkuName = $targetServer.SkuName
        $assignedStorageType = $targetServer.StorageType
        $expectedStorageEdition = Get-ExpectedStorageEditionName -StorageType $assignedStorageType
        $assignedVersion = [string]$targetServer.Version

        $tierCapability = @($capabilities.SupportedServerEdition | Where-Object { $_.Name -eq $assignedTier }) | Select-Object -First 1
        $tierCapability | Should -Not -BeNullOrEmpty

        $supportedSkuNames = @($tierCapability.SupportedServerSku | ForEach-Object { $_.Name })
        $supportedSkuNames | Should -Contain $assignedSkuName

        $supportedStorageEditions = @($tierCapability.SupportedStorageEdition | ForEach-Object { $_.Name })
        $supportedStorageEditions | Should -Contain $expectedStorageEdition

        $supportedVersions = @($capabilities.SupportedServerVersion | ForEach-Object { [string]$_.Name })
        $supportedVersions | Should -Contain $assignedVersion
    }
}
