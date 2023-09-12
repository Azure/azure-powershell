if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserSchedule')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserSchedule.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserSchedule' {
    It 'Get'  {
        $schedule = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -PoolName $env.poolName -ProjectName $env.projectName
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
        $schedule.Type | Should -Be "StopDevBox"

        if ($Record -or $Live) {
            $schedule = Get-AzDevCenterUserSchedule -DevCenter $env.devCenterName -PoolName $env.poolName -ProjectName $env.projectName
            $schedule.Frequency | Should -Be "Daily"
            $schedule.Name | Should -Be "default"
            $schedule.Time | Should -Be "18:30"
            $schedule.TimeZone | Should -Be "America/Los_Angeles"
            $schedule.Type | Should -Be "StopDevBox"
        }
    }

    It 'GetViaIdentity'  {
        $scheduleInput = @{"ProjectName" = $env.projectName; "PoolName" = $env.poolName }
        
        $schedule = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -InputObject $scheduleInput
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
        $schedule.Type | Should -Be "StopDevBox"

        if ($Record -or $Live) {
            $schedule = Get-AzDevCenterUserSchedule -DevCenter $env.devCenterName -InputObject $scheduleInput
            $schedule.Frequency | Should -Be "Daily"
            $schedule.Name | Should -Be "default"
            $schedule.Time | Should -Be "18:30"
            $schedule.TimeZone | Should -Be "America/Los_Angeles"
            $schedule.Type | Should -Be "StopDevBox"
        }
    }
}
