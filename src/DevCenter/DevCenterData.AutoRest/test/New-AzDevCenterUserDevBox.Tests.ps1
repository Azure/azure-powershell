if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterUserDevBox' {
    It 'CreateExpanded'  {
        $devBox = New-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name "devbox3" -ProjectName $env.projectName -PoolName $env.poolName
        $devBox.Name | Should -Be "devbox3"
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 32
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $devBox = New-AzDevCenterUserDevBox -DevCenter $env.devCenterName -Name "devbox2" -ProjectName $env.projectName -PoolName $env.poolName
            $devBox.Name | Should -Be "devbox2"
            $devBox.User | Should -Be $env.userObjectId
            $devBox.ProjectName | Should -Be $env.projectName
            $devBox.poolName | Should -Be $env.poolName
            $devBox.OSType | Should -Be "Windows"
            $devBox.OSDiskSizeGb | Should -Be "1024"
            $devBox.Location | Should -Be $env.location
            $devBox.LocalAdministrator | Should -Be "Enabled"
            $devBox.ImageReferenceVersion | Should -Be "1.0.0"
            $devBox.HibernateSupport | Should -Be "Enabled"
            $devBox.ImageReferenceName | Should -Be $env.imageName
            $devBox.HardwareProfileVCpUs | Should -Be 8
            $devBox.HardwareProfileMemoryGb | Should -Be 32
            $devBox.HardwareProfileSkuName | Should -Be $env.skuName
            $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
            $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
            $devBox.ProvisioningState | Should -Be "Succeeded"
            $devBox.PowerState | Should -Be "Running"
        }
    }

    It 'CreateViaIdentityExpanded'  {
        $devBoxInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox5" }
        $devBoxInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox6" }

        $devBox = New-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput -PoolName $env.poolName
        $devBox.Name | Should -Be "devbox5"
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 32
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $devBox = New-AzDevCenterUserDevBox -DevCenter $env.devCenterName -InputObject  $devBoxInput2 -PoolName $env.poolName
            $devBox.Name | Should -Be "devbox6"
            $devBox.User | Should -Be $env.userObjectId
            $devBox.ProjectName | Should -Be $env.projectName
            $devBox.poolName | Should -Be $env.poolName
            $devBox.OSType | Should -Be "Windows"
            $devBox.OSDiskSizeGb | Should -Be "1024"
            $devBox.Location | Should -Be $env.location
            $devBox.LocalAdministrator | Should -Be "Enabled"
            $devBox.ImageReferenceVersion | Should -Be "1.0.0"
            $devBox.HibernateSupport | Should -Be "Enabled"
            $devBox.ImageReferenceName | Should -Be $env.imageName
            $devBox.HardwareProfileVCpUs | Should -Be 8
            $devBox.HardwareProfileMemoryGb | Should -Be 32
            $devBox.HardwareProfileSkuName | Should -Be $env.skuName
            $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
            $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
            $devBox.ProvisioningState | Should -Be "Succeeded"
            $devBox.PowerState | Should -Be "Running"
        }

    }

}
