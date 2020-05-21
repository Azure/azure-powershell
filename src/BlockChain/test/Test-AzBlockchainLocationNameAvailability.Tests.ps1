$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzBlockchainLocationNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzBlockchainLocationNameAvailability' {
    It 'CheckExpanded' {
        $result = Test-AzBlockchainLocationNameAvailability -Location eastus -Name '123' -Type Microsoft.Blockchain/blockchainMembers
        $result.NameAvailable| Should -Be $False
        
        $result = Test-AzBlockchainLocationNameAvailability -Location eastus -Name 'lucasblockchain01' -Type Microsoft.Blockchain/blockchainMembers
        $result.NameAvailable| Should -Be $True
    }
}
