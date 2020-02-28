$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMySqlServer' {
    It 'CreateExpanded' {
        {
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            New-AzMySqlServer -Name "leijin-mysql-server" -ResourceGroupName $env.resourceGroup -Location eastus -AdministratorLogin mysql_test -AdministratorLoginPassword $password -SkuName GP_Gen5_4 -Subscription 0b1f6471-1bf0-4dda-aec3-cb9272f09590
        } | Should -Not -Throw
    }
}
