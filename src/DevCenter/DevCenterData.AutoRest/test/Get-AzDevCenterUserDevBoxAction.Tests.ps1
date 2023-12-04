if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserDevBoxAction' {
    It 'List'  {
        $listOfActions = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName
        $listOfActions.Count | Should -BeGreaterOrEqual 2

        if ($Record -or $Live) {
            $listOfActions = Get-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
            $listOfActions.Count | Should -BeGreaterOrEqual 2
        }

    }

    It 'Get'  {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -Name "schedule-default"
        
        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"

        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -Name "schedule-default"

            $action.Name | Should -Be "schedule-default"
            $action.ActionType | Should -Be "Stop"
        }
    
    }

    It 'GetViaIdentity'  {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName; "ActionName" = "schedule-default" }

        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -InputObject $devBoxInput

        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"

        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName -InputObject $devBoxInput

            $action.Name | Should -Be "schedule-default"
            $action.ActionType | Should -Be "Stop"
        }
    }
}
