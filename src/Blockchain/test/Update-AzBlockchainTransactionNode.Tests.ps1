$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzBlockchainTransactionNode.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzBlockchainTransactionNode' {
    $passwd2 = 'strongMemberAccountPassword@2' | ConvertTo-SecureString -AsPlainText -Force
    $passwd3 = 'strongMemberAccountPassword@3' | ConvertTo-SecureString -AsPlainText -Force
    It 'UpdateExpanded' {
        { Update-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $env.blockchainTransactionNode -ResourceGroupName $env.resourceGroup -Password $passwd2 } | Should -Not -Throw

    }

    It 'UpdateViaIdentityExpanded' {
        #$PSDefaultParameterValues["Disabled"] = $True
        {
            $tNode = Get-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -Name $env.blockchainTransactionNode 
            Update-AzBlockchainTransactionNode -InputObject $tNode -Password $passwd3
        } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
