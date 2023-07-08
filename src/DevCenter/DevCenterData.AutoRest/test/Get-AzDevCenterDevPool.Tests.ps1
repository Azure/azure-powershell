if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevPool' {
    It 'List' -skip {
        $listOfPools = Get-AzDevCenterDevPool -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfPools.Count | Should -Be 2

        $listOfPools = Get-AzDevCenterDevPool -DevCenter $env.devCenterName -ProjectName $env.projectName
        $listOfPools.Count | Should -Be 2

    }

    It 'Get' -skip {
        $pool = Get-AzDevCenterDevPool -Endpoint $env.endpoint -ProjectName $env.projectName -PoolName $env.poolName
        $pool.HardwareProfileMemoryGb | Should -Be 32
        $pool.HardwareProfileSkuName | Should -Be $env.skuName
        $pool.HardwareProfileVCpUs | Should -Be 8
        $pool.HibernateSupport | Should -Be "Enabled"
        $pool.ImageReferenceName | Should -Be $env.imageName
        $pool.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $pool.ImageReferenceVersion | Should -Be "1.0.0"
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.Location | Should -Be $env.location
        $pool.Name | Should -Be $env.poolName
        $pool.OSDiskSizeGb | Should -Be "1024"
        $pool.OSType | Should -Be "Windows"
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"

        $pool = Get-AzDevCenterDevPool -DevCenter $env.devCenterName -ProjectName $env.projectName -PoolName $env.
        $pool.HardwareProfileMemoryGb | Should -Be 32
        $pool.HardwareProfileSkuName | Should -Be $env.skuName
        $pool.HardwareProfileVCpUs | Should -Be 8
        $pool.HibernateSupport | Should -Be "Enabled"
        $pool.ImageReferenceName | Should -Be $env.imageName
        $pool.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $pool.ImageReferenceVersion | Should -Be "1.0.0"
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.Location | Should -Be $env.location
        $pool.Name | Should -Be $env.poolName
        $pool.OSDiskSizeGb | Should -Be "1024"
        $pool.OSType | Should -Be "Windows"
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"

    
    }

    It 'GetViaIdentity' -skip {
        $poolInput = @{"ProjectName" = $env.projectName; "PoolName" = $env.poolName}
        $pool = Get-AzDevCenterDevPool -Endpoint $env.endpoint -InputObject $poolInput
        $pool.HardwareProfileMemoryGb | Should -Be 32
        $pool.HardwareProfileSkuName | Should -Be $env.skuName
        $pool.HardwareProfileVCpUs | Should -Be 8
        $pool.HibernateSupport | Should -Be "Enabled"
        $pool.ImageReferenceName | Should -Be $env.imageName
        $pool.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $pool.ImageReferenceVersion | Should -Be "1.0.0"
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.Location | Should -Be $env.location
        $pool.Name | Should -Be $env.poolName
        $pool.OSDiskSizeGb | Should -Be "1024"
        $pool.OSType | Should -Be "Windows"
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"

        $pool = Get-AzDevCenterDevPool -DevCenter $env.devCenterName -InputObject $poolInput
        $pool.HardwareProfileMemoryGb | Should -Be 32
        $pool.HardwareProfileSkuName | Should -Be $env.skuName
        $pool.HardwareProfileVCpUs | Should -Be 8
        $pool.HibernateSupport | Should -Be "Enabled"
        $pool.ImageReferenceName | Should -Be $env.imageName
        $pool.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $pool.ImageReferenceVersion | Should -Be "1.0.0"
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.Location | Should -Be $env.location
        $pool.Name | Should -Be $env.poolName
        $pool.OSDiskSizeGb | Should -Be "1024"
        $pool.OSType | Should -Be "Windows"
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"
    }
}
