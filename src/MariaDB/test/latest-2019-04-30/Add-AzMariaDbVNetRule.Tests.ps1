$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzMariaDbVNetRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$skuCapacity = 4
$skuFamily = 'Gen5'
$skuName = 'GP_Gen5_4'
$skuTier = 'GeneralPurpose'
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -SkuName $skuName  -Location eastus
Describe 'Add-AzMariaDbVNetRule' {
    It 'CreateExpanded' {
        $vnetName = $env.VnetName
        $vnetRuleName = 'vnetrule-01'
        $vnetobj = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroupGet -Name $vnetName
        Add-AzMariaDbVNetRule -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName -SubnetId $vnetobj.Subnets[0].id -IgnoreMissingVnetServiceEndpoint
        $mariaDbVnet = Get-AzMariaDbVNetRule -Name $vnetRuleName -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Be $vnetRuleName
    }
}
