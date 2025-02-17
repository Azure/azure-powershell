$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerGroupReuseFromStandbyPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName
 
Describe 'New-AzContainerGroupReuseFromStandbyPool' {
    It 'Reuses a container group from a standby pool' {
        $container = New-AzContainerInstancenoDefaultObject -Name $env.reusedcontainerInstanceName -ConfigMapKeyValuePair @{"key1"="value1"}
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.reusedContainerGroupName -Container $container -Location $env.location -ContainerGroupProfileId $env.containerGroupProfileId -ContainerGroupProfileRevision $env.containerGroupProfileRevision -StandbyPoolProfileId $env.standbyPoolProfileId
 
        $containerGroup | Should -Not -Be $null
        $containerGroup.Name | Should -Be $env.reusedContainerGroupName
        $containerGroup.Location | Should -Be $env.location
       
        $containerGroup.Container | Should -Not -Be $null
        $containerGroup.Container.Count | Should -Be 1
        $containerGroup.Container[0].Name | Should -Be $env.reusedcontainerInstanceName
        $containerGroup.Container[0].Image | Should -Be $env.image
        $containerGroup.Container[0].RequestCpu | Should -Be 1
        $containerGroup.Container[0].RequestMemoryInGb | Should -Be 1
 
        $containerGroup.OSType | Should -Be $env.osType
        $containerGroup.IsCreatedFromStandbyPool | Should -Be True
    }
}