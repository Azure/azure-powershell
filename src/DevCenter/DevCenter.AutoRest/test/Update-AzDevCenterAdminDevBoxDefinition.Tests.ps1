if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminDevBoxDefinition')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminDevBoxDefinition.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminDevBoxDefinition' {
    It 'UpdateExpanded' {
        $vsImage = "microsoftvisualstudio_visualstudioplustools_vs-2022-pro-general-win10-m365-gen2"
        $vsImageReferenceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $env.devCenterName + "/galleries/Default/images/" + $vsImage

        $devBoxDefinition = Update-AzDevCenterAdminDevBoxDefinition -Name $env.devBoxDefinitionUpdate -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup -HibernateSupport "Disabled" -ImageReferenceId $vsImageReferenceId
        $devBoxDefinition.Name | Should -Be $env.devBoxDefinitionUpdate
        $devBoxDefinition.ImageReferenceId | Should -Be $vsImageReferenceId
        $devBoxDefinition.OSStorageType | Should -Be $env.osStorageType
        $devBoxDefinition.SkuName | Should -Be $env.skuName
        $devBoxDefinition.ImageReferenceExactVersion | Should -Be "1.0.0"
        $devBoxDefinition.HibernateSupport | Should -Be "Disabled"
    }

    It 'UpdateViaIdentityExpanded' {
        $id = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $env.devCenterName + "/devboxdefinitions/" + $env.devBoxDefinitionUpdate
        $devBoxDefinitionId = @{"Id" = $id }

        $vsImage = "microsoftvisualstudio_visualstudioplustools_vs-2022-pro-general-win10-m365-gen2"
        $vsImageReferenceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $env.devCenterName + "/galleries/Default/images/" + $vsImage

        $devBoxDefinition = Update-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinitionId -HibernateSupport "Disabled" -ImageReferenceId $vsImageReferenceId
        $devBoxDefinition.Name | Should -Be $env.devBoxDefinitionUpdate
        $devBoxDefinition.ImageReferenceId | Should -Be $vsImageReferenceId
        $devBoxDefinition.OSStorageType | Should -Be $env.osStorageType
        $devBoxDefinition.SkuName | Should -Be $env.skuName
        $devBoxDefinition.ImageReferenceExactVersion | Should -Be "1.0.0"
        $devBoxDefinition.HibernateSupport | Should -Be "Disabled"
    }

}
