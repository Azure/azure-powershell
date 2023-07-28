if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterUserDevBox' {
    It 'Delete' -skip {
        Remove-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name "devbox3" -ProjectName $env.projectName
        { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox3" } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserDevBox -DevCenter $env.devCenterName -Name "devbox2" -ProjectName $env.projectName
            { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox2" } | Should -Throw
        }

    }

    It 'DeleteViaIdentity' -skip {
        $devBoxInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox5" }
        $devBoxInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox6" }

        Remove-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput 
        { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox5" } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput2
            { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox6" } | Should -Throw
        }
    }
}
