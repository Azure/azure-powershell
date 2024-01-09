if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterUserEnvironment')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterUserEnvironment.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterUserEnvironment' {
    It 'Delete'  {
        Remove-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name $env.envNameToDelete -ProjectName $env.projectName
        { Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -Name $env.envNameToDelete2  -ProjectName $env.projectName
            { Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete2 } | Should -Throw
        }

    }

    It 'DeleteViaIdentity'  {
        $envInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "EnvironmentName" = $env.envNameToDelete3 }
        $envInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "EnvironmentName" = $env.envNameToDelete4 }

        Remove-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput
        { Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete3 } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName  -InputObject $envInput2
            { Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete4 } | Should -Throw
        }

    }
}
