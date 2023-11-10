if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminProjectEnvironmentType')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminProjectEnvironmentType.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminProjectEnvironmentType' {
    It 'Delete' {
        Remove-AzDevCenterAdminProjectEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.projEnvironmentTypeNameDelete
        { Get-AzDevCenterAdminProjectEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.projEnvironmentTypeNameDelete } | Should -Throw

    }

    It 'DeleteViaIdentity' {
        $projEnvType = Get-AzDevCenterAdminProjectEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.projEnvironmentTypeNameDelete2
        Remove-AzDevCenterAdminProjectEnvironmentType -InputObject $projEnvType
        { Get-AzDevCenterAdminProjectEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.projEnvironmentTypeNameDelete2 } | Should -Throw

    }
}
