if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserPool' {
    It 'List'  {
        $listOfPools = Get-AzDevCenterUserPool -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfPools.Count | Should -Be 1

        if ($Record -or $Live) {
            $listOfPools = Get-AzDevCenterUserPool -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $listOfPools.Count | Should -Be 1
        }

    }

    It 'Get'  {
        $pool = Get-AzDevCenterUserPool -Endpoint $env.endpoint -ProjectName $env.projectName -PoolName $env.poolName
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

        if ($Record -or $Live) {
            $pool = Get-AzDevCenterUserPool -DevCenterName $env.devCenterName -ProjectName $env.projectName -PoolName $env.poolName
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

    It 'GetViaIdentity'  {
        $poolInput = @{"ProjectName" = $env.projectName; "PoolName" = $env.poolName }
        $pool = Get-AzDevCenterUserPool -Endpoint $env.endpoint -InputObject $poolInput
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

        if ($Record -or $Live) {
            $pool = Get-AzDevCenterUserPool -DevCenterName $env.devCenterName -InputObject $poolInput
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
}
