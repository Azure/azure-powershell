if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserProject')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserProject.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserProject' {
    It 'List'  {
        $listOfProjects = Get-AzDevCenterUserProject -Endpoint $env.endpoint
        $listOfProjects.Count | Should -Be 2

        if ($Record -or $Live) {
            $listOfProjects = Get-AzDevCenterUserProject -DevCenterName $env.devCenterName
            $listOfProjects.Count | Should -Be 2
        }

    }

    It 'Get'  {
        $project = Get-AzDevCenterUserProject -Endpoint $env.endpoint -ProjectName $env.projectName
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 20

        if ($Record -or $Live) {
            $project = Get-AzDevCenterUserProject -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $project.Name | Should -Be $env.projectName
            $project.MaxDevBoxesPerUser | Should -Be 20
        }
    }

    It 'GetViaIdentity'  {
        $poolInput = @{"ProjectName" = $env.projectName }
        $project = Get-AzDevCenterUserProject -Endpoint $env.endpoint -InputObject $poolInput
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 20

        if ($Record -or $Live) {
            $project = Get-AzDevCenterUserProject -DevCenterName $env.devCenterName -InputObject $poolInput
            $project.Name | Should -Be $env.projectName
            $project.MaxDevBoxesPerUser | Should -Be 20
        }
    }
}
