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
    It 'CreateExpanded' -skip {
        $identityHashTable = @{$env.identityId = @{} }
        $devCenter = New-AzDevCenterAdminDevCenter -Name $env.devCenterNew -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType "UserAssigned" -IdentityUserAssignedIdentity $identityHashTable
        $devCenter.Name | Should -Be $env.devCenterNew
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }

    It 'Create' -skip {
        $identityHashTable = @{$env.identityId = @{} }
        $body = @{"Location" = $env.location; "IdentityType" = "UserAssigned"; "IdentityUserAssignedIdentity" = $identityHashTable }

        $devCenter = New-AzDevCenterAdminDevCenter -Name $env.devCenterNew2 -ResourceGroupName $env.resourceGroup -Body $body
        $devCenter.Name | Should -Be $env.devCenterNew2
        $devCenter.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }

}
