# ------------------------------------------------------------------------------
# Entra Agentic Sessions - E2E cache isolation and claim verification
#
# Mirrors CLI's test_agentic_session_e2e.py (Azure/azure-cli#33309).
# Requires a user identity signed into an ESTS-agentic-enabled tenant.
# Set AZURE_AGENTIC_TEST_TENANT to the enabled tenant GUID.
# Skipped with a warning when the env var is unset (expected in the pipeline).
# Throws when the env var is set but the current context is wrong (misconfig).
# ------------------------------------------------------------------------------

function Get-AgenticTokenClaims {
    param ([string] $ResourceUrl = "https://management.azure.com/")
    $tokenObj = Get-AzAccessToken -ResourceUrl $ResourceUrl -AsSecureString -ErrorAction Stop
    $plain = [System.Net.NetworkCredential]::new("", $tokenObj.Token).Password
    $payload = ($plain -split "\.")[1]
    switch ($payload.Length % 4) {
        2 { $payload += "==" }
        3 { $payload += "=" }
    }
    $json = [System.Text.Encoding]::UTF8.GetString(
        [Convert]::FromBase64String($payload.Replace("-", "+").Replace("_", "/")))
    ConvertFrom-Json $json
}

function Should-SkipAgenticScenario {
    if ([string]::IsNullOrEmpty($env:AZURE_AGENTIC_TEST_TENANT)) {
        Write-Output "##[warning]Skipping agentic scenario: AZURE_AGENTIC_TEST_TENANT is not set. Set it to the GUID of an ESTS-agentic-enabled tenant to run."
        return $true
    }
    $ctx = Get-AzContext
    if ($null -eq $ctx) {
        throw "Cannot run agentic scenario: no Az context. Run Connect-AzAccount -TenantId $($env:AZURE_AGENTIC_TEST_TENANT) first."
    }
    if ($ctx.Tenant.Id -ne $env:AZURE_AGENTIC_TEST_TENANT) {
        throw "Cannot run agentic scenario: expected tenant $($env:AZURE_AGENTIC_TEST_TENANT), got $($ctx.Tenant.Id)."
    }
    return $false
}

# Agentic scenarios run before the existing scenarios below, because the
# 'Disconnect service principal account' scenario tears down the Az context
# and would leave nothing for these to run against.

Invoke-LiveTestScenario -Name "Agentic session: manual then manual reuses cache" -Description "Two manual token acquisitions should reuse the cached token (same uti); neither should carry xms_cli_ses" -NoResourceGroup -ScenarioScript `
{
    if (Should-SkipAgenticScenario) { return }

    Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    $c1 = Get-AgenticTokenClaims
    $c2 = Get-AgenticTokenClaims

    Assert-AreEqual $c1.uti $c2.uti
    Assert-Null $c1.xms_cli_ses
    Assert-Null $c2.xms_cli_ses
}

Invoke-LiveTestScenario -Name "Agentic session: agent then agent (same session) reuses cache" -Description "Two agent acquisitions with the same session ID should reuse the cached token; both should carry xms_cli_ses" -NoResourceGroup -ScenarioScript `
{
    if (Should-SkipAgenticScenario) { return }

    $sessionId = "livetest-agent-same-session-01"
    $env:COPILOT_AGENT_SESSION_ID = $sessionId
    try
    {
        $c1 = Get-AgenticTokenClaims
        $c2 = Get-AgenticTokenClaims

        Assert-AreEqual $c1.uti $c2.uti
        Assert-AreEqual $sessionId $c1.xms_cli_ses
        Assert-AreEqual $sessionId $c2.xms_cli_ses
    }
    finally
    {
        Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    }
}

Invoke-LiveTestScenario -Name "Agentic session: manual then agent does not reuse cache" -Description "A manual token followed by an agent token should NOT reuse the cache; only the agent token should carry xms_cli_ses" -NoResourceGroup -ScenarioScript `
{
    if (Should-SkipAgenticScenario) { return }

    Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    $manual = Get-AgenticTokenClaims

    $sessionId = "livetest-agent-after-manual-01"
    $env:COPILOT_AGENT_SESSION_ID = $sessionId
    try
    {
        $agent = Get-AgenticTokenClaims

        Assert-AreNotEqual $manual.uti $agent.uti
        Assert-Null $manual.xms_cli_ses
        Assert-AreEqual $sessionId $agent.xms_cli_ses
    }
    finally
    {
        Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    }
}

Invoke-LiveTestScenario -Name "Agentic session: agent then manual does not reuse cache" -Description "An agent token followed by a manual token should NOT reuse the cache; only the agent token should carry xms_cli_ses" -NoResourceGroup -ScenarioScript `
{
    if (Should-SkipAgenticScenario) { return }

    $sessionId = "livetest-manual-after-agent-01"
    $env:COPILOT_AGENT_SESSION_ID = $sessionId
    try
    {
        $agent = Get-AgenticTokenClaims
    }
    finally
    {
        Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    }
    $manual = Get-AgenticTokenClaims

    Assert-AreNotEqual $agent.uti $manual.uti
    Assert-AreEqual $sessionId $agent.xms_cli_ses
    Assert-Null $manual.xms_cli_ses
}

Invoke-LiveTestScenario -Name "Agentic session: two different sessions do not reuse cache" -Description "Two agent tokens with different session IDs should NOT reuse the cache; each should carry its own xms_cli_ses value" -NoResourceGroup -ScenarioScript `
{
    if (Should-SkipAgenticScenario) { return }

    $sessionA = "livetest-agent-session-AAA-01"
    $sessionB = "livetest-agent-session-BBB-01"
    try
    {
        $env:COPILOT_AGENT_SESSION_ID = $sessionA
        $agentA = Get-AgenticTokenClaims
        $env:COPILOT_AGENT_SESSION_ID = $sessionB
        $agentB = Get-AgenticTokenClaims

        Assert-AreNotEqual $agentA.uti $agentB.uti
        Assert-AreEqual $sessionA $agentA.xms_cli_ses
        Assert-AreEqual $sessionB $agentB.xms_cli_ses
    }
    finally
    {
        Remove-Item Env:COPILOT_AGENT_SESSION_ID -ErrorAction SilentlyContinue
    }
}

Invoke-LiveTestScenario -Name "Validate access token" -Description "Test validating access token" -NoResourceGroup -ScenarioScript `
{
    $account = (Get-AzContext).Account
    $applicationId = $account.Id
    $tenantId = $account.Tenants[0]
    $token = Get-AzAccessToken
    Assert-AreEqual $applicationId $token.UserId
    Assert-AreEqual $tenantId $token.TenantId
}

Invoke-LiveTestScenario -Name "Disconnect service principal account" -Description "Test disconnecting service principal account" -NoResourceGroup -ScenarioScript `
{
    $account = (Get-AzContext).Account
    $applicationId = $account.Id
    $tenantId = $account.Tenants[0]
    Disconnect-AzAccount -ApplicationId $applicationId -TenantId $tenantId

    $token = Get-AzAccessToken -ErrorAction SilentlyContinue
    Assert-True { ($null -eq $token) -or ($null -ne $token -and $token.UserId -ne $applicationId) }
}
