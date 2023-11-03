$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMariaDbServer' {
    It 'CreateExpanded' {
        $rstr01 = $env.rstr01
        $adminLogin = $env.AdminLogin
        $adminLoginPassword = $env.AdminLoginPassword
        $administratorLoginPassword =  ConvertTo-SecureString $adminLoginPassword -AsPlainText -Force
        $skuName = 'B_Gen5_1' 
        $mariadb = New-AzMariaDBServer -Name $rstr01 -Sku $skuName -ResourceGroupName $env.ResourceGroup -AdministratorUsername $adminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location
        $mariadb.Name | Should -Be $rstr01
    }
}
