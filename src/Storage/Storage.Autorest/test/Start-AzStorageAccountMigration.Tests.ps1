if(($null -eq $TestName) -or ($TestName -contains 'Start-AzStorageAccountMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzStorageAccountMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzStorageAccountMigration' {
    # Start-AzStorageAccountMigration takes 5 days to 2 months to run, so will cover the tests locally and skip the tests here
    It 'CustomerExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CustomerViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CustomerViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CustomerViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    InModuleScope 'Az.Storage.custom' {
        Context 'Change Safety forwarding' {
            BeforeAll {
                $script:migrationWrapper = (Get-Command Start-AzStorageAccountMigration -ErrorAction Stop).ScriptBlock
                $script:migrationCommands = @{}
                foreach ($variant in 'StartExpanded', 'StartViaIdentityExpanded', 'StartViaJsonFilePath', 'StartViaJsonString') {
                    $commandName = "Az.Storage.private\Start-AzStorageAccountMigration_$variant"
                    $script:migrationCommands[$commandName] = Get-Command -Name $commandName -ErrorAction Stop
                }
                $writeCommand = Get-Command 'Az.Storage.internal\Start-AzStorageAccountMigration' -ErrorAction Stop
                $metadata = [System.Management.Automation.CommandMetadata]$writeCommand
                foreach ($parameter in $writeCommand.Parameters.Values | Where-Object IsDynamic) {
                    $copy = [System.Management.Automation.ParameterMetadata]::new($parameter.Name, $parameter.ParameterType)
                    foreach ($attribute in $parameter.Attributes) {
                        $copy.Attributes.Add($attribute)
                    }
                    $metadata.Parameters.Add($parameter.Name, $copy)
                }
                # Materialize dynamic metadata: Pester 4 cannot replay this generated proxy's dynamicparam block.
                $parameterBlock = [System.Management.Automation.ProxyCommand]::GetParamBlock($metadata)
                $capture = @'
process {
    $parameters = @{}
    foreach ($entry in $PSBoundParameters.GetEnumerator()) {
        $parameters[$entry.Key] = $entry.Value
    }
    $script:migrationCalls += @{ ParameterSet = $PSCmdlet.ParameterSetName; Parameters = $parameters }
}
'@
                $mockWrite = [scriptblock]::Create("[CmdletBinding(DefaultParameterSetName='StartExpanded', SupportsShouldProcess)] param($parameterBlock) $capture")
                Set-Item -Path Function:script:Invoke-MigrationWrite -Value $mockWrite
                Set-Alias -Name 'Az.Storage.internal\Start-AzStorageAccountMigration' -Value Invoke-MigrationWrite -Scope Script
            }

            AfterAll {
                Remove-Item -LiteralPath 'Alias:Az.Storage.internal\Start-AzStorageAccountMigration'
                Remove-Item -LiteralPath Function:Invoke-MigrationWrite
            }

            BeforeEach {
                $script:migrationCalls = @()
                Mock Get-Command {
                    $script:migrationCommands[$Name]
                } -ParameterFilter { $Name -like 'Az.Storage.private\Start-AzStorageAccountMigration_*' }
            }

            $testCases = foreach ($route in @(
                @{ Public = 'CustomerExpanded'; Private = 'StartExpanded' }
                @{ Public = 'CustomerViaIdentityExpanded'; Private = 'StartViaIdentityExpanded' }
                @{ Public = 'CustomerViaJsonFilePath'; Private = 'StartViaJsonFilePath' }
                @{ Public = 'CustomerViaJsonString'; Private = 'StartViaJsonString' }
            )) {
                foreach ($scenario in @(
                    @{ Name = 'unbound parameters'; Parameters = @{} }
                    @{ Name = 'policy token'; Parameters = @{ AcquirePolicyToken = $true } }
                    @{ Name = 'explicitly false policy token'; Parameters = @{ AcquirePolicyToken = $false } }
                    @{ Name = 'change reference'; Parameters = @{ ChangeReference = 'change-safety-test' } }
                    @{ Name = 'both parameters'; Parameters = @{ AcquirePolicyToken = $true; ChangeReference = 'change-safety-test' } }
                )) {
                    @{
                        PublicSet = $route.Public
                        PrivateSet = $route.Private
                        Scenario = $scenario.Name
                        ChangeSafety = $scenario.Parameters
                    }
                }
            }

            It 'maps <PublicSet> to <PrivateSet> and forwards <Scenario>' -TestCases $testCases {
                param($PublicSet, $PrivateSet, $Scenario, $ChangeSafety)
                $parameters = @{ Force = $true; Confirm = $false }
                if ($PublicSet -eq 'CustomerViaIdentityExpanded') {
                    $parameters.InputObject = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.StorageIdentity]@{
                        Id = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/change-safety/providers/Microsoft.Storage/storageAccounts/migrationtest'
                    }
                } else {
                    $parameters.SubscriptionId = '00000000-0000-0000-0000-000000000001'
                    $parameters.ResourceGroupName = 'change-safety'
                    $parameters.AccountName = 'migrationtest'
                }
                switch ($PublicSet) {
                    'CustomerViaJsonFilePath' { $parameters.JsonFilePath = Join-Path $TestDrive 'migration.json' }
                    'CustomerViaJsonString' { $parameters.JsonString = '{"properties":{"targetSkuName":"Standard_ZRS"}}' }
                    default { $parameters.TargetSku = 'Standard_ZRS' }
                }
                foreach ($entry in $ChangeSafety.GetEnumerator()) {
                    $parameters[$entry.Key] = $entry.Value
                }

                & $script:migrationWrapper @parameters

                $expectedCommand = "Az.Storage.private\Start-AzStorageAccountMigration_$PrivateSet"
                Assert-MockCalled Get-Command -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $expectedCommand }
                Assert-MockCalled Get-Command -Times 0 -Exactly -Scope It -ParameterFilter {
                    $Name -like 'Az.Storage.private\Start-AzStorageAccountMigration_*' -and $Name -ne $expectedCommand
                }
                $script:migrationCalls.Count | Should -Be 1
                $call = $script:migrationCalls[0]
                $call.ParameterSet | Should -Be $PrivateSet
                $call.Parameters.ContainsKey('Force') | Should -Be $false
                foreach ($name in 'AcquirePolicyToken', 'ChangeReference') {
                    $call.Parameters.ContainsKey($name) | Should -Be ($ChangeSafety.ContainsKey($name))
                    if ($ChangeSafety.ContainsKey($name)) {
                        $call.Parameters[$name] | Should -Be $ChangeSafety[$name]
                    }
                }
            }
        }
    }
}
