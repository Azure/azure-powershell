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
    It 'ListByProject'  {
        $listofSchedules = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -ProjectName $env.projectName
        $listofSchedules.Count | Should -Be 1

        if ($Record -or $Live) {
            $listofSchedules = Get-AzDevCenterUserSchedule -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $listofSchedules.Count | Should -Be 1

        }
    }

    It 'ListByPool'  {
        $listofSchedules = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -PoolName $env.poolName -ProjectName $env.projectName
        $listofSchedules.Count | Should -Be 1

        if ($Record -or $Live) {
            $listofSchedules = Get-AzDevCenterUserSchedule -DevCenterName $env.devCenterName -PoolName $env.poolName -ProjectName $env.projectName
            $listofSchedules.Count | Should -Be 1
        }
    }

    It 'Get'  {
        $schedule = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -PoolName $env.poolName -ProjectName $env.projectName -ScheduleName "default"
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.Time | Should -Be "19:00"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
        $schedule.Type | Should -Be "StopDevBox"

        if ($Record -or $Live) {
            $schedule = Get-AzDevCenterUserSchedule -DevCenterName $env.devCenterName -PoolName $env.poolName -ProjectName $env.projectName -ScheduleName "default"
            $schedule.Frequency | Should -Be "Daily"
            $schedule.Name | Should -Be "default"
            $schedule.Time | Should -Be "19:00"
            $schedule.TimeZone | Should -Be "America/Los_Angeles"
            $schedule.Type | Should -Be "StopDevBox"
        }
    }

    It 'GetViaIdentity'  {
        $scheduleInput = @{"ProjectName" = $env.projectName; "PoolName" = $env.poolName; "ScheduleName" = "default" }
        
        $schedule = Get-AzDevCenterUserSchedule -Endpoint $env.endpoint -InputObject $scheduleInput
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.Time | Should -Be "19:00"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
        $schedule.Type | Should -Be "StopDevBox"

        if ($Record -or $Live) {
            $schedule = Get-AzDevCenterUserSchedule -DevCenterName $env.devCenterName -InputObject $scheduleInput
            $schedule.Frequency | Should -Be "Daily"
            $schedule.Name | Should -Be "default"
            $schedule.Time | Should -Be "19:00"
            $schedule.TimeZone | Should -Be "America/Los_Angeles"
            $schedule.Type | Should -Be "StopDevBox"
        }
    }
}
