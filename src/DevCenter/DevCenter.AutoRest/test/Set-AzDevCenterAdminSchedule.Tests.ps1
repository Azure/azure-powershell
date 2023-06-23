if (($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminSchedule')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminSchedule.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminSchedule' {
    It 'UpdateExpanded' {
        $schedule = New-AzDevCenterAdminSchedule -PoolName $env.scheduleSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Disabled"
        $schedule.Time | Should -Be "17:30"
        $schedule.TimeZone | Should -Be "America/New_York"
    }

    It 'Update' {
        $body = @{"State" = "Enabled"; "Time" = $env.time; "TimeZone" = $env.timeZone }
        $schedule = New-AzDevCenterAdminSchedule -PoolName $env.scheduleSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Body $body
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Enabled"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles" 
    }
}
