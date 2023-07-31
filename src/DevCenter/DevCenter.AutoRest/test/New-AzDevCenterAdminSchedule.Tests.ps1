if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminSchedule')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminSchedule.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminSchedule' {
    It 'CreateExpanded' {
        $schedule = New-AzDevCenterAdminSchedule -PoolName $env.poolForScheduleNew -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -State "Enabled" -Time $env.time -TimeZone $env.timeZone
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Enabled"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
    }
}
