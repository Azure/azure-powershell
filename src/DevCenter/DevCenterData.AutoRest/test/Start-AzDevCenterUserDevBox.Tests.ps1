if (($null -eq $TestName) -or ($TestName -contains 'Start-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzDevCenterUserDevBox' {
    It 'Start'  {
        $startOperation = Start-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devboxName3 -ProjectName $env.projectName
        $startOperation.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devboxName3 -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Started"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $startOperation = Start-AzDevCenterUserDevBox -DevCenter $env.devCenterName -Name $env.devboxName3 -ProjectName $env.projectName 
            $startOperation.Status | Should -Be "Succeeded"
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devboxName3 -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Started"
            $devBox.PowerState | Should -Be "Running"
        }


    }

    It 'StartViaIdentity'  {
        $devBoxInput = @{"DevBoxName" = $env.devboxName3; "UserId" = "me"; "ProjectName" = $env.projectName }

        $startOperation = Start-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput
        $startOperation.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devboxName3 -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Started"
        $devBox.PowerState | Should -Be "Running"

        if ($Record -or $Live) {
            $startOperation = Start-AzDevCenterUserDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput
            $startOperation.Status | Should -Be "Succeeded"
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.devboxName3 -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Started"
            $devBox.PowerState | Should -Be "Running"
        }

    }
}
