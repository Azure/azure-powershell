if (($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminProject')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminProject.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminProject' {
    It 'UpdateExpanded' {
        $project = Set-AzDevCenterAdminProject -Name $env.projectSet -ResourceGroupName $env.resourceGroup -Location $env.location -DevCenterId $env.devCenterId -MaxDevBoxesPerUser 5
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectSet
        $project.MaxDevBoxesPerUser | Should -Be 5
     }

    It 'Update' {
        $body = @{"DevCenterId" = $env.devCenterId; "Location" = $env.location; "MaxDevBoxesPerUser" = 3 }
        $project = Set-AzDevCenterAdminProject -Name $env.projectSet -ResourceGroupName $env.resourceGroup -Body $body
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectSet
        $project.MaxDevBoxesPerUser | Should -Be 3
     }
}
