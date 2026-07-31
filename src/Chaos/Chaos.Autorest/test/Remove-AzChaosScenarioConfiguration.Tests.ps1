if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChaosScenarioConfiguration'))
{
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
}

Describe 'Remove-AzChaosScenarioConfiguration' {
    $deleteVariants = @(
        'RemoveAzChaosScenarioConfiguration_Delete',
        'RemoveAzChaosScenarioConfiguration_DeleteViaIdentity',
        'RemoveAzChaosScenarioConfiguration_DeleteViaIdentityScenario',
        'RemoveAzChaosScenarioConfiguration_DeleteViaIdentityWorkspace'
    )

    function New-ErrorResponseTask {
        param(
            [string]$Code,
            [string]$Message
        )

        $json = '{{"error":{{"code":"{0}","message":"{1}"}}}}' -f $Code, $Message
        $errorResponse = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ErrorResponse].GetMethod('FromJsonString', [System.Reflection.BindingFlags]'Public, Static').Invoke($null, @($json))
        $source = New-Object 'System.Threading.Tasks.TaskCompletionSource[Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IErrorResponse]'
        $source.SetResult($errorResponse)
        $source.Task
    }

    function Invoke-PrivateResponseHandler {
        param(
            [string]$Variant,
            [string]$Method,
            [System.Net.HttpStatusCode]$StatusCode,
            [System.Threading.Tasks.Task[Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IErrorResponse]]$ErrorResponse
        )

        $type = [type]"Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.$Variant"
        $cmdlet = $type::new()
        $handler = $type.GetMethod($Method, [System.Reflection.BindingFlags]'NonPublic, Instance')
        $response = [System.Net.Http.HttpResponseMessage]::new($StatusCode)
        if ($Method -eq 'onDefault') {
            $task = $handler.Invoke($cmdlet, @($response, $ErrorResponse))
        }
        else {
            $task = $handler.Invoke($cmdlet, @($response))
        }

        $task.Wait()
    }

    foreach ($variant in $deleteVariants) {
        It "treats an already-absent scenario configuration as a successful delete in $variant" {
            {
                Invoke-PrivateResponseHandler -Variant $variant -Method 'onDefault' -StatusCode NotFound -ErrorResponse (New-ErrorResponseTask -Code 'NotFound' -Message 'The scenario configuration was not found.')
            } | Should -Not -Throw
        }

        It "still treats accepted scenario configuration deletes as successful in $variant" {
            {
                Invoke-PrivateResponseHandler -Variant $variant -Method 'onAccepted' -StatusCode Accepted
            } | Should -Not -Throw
        }

        It "still treats no-content scenario configuration deletes as successful in $variant" {
            {
                Invoke-PrivateResponseHandler -Variant $variant -Method 'onNoContent' -StatusCode NoContent
            } | Should -Not -Throw
        }

        It "does not swallow non-NotFound scenario configuration delete failures in $variant" {
            {
                Invoke-PrivateResponseHandler -Variant $variant -Method 'onDefault' -StatusCode InternalServerError -ErrorResponse (New-ErrorResponseTask -Code 'InternalError' -Message 'The service failed.')
            } | Should -Throw
        }
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityScenario' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
