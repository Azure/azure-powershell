# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Start a scenario run for a scenario configuration.
.Description
Start a scenario run for a scenario configuration. This is a workflow cmdlet: it
validates the scenario configuration first and starts the run only if validation
succeeds, mirroring the Azure Portal where validation precedes the Run action. Pass
-SkipValidation to bypass the pre-flight check. For a catalog (non-custom) scenario
the workspace must have been evaluated before a run can start; if it has not, the
cmdlet fails with a friendly error and does not trigger evaluation as a side effect.
.Example
Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg
.Example
Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -SkipValidation -NoWait
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioRun
Microsoft.Azure.PowerShell.Cmdlets.Chaos.Runtime.PowerShell.AsyncOperationResponse
.Link
https://learn.microsoft.com/powershell/module/az.chaos/start-azchaosscenariorun
#>
function Start-AzChaosScenarioRun {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioRun', 'Microsoft.Azure.PowerShell.Cmdlets.Chaos.Runtime.PowerShell.AsyncOperationResponse')]
    [CmdletBinding(DefaultParameterSetName='StartExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the scenario configuration to run.')]
        [Alias('ScenarioConfigurationName')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage='Name of the scenario.')]
        [System.String]
        ${ScenarioName},

        [Parameter(Mandatory, HelpMessage='Name of the workspace.')]
        [System.String]
        ${WorkspaceName},

        [Parameter(Mandatory, HelpMessage='Name of the resource group.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The ID of the target subscription.')]
        [System.String]
        ${SubscriptionId},

        [Parameter(HelpMessage='Bypass the pre-flight validation of the scenario configuration.')]
        [System.Management.Automation.SwitchParameter]
        ${SkipValidation},

        [Parameter(HelpMessage='Run the command asynchronously and return before the scenario run completes.')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},

        [Parameter(HelpMessage='The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.')]
        [Alias('AzureRMContext','AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )

    process {
        # Emit errors through $PSCmdlet so PowerShell attributes them to the cmdlet and
        # the caller's own command line. A bare `throw` or `Write-Error` raised inside one
        # of the private helpers below reports this file's path, line number and the
        # private function's name instead -- none of which the caller can act on. See
        # DEV-040 in the deviation log.
        function New-AzChaosErrorRecord {
            param(
                [string]$Message,
                [string]$ErrorId,
                [System.Management.Automation.ErrorCategory]$Category = [System.Management.Automation.ErrorCategory]::InvalidOperation,
                [object]$TargetObject
            )

            return [System.Management.Automation.ErrorRecord]::new(
                [System.InvalidOperationException]::new($Message),
                $ErrorId,
                $Category,
                $TargetObject)
        }

        function Get-AzChaosObjectPropertyValue {
            param(
                [object]$InputObject,
                [string[]]$Name
            )

            if ($null -eq $InputObject) {
                return $null
            }

            foreach ($candidate in $Name) {
                $property = $InputObject.PSObject.Properties[$candidate]
                if ($null -ne $property) {
                    return $property.Value
                }
            }

            $properties = $InputObject.PSObject.Properties['Properties']
            if ($null -ne $properties -and $null -ne $properties.Value -and -not [object]::ReferenceEquals($InputObject, $properties.Value)) {
                foreach ($candidate in $Name) {
                    $property = $properties.Value.PSObject.Properties[$candidate]
                    if ($null -ne $property) {
                        return $property.Value
                    }
                }
            }

            return $null
        }

        function Get-AzChaosValidationErrorCollection {
            param(
                [object]$Validation,
                [string[]]$Name
            )

            $errors = @(ConvertTo-AzChaosCollection -InputObject (Get-AzChaosObjectPropertyValue -InputObject $Validation -Name $Name) | Where-Object { $null -ne $_ })
            if ($errors.Count -gt 0) {
                return $errors
            }

            $validationErrors = Get-AzChaosObjectPropertyValue -InputObject $Validation -Name @('ValidationErrors')
            if ($null -ne $validationErrors) {
                return @(ConvertTo-AzChaosCollection -InputObject (Get-AzChaosObjectPropertyValue -InputObject $validationErrors -Name $Name) | Where-Object { $null -ne $_ })
            }

            return @()
        }

        function ConvertTo-AzChaosCollection {
            param([object]$InputObject)

            if ($null -eq $InputObject) {
                return @()
            }

            if ($InputObject -is [string]) {
                return @($InputObject)
            }

            if ($InputObject -is [System.Collections.IEnumerable]) {
                return @($InputObject)
            }

            return @($InputObject)
        }

        function Test-AzChaosErrorObjectHasContent {
            param(
                [object]$InputObject,
                [string[]]$Name
            )

            if ($null -eq $InputObject) {
                return $false
            }

            foreach ($candidate in $Name) {
                $value = Get-AzChaosObjectPropertyValue -InputObject $InputObject -Name @($candidate)
                if ($value -is [System.Collections.IEnumerable] -and $value -isnot [string]) {
                    if (@($value | Where-Object { -not [System.String]::IsNullOrWhiteSpace([string]$_) }).Count -gt 0) {
                        return $true
                    }
                }
                elseif (-not [System.String]::IsNullOrWhiteSpace([string]$value)) {
                    return $true
                }
            }

            return $false
        }

        function Test-AzChaosValidationHasPermissionOnlyErrors {
            param([object]$Validation)

            $permissionErrors = @(Get-AzChaosValidationErrorCollection -Validation $Validation -Name @('ErrorPermission', 'ValidationErrorPermission', 'Permission') | Where-Object { Test-AzChaosErrorObjectHasContent -InputObject $_ -Name @('ResourceId', 'MissingPermission', 'MissingPermissions', 'RecommendedRole', 'RecommendedRoles') })
            $resourceErrors = @(Get-AzChaosValidationErrorCollection -Validation $Validation -Name @('ErrorResource', 'ValidationErrorResource', 'Resource') | Where-Object { Test-AzChaosErrorObjectHasContent -InputObject $_ -Name @('ResourceId', 'ErrorMessage', 'Message') })
            $operationErrors = @(ConvertTo-AzChaosCollection -InputObject (Get-AzChaosObjectPropertyValue -InputObject $Validation -Name @('Errors', 'Error')) | Where-Object { Test-AzChaosErrorObjectHasContent -InputObject $_ -Name @('ErrorCode', 'Code', 'ErrorMessage', 'Message') })
            $retryableOperationErrorCodes = @(
                # Chaos.Workspaces.Worker/ErrorCodes.cs emits this as the typed summary for RBAC validation failures.
                'ScenarioExecutionRbacValidationError'
            )
            $blockingOperationErrors = @($operationErrors | Where-Object {
                $code = Get-AzChaosObjectPropertyValue -InputObject $_ -Name @('ErrorCode', 'Code')
                $code -notin $retryableOperationErrorCodes
            })

            return ($permissionErrors.Count -gt 0 -and $resourceErrors.Count -eq 0 -and $blockingOperationErrors.Count -eq 0)
        }

        function Format-AzChaosValidationFailure {
            param(
                [string]$ScenarioConfigurationName,
                [object]$Validation
            )

            $status = Get-AzChaosObjectPropertyValue -InputObject $Validation -Name @('Status')
            $details = @()

            foreach ($permissionError in @(Get-AzChaosValidationErrorCollection -Validation $Validation -Name @('ErrorPermission', 'ValidationErrorPermission', 'Permission'))) {
                $resourceId = Get-AzChaosObjectPropertyValue -InputObject $permissionError -Name @('ResourceId')
                $missingPermissions = @(Get-AzChaosObjectPropertyValue -InputObject $permissionError -Name @('MissingPermission', 'MissingPermissions'))
                $recommendedRoles = @(Get-AzChaosObjectPropertyValue -InputObject $permissionError -Name @('RecommendedRole', 'RecommendedRoles'))
                $details += "Permission error on '$resourceId'. Missing permissions: $($missingPermissions -join ', '). Recommended roles: $($recommendedRoles -join ', ')."
            }

            foreach ($resourceError in @(Get-AzChaosValidationErrorCollection -Validation $Validation -Name @('ErrorResource', 'ValidationErrorResource', 'Resource'))) {
                $resourceId = Get-AzChaosObjectPropertyValue -InputObject $resourceError -Name @('ResourceId')
                $message = Get-AzChaosObjectPropertyValue -InputObject $resourceError -Name @('ErrorMessage')
                $details += "Resource error on '$resourceId'. $message"
            }

            foreach ($operationError in @(Get-AzChaosObjectPropertyValue -InputObject $Validation -Name @('Errors', 'Error') | Where-Object { $null -ne $_ })) {
                $code = Get-AzChaosObjectPropertyValue -InputObject $operationError -Name @('Code', 'ErrorCode')
                $message = Get-AzChaosObjectPropertyValue -InputObject $operationError -Name @('Message', 'ErrorMessage')
                $details += "Operation error '$code'. $message"
            }

            if ($details.Count -eq 0) {
                $details += 'No detailed validation errors were returned.'
            }

            return "Validation for scenario configuration '$ScenarioConfigurationName' returned status '$status'. The scenario run was not started. $($details -join ' ') Fix the validation errors, or re-run with -SkipValidation to bypass the pre-flight check."
        }

        function Invoke-AzChaosScenarioConfigurationValidationWithRetry {
            param(
                [hashtable]$CommonParameter,
                [string]$ScenarioName,
                [string]$ScenarioConfigurationName
            )

            # Keep status list in sync with generated\api\Models\ValidationProperties.cs:163.
            $knownStatuses = @('Resolving', 'Generating', 'Validating', 'Accepted', 'NotStarted', 'RequiresAttention', 'NoResolvedResources', 'Succeeded')
            $retryIntervalSeconds = 15
            # 21 attempts: the initial validation plus twenty retries, so five minutes of
            # RBAC propagation. Sized from a measured worst case of 222 seconds between a
            # successful permission repair and validation clearing; the previous 90-second
            # budget was under half of that and failed a repair-then-run sequence that
            # would have succeeded. See DEV-041 in the deviation log.
            $maxAttempts = 21

            for ($attempt = 1; $attempt -le $maxAttempts; $attempt++) {
                $validation = Test-AzChaosScenarioConfiguration @CommonParameter -ScenarioName $ScenarioName -Name $ScenarioConfigurationName -ErrorAction Stop
                if ($validation -is [bool]) {
                    if ($validation) {
                        return $validation
                    }

                    $PSCmdlet.WriteError((New-AzChaosErrorRecord `
                        -Message "Validation failed for scenario configuration '$ScenarioConfigurationName'. The scenario run was not started. Fix the reported validation errors, or re-run with -SkipValidation to bypass the pre-flight check." `
                        -ErrorId 'ScenarioConfigurationValidationFailed' `
                        -TargetObject $ScenarioConfigurationName))
                    return $null
                }

                $status = Get-AzChaosObjectPropertyValue -InputObject $validation -Name @('Status')
                if ($status -eq 'Succeeded') {
                    return $validation
                }

                if ([System.String]::IsNullOrEmpty($status) -or $status -notin $knownStatuses) {
                    $PSCmdlet.ThrowTerminatingError((New-AzChaosErrorRecord `
                        -Message "Validation for scenario configuration '$ScenarioConfigurationName' returned unrecognized status '$status'. The scenario run was not started." `
                        -ErrorId 'ScenarioConfigurationValidationUnrecognizedStatus' `
                        -TargetObject $ScenarioConfigurationName))
                }

                $permissionOnly = Test-AzChaosValidationHasPermissionOnlyErrors -Validation $validation
                $shouldRetry = ($status -in @('Resolving', 'Generating', 'Validating', 'Accepted', 'NotStarted')) -or ($status -eq 'RequiresAttention' -and $permissionOnly)
                if (-not $shouldRetry -or $attempt -eq $maxAttempts) {
                    $PSCmdlet.WriteError((New-AzChaosErrorRecord `
                        -Message (Format-AzChaosValidationFailure -ScenarioConfigurationName $ScenarioConfigurationName -Validation $validation) `
                        -ErrorId 'ScenarioConfigurationValidationFailed' `
                        -TargetObject $ScenarioConfigurationName))
                    return $null
                }

                if ($status -eq 'RequiresAttention') {
                    Write-Verbose "Validation for scenario configuration '$ScenarioConfigurationName' reported permission-only errors. Waiting $retryIntervalSeconds seconds for RBAC propagation before retrying validation."
                }
                else {
                    Write-Verbose "Validation for scenario configuration '$ScenarioConfigurationName' returned status '$status'. Waiting $retryIntervalSeconds seconds before retrying validation."
                }
                Start-Sleep -Seconds $retryIntervalSeconds
            }
        }

        # Parameters common to every plumbing call. ScenarioName is added per call because
        # Get-AzChaosScenario exposes the scenario name as -Name, not -ScenarioName.
        $common = @{
            ResourceGroupName = $ResourceGroupName
            WorkspaceName     = $WorkspaceName
        }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $common['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $common['DefaultProfile'] = $DefaultProfile }

        # Step 1: validate the scenario configuration first, unless bypassed.
        if (-not $SkipValidation) {
            $validation = Invoke-AzChaosScenarioConfigurationValidationWithRetry -CommonParameter $common -ScenarioName $ScenarioName -ScenarioConfigurationName $Name
            if ($null -eq $validation) {
                return
            }
        }

        # Step 2: guard catalog (non-custom) scenarios that the workspace has not evaluated.
        # A catalog scenario carries a CreatedFrom template reference; a run needs a prior
        # workspace evaluation. Do not trigger evaluation here as a side effect.
        $scenario = Get-AzChaosScenario @common -Name $ScenarioName -ErrorAction Stop
        if ($null -ne $scenario -and -not [System.String]::IsNullOrEmpty($scenario.CreatedFrom)) {
            $recommendationStatus = $scenario.RecommendationStatus
            if ([System.String]::IsNullOrEmpty($recommendationStatus) -or $recommendationStatus -eq 'NotEvaluated') {
                $PSCmdlet.ThrowTerminatingError((New-AzChaosErrorRecord `
                    -Message "Scenario '$ScenarioName' is a catalog scenario, but workspace '$WorkspaceName' has not been evaluated yet. Evaluate the workspace first with 'Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName', then start the run again." `
                    -ErrorId 'WorkspaceNotEvaluated' `
                    -TargetObject $ScenarioName))
            }
        }

        # Step 3: execute the run. Gate the mutation with ShouldProcess so -WhatIf prevents it.
        if ($PSCmdlet.ShouldProcess("Scenario configuration '$Name'", 'Start scenario run')) {
            $executeParameters = @{} + $common
            if ($NoWait) { $executeParameters['NoWait'] = $true }
            $run = Invoke-AzChaosScenarioConfigurationExecution @executeParameters -ScenarioName $ScenarioName -ScenarioConfigurationName $Name
            if ($NoWait) {
                return $run
            }

            # Keep failure statuses in sync with generated\api\Models\ScenarioRunProperties.cs:375.
            if ($run.Status -in @('Failed', 'Canceled')) {
                $PSCmdlet.WriteError((New-AzChaosErrorRecord `
                    -Message "Scenario run '$($run.RunId)' completed with status '$($run.Status)'." `
                    -ErrorId 'ScenarioRunDidNotSucceed' `
                    -TargetObject $run.RunId))
            }
            return $run
        }
    }
}
