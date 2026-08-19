Set-StrictMode -Version 2.0

function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | ForEach-Object { [char]$_ })
    }

    return -join ((48..57) + (97..122) | Get-Random -Count $len | ForEach-Object { [char]$_ })
}

function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $cachedEnvPath = Join-Path $PSScriptRoot 'env.json'
    if (Test-Path -Path $cachedEnvPath) {
        $previousEnv = Get-Content -Path $cachedEnvPath | ConvertFrom-Json
        $previousEnv.PSObject.Properties | ForEach-Object { $env[$_.Name] = $_.Value }
    }
}

$env | Add-Member -Type ScriptMethod -Value {
    param([string] $key, [object] $val, [bool] $useCache)

    if ($this.Contains($key) -and $useCache) {
        return $this[$key]
    }

    $this[$key] = $val
    return $val
} -Name 'AddWithCache'

function setupEnv() {
    if ($TestMode -eq 'playback') {
        return
    }

    $context = Get-AzContext
    if ($null -eq $context) {
        throw 'Az context is required for CloudHealth record/live tests.'
    }

    $suffix = RandomString $false 6
    $location = $env:AZURE_TEST_LOCATION
    if ([string]::IsNullOrWhiteSpace($location)) {
        $location = 'centralus'
    }
    $location = $location.ToLowerInvariant()

    $env.SubscriptionId = $context.Subscription.Id
    $env.Tenant = $context.Tenant.Id
    $env.Location = $location
    $env.ResourceGroupName = $env.AddWithCache('ResourceGroupName', "azps-ch-rg-$suffix", $UsePreviousConfigForRecord)

    $env.HealthModelName = $env.AddWithCache('HealthModelName', "azps-hm-shared-$suffix", $UsePreviousConfigForRecord)
    $env.HealthModelCreateName = $env.AddWithCache('HealthModelCreateName', "azps-hm-create-$suffix", $UsePreviousConfigForRecord)
    $env.HealthModelDeleteName = $env.AddWithCache('HealthModelDeleteName', "azps-hm-delete-$suffix", $UsePreviousConfigForRecord)

    $env.EntityName = $env.AddWithCache('EntityName', "azps-ent-shared-$suffix", $UsePreviousConfigForRecord)
    $env.EntityCreateName = $env.AddWithCache('EntityCreateName', "azps-ent-create-$suffix", $UsePreviousConfigForRecord)
    $env.EntityDeleteName = $env.AddWithCache('EntityDeleteName', "azps-ent-delete-$suffix", $UsePreviousConfigForRecord)
    $env.ChildEntityName = $env.AddWithCache('ChildEntityName', "azps-ent-child-$suffix", $UsePreviousConfigForRecord)

    $env.AuthenticationSettingName = $env.AddWithCache('AuthenticationSettingName', "azps-auth-shared-$suffix", $UsePreviousConfigForRecord)
    $env.AuthenticationSettingCreateName = $env.AddWithCache('AuthenticationSettingCreateName', "azps-auth-create-$suffix", $UsePreviousConfigForRecord)
    $env.AuthenticationSettingDeleteName = $env.AddWithCache('AuthenticationSettingDeleteName', "azps-auth-delete-$suffix", $UsePreviousConfigForRecord)

    $env.SignalDefinitionName = $env.AddWithCache('SignalDefinitionName', "azps-sig-shared-$suffix", $UsePreviousConfigForRecord)
    $env.SignalDefinitionCreateName = $env.AddWithCache('SignalDefinitionCreateName', "azps-sig-create-$suffix", $UsePreviousConfigForRecord)
    $env.SignalDefinitionDeleteName = $env.AddWithCache('SignalDefinitionDeleteName', "azps-sig-delete-$suffix", $UsePreviousConfigForRecord)

    $env.RelationshipName = $env.AddWithCache('RelationshipName', "azps-rel-shared-$suffix", $UsePreviousConfigForRecord)
    $env.RelationshipCreateName = $env.AddWithCache('RelationshipCreateName', "azps-rel-create-$suffix", $UsePreviousConfigForRecord)
    $env.RelationshipDeleteName = $env.AddWithCache('RelationshipDeleteName', "azps-rel-delete-$suffix", $UsePreviousConfigForRecord)
    $env.RelationshipCreateChildEntityName = $env.AddWithCache('RelationshipCreateChildEntityName', "azps-ent-relcreate-$suffix", $UsePreviousConfigForRecord)
    $env.RelationshipDeleteChildEntityName = $env.AddWithCache('RelationshipDeleteChildEntityName', "azps-ent-reldelete-$suffix", $UsePreviousConfigForRecord)

    $env.DiscoveryRuleName = $env.AddWithCache('DiscoveryRuleName', "azps-disc-shared-$suffix", $UsePreviousConfigForRecord)
    $env.DiscoveryRuleCreateName = $env.AddWithCache('DiscoveryRuleCreateName', "azps-disc-create-$suffix", $UsePreviousConfigForRecord)
    $env.DiscoveryRuleDeleteName = $env.AddWithCache('DiscoveryRuleDeleteName', "azps-disc-delete-$suffix", $UsePreviousConfigForRecord)

    $resourceGroup = Get-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction SilentlyContinue
    if ($null -eq $resourceGroup) {
        New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null
    }

    $healthModel = Get-AzMonitorHealthModel -ResourceGroupName $env.ResourceGroupName -Name $env.HealthModelName -ErrorAction SilentlyContinue
    if ($null -eq $healthModel) {
        $healthModel = New-AzMonitorHealthModel -Name $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -EnableSystemAssignedIdentity -Tag @{ scenario = 'shared' }
    }

    $entity = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName -ErrorAction SilentlyContinue
    if ($null -eq $entity) {
        $entity = New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName -DisplayName 'Shared entity' -Impact Standard -HealthObjective 99.9
    }

    $childEntity = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.ChildEntityName -ErrorAction SilentlyContinue
    if ($null -eq $childEntity) {
        $childEntity = New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.ChildEntityName -DisplayName 'Shared child entity' -Impact Standard -HealthObjective 99.5
    }

    $authenticationSetting = Get-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingName -ErrorAction SilentlyContinue
    if ($null -eq $authenticationSetting) {
        $authenticationProperty = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName 'SystemAssigned' -DisplayName 'Shared auth setting'
        $authenticationSetting = New-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingName -Property $authenticationProperty
    }

    $signalDefinition = Get-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionName -ErrorAction SilentlyContinue
    if ($null -eq $signalDefinition) {
        $degradedRule = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
        $unhealthyRule = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
        $evaluationRule = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degradedRule -UnhealthyRule $unhealthyRule
        $signalProperty = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain 'PT5M' -AggregationType Average -EvaluationRule $evaluationRule -DisplayName 'Shared signal definition' -DataUnit Percent -RefreshInterval 'PT5M'
        $signalDefinition = New-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionName -Property $signalProperty
    }

    $relationship = Get-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipName -ErrorAction SilentlyContinue
    if ($null -eq $relationship) {
        try {
            $relationship = New-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipName -ParentEntityName $env.EntityName -ChildEntityName $env.ChildEntityName -DisplayName 'Shared relationship'
        } catch {
            Start-TestSleep -Seconds 5
            $relationship = New-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipName -ParentEntityName $env.EntityName -ChildEntityName $env.ChildEntityName -DisplayName 'Shared relationship'
        }
    }

    $discoveryRule = Get-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleName -ErrorAction SilentlyContinue
    if ($null -eq $discoveryRule) {
        $specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where isnotempty(id) | project id | take 1"
        $discoveryProperty = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting $env.AuthenticationSettingName -AddRecommendedSignal Enabled -AddResourceHealthSignal Disabled -DiscoverRelationship Disabled -DisplayName 'Shared discovery rule' -Specification $specification
        $discoveryRule = New-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleName -Property $discoveryProperty
    }

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 20)
}

function cleanupEnv() {
    if (($TestMode -eq 'record') -or ($TestMode -eq 'live')) {
        if ($env.ContainsKey('ResourceGroupName') -and -not [string]::IsNullOrWhiteSpace($env.ResourceGroupName)) {
            Remove-AzResourceGroup -Name $env.ResourceGroupName -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }
}
