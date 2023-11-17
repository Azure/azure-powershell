if (($null -eq $TestName) -or ($TestName -contains 'Stop-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzDevCenterUserDevBox' {
    It 'Stop'  {
        $stopAction = Stop-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.skipDevBox1 -ProjectName $env.projectName
        $stopAction.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.skipDevBox1 -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"

        if ($Record -or $Live) {
            $stopAction = Stop-AzDevCenterUserDevBox -DevCenter $env.devCenterName -Name $env.skipDevBox2 -ProjectName $env.projectName  
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.skipDevBox2 -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Stopped"
            $devBox.PowerState | Should -Be "Hibernated"
        }
   
    }

    It 'StopViaIdentity'  {
        $devBoxInput1 = @{"DevBoxName" = $env.skipDevBox3; "UserId" = "me"; "ProjectName" = $env.projectName }
        $devBoxInput2 = @{"DevBoxName" = $env.skipDevBox4; "UserId" = "me"; "ProjectName" = $env.projectName }

        $stopAction = Stop-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput1
        $stopAction.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.skipDevBox3 -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"

        if ($Record -or $Live) {
            $stopAction = Stop-AzDevCenterUserDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput2 
            $stopAction.Status | Should -Be "Succeeded"
            $devBox = Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.skipDevBox4 -ProjectName $env.projectName -UserId "me"
            $devBox.ActionState | Should -Be "Stopped"
            $devBox.PowerState | Should -Be "Hibernated"
        }
 
    }
}
