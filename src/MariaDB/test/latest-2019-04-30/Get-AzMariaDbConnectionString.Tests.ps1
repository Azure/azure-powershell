$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbConnectionString' {
    It 'ServerName' -Skip {
        $client = 'ADO.NET'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $conStr | Should -Not -BeNullOrEmpty
    }
    It 'ServerObject' -Skip {
        $client = 'JDBC'
        $mariadb = Get-AzMariaDbServer -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Not -BeNullOrEmpty
    }   
}
