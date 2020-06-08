$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedKubernetes.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzConnectedKubernetes' {
    It 'CreateExpanded' {
        $kubeContext = 'portal-aks-t01'
        New-AzConnectedKubernetes -ClusterName $env.connaksName02 -ResourceGroupName $env.resourceGroup -Location $env.location -KubeConfig $HOME\.kube\config -KubeContext $kubeContext
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02
        $connaks.ProvisioningState | Should -Be 'Succeeded'
    }
}
