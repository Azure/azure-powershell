if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminPool' {
    It 'Delete' {
        Remove-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolNameDelete -ProjectName $env.projectName
        { Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolNameDelete -ProjectName $env.projectName } | Should -Throw

    }

    It 'DeleteViaIdentity' {
        $pool = Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolNameDelete2 -ProjectName $env.projectName
        Remove-AzDevCenterAdminPool -InputObject $pool
        { Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolNameDelete2 -ProjectName $env.projectName } | Should -Throw

    }
}
