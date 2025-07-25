$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzPostgreSqlFlexibleServerFirewallRule' {

    It 'ViaName' {
        { 
            #CreateExpanded
            $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1

            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1 

            $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
            $rule.StartIPAddress | Should -Be 0.0.0.2
            $rule.EndIPAddress | Should -Be 0.0.0.3

            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
            $rule.Count | Should -Be 1

            Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
            #ClientIPAddress
            $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -ClientIPAddress 0.0.0.1
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.1
            $rule.EndIPAddress | Should -Be 0.0.0.1

            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $rule.StartIPAddress | Should -Be 0.0.0.1
            $rule.EndIPAddress | Should -Be 0.0.0.1 

            Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            #AllowAll
            
            $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AllowAll
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 255.255.255.255

            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 255.255.255.255

            $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule -ClientIPAddress 0.0.0.2
            $rule.StartIPAddress | Should -Be 0.0.0.2
            $rule.EndIPAddress | Should -Be 0.0.0.2

            Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule

        } | Should -Not -Throw
    }
}