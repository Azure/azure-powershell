$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($helperPath)
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDBServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
#$rstr02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
Describe 'New-AzMariaDBServer' {
    It 'CreateExpanded' {
        # ConvertTo-SecureString "P@ssW0rD!" -AsPlainText -Force
        $administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
        $mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location
        $mariadb.Name | Should -Be $rstr01
    }
}
