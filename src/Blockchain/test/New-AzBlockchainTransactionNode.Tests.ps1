$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBlockchainTransactionNode.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzBlockchainTransactionNode' {
    It 'CreateExpanded' {
        $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
        $tNodeName = "myblockchain" + $env.rstr2
        New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $tNodeName -ResourceGroupName $env.resourceGroup -Password $passwd -Location eastus 
        $tNode = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $tNodeName
        $tNode.Name | Should -Be $tNodeName
    }
}
