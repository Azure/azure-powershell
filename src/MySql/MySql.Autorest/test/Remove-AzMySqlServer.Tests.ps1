$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMySqlServer' {
    It 'Delete' {
        {
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            New-AzMySqlServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Location $env.location -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku $env.Sku
            Remove-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
            New-AzMySqlServer -Name mysqldelete -ResourceGroupName $env.resourceGroup -Location $env.location -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku $env.Sku
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/servers/mysqldelete"
            Remove-AzMySqlServer -InputObject $ID
        } | Should -Not -Throw
    }
}
