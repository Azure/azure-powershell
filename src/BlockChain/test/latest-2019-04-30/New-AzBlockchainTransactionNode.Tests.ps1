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
        { New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name ("myblockchain" + $env.rstr2) -ResourceGroupName $env.resourceGroup -Password $passwd -Location eastus } | Should -Not -Throw
    }
}
