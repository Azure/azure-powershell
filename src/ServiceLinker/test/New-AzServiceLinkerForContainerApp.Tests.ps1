$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerForContainerApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzServiceLinkerForContainerApp' {

    It 'New storage connection' { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.postgresqId
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject
        $newLinker = New-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo -Scope $env.container
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true
    }
}
