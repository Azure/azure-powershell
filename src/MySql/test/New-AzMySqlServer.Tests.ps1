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
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            $server = New-AzMySqlServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Location $env.location -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku $env.Sku
            Remove-AzMySqlServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw   
    }
}
