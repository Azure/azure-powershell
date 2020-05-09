$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBlockchainTransactionNodeApiKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzBlockchainTransactionNodeApiKey' {
    $keyPair = {}

    It 'RegenerateExpanded' {
        $keys = New-AzBlockchainTransactionNodeApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode -KeyName $keyPair[0].KeyName
        $keys[0].Value | Should -Not -Be $keyPair[0].Value
    }

    It 'RegenerateViaIdentityExpanded' {
        $tNode = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode 
        $keys = New-AzBlockchainTransactionNodeApiKey -InputObject $tnode -KeyName $keyPair[0].KeyName
        $keys[0].Value | Should -Not -Be $keyPair[0].Value
    }

    BeforeEach {
        $keyPair = Get-AzBlockchainTransactionNodeApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode
    }
}
