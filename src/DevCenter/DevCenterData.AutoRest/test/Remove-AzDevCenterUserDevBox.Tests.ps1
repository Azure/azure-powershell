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
    It 'Delete'  {
        Remove-AzDevCenterUserDevBox -Endpoint $env.endpoint -Name $env.deleteDevBox1 -ProjectName $env.projectName
        { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.deleteDevBox1 } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserDevBox -DevCenterName $env.devCenterName -Name $env.deleteDevBox2 -ProjectName $env.projectName
            { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.deleteDevBox2 } | Should -Throw
        }

    }

    It 'DeleteViaIdentity'  {
        $devBoxInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = $env.deleteDevBox3 }
        $devBoxInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = $env.deleteDevBox4 }

        Remove-AzDevCenterUserDevBox -Endpoint $env.endpoint -InputObject $devBoxInput 
        { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.deleteDevBox3 } | Should -Throw

        if ($Record -or $Live) {
            Remove-AzDevCenterUserDevBox -DevCenterName $env.devCenterName -InputObject $devBoxInput2
            { Get-AzDevCenterUserDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.deleteDevBox4 } | Should -Throw
        }
    }
}
