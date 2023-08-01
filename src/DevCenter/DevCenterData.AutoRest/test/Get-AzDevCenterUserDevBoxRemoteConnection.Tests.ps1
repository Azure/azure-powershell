if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserDevBoxRemoteConnection')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserDevBoxRemoteConnection.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserDevBoxRemoteConnection' {
    It 'Get'  {
        $connection = Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName

        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty

        if ($Record -or $Live) {
            $connection = Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
            $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
            $connection.WebUrl | Should -Not -BeNullOrEmpty
        }

    }

    It 'GetViaIdentity'  {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName; }

        $connection = Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint $env.endpoint -InputObject $devBoxInput
        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty

        if ($Record -or $Live) {
            $connection = Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter $env.devCenterName -InputObject $devBoxInput
            $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
            $connection.WebUrl | Should -Not -BeNullOrEmpty
        }
    }
}
