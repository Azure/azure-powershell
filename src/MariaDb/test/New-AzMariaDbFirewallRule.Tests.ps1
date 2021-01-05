$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMariaDbFirewallRule' {
    It 'CreateExpanded' {
       $firewallName = 'frname-001' 
       $endIPAddress = '0.0.2.125'
       $startIPAddress = '0.0.2.1'
       New-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
       $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02
       $mariaDbFirewall.Name | Should -Be $firewallName 
    }

    It 'ClientIPAddress' {
        $firewallName = 'frname-002'
        $rule = New-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.resourceGroup -ServerName $env.rstrbc02 -ClientIPAddress 0.0.0.1
        $rule.Name | Should -Be $firewallName
        $rule.StartIPAddress | Should -Be 0.0.0.1
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.resourceGroup -ServerName $env.rstrbc02
    }

    It 'AllowAll' {
        $allowAllName = 'AllowAll_2020-08-11_21-28-19'
        $rule = New-AzMariaDbFirewallRule -Name $allowAllName -ResourceGroupName $env.resourceGroup -ServerName $env.rstrbc02 -AllowAll
        $rule.Name | Should -Be $allowAllName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 255.255.255.255
        Remove-AzMariaDbFirewallRule -Name $rule.Name -ResourceGroupName $env.resourceGroup -ServerName $env.rstrbc02
    }
}
