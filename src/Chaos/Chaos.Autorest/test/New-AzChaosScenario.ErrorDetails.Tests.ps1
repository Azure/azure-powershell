if(($null -eq $TestName) -or ($TestName -contains 'New-AzChaosScenarioErrorDetails'))
{
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
}

Describe 'New-AzChaosScenario error detail rendering' {
    BeforeAll {
        $script:errorHandler = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.NewAzChaosScenario_CreateExpanded].Assembly.
            GetType('Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.CmdletRestExtension').
            GetMethod('TryCreateDetailedErrorMessage', [System.Reflection.BindingFlags]'NonPublic, Static')
    }

    function New-ErrorResponseTask {
        param([string]$Json)

        $errorResponse = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ErrorResponse].GetMethod('FromJsonString', [System.Reflection.BindingFlags]'Public, Static').Invoke($null, @($Json))
        [System.Threading.Tasks.Task]::FromResult([Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IErrorResponse]$errorResponse)
    }

    It 'includes top-level error code and nested detail targets and messages' {
        $json = '{"error":{"code":"InvalidRequestContent","message":"One or more errors occured while validating the request body.","details":[{"message":"The ScenarioId field is required.","target":"Properties.ScenarioId","details":[{"message":"Nested detail message.","target":"Properties.Nested"}]}]}}'
        $arguments = @((New-ErrorResponseTask -Json $json), $null, $null)

        $handled = $script:errorHandler.Invoke($null, $arguments)
        $message = $arguments[2]

        $handled | Should -Be $true
        $arguments[1] | Should -Be 'InvalidRequestContent'
        $message | Should -Match '\[InvalidRequestContent\] : One or more errors occured while validating the request body\.'
        $message | Should -BeLike '*Target: Properties.ScenarioId; Message: The ScenarioId field is required.*'
        $message | Should -BeLike '*Target: Properties.Nested; Message: Nested detail message.*'
    }

    It 'does not handle responses without details so generated behavior is unchanged' {
        $json = '{"error":{"code":"InvalidRequestContent","message":"One or more errors occured while validating the request body."}}'
        $arguments = @((New-ErrorResponseTask -Json $json), $null, $null)

        $handled = $script:errorHandler.Invoke($null, $arguments)

        $handled | Should -Be $false
        $arguments[1] | Should -BeNullOrEmpty
        $arguments[2] | Should -BeNullOrEmpty
    }

    It 'does not handle faulted error response tasks so malformed responses fall back to generated behavior' {
        $source = New-Object 'System.Threading.Tasks.TaskCompletionSource[Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IErrorResponse]'
        $source.SetException([System.Exception]::new('malformed response'))
        $arguments = @($source.Task, $null, $null)

        $handled = $script:errorHandler.Invoke($null, $arguments)

        $handled | Should -Be $false
        $arguments[1] | Should -BeNullOrEmpty
        $arguments[2] | Should -BeNullOrEmpty
    }
}
