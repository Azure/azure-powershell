if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminDevCenter')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminDevCenter.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminDevCenter' {
    It 'CreateExpanded' {
        $devCenter = New-AzDevCenterAdminDevCenter -Name $env.devCenterNew -ResourceGroupName $env.resourceGroup -Location $env.location -UserAssignedIdentity @($env.identityId)
        $devCenter.Name | Should -Be $env.devCenterNew
        $devCenter.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }

}
