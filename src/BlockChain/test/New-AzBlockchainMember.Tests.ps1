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
        { New-AzBlockchainMember -Name ("myblockchain" + $env.rstr2) -ResourceGroupName $env.resourceGroup -Consortium ('PowershellConsortiumName' + $env.rstr2) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -SkuName S0 } | Should -Not -Throw
    }
}
