if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminDevBoxDefinition')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminDevBoxDefinition.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminDevBoxDefinition' {
    It 'Delete' {
        Remove-AzDevCenterAdminDevBoxDefinition -DevCenterName $env.devCenterName -Name $env.devBoxDefinitionNameDelete -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.devBoxDefinitionNameDelete } | Should -Throw

    }

    It 'DeleteViaIdentity' {
        $id = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $env.devCenterName + "/devboxdefinitions/" + $env.devBoxDefinitionNameDelete2
        $devBoxDefinitionId = @{"Id" = $id }

        Remove-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinitionId 
        { Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.devBoxDefinitionNameDelete2 } | Should -Throw

    }
}
