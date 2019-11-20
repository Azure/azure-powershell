$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBlockchainTransactionNode.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzBlockchainTransactionNode' {
    It 'List' {
        { Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $env.blockchainTransactionNode } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        { Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $env.blockchainTransactionNode | Get-AzBlockchainTransactionNode } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
