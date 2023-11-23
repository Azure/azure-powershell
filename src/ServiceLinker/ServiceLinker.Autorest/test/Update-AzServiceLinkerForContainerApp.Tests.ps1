$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerForContainerApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzServiceLinkerForContainerApp' {
    It 'UpdateExpanded' {
        $linker = Get-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp -Name $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp -LinkerName $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -Scope $linker.Scope -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }
}
