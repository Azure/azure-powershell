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
        { New-AzBlockchainTransactionNodeApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode -KeyName $keyPair[0].KeyName -Value $keyPair[0].Value } | Should -Not -Throw
    }

    It 'RegenerateViaIdentityExpanded' -skip {
        { Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode | New-AzBlockchainTransactionNodeApiKey -KeyName $keyPair[0].KeyName -Value $keyPair[0].Value } | Should -Not -Throw
    }

    BeforeEach {
        $keyPair = Get-AzBlockchainTransactionNodeApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -TransactionNodeName $env.blockchainTransactionNode
    }
}
