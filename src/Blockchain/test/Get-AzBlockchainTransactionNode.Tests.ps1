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
        $tNodes = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup 
        $tNodes.Count | Should -Be 2
    }

    It 'Get' {
        $tNode = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $env.blockchainTransactionNode
        $tNode.Name | Should -Be $env.blockchainTransactionNode
    }

    It 'GetViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $tNode = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $env.blockchainTransactionNode 
        $tNode = Get-AzBlockchainTransactionNode -InputObject $tNode
        $tNode.Name | Should -Be $env.blockchainTransactionNode
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
