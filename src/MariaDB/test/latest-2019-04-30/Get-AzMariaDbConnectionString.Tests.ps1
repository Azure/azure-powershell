$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location

Describe 'Get-AzMariaDbConnectionString' {
    It 'ServerName' {
        $client = 'ADO.NET'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $rstr01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Not -BeNullOrEmpty
    }
    It 'ServerObject' {
        $client = 'JDBC'
        $mariadb = Get-AzMariaDbServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Not -BeNullOrEmpty
    }   
}
