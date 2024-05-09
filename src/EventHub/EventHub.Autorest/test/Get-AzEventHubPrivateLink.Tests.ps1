$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubPrivateLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzEventHubPrivateLink' {
    It 'Get'  {
        $namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace
        $privateLink = Get-AzEventHubPrivateLink -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        $privateLink.Name | Should -Be "namespace"
        $privateLink.GroupId | Should -Be "namespace"
        $privateLink.RequiredMember[0] | Should -Be "namespace"
        $privateLink.RequiredZoneName[0] | Should -Be $([System.Uri]$namespace.ServiceBusEndpoint).Host.ToLower().Replace($env.namespace.ToLower(), 'privatelink')
    }
}
