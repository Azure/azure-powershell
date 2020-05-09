$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBlockchainMember.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzBlockchainMember' {
    It 'CreateExpanded' {
        $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
        $csPasswd = 'strongConsortiumManagementPassword@1' | ConvertTo-SecureString -AsPlainText -Force
        $bcMemberName = "myblockchain" + $env.rstr2
        New-AzBlockchainMember -Name $bcMemberName -ResourceGroupName $env.resourceGroup -Consortium ('PowershellConsortiumName' + $env.rstr2) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -Sku S0 
        $bcMember = Get-AzBlockchainMember -Name $bcMemberName -ResourceGroupName $env.resourceGroup
        $bcMember.Name  | Should -Be $bcMemberName
    }
}
