if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminProject')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminProject.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminProject' {
    It 'CreateExpanded' {
        $project = New-AzDevCenterAdminProject -Name $env.projectNew -ResourceGroupName $env.resourceGroup -Location $env.location -DevCenterId $env.devCenterId -MaxDevBoxesPerUser 3
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectNew
        $project.MaxDevBoxesPerUser | Should -Be 3
    }
}
