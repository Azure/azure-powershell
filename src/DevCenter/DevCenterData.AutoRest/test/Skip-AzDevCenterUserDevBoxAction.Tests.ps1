if (($null -eq $TestName) -or ($TestName -contains 'Skip-AzDevCenterUserDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Skip-AzDevCenterUserDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Skip-AzDevCenterUserDevBoxAction' {
    It 'Skip'  {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox1 -ProjectName $env.projectName -Name "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan

        Skip-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox1 -ProjectName $env.projectName -Name "schedule-default"
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox1 -ProjectName $env.projectName -Name "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime

        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox4 -ProjectName $env.projectName -Name "schedule-default"
            $skipTimeSpan = New-TimeSpan -Days 1
            $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan

            Skip-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.skipDevBox4 -ProjectName $env.projectName -Name "schedule-default"
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox4 -ProjectName $env.projectName -Name "schedule-default"
            $action.NextScheduledTime | Should -Be $newScheduledTime
        }

    }

    It 'SkipViaIdentity'  {
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.skipDevBox2; "ActionName" = "schedule-default"; "UserId" = "me" }
        $actionInput2 = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.skipDevBox3; "ActionName" = "schedule-default"; "UserId" = "me"}

        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox2 -ProjectName $env.projectName -Name "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan
        Skip-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -InputObject $actionInput
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox2 -ProjectName $env.projectName -Name "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime
    
        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox3 -ProjectName $env.projectName -Name "schedule-default"
            $skipTimeSpan = New-TimeSpan -Days 1
            $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan
            Skip-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName  -InputObject $actionInput2
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.skipDevBox3 -ProjectName $env.projectName -Name "schedule-default"
            $action.NextScheduledTime | Should -Be $newScheduledTime
        }
    }
}
