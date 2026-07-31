if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChaosScenario'))
{
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
}

Describe 'Remove-AzChaosScenario' {
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

    It 'treats a present scenario delete 204 as successful without a custom NotFound override' {
        {
            Invoke-PrivateResponseHandler -Variant 'RemoveAzChaosScenario_Delete' -Method 'onNoContent' -StatusCode NoContent
        } | Should -Not -Throw
    }

    It 'treats a present scenario delete 202 as successful without a custom NotFound override' {
        {
            Invoke-PrivateResponseHandler -Variant 'RemoveAzChaosScenario_Delete' -Method 'onAccepted' -StatusCode Accepted
        } | Should -Not -Throw
    }

    It 'does not have a custom scenario NotFound swallow; absent success relies on the service returning a success code' {
        {
            Invoke-PrivateResponseHandler -Variant 'RemoveAzChaosScenario_Delete' -Method 'onDefault' -StatusCode NotFound -ErrorResponse (New-ErrorResponseTask -Code 'NotFound' -Message 'The scenario was not found.')
        } | Should -Throw
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
