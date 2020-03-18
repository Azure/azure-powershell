$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbVNetRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$skuName = 'GP_Gen5_4'
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -SkuName $skuName  -Location $env.Location
$vnetResourceGroup = 'lucas-vnet'
$vnetName = 'vnet-01'
$vnetobj = Get-AzVirtualNetwork -ResourceGroupName $vnetResourceGroup -Name $vnetName
$vnetRuleName01 = 'vnetrule-01'
$vnetRuleName02 = 'vnetrule-02'
$serverName = $rstr01
New-AzMariaDbVNetRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName01 -SubnetId $vnetobj.Subnets[1].id -IgnoreMissingVnetServiceEndpoint
New-AzMariaDbVNetRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName02 -SubnetId $vnetobj.Subnets[2].id -IgnoreMissingVnetServiceEndpoint

Describe 'Get-AzMariaDbVNetRule' {
    # The basic mariadb not support vnet feature. 
    It 'List' {
        $mariaDbVnet = Get-AzMariaDbVNetRule -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Count | Should -Be 2
    }

    It 'Get' {
        $mariaDbVnet = Get-AzMariaDbVNetRule -Name $vnetRuleName01 -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Be $vnetRuleName01
    }
}
