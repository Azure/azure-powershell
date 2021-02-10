$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzMySqlFlexibleServerFirewallRule' {

    It 'List' {
        { 
            New-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            $rule = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
            $rule.Count | Should -Be 1 
        } | Should -Not -Throw
    }

    It 'ViaName' {
        { 
            #CreateExpanded
            $rule = New-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1

            $rule = Get-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1 

            $rule = Update-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
            $rule.StartIPAddress | Should -Be 0.0.0.2
            $rule.EndIPAddress | Should -Be 0.0.0.3

            $rule = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
            $rule.Count | Should -Be 1

            Remove-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
            #ClientIPAddress
            $rule = New-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -ClientIPAddress 0.0.0.1
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.1
            $rule.EndIPAddress | Should -Be 0.0.0.1

            $rule = Get-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $rule.StartIPAddress | Should -Be 0.0.0.1
            $rule.EndIPAddress | Should -Be 0.0.0.1 

            Remove-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            #AllowAll
            
            $rule = New-AzMySqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AllowAll
            $rule.Name | Should -Be $env.firewallRuleName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 255.255.255.255

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/firewallRules/$($env.firewallRuleName)"

            $rule = Get-AzMySqlFlexibleServerFirewallRule -InputObject $ID
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 255.255.255.255

            $rule = Update-AzMySqlFlexibleServerFirewallRule -InputObject $ID -ClientIPAddress 0.0.0.2
            $rule.StartIPAddress | Should -Be 0.0.0.2
            $rule.EndIPAddress | Should -Be 0.0.0.2

            Remove-AzMySqlFlexibleServerFirewallRule -InputObject $ID

        } | Should -Not -Throw
    }
}