$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

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
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $mariadbTest01.Name
    }

    It 'DeleteViaIdentity' {
        Remove-AzMariaDbServer -InputObject $mariadbTest02
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $mariadbTest02.Name
    }
}
