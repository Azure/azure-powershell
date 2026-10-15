# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Pester 4, offline only. The tooling under test requires PowerShell 7.2, but this
# test file deliberately uses no PowerShell 7-only syntax. No built/cloud module
# is needed when running this file alone. Never dot-source either live entrypoint.
$harnessRepoRoot = $PSScriptRoot
foreach ($level in 1..4) { $harnessRepoRoot = Split-Path -Parent $harnessRepoRoot }
$harnessSources = @{}
foreach ($sourceName in @('Invoke-CosmosRestoreScenario', 'Invoke-CosmosRestoreNegativeTests')) {
    $sourcePath = Join-Path $harnessRepoRoot "tools/Test/$sourceName.ps1"
    $sourceTokens = $null
    $sourceErrors = $null
    $sourceText = [System.IO.File]::ReadAllText($sourcePath, [System.Text.Encoding]::UTF8)
    $sourceAst = [System.Management.Automation.Language.Parser]::ParseInput($sourceText, $sourcePath, [ref]$sourceTokens, [ref]$sourceErrors)
    if ($sourceErrors.Count -ne 0) { throw "Cannot extract harness functions: $sourcePath has parse errors." }
    $harnessSources[$sourceName] = $sourceAst
}
if ($PSVersionTable.PSVersion -lt [version]'7.2') {
    # Desktop coverage is deliberately structural, not a compatibility shim for
    # the 7.2-only tools. Never GetScriptBlock/dot-source their definitions here.
    # Eight contracts replace (not skip) the 40 mandatory 7.2+ behavioral cases.
    Describe 'CosmosRestoreHarnessDesktop' {
        function Get-DesktopFunctionAst([string] $Source, [string] $Name) {
            $definitions = @($harnessSources[$Source].FindAll({
                param($node)
                $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -eq $Name
            }, $true))
            $definitions.Count | Should -Be 1
            return $definitions[0]
        }
        function Assert-DesktopAstOrder([string] $Text, [string[]] $Fragments) {
            $offset = 0
            foreach ($fragment in $Fragments) {
                $position = $Text.IndexOf($fragment, $offset, [StringComparison]::Ordinal)
                $position | Should -BeGreaterThan -1
                if ($position -lt 0) { return }
                $offset = $position + $fragment.Length
            }
        }
        function Get-DesktopCommands($Ast) {
            $Ast.FindAll({ param($node) $node -is [System.Management.Automation.Language.CommandAst] }, $true) |
                ForEach-Object { $_.GetCommandName() }
        }

        It 'AST contract only: both tools require exactly PowerShell 7.2 without an edition restriction' {
            foreach ($ast in $harnessSources.Values) {
                $ast.ScriptRequirements.RequiredPSVersion | Should -Be ([version]'7.2')
                @($ast.ScriptRequirements.RequiredPSEditions).Count | Should -Be 0
                $ast.ParamBlock.Parameters.Name.VariablePath.UserPath | Should -Contain 'EnableLive'
                $ast.Extent.Text | Should -Match 'if \(-not \$EnableLive\) \{ throw'
            }
        }

        It 'AST contract only: neither tool removes resources or stops protection and negatives cannot submit jobs' {
            foreach ($ast in $harnessSources.Values) {
                $commands = @(Get-DesktopCommands $ast)
                @($commands | Where-Object { $_ -match '(^|\\)(Remove-Az|Stop-Az.*Protection|Disable-Az.*Protection|Invoke-AzRestMethod)' }).Count | Should -Be 0
            }
            $negativeCommands = @(Get-DesktopCommands $harnessSources['Invoke-CosmosRestoreNegativeTests'])
            @($negativeCommands | Where-Object { $_ -match '(^|\\)(Start-Az|Backup-Az|Set-Az|Connect-Az|New-AzResource|New-AzCosmos)' }).Count | Should -Be 0
        }

        It 'AST contract only: restore and negative validation use public native DPP commands' {
            $commands = @(Get-DesktopCommands (Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Invoke-Restore'))
            foreach ($name in @('New-AzDataProtectionRestoreConfigurationClientObject', 'Initialize-AzDataProtectionRestoreRequest',
                'Set-AzDataProtectionMSIPermission', 'Test-AzDataProtectionBackupInstanceRestore', 'Start-AzDataProtectionBackupInstanceRestore')) {
                $commands | Should -Contain $name
            }
            $negativeCommands = @(Get-DesktopCommands $harnessSources['Invoke-CosmosRestoreNegativeTests'])
            foreach ($name in @('New-AzDataProtectionRestoreConfigurationClientObject', 'Initialize-AzDataProtectionRestoreRequest', 'Test-AzDataProtectionBackupInstanceRestore')) {
                $negativeCommands | Should -Contain "Az.DataProtection\$name"
            }
            @($commands + $negativeCommands | Where-Object { $_ -match '(^|\\)Az\.DataProtection\.internal\\|^Invoke-(RestMethod|WebRequest)$' }).Count | Should -Be 0
        }

        It 'AST contract only: creation backup and restore persist write-ahead intents before native writes' {
            $create = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Initialize-ScenarioAccount').Extent.Text
            Assert-DesktopAstOrder $create @("if (`$record.Status -eq 'Creating') { throw", "`$record.Status = 'Creating'", 'Save-State', 'Assert-Context', '$null = New-AzCosmosDBAccount')
            Assert-DesktopAstOrder $create @("`$record.Status = 'Creating'", 'Save-State', '$null = New-AzResource')
            $backup = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Invoke-Backup').Extent.Text
            Assert-DesktopAstOrder $backup @('if ($script:State.Backup.JobId) { return }', "if (`$script:State.Backup.Status -eq 'Submitting') { throw", "`$script:State.Backup.Status = 'Submitting'", 'Save-State', 'Backup-AzDataProtectionBackupInstanceAdhoc', 'Save-SubmittedJob')
            $restore = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Invoke-Restore').Extent.Text
            Assert-DesktopAstOrder $restore @('$record.RequestJson = $wire', '$record.TargetResourceId = $account.Id', "`$record.Status = 'Initialized'", 'Save-State', "`$record.Status = 'Submitting'", 'Save-State', 'Start-AzDataProtectionBackupInstanceRestore', 'Save-SubmittedJob')
        }

        It 'AST contract only: all submitted restores block provisioning until Completed and each new job returns pending' {
            $restore = Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Invoke-Restore'
            $loops = @($restore.Body.FindAll({ param($node) $node -is [System.Management.Automation.Language.ForEachStatementAst] }, $false))
            $loops.Count | Should -Be 2
            $loops[0].Body.Extent.Text | Should -Match "if \(\`$record.Status -ne 'Completed'\) \{ \`$pending = \`$true \}"
            $loops[0].Body.Extent.Text | Should -Match "elseif \(\`$record.Status -eq 'Submitting'\)"
            Assert-DesktopAstOrder $restore.Extent.Text @("Update-Job `$record 'Restore'", 'Assert-JobNotFailed $record', 'if ($pending) { return }', 'Initialize-ScenarioAccount $key')
            Assert-DesktopAstOrder $loops[1].Body.Extent.Text @('Save-SubmittedJob', "Update-Job `$record 'Restore'", 'Assert-JobNotFailed $record', "if (`$record.Status -ne 'Completed') { return }")
            @(Get-DesktopCommands $restore) | Should -Not -Contain 'Start-Sleep'
        }

        It 'AST contract only: both validation paths require entire owned EmptyTarget inventory before native validation' {
            $restore = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreScenario' 'Invoke-Restore').Extent.Text
            Assert-DesktopAstOrder $restore @('Initialize-ScenarioAccount $key', 'Get-AzCosmosDBSqlDatabase', '.Count -ne 0) { throw', 'Initialize-AzDataProtectionRestoreRequest', 'Test-AzDataProtectionBackupInstanceRestore')
            $target = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreNegativeTests' 'Assert-NegativeTarget').Extent.Text
            Assert-DesktopAstOrder $target @('Assert-NegativeContext', 'Get-AzCosmosDBAccount', "`$target.Tags['CosmosRestoreRun'] -cne `$script:State.RunId", 'Get-AzCosmosDBSqlDatabase', '.Count -ne 0)', 'throw')
            $targetState = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreNegativeTests' 'Assert-NegativeTargetState').Extent.Text
            foreach ($fragment in @("`$TargetId -ieq `$State.Accounts['source']['Id']", "['Status'] -cne 'Created'", "`$restore['JobId']", "`$restore['Status'] -cnotin `$allowed")) {
                $targetState.Contains($fragment) | Should -Be $true
            }
            Assert-DesktopAstOrder (Get-DesktopFunctionAst 'Invoke-CosmosRestoreNegativeTests' 'Invoke-NativeNegativeValidation').Extent.Text @('Assert-NegativeTarget', 'Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore')
        }

        It 'AST contract only: live and output guards precede exclusive leases and state loading follows the negative lease' {
            $positive = $harnessSources['Invoke-CosmosRestoreScenario'].Extent.Text
            Assert-DesktopAstOrder $positive @('if (-not $EnableLive) { throw', "throw 'OutputDirectory cannot be inside the module artifact.'", '$script:Lease = [IO.File]::Open', '[IO.FileShare]::None)', 'Import-Module $ModulePath')
            $negative = $harnessSources['Invoke-CosmosRestoreNegativeTests'].Extent.Text
            Assert-DesktopAstOrder $negative @('if (-not $EnableLive) { throw', "throw 'OutputDirectory must be separate from the positive state directory", 'if ($ServiceValidation) { $scenarioLease = Open-NegativeScenarioLease $StatePath }', '$script:State = Get-Content', 'Assert-NegativeTargetState $script:State $TargetAccountId', 'Invoke-NativeNegativeValidation (New-PositiveNegativeRequest) $control', 'Invoke-ServiceNegative $case')
            $lease = (Get-DesktopFunctionAst 'Invoke-CosmosRestoreNegativeTests' 'Open-NegativeScenarioLease').Extent.Text
            $lease | Should -Match "'scenario.lock'"
            $lease | Should -Match '\[IO.FileShare\]::None'
            $negative | Should -Match '\$scenarioLease.Dispose\(\)'
            $positive | Should -Match '\$script:Lease.Dispose\(\)'
        }

        It 'AST contract only: sanitizers retain exact traversal allowlists and redact bounded messages without executing JSON' {
            foreach ($pair in @(
                @{ Source = 'Invoke-CosmosRestoreScenario'; Reader = 'Read-NativeError'; Failure = 'Get-SafeNativeFailure'; Protect = 'Protect-FailureText'; Keys = 'error,innerError,additionalInfo,details' }
                @{ Source = 'Invoke-CosmosRestoreNegativeTests'; Reader = 'Read-AllowlistedError'; Failure = 'Get-NegativeFailure'; Protect = 'Protect-NegativeText'; Keys = 'error,innererror,additionalinfo,info,details' }
            )) {
                $reader = Get-DesktopFunctionAst $pair.Source $pair.Reader
                $allowlists = @($reader.FindAll({
                    param($node)
                    $node -is [System.Management.Automation.Language.ArrayLiteralAst] -and
                    $node.Elements.Count -ge 4 -and $node.Elements[0].Extent.Text -eq "'error'"
                }, $true))
                $allowlists.Count | Should -Be 1
                ($allowlists[0].Elements.Value -join ',') | Should -BeExactly $pair.Keys
                $reader.Extent.Text | Should -Match '\$Depth -gt 16'
                $failure = (Get-DesktopFunctionAst $pair.Source $pair.Failure).Extent.Text
                foreach ($field in @('Code', 'InnerCodes', 'StatusCode', 'RequestId', 'ExceptionType', 'ErrorId', 'Message', 'Errors')) {
                    $failure | Should -Match ([regex]::Escape($field) + '\s*=')
                }
                $protect = (Get-DesktopFunctionAst $pair.Source $pair.Protect).Extent.Text
                foreach ($token in @('Request', 'Response', 'Authorization', 'Bearer', 'token', 'password', 'accountkey', '[REDACTED]', '[Math]::Min(2048, $text.Length)')) {
                    $protect.Contains($token) | Should -Be $true
                }
                $protect | Should -Match '\[regex\]::Split'
                $protect | Should -Match '\[regex\]::Replace'
            }
        }
    }
    return
}
$harnessFunctionNames = @{
    'Invoke-CosmosRestoreScenario' = @(
        'Protect-FailureText', 'Get-SafeNativeFailure', 'Save-State', 'Get-ScenarioKeys',
        'Resolve-ScenarioIdentity', 'Initialize-ScenarioSelection', 'Get-CanonicalValue',
        'Get-CanonicalJson', 'Assert-Equal', 'Assert-Context', 'Get-Accounts',
        'Assert-OwnedAccount', 'Initialize-ScenarioAccount', 'Set-ScenarioDataRole',
        'Get-ExpectedInventory', 'Get-MutationInventory', 'Save-SubmittedJob',
        'Update-Job', 'Assert-JobNotFailed', 'Invoke-Restore'
    )
    'Invoke-CosmosRestoreNegativeTests' = @(
        'Protect-NegativeText', 'Get-NegativeFailure', 'Get-NegativeCases',
        'New-NegativeRow', 'Get-LocalRequestArguments'
    )
}
$harnessDefinitions = @(
    foreach ($sourceName in $harnessFunctionNames.Keys) {
        foreach ($functionName in $harnessFunctionNames[$sourceName]) {
            $functionDefinitions = @($harnessSources[$sourceName].FindAll({
                param($node)
                $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -eq $functionName
            }, $true))
            if ($functionDefinitions.Count -ne 1) { throw "Expected exactly one harness function: $functionName" }
            # Parse ONLY the named definition, preserving its original source path.
            # Using Body alone would lose inline function parameters. Never evaluate
            # the parent ScriptBlockAst (which contains live imports and entrypoints).
            $definitionTokens = $null
            $definitionErrors = $null
            $definitionAst = [System.Management.Automation.Language.Parser]::ParseInput(
                $functionDefinitions[0].Extent.Text, $functionDefinitions[0].Extent.File, [ref]$definitionTokens, [ref]$definitionErrors)
            if ($definitionErrors.Count -ne 0) { throw "Invalid extracted definition: $functionName" }
            $definitionAst.GetScriptBlock()
        }
    }
)

# Dedicated module scope prevents generic State/Record/Account variables and mocks
# from colliding with public cmdlets or the other 773 core regression cases.
if (Get-Module -Name CosmosRestoreHarness.Offline) { throw 'Harness isolation module is already loaded.' }
$harnessModule = New-Module -Name CosmosRestoreHarness.Offline -ArgumentList @($harnessDefinitions, $harnessSources) -ScriptBlock {
    param($Definitions, $Sources)
    foreach ($definition in $Definitions) { . $definition }
    $script:HarnessSources = $Sources

    # Local throwing stubs shadow installed commands AND prevent module autoload.
    # Even an incorrectly filtered mock cannot accidentally reach Azure or HTTP.
    $boundaries = @($Sources.Values | ForEach-Object {
        $_.FindAll({ param($node) $node -is [System.Management.Automation.Language.CommandAst] }, $true) |
            ForEach-Object { $_.GetCommandName() } |
            Where-Object { $_ -match '(^|\\)[\w-]+-Az|^Invoke-(WebRequest|RestMethod)$|^Start-Sleep$|^Import-Module$' }
    } | Select-Object -Unique)
    foreach ($boundary in $boundaries) {
        # Module-qualified negative helpers are intentionally NOT extracted for
        # execution. Their unqualified equivalents are nevertheless blocked.
        $name = ($boundary -split '\\')[-1]
        $stub = [scriptblock]::Create(@'
[CmdletBinding(SupportsShouldProcess = $true)]
param($ResourceGroupName, $Name, $ResourceId, $ApiVersion, $ResourceType,
      $ResourceName, $Location, $Kind, $PropertyObject, $Tag, $ApiKind,
      $DefaultConsistencyLevel, $BackupPolicyType, $ContinuousTier,
      $DisableLocalAuth, $EnableFreeTier, $AccountName, $Id, $PrincipalId,
      $RoleDefinitionId, $Scope, $SubscriptionId, $DatabaseName, $VaultName,
      $BackupInstanceName, $Parameter, $DatasourceType, $ResourceIdentifier,
      $RestoreRequest, $PermissionsScope, $VaultResourceGroup,
      [switch]$ExpandProperties, [switch]$Force)
throw 'Unexpected offline harness boundary; no cloud, HTTP, import or wait is allowed.'
'@)
        Set-Item -Path "Function:script:$name" -Value $stub
    }
    # InModuleScope can reach private functions. Export nothing: in particular do
    # not shadow the caller's Import-Module or Az commands outside this module.
    Export-ModuleMember -Function @()
}
Import-Module $harnessModule
try {
    InModuleScope CosmosRestoreHarness.Offline {
        Describe 'CosmosRestoreHarness' {
            function New-HarnessError([string] $Body, [string] $Message = 'Synthetic native failure') {
                $exception = New-Object System.InvalidOperationException $Message
                $record = New-Object System.Management.Automation.ErrorRecord -ArgumentList @(
                    $exception, 'OfflineHarness', [System.Management.Automation.ErrorCategory]::InvalidOperation, $null)
                $record.ErrorDetails = New-Object System.Management.Automation.ErrorDetails $Body
                return $record
            }

            BeforeEach {
                $script:SubscriptionId = '00000000-0000-0000-0000-000000000001'
                $script:ResourceGroupName = 'offline-harness'
                $script:VaultName = 'offline-vault'
                $script:TestPrefix = 'offline-12345678'
                $script:RestoreLocation = 'eastus'
                $script:AdditionalScenario = @()
                $script:RestoreUserAssignedIdentityArmId = $null
                $script:State = @{
                    RunId = 'offline-run'; PrincipalId = '00000000-0000-0000-0000-000000000002'; VaultPrincipalId = '00000000-0000-0000-0000-000000000003'
                    UserAssignedIdentityArmId = $null; Verified = $true
                    VaultId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DataProtection/backupVaults/$VaultName"
                    ScenarioOrder = @('full', 'single', 'database', 'mixed')
                    Accounts = [ordered]@{}; Restores = [ordered]@{}
                    Backup = @{ Status = 'Completed' }; RecoveryPointId = 'offline-point'
                    SourceInventory = @(
                        @{ Database = 'db1'; Containers = @(
                            @{ Name = 'cont1'; PartitionKey = @('/id'); Documents = @(@{ id = 'one'; nested = @{ keep = @('a', 'b') } }) }
                            @{ Name = 'col1'; PartitionKey = @('/id'); Documents = @() }
                            @{ Name = 'col2'; PartitionKey = @('/id'); Documents = @() }
                            @{ Name = 'excluded'; PartitionKey = @('/id'); Documents = @() }
                        ) }
                        @{ Database = 'db2'; Containers = @(
                            @{ Name = 'c1'; PartitionKey = @('/id'); Documents = @() }
                            @{ Name = 'c2'; PartitionKey = @('/id'); Documents = @() }
                        ) }
                        @{ Database = 'unselectedDB'; Containers = @(@{ Name = 'control'; PartitionKey = @('/id'); Documents = @() }) }
                    )
                }
                $selectors = @{ full = @(); single = @('db1/cont1'); database = @('db2'); mixed = @('db1/col1', 'db1/col2', 'db2') }
                foreach ($key in @('source', 'full', 'single', 'database', 'mixed')) {
                    $script:State.Accounts[$key] = @{
                        Name = "$TestPrefix-$key"; Status = 'Planned'; DataRoleId = '00000000-0000-0000-0000-000000000004'
                        Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/$TestPrefix-$key"
                    }
                    if ($key -ne 'source') {
                        $script:State.Restores[$key] = @{
                            Status = 'Planned'; JobId = $null; RequestJson = $null; Selectors = $selectors[$key]
                            Identity = @{ UseSystemAssignedIdentity = $true; UserAssignedIdentityArmId = $null; PrincipalId = $script:State.VaultPrincipalId }
                        }
                    }
                }
                $script:HarnessAccount = [pscustomobject]@{ Id = $script:State.Accounts.source.Id; Name = $script:State.Accounts.source.Name }
                # Deliberately no BackupPolicy/DisableLocalAuth getters on the old
                # native model. Ownership must consult expanded ARM properties.
                $script:HarnessResource = [pscustomobject]@{
                    Id = $script:HarnessAccount.Id; Name = $script:HarnessAccount.Name
                    Kind = 'GlobalDocumentDB'; Location = 'East US'; Tags = @{ CosmosRestoreRun = 'offline-run' }
                    Properties = @{
                        disableLocalAuth = $true; enableFreeTier = $false
                        backupPolicy = @{ type = 'Continuous'; continuousModeProperties = @{ tier = 'Continuous7Days' } }
                    }
                }
                $script:HarnessVault = [pscustomobject]@{ IdentityPrincipalId = $script:State.VaultPrincipalId }
                $script:HarnessRoles = @()
                $script:VaultArguments = @{}
                Mock Save-State {}
                Mock Assert-Context {}
                Mock Get-Accounts { throw 'Unexpected account inventory boundary.' }
                Mock Get-AzResource { $script:HarnessResource }
                Mock Get-AzCosmosDBAccount { $script:HarnessAccount }
                Mock Get-AzCosmosDBSqlRoleAssignment { $script:HarnessRoles }
            }

            Context 'Continuous account provisioning and expanded ownership' {
                It 'provisions Continuous7Days with a capable native Cosmos command' {
                    Mock Get-Accounts { @() }
                    Mock Get-Command { @{ Parameters = @{ DisableLocalAuth = @{}; ContinuousTier = @{}; EnableFreeTier = @{} } } } -ParameterFilter { $Name -eq 'New-AzCosmosDBAccount' }
                    Mock New-AzCosmosDBAccount {}
                    $result = Initialize-ScenarioAccount source
                    $result.Id | Should -Be $script:HarnessAccount.Id
                    $script:State.Accounts.source.Status | Should -Be 'Created'
                    Assert-MockCalled New-AzCosmosDBAccount -Exactly -Times 1 -Scope It -ParameterFilter {
                        $BackupPolicyType -eq 'Continuous' -and $ContinuousTier -eq 'Continuous7Days' -and
                        $DisableLocalAuth -eq $true -and $EnableFreeTier -eq $false -and $Tag.CosmosRestoreRun -eq 'offline-run'
                    }
                    Assert-MockCalled Save-State -Exactly -Times 2 -Scope It
                    Assert-MockCalled Get-AzResource -Exactly -Times 1 -Scope It -ParameterFilter { $ExpandProperties -and $ApiVersion -eq '2025-04-15' }
                }

                It 'uses the native ARM fallback when the older Cosmos command lacks capabilities' {
                    Mock Get-Accounts { @() }
                    Mock Get-Command { @{ Parameters = @{} } } -ParameterFilter { $Name -eq 'New-AzCosmosDBAccount' }
                    Mock New-AzResource {}
                    $null = Initialize-ScenarioAccount source
                    Assert-MockCalled New-AzResource -Exactly -Times 1 -Scope It -ParameterFilter {
                        $ResourceType -eq 'Microsoft.DocumentDB/databaseAccounts' -and $ApiVersion -eq '2025-04-15' -and
                        $Kind -eq 'GlobalDocumentDB' -and $PropertyObject.disableLocalAuth -eq $true -and
                        $PropertyObject.enableFreeTier -eq $false -and $PropertyObject.backupPolicy.type -eq 'Continuous' -and
                        $PropertyObject.backupPolicy.continuousModeProperties.tier -eq 'Continuous7Days'
                    }
                }

                It 'refuses <Situation> without a checkpoint or write' -TestCases @(
                    # Pester 4 -Throw matches a literal message substring, not a wildcard.
                    @{ Situation = 'a planned name collision'; Status = 'Planned'; Exists = $true; Message = 'name already exists' }
                    @{ Situation = 'a missing recorded account'; Status = 'Created'; Exists = $false; Message = 'recorded account is missing' }
                    @{ Situation = 'an ambiguous creation intent'; Status = 'Creating'; Exists = $false; Message = 'outcome is still ambiguous' }
                ) {
                    param($Situation, $Status, $Exists, $Message)
                    $script:State.Accounts.source.Status = $Status
                    $script:HarnessExists = $Exists
                    Mock Get-Accounts { if ($script:HarnessExists) { $script:HarnessAccount } }
                    { Initialize-ScenarioAccount source } | Should -Throw $Message
                    Assert-MockCalled Save-State -Times 0 -Exactly -Scope It
                }

                It 'rejects expanded ARM <Mismatch> without writing' -TestCases @(
                    @{ Mismatch = 'ownership' }
                    @{ Mismatch = 'local authentication' }
                    @{ Mismatch = 'Periodic backup' }
                    @{ Mismatch = 'wrong continuous tier' }
                    @{ Mismatch = 'free tier' }
                ) {
                    param($Mismatch)
                    switch ($Mismatch) {
                        'ownership' { $script:HarnessResource.Tags.CosmosRestoreRun = 'someone-else' }
                        'local authentication' { $script:HarnessResource.Properties.disableLocalAuth = $false }
                        'Periodic backup' { $script:HarnessResource.Properties.backupPolicy.type = 'Periodic' }
                        'wrong continuous tier' { $script:HarnessResource.Properties.backupPolicy.continuousModeProperties.tier = 'Continuous30Days' }
                        'free tier' { $script:HarnessResource.Properties.enableFreeTier = $true }
                    }
                    $message = if ($Mismatch -in @('wrong continuous tier', 'free tier')) { 'settings differ' } else { 'assertion failed' }
                    { Assert-OwnedAccount $script:HarnessAccount $script:State.Accounts.source } | Should -Throw $message
                    Assert-MockCalled Save-State -Times 0 -Exactly -Scope It
                }
            }

            Context 'Cosmos SQL data role reuse' {
                BeforeEach {
                    $record = $script:State.Accounts.source
                    $script:HarnessRoles = @([pscustomobject]@{
                        Id = "$($record.Id)/sqlRoleAssignments/$($record.DataRoleId)"
                        PrincipalId = $script:State.PrincipalId; Scope = $record.Id
                        RoleDefinitionId = "$($record.Id)/sqlRoleDefinitions/00000000-0000-0000-0000-000000000002"
                    })
                }
                It 'reuses the correct data contributor role without any role write' {
                    Set-ScenarioDataRole source
                    $script:State.Accounts.source.DataRoleAssigned | Should -Be $true
                    Assert-MockCalled Save-State -Times 1 -Exactly -Scope It
                    # New-AzCosmosDBSqlRoleAssignment remains a throwing stub.
                }
                It 'rejects a persisted role with the wrong principal without writes' {
                    $script:HarnessRoles[0].PrincipalId = '00000000-0000-0000-0000-000000000005'
                    { Set-ScenarioDataRole source } | Should -Throw 'does not match'
                    Assert-MockCalled Save-State -Times 0 -Exactly -Scope It
                }
            }

            Context 'Allowlisted failure diagnostics' {
                It 'retains positive native codes only from currently promised error paths' {
                    # info is intentionally tested below on the negative sanitizer:
                    # the positive sanitizer currently does not traverse that path.
                    # Keep the multi-code contract: Read-NativeError constructs ordered
                    # dictionaries internally. A Select-Object -ExpandProperty Code
                    # failure there is a harness defect, not an ErrorRecord fixture issue.
                    $errorRecord = New-HarnessError '{"error":{"code":"Outer","details":[{"code":"Detail"}],"additionalInfo":[{"innerError":"{\"code\":\"Inner\"}"}]},"request":{"code":"NeverRetain","token":"secret-value"}}'
                    $safe = Get-SafeNativeFailure $errorRecord
                    $safe.Code | Should -Be 'Outer'
                    ($safe.InnerCodes -join ',') | Should -Be 'Inner,Detail'
                    ($safe | ConvertTo-Json -Depth 20) | Should -Not -Match 'NeverRetain|secret-value'
                }
                It 'retains negative additionalInfo info JSON and nested case-variant innererror codes' {
                    $errorRecord = New-HarnessError '{"error":{"code":"Outer","additionalInfo":[{"info":"{\"INNERERROR\":{\"code\":\"Inner\",\"message\":\"token=hidden-token\"}}"}]},"headers":{"code":"NeverRetain","Authorization":"hidden-header"}}'
                    $safe = Get-NegativeFailure $errorRecord
                    $safe.Code | Should -Be 'Outer'
                    @($safe.InnerCodes).Count | Should -Be 1
                    $safe.InnerCodes[0] | Should -Be 'Inner'
                    ($safe | ConvertTo-Json -Depth 20) | Should -Not -Match 'hidden-token|hidden-header|NeverRetain'
                }
                It 'redacts <Kind> in both sanitizers' -TestCases @(
                    @{ Kind = 'URL queries'; Text = 'failed https://example.invalid/path?sig=hidden-query'; Secret = 'hidden-query' }
                    @{ Kind = 'bearer credentials'; Text = 'failed Bearer hidden-bearer'; Secret = 'hidden-bearer' }
                    @{ Kind = 'named tokens'; Text = 'failed accessToken="hidden-token"'; Secret = 'hidden-token' }
                ) {
                    param($Kind, $Text, $Secret)
                    foreach ($command in @('Protect-FailureText', 'Protect-NegativeText')) {
                        $safe = & $command $Text
                        $safe | Should -Not -Match $Secret
                        $safe | Should -Match '\[REDACTED\]'
                    }
                }
                It 'preserves an already sanitized native document failure without reserializing it' {
                    $errorRecord = New-HarnessError '{}'
                    $expected = @{ Code = 'SafeCode'; Message = 'safe' }
                    $errorRecord.Exception.Data['SafeFailure'] = $expected
                    [object]::ReferenceEquals((Get-SafeNativeFailure $errorRecord), $expected) | Should -Be $true
                }
                It 'caps messages and discards request dumps and malformed error bodies in both sanitizers' {
                    foreach ($command in @('Protect-FailureText', 'Protect-NegativeText')) {
                        (& $command ('short ' * 600)).Length | Should -Be 2048
                        (& $command 'safe summary Request Body: hidden-body') | Should -Be 'safe summary'
                    }
                    $errorRecord = New-HarnessError 'not JSON: hidden-body'
                    foreach ($command in @('Get-SafeNativeFailure', 'Get-NegativeFailure')) {
                        $safe = & $command $errorRecord
                        @($safe.Errors).Count | Should -Be 0
                        ($safe | ConvertTo-Json -Depth 20) | Should -Not -Match 'hidden-body'
                    }
                }
            }

            Context 'Submission checkpoints' {
                It 'saves a bare native job name once' {
                    $record = @{ Status = 'Submitting'; JobId = $null }
                    Save-SubmittedJob ([pscustomobject]@{ JobId = 'offline-job-1' }) $record
                    $record.JobId | Should -Be 'offline-job-1'
                    $record.JobResourceId | Should -Be "$($script:State.VaultId)/backupJobs/offline-job-1"
                    $record.Status | Should -Be 'Submitted'
                    Assert-MockCalled Save-State -Exactly -Times 1 -Scope It
                }
                It 'normalizes an ARM job ID from the same vault' {
                    $record = @{ Status = 'Submitting'; JobId = $null }
                    Save-SubmittedJob ([pscustomobject]@{ JobId = "$($script:State.VaultId.ToUpperInvariant())/backupJobs/offline-job-2" }) $record
                    $record.JobId | Should -Be 'offline-job-2'
                    Assert-MockCalled Save-State -Exactly -Times 1 -Scope It
                }
                It 'rejects <Invalid> while leaving submission ambiguous and unsaved' -TestCases @(
                    @{ Invalid = 'an unusable job ID'; JobId = 'invalid?job' }
                    @{ Invalid = 'another vault'; JobId = '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.DataProtection/backupVaults/other/backupJobs/job-1' }
                ) {
                    param($Invalid, $JobId)
                    $record = @{ Status = 'Submitting'; JobId = $null }
                    { Save-SubmittedJob ([pscustomobject]@{ JobId = $JobId }) $record } | Should -Throw
                    $record.Status | Should -Be 'Submitting'
                    $record.JobId | Should -BeNullOrEmpty
                    Assert-MockCalled Save-State -Exactly -Times 0 -Scope It
                }
            }

            Context 'Sequential restore pending returns' {
                It 'takes one snapshot and returns before provisioning when status is <Status>' -TestCases @(
                    @{ Status = 'InProgress' }
                    @{ Status = 'Paused' }
                    @{ Status = 'Unknown' }
                ) {
                    param($Status)
                    $script:HarnessJobStatus = $Status
                    $script:State.Restores.full.JobId = 'offline-job'
                    Mock Update-Job { $Record.Status = $script:HarnessJobStatus }
                    Mock Initialize-ScenarioAccount { throw 'Must not provision while pending.' }
                    Mock Set-ScenarioDataRole { throw 'Must not assign roles while pending.' }
                    Invoke-Restore
                    Assert-MockCalled Update-Job -Exactly -Times 1 -Scope It -ParameterFilter { $ExpectedCategory -eq 'Restore' }
                    Assert-MockCalled Initialize-ScenarioAccount -Exactly -Times 0 -Scope It
                    Assert-MockCalled Set-ScenarioDataRole -Exactly -Times 0 -Scope It
                    Assert-MockCalled Save-State -Exactly -Times 0 -Scope It
                }
                It 'rejects an ambiguous restore intent before reaching a target boundary' {
                    $script:State.Restores.single.Status = 'Submitting'
                    Mock Update-Job { throw 'No submitted job exists.' }
                    Mock Initialize-ScenarioAccount { throw 'Must not provision an ambiguous run.' }
                    { Invoke-Restore } | Should -Throw 'ambiguous'
                    Assert-MockCalled Initialize-ScenarioAccount -Exactly -Times 0 -Scope It
                }
            }

            Context 'Per-case inventory union and backup baseline' {
                It 'returns non-nested arrays for <Case> selections' -TestCases @(
                    @{ Case = 'single'; Databases = 'db1'; Containers = 'cont1'; Count = 1 }
                    @{ Case = 'database'; Databases = 'db2'; Containers = 'c1,c2'; Count = 1 }
                    @{ Case = 'mixed'; Databases = 'db1,db2'; Containers = 'col1,col2,c1,c2'; Count = 2 }
                ) {
                    param($Case, $Databases, $Containers, $Count)
                    $result = Get-ExpectedInventory $Case
                    $result -is [array] | Should -Be $true
                    $result.Length | Should -Be $Count
                    ($result | ForEach-Object { $_.Database }) -join ',' | Should -Be $Databases
                    ($result | ForEach-Object { $_.Containers } | ForEach-Object { $_.Name }) -join ',' | Should -Be $Containers
                    $result[0].Containers -is [array] | Should -Be $true
                }
                It 'excludes post-backup churn from all restore inventories without mutating the baseline' {
                    $before = Get-CanonicalJson $script:State.SourceInventory
                    $script:State.Mutation = @{ Document = @{ id = 'afterBackup' } }
                    $script:State.CurrentSourceInventory = Get-MutationInventory -IncludeDocument
                    foreach ($key in Get-ScenarioKeys) {
                        $result = Get-ExpectedInventory $key
                        @($result | ForEach-Object { $_.Containers } | Where-Object { $_.Name -ceq 'afterBackup' }).Count | Should -Be 0
                    }
                    @($script:State.CurrentSourceInventory | ForEach-Object { $_.Containers } | Where-Object { $_.Name -ceq 'afterBackup' }).Count | Should -Be 1
                    (Get-CanonicalJson $script:State.SourceInventory) | Should -Be $before
                }
            }

            Context 'Optional scenario state invariants' {
                It 'appends unique opt-ins once in canonical order and retains them when later omitted' {
                    Mock Get-Accounts { @() }
                    $script:AdditionalScenario = @('multiDatabase', 'containers', 'containers')
                    Initialize-ScenarioSelection $script:HarnessVault
                    (@(Get-ScenarioKeys) -join ',') | Should -Be 'full,single,database,mixed,containers,multiDatabase'
                    $script:State.Verified | Should -Be $false
                    $before = Get-CanonicalJson $script:State
                    $script:AdditionalScenario = @()
                    Initialize-ScenarioSelection $script:HarnessVault
                    (Get-CanonicalJson $script:State) | Should -Be $before
                    Assert-MockCalled Get-Accounts -Exactly -Times 1 -Scope It
                }
                It 'rejects duplicate persisted order without changing state' {
                    $script:State.ScenarioOrder += 'mixed'
                    $before = Get-CanonicalJson $script:State
                    { Initialize-ScenarioSelection $script:HarnessVault } | Should -Throw 'duplicated'
                    (Get-CanonicalJson $script:State) | Should -Be $before
                    Assert-MockCalled Get-Accounts -Exactly -Times 0 -Scope It
                }
                It 'checks all optional name collisions before mutating the selected case set' {
                    $script:AdditionalScenario = @('containers', 'multiDatabase')
                    Mock Get-Accounts { [pscustomobject]@{ Name = "$script:TestPrefix-multiDatabase" } }
                    $before = Get-CanonicalJson $script:State
                    { Initialize-ScenarioSelection $script:HarnessVault } | Should -Throw 'Refusing to adopt'
                    (Get-CanonicalJson $script:State) | Should -Be $before
                }
                It 'rejects changed selectors without mutating the persisted run' {
                    $script:State.Restores.single.Selectors = @('db1/other')
                    $before = Get-CanonicalJson $script:State
                    { Initialize-ScenarioSelection $script:HarnessVault } | Should -Throw 'immutable single selectors'
                    (Get-CanonicalJson $script:State) | Should -Be $before
                }
                It 'requires an explicit identity for the optional UAMI case before any selection mutation' {
                    $script:AdditionalScenario = @('containers', 'uami')
                    $before = Get-CanonicalJson $script:State
                    { Initialize-ScenarioSelection $script:HarnessVault } | Should -Throw 'requires RestoreUserAssignedIdentityArmId'
                    (Get-CanonicalJson $script:State) | Should -Be $before
                    Assert-MockCalled Get-Accounts -Exactly -Times 0 -Scope It
                }
            }

            Context 'Negative case tables and local request arguments' {
                It 'keeps nine distinct benchmarks and treats star/comma names literally' {
                    $cases = @(Get-NegativeCases 'db*/container,one' 'absent*/container,two')
                    $cases.Count | Should -Be 9
                    @($cases.CaseId | Select-Object -Unique).Count | Should -Be 9
                    ($cases | Where-Object CaseId -EQ B11).Identifiers[0] | Should -Be 'db*/container,one/item'
                    ($cases | Where-Object CaseId -EQ Nonexistent).Identifiers[0] | Should -Be 'absent*/container,two'
                    @(($cases | Where-Object CaseId -EQ Count51).Identifiers).Count | Should -Be 51
                    $row = New-NegativeRow $cases[0] 'Client'
                    $row.NoJob | Should -Be $true
                    $row.RestoreSubmitted | Should -Be $false
                    $row.NativeCall | Should -Be $false
                }
                It 'uses a local RP placeholder and preserves saved UAMI without cloud lookup or state mutation' {
                    $script:State.RecoveryPointId = $null
                    $script:State.UserAssignedIdentityArmId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/offline-uami"
                    $script:LocalTargetId = $script:State.Accounts.single.Id
                    $before = Get-CanonicalJson $script:State
                    $arguments = Get-LocalRequestArguments
                    $arguments.RecoveryPoint | Should -Be 'local-only-no-completed-recovery-point'
                    $arguments.UseSystemAssignedIdentity | Should -Be $false
                    $arguments.UserAssignedIdentityArmId | Should -Be $script:State.UserAssignedIdentityArmId
                    (Get-CanonicalJson $script:State) | Should -Be $before
                }
            }

            Context 'Targets phase and negative entrypoint AST safety only' {
                It 'limits Targets to account/role provisioning and empty inventory with a submitted-job guard' {
                    $switches = @($script:HarnessSources['Invoke-CosmosRestoreScenario'].FindAll({
                        param($node) $node -is [System.Management.Automation.Language.SwitchStatementAst] -and $node.Condition.Extent.Text -eq '$Phase'
                    }, $true))
                    $switches.Count | Should -Be 1
                    $clauses = @($switches[0].Clauses | Where-Object { $_.Item1.Value -eq 'Targets' })
                    $clauses.Count | Should -Be 1
                    $body = $clauses[0].Item2
                    $commands = @($body.FindAll({ param($node) $node -is [System.Management.Automation.Language.CommandAst] }, $true) | ForEach-Object { $_.GetCommandName() })
                    ($commands -join ',') | Should -Be 'Get-ScenarioKeys,Initialize-ScenarioAccount,Set-ScenarioDataRole,Get-AzCosmosDBSqlDatabase'
                    $body.Extent.Text | Should -Match '\.JobId\)\s*\{\s*continue\s*\}'
                    $body.Extent.Text | Should -Match '\.Count -ne 0'
                    $body.Extent.Text | Should -Match 'throw'
                }
                It 'contains no restore trigger, backup, context switch or resource write in the negative harness' {
                    $commands = @($script:HarnessSources['Invoke-CosmosRestoreNegativeTests'].FindAll({
                        param($node) $node -is [System.Management.Automation.Language.CommandAst]
                    }, $true) | ForEach-Object { $_.GetCommandName() })
                    @($commands | Where-Object { $_ -match '(^|\\)(Start-Az|Backup-Az|Set-Az|Connect-Az|Remove-Az|New-AzResource|New-AzCosmos|Invoke-AzRestMethod)' }).Count | Should -Be 0
                    $commands | Should -Contain 'Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore'
                }
            }
        }
    }
} finally {
    Remove-Module $harnessModule -Force
}