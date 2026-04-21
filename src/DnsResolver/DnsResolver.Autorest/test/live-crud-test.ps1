<#
.SYNOPSIS
    Comprehensive live CRUD test for all Az.DnsResolver cmdlets (PR #28695 v4 migration).
    Creates a single resource group, exercises every cmdlet, then cleans up.

.DESCRIPTION
    Runs against the Validation Corp subscription (97db216c).
    Tests: 43 cmdlets covering DNS Resolver, Inbound/Outbound Endpoints,
    Forwarding Rulesets, Rules, VNet Links, Policies, Security Rules,
    Domain Lists, Policy VNet Links, and helper object constructors.

    VNet/Subnet creation runs in a SEPARATE process to avoid assembly
    conflicts between Az.Network and the locally-built Az.DnsResolver module.

    Resource group is cleaned up at the end regardless of test results.
#>
param(
    [string]$SubscriptionId = "97db216c-169d-4ea9-9d98-114adba0aa20",
    [string]$Location = "westus2",
    [string]$ResourceGroupName = "ps-dnsresolver-v4-test-$(Get-Random -Maximum 9999)"
)

$ErrorActionPreference = "Continue"
$passed = 0; $failed = 0; $skipped = 0
$results = @()

function Test-Step {
    param([string]$Name, [scriptblock]$Action)
    Write-Host "`n--- $Name ---" -ForegroundColor Cyan
    try {
        $output = & $Action
        Write-Host "PASS" -ForegroundColor Green
        $script:passed++
        $script:results += [PSCustomObject]@{Test=$Name; Result="PASS"; Detail=""}
        return $output
    } catch {
        Write-Host "FAIL: $($_.Exception.Message)" -ForegroundColor Red
        $script:failed++
        $script:results += [PSCustomObject]@{Test=$Name; Result="FAIL"; Detail=$_.Exception.Message}
        return $null
    }
}

# ── PHASE 1: Setup RG + VNet in a CLEAN process (no DnsResolver module) ──
Write-Host "====== PHASE 1: SETUP (separate process — no module conflicts) ======" -ForegroundColor Yellow
$setupResult = pwsh -NoProfile -Command @"
Import-Module Az.Accounts, Az.Resources, Az.Network
Connect-AzAccount -SubscriptionId '$SubscriptionId' -TenantId '72f988bf-86f1-41af-91ab-2d7cd011db47' | Out-Null

New-AzResourceGroup -Name '$ResourceGroupName' -Location '$Location' -Force | Out-Null

`$subnetInbound = New-AzVirtualNetworkSubnetConfig -Name 'sn-inbound' -AddressPrefix '10.0.1.0/24' -Delegation (New-AzDelegation -Name 'dnsdel' -ServiceName 'Microsoft.Network/dnsResolvers')
`$subnetOutbound = New-AzVirtualNetworkSubnetConfig -Name 'sn-outbound' -AddressPrefix '10.0.2.0/24' -Delegation (New-AzDelegation -Name 'dnsdel' -ServiceName 'Microsoft.Network/dnsResolvers')
`$subnetGeneral = New-AzVirtualNetworkSubnetConfig -Name 'sn-general' -AddressPrefix '10.0.3.0/24'
`$vnet = New-AzVirtualNetwork -Name 'test-vnet' -ResourceGroupName '$ResourceGroupName' -Location '$Location' -AddressPrefix '10.0.0.0/16' -Subnet `$subnetInbound, `$subnetOutbound, `$subnetGeneral

# Output the IDs as a simple key=value block for the parent to parse
Write-Output "VNET_ID=`$(`$vnet.Id)"
Write-Output "SUBNET_INBOUND_ID=`$((`$vnet.Subnets | Where-Object Name -eq 'sn-inbound').Id)"
Write-Output "SUBNET_OUTBOUND_ID=`$((`$vnet.Subnets | Where-Object Name -eq 'sn-outbound').Id)"
"@

# Parse the output
$vnetId = ($setupResult | Where-Object { $_ -match "^VNET_ID=" }) -replace "^VNET_ID=",""
$subnetInboundId = ($setupResult | Where-Object { $_ -match "^SUBNET_INBOUND_ID=" }) -replace "^SUBNET_INBOUND_ID=",""
$subnetOutboundId = ($setupResult | Where-Object { $_ -match "^SUBNET_OUTBOUND_ID=" }) -replace "^SUBNET_OUTBOUND_ID=",""

Write-Host "RG: $ResourceGroupName"
Write-Host "VNet ID: $vnetId"
Write-Host "Inbound Subnet: $subnetInboundId"
Write-Host "Outbound Subnet: $subnetOutboundId"

if (-not $vnetId -or -not $subnetInboundId) {
    Write-Host "FATAL: VNet setup failed. Aborting." -ForegroundColor Red
    exit 1
}

# ── PHASE 2: Auth FIRST (before module load), then load DnsResolver ───
Write-Host "`n====== PHASE 2: AUTH + LOAD MODULE ======" -ForegroundColor Yellow
Import-Module Az.Accounts -ErrorAction SilentlyContinue
Connect-AzAccount -SubscriptionId $SubscriptionId -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47" | Out-Null
Write-Host "Authenticated: $((Get-AzContext).Subscription.Name)" -ForegroundColor Green

$modulePath = "C:\Git\azure-powershell\src\DnsResolver\DnsResolver.Autorest"
Import-Module (Join-Path $modulePath "Az.DnsResolver.psd1") -Force
Write-Host "Loaded Az.DnsResolver module"

$sp = @{ SubscriptionId = $SubscriptionId; ResourceGroupName = $ResourceGroupName }

# ── 1. Helper Object Constructors ────────────────────────────────────
Write-Host "`n====== HELPER OBJECTS ======" -ForegroundColor Yellow

$ipConfig = Test-Step "New-AzDnsResolverIPConfigurationObject" {
    New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod "Dynamic" -SubnetId $subnetInboundId
}

$targetDns = Test-Step "New-AzDnsResolverTargetDnsServerObject" {
    New-AzDnsResolverTargetDnsServerObject -IPAddress "10.0.0.1" -Port 53
}

# ── 2. DNS Resolver CRUD ─────────────────────────────────────────────
Write-Host "`n====== DNS RESOLVER ======" -ForegroundColor Yellow
$resolverName = "test-resolver"

$resolver = Test-Step "New-AzDnsResolver" {
    New-AzDnsResolver -Name $resolverName @sp -Location $Location -VirtualNetworkId $vnetId
}
Test-Step "Get-AzDnsResolver (by name)" {
    Get-AzDnsResolver -Name $resolverName @sp | Out-Null
}
Test-Step "Get-AzDnsResolver (list by RG)" {
    $r = Get-AzDnsResolver @sp; if ($r.Count -lt 1) { throw "Expected at least 1 resolver" }
}
Test-Step "Get-AzDnsResolver (list by sub)" {
    $r = Get-AzDnsResolver -SubscriptionId $SubscriptionId; if ($r.Count -lt 1) { throw "Expected resolvers" }
}
Test-Step "Update-AzDnsResolver" {
    Update-AzDnsResolver -Name $resolverName @sp -Tag @{env="test"; pr="28695"} | Out-Null
}

# ── 3. Inbound Endpoint CRUD ─────────────────────────────────────────
Write-Host "`n====== INBOUND ENDPOINT ======" -ForegroundColor Yellow
$inboundName = "test-inbound-ep"

Test-Step "New-AzDnsResolverInboundEndpoint" {
    New-AzDnsResolverInboundEndpoint -Name $inboundName -DnsResolverName $resolverName @sp -Location $Location -IPConfiguration $ipConfig | Out-Null
}
Test-Step "Get-AzDnsResolverInboundEndpoint (by name)" {
    Get-AzDnsResolverInboundEndpoint -Name $inboundName -DnsResolverName $resolverName @sp | Out-Null
}
Test-Step "Get-AzDnsResolverInboundEndpoint (list)" {
    Get-AzDnsResolverInboundEndpoint -DnsResolverName $resolverName @sp | Out-Null
}
Test-Step "Update-AzDnsResolverInboundEndpoint" {
    Update-AzDnsResolverInboundEndpoint -Name $inboundName -DnsResolverName $resolverName @sp -Tag @{updated="true"} | Out-Null
}

# ── 4. Outbound Endpoint CRUD ────────────────────────────────────────
Write-Host "`n====== OUTBOUND ENDPOINT ======" -ForegroundColor Yellow
$outboundName = "test-outbound-ep"

Test-Step "New-AzDnsResolverOutboundEndpoint" {
    New-AzDnsResolverOutboundEndpoint -Name $outboundName -DnsResolverName $resolverName @sp -Location $Location -SubnetId $subnetOutboundId | Out-Null
}
Test-Step "Get-AzDnsResolverOutboundEndpoint (by name)" {
    Get-AzDnsResolverOutboundEndpoint -Name $outboundName -DnsResolverName $resolverName @sp | Out-Null
}
Test-Step "Update-AzDnsResolverOutboundEndpoint" {
    Update-AzDnsResolverOutboundEndpoint -Name $outboundName -DnsResolverName $resolverName @sp -Tag @{updated="true"} | Out-Null
}

# ── 5. Forwarding Ruleset CRUD ───────────────────────────────────────
Write-Host "`n====== FORWARDING RULESET ======" -ForegroundColor Yellow
$rulesetName = "test-fwd-ruleset"
$outboundEpId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/dnsResolvers/$resolverName/outboundEndpoints/$outboundName"

Test-Step "New-AzDnsForwardingRuleset" {
    New-AzDnsForwardingRuleset -Name $rulesetName @sp -Location $Location -DnsResolverOutboundEndpoint @(@{id=$outboundEpId}) | Out-Null
}
Test-Step "Get-AzDnsForwardingRuleset (by name)" {
    Get-AzDnsForwardingRuleset -Name $rulesetName @sp | Out-Null
}
Test-Step "Update-AzDnsForwardingRuleset" {
    Update-AzDnsForwardingRuleset -Name $rulesetName @sp -Tag @{env="test"} | Out-Null
}

# ── 6. Forwarding Rule CRUD ──────────────────────────────────────────
Write-Host "`n====== FORWARDING RULE ======" -ForegroundColor Yellow
$ruleName = "test-fwd-rule"

Test-Step "New-AzDnsForwardingRulesetForwardingRule" {
    New-AzDnsForwardingRulesetForwardingRule -Name $ruleName -DnsForwardingRulesetName $rulesetName @sp -DomainName "example.com." -TargetDnsServer $targetDns | Out-Null
}
Test-Step "Get-AzDnsForwardingRulesetForwardingRule" {
    Get-AzDnsForwardingRulesetForwardingRule -Name $ruleName -DnsForwardingRulesetName $rulesetName @sp | Out-Null
}
Test-Step "Update-AzDnsForwardingRulesetForwardingRule" {
    Update-AzDnsForwardingRulesetForwardingRule -Name $ruleName -DnsForwardingRulesetName $rulesetName @sp -Metadata @{updated="true"} | Out-Null
}

# ── 7. Forwarding Ruleset VNet Link CRUD ─────────────────────────────
Write-Host "`n====== FORWARDING VNET LINK ======" -ForegroundColor Yellow
$fwdLinkName = "test-fwd-vnet-link"

Test-Step "New-AzDnsForwardingRulesetVirtualNetworkLink" {
    New-AzDnsForwardingRulesetVirtualNetworkLink -Name $fwdLinkName -DnsForwardingRulesetName $rulesetName @sp -VirtualNetworkId $vnetId | Out-Null
}
Test-Step "Get-AzDnsForwardingRulesetVirtualNetworkLink" {
    Get-AzDnsForwardingRulesetVirtualNetworkLink -Name $fwdLinkName -DnsForwardingRulesetName $rulesetName @sp | Out-Null
}
Test-Step "Update-AzDnsForwardingRulesetVirtualNetworkLink" {
    Update-AzDnsForwardingRulesetVirtualNetworkLink -Name $fwdLinkName -DnsForwardingRulesetName $rulesetName @sp -Metadata @{updated="true"} | Out-Null
}

# ── 8. DNS Resolver Policy CRUD ──────────────────────────────────────
Write-Host "`n====== DNS RESOLVER POLICY ======" -ForegroundColor Yellow
$policyName = "test-policy"

Test-Step "New-AzDnsResolverPolicy" {
    New-AzDnsResolverPolicy -Name $policyName @sp -Location $Location | Out-Null
}
Test-Step "Get-AzDnsResolverPolicy (by name)" {
    Get-AzDnsResolverPolicy -Name $policyName @sp | Out-Null
}
Test-Step "Update-AzDnsResolverPolicy" {
    Update-AzDnsResolverPolicy -Name $policyName @sp -Tag @{env="test"} | Out-Null
}

# ── 9. Domain List CRUD ──────────────────────────────────────────────
Write-Host "`n====== DOMAIN LIST ======" -ForegroundColor Yellow
$domainListName = "test-domain-list"

Test-Step "New-AzDnsResolverDomainList" {
    New-AzDnsResolverDomainList -Name $domainListName @sp -Location $Location -Domain @("contoso.com.","fabrikam.com.") | Out-Null
}
Test-Step "Get-AzDnsResolverDomainList (by name)" {
    Get-AzDnsResolverDomainList -Name $domainListName @sp | Out-Null
}
Test-Step "Get-AzDnsResolverDomainList (list by RG)" {
    Get-AzDnsResolverDomainList @sp | Out-Null
}
Test-Step "Update-AzDnsResolverDomainList" {
    Update-AzDnsResolverDomainList -Name $domainListName @sp -Tag @{env="test"} | Out-Null
}

# ── 10. DNS Security Rule CRUD ───────────────────────────────────────
Write-Host "`n====== DNS SECURITY RULE ======" -ForegroundColor Yellow
$secRuleName = "test-sec-rule"
$domainListId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/dnsResolverDomainLists/$domainListName"

Test-Step "New-AzDnsResolverPolicyDnsSecurityRule" {
    New-AzDnsResolverPolicyDnsSecurityRule -Name $secRuleName -DnsResolverPolicyName $policyName @sp -Location $Location -Priority 100 -DnsResolverDomainList @(@{id=$domainListId}) -ActionType "Block" -DnsSecurityRuleState "Enabled" | Out-Null
}
Test-Step "Get-AzDnsResolverPolicyDnsSecurityRule" {
    Get-AzDnsResolverPolicyDnsSecurityRule -Name $secRuleName -DnsResolverPolicyName $policyName @sp | Out-Null
}
Test-Step "Update-AzDnsResolverPolicyDnsSecurityRule" {
    Update-AzDnsResolverPolicyDnsSecurityRule -Name $secRuleName -DnsResolverPolicyName $policyName @sp -Tag @{updated="true"} | Out-Null
}

# ── 11. Policy VNet Link CRUD ────────────────────────────────────────
Write-Host "`n====== POLICY VNET LINK ======" -ForegroundColor Yellow
$policyLinkName = "test-policy-vnet-link"

Test-Step "New-AzDnsResolverPolicyVirtualNetworkLink" {
    New-AzDnsResolverPolicyVirtualNetworkLink -Name $policyLinkName -DnsResolverPolicyName $policyName @sp -Location $Location -VirtualNetworkId $vnetId | Out-Null
}
Test-Step "Get-AzDnsResolverPolicyVirtualNetworkLink" {
    Get-AzDnsResolverPolicyVirtualNetworkLink -Name $policyLinkName -DnsResolverPolicyName $policyName @sp | Out-Null
}
Test-Step "Update-AzDnsResolverPolicyVirtualNetworkLink" {
    Update-AzDnsResolverPolicyVirtualNetworkLink -Name $policyLinkName -DnsResolverPolicyName $policyName @sp -Tag @{updated="true"} | Out-Null
}

# ── 12. Bulk Domain List ─────────────────────────────────────────────
Write-Host "`n====== BULK DOMAIN LIST ======" -ForegroundColor Yellow
Test-Step "Invoke-AzDnsResolverBulkDnsResolverDomainList" {
    Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName $domainListName @sp | Out-Null
}

# ══ CLEANUP (reverse order) ══════════════════════════════════════════
Write-Host "`n====== CLEANUP ======" -ForegroundColor Yellow

Test-Step "Remove-AzDnsResolverPolicyVirtualNetworkLink" {
    Remove-AzDnsResolverPolicyVirtualNetworkLink -Name $policyLinkName -DnsResolverPolicyName $policyName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolverPolicyDnsSecurityRule" {
    Remove-AzDnsResolverPolicyDnsSecurityRule -Name $secRuleName -DnsResolverPolicyName $policyName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolverDomainList" {
    Remove-AzDnsResolverDomainList -Name $domainListName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolverPolicy" {
    Remove-AzDnsResolverPolicy -Name $policyName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsForwardingRulesetVirtualNetworkLink" {
    Remove-AzDnsForwardingRulesetVirtualNetworkLink -Name $fwdLinkName -DnsForwardingRulesetName $rulesetName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsForwardingRulesetForwardingRule" {
    Remove-AzDnsForwardingRulesetForwardingRule -Name $ruleName -DnsForwardingRulesetName $rulesetName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsForwardingRuleset" {
    Remove-AzDnsForwardingRuleset -Name $rulesetName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolverInboundEndpoint" {
    Remove-AzDnsResolverInboundEndpoint -Name $inboundName -DnsResolverName $resolverName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolverOutboundEndpoint" {
    Remove-AzDnsResolverOutboundEndpoint -Name $outboundName -DnsResolverName $resolverName @sp -Confirm:$false | Out-Null
}
Test-Step "Remove-AzDnsResolver" {
    Remove-AzDnsResolver -Name $resolverName @sp -Confirm:$false | Out-Null
}

# Remove RG
Write-Host "`nRemoving resource group $ResourceGroupName..." -ForegroundColor Yellow
Remove-AzResourceGroup -Name $ResourceGroupName -Force -AsJob | Out-Null
Write-Host "RG deletion started (async)"

# ══ RESULTS ══════════════════════════════════════════════════════════
Write-Host "`n====== RESULTS ======" -ForegroundColor Yellow
$results | Format-Table -AutoSize
Write-Host "TOTAL: $($passed + $failed + $skipped) | PASSED: $passed | FAILED: $failed | SKIPPED: $skipped" -ForegroundColor $(if ($failed -gt 0) {"Red"} else {"Green"})
