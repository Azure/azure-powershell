if (($null -eq $TestName) -or ($TestName -contains 'Restart-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzDevCenterUserDevBox' {
    It 'Restart'  {
        $restartOperation = Restart-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName
        $restartOperation.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Started"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $restartOperation = Restart-AzDevCenterUserDevBox -DevCenter $env.devCenterName -Name $env.devBoxName -ProjectName $env.projectName
            $restartOperation.Status | Should -Be "Succeeded"
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Started"
            $devBox.PowerState | Should -Be "Running"
        }
    }

    It 'RestartViaIdentity'  {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName }

        $restartOperation = Restart-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput
        $restartOperation.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Started"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $restartOperation = Restart-AzDevCenterUserDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput
            $restartOperation.Status | Should -Be "Succeeded"
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Started"
            $devBox.PowerState | Should -Be "Running"
        }
    }
}
