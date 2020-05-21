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
    It 'Delete' {
        $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
        $tNodeName = "tranctionnode" + $env.rstr3
        New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $tNodeName -ResourceGroupName $env.resourceGroup -Location eastus -Password $passwd
        Remove-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $tNodeName -ResourceGroupName $env.resourceGroup 
        $tNodeList = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup 
        $tNodeList.Name | Should -Not -Contain $tNodeName
    }

    It 'DeleteViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $tNodeName = "tranctionnode" + $env.rstr4
        $node = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $tNodeName -ResourceGroupName $env.resourceGroup 
        Remove-AzBlockchainTransactionNode -InputObject $node
        $tNodeList = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup 
        $tNodeList.Name | Should -Not -Contain $tNodeName
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
