# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Inert test helpers. Every exchange explicitly selects Record or Playback;
# never set a global pipeline default, read a cached fixture or fall back to live.
function ConvertTo-CosmosRecordedCanonicalJson {
    param([Parameter(Mandatory)][AllowNull()] $Value)

    function Convert-RecordedNode($Node) {
        if ($null -eq $Node) { return $null }
        if ($Node -is [System.Management.Automation.PSCustomObject]) {
            $map = [ordered]@{}
            foreach ($property in $Node.PSObject.Properties) { $map[$property.Name] = $property.Value }
            $Node = $map
        }
        if ($Node -is [System.Collections.IDictionary]) {
            [string[]]$keys = @($Node.Keys)
            [Array]::Sort($keys, [StringComparer]::Ordinal)
            $result = [ordered]@{}
            foreach ($key in $keys) { $result[$key] = Convert-RecordedNode $Node[$key] }
            return ,$result
        }
        if ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            return ,@(foreach ($item in $Node) { Convert-RecordedNode $item })
        }
        return $Node
    }
    ConvertTo-Json -InputObject (Convert-RecordedNode $Value) -Depth 100 -Compress
}

function New-CosmosRecordedRestoreRequest {
    param([Parameter(Mandatory)] $Fixture, [Parameter(Mandatory)] $Case)

    $arguments = @{
        DatasourceType = 'AzureCosmosDB'; SourceDataStore = 'VaultStore'
        RestoreType = 'AlternateLocation'; RestoreLocation = [string]$Fixture.Location
        TargetResourceId = [string]$Case.TargetId; RecoveryPoint = [string]$Fixture.RecoveryPointId
        UseSystemAssignedIdentity = $true
    }
    if ([string]$Case.Name -cne 'full') {
        $configuration = Az.DataProtection\New-AzDataProtectionRestoreConfigurationClientObject `
            -DatasourceType AzureCosmosDB -ResourceIdentifier @($Case.Selectors)
        $arguments.ItemLevelRecovery = $true
        $arguments.RestoreConfiguration = $configuration
    }
    $request = Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @arguments
    $wire = $request.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString()
    $shape = ConvertFrom-Json -InputObject $wire
    if ($shape.objectType -cne 'AzureBackupRecoveryPointBasedRestoreRequest' -or
        $shape.sourceDataStoreType -cne 'VaultStore' -or
        $shape.recoveryPointId -cne [string]$Fixture.RecoveryPointId -or
        $shape.restoreTargetInfo.datasourceInfo.resourceID -ine [string]$Case.TargetId -or
        $shape.restoreTargetInfo.datasourceInfo.resourceUri -ine [string]$Case.TargetId -or
        $shape.restoreTargetInfo.recoveryOption -cne 'FailIfExists' -or
        $shape.identityDetails.useSystemAssignedIdentity -ne $true) {
        throw 'Recorded Cosmos request is outside the explicitly selected fixture.'
    }
    if ([string]$Case.Name -ceq 'full') {
        if ($shape.restoreTargetInfo.objectType -cne 'RestoreTargetInfo' -or
            $null -ne $shape.restoreTargetInfo.PSObject.Properties['restoreCriteria']) {
            throw 'Full restore must not contain ILR criteria.'
        }
    } else {
        $criteria = @($shape.restoreTargetInfo.restoreCriteria)
        if ($shape.restoreTargetInfo.objectType -cne 'ItemLevelRestoreTargetInfo' -or $criteria.Count -ne 1 -or
            $criteria[0].objectType -cne 'GenericRestoreDatasourceCriteria' -or
            $criteria[0].resourceSelectors.objectType -cne 'ResourceListSelectionCriteria' -or
            (@($criteria[0].resourceSelectors.resourceIdentifiers) -join '|') -cne (@($Case.Selectors) -join '|')) {
            throw 'Recorded ILR selectors differ from the approved ordered selection.'
        }
    }
    return $request
}

function Invoke-CosmosRecordedExchange {
    param(
        [Parameter(Mandatory)] $Fixture,
        [Parameter(Mandatory)] $Case,
        [Parameter(Mandatory)][ValidateSet('Record', 'Playback')][string] $Mode,
        [Parameter(Mandatory)][string] $RecordingPath,
        [Parameter(Mandatory)][ValidateSet('Validate', 'Submit', 'Job')][string] $Operation,
        [Parameter(Mandatory)][ValidatePattern('^(validate|submit|poll-[0-9]{6})$')][string] $Step,
        [string] $JobId
    )

    if ($Case.Name -cnotin @('full', 'single', 'database', 'mixed') -or
        [string]::IsNullOrWhiteSpace([string]$Fixture.SubscriptionId) -or
        [string]::IsNullOrWhiteSpace([string]$Fixture.BackupInstanceName) -or
        [string]::IsNullOrWhiteSpace([string]$Case.TargetId)) {
        throw 'Invalid recorded-service fixture.'
    }
    if (($Operation -ceq 'Validate' -and $Step -cne 'validate') -or
        ($Operation -ceq 'Submit' -and $Step -cne 'submit') -or
        ($Operation -ceq 'Job' -and ($Step -cnotmatch '^poll-[0-9]{6}$' -or $JobId -cnotmatch '^[a-zA-Z0-9-]+$'))) {
        throw 'Operation and deterministic recording step do not match.'
    }
    if ($Mode -ceq 'Playback' -and -not (Test-Path -LiteralPath $RecordingPath -PathType Leaf)) {
        throw 'Recorded service evidence is missing; never fall back to Azure.'
    }
    # One new private fragment per actual operation/snapshot. This avoids the
    # framework bootstrap's erase and concurrent whole-file append behavior.
    if ($Mode -ceq 'Record' -and (Test-Path -LiteralPath $RecordingPath)) {
        throw 'Recording fragment exists; reconcile its checkpoint instead of overwriting it.'
    }
    $recorder = New-Object Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PipelineMock $RecordingPath
    if ($Mode -ceq 'Record') { $recorder.SetRecord() } else {
        $recorder.SetPlayback()
        $recorder.ForceResponseHeaders['Retry-After'] = '0'
    }
    $recorder.PushDescription('CosmosRecordedService')
    $recorder.PushContext([string]$Case.Name)
    $recorder.PushScenario($Step)
    try {
        $pipeline = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep]$recorder
        $vault = @{
            SubscriptionId = [string]$Fixture.SubscriptionId
            ResourceGroupName = [string]$Fixture.VaultResourceGroup
            VaultName = [string]$Fixture.VaultName
            HttpPipelinePrepend = @($pipeline)
        }
        switch ($Operation) {
            'Validate' {
                $request = New-CosmosRecordedRestoreRequest -Fixture $Fixture -Case $Case
                Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore @vault `
                    -Name ([string]$Fixture.BackupInstanceName) -RestoreRequest $request -Confirm:$false
            }
            'Submit' {
                $request = New-CosmosRecordedRestoreRequest -Fixture $Fixture -Case $Case
                Az.DataProtection\Start-AzDataProtectionBackupInstanceRestore @vault `
                    -BackupInstanceName ([string]$Fixture.BackupInstanceName) -Parameter $request -Confirm:$false
            }
            'Job' {
                Az.DataProtection\Get-AzDataProtectionJob @vault -Id $JobId
            }
        }
    } finally {
        $recorder.PopScenario()
        $recorder.PopContext()
        $recorder.PopDescription()
    }
}