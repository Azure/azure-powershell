$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$rstr02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)

# ConvertTo-SecureString "P@ssW0rD!" -AsPlainText -Force
$passwordSecure =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadbTest01 = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $passwordSecure -Location eastus
$mariadbTest02 = New-AzMariaDBServer -Name $rstr02 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $passwordSecure -Location eastus

Describe 'Remove-AzMariaDbServer' {
    It 'Delete' {
        Remove-AzMariaDbServer -Name $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup
        (Get-AzMariaDbServer -Name name -ResourceGroupName $env.ResourceGroup) | Should -Throw
    }

    It 'DeleteViaIdentity' {
        Remove-AzMariaDbServer -InputObject $mariadbTest02
        (Get-AzMariaDbServer -Name $mariadbTest02.Name -ResourceGroupName $env.ResourceGroup) | Should -Throw
    }
}
