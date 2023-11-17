if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminSchedule')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminSchedule.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminSchedule' {
    It 'Delete' {
        Remove-AzDevCenterAdminSchedule -PoolName $env.poolForScheduleDelete -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminSchedule -PoolName $env.poolForScheduleDelete -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup } | Should -Throw

    }

    It 'DeleteViaIdentity' {
        $schedule = Get-AzDevCenterAdminSchedule -PoolName $env.poolForScheduleDelete2 -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        Remove-AzDevCenterAdminSchedule -InputObject $schedule
        { Get-AzDevCenterAdminSchedule -PoolName $env.poolForScheduleDelete2 -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup } | Should -Throw
    }
}
