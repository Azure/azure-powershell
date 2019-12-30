$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzBlockchainTransactionNode.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzBlockchainTransactionNode' {
    $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
    It 'Delete' {
        New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name ("tranctionnode" + $env.rstr3) -ResourceGroupName $env.resourceGroup -Location eastus -Password $passwd
        { Remove-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name ("tranctionnode" + $env.rstr3) -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        { Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name ("tranctionnode" + $env.rstr4) -ResourceGroupName $env.resourceGroup | Remove-AzBlockchainTransactionNode } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
