$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBlockchainTransactionNodeApiKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzBlockchainTransactionNodeApiKey' {
    It 'List' {
        { Get-AzBlockchainTransactionNodeApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode } | Should -Not -Throw
    }
}
