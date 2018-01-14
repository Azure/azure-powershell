# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
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
.SYNOPSIS
    All the test methods are executed through this cmdlet. The test common methods are tracking the created resource groups and subscriptions
#>
function Start-Test
{
    param(
    [ScriptBlock] $Test
    )

    Write-Verbose "=================================================================="
    Write-Verbose "Starting Test- $Test"
    Write-Verbose "=================================================================="

    try
    {
        $Global:CreatedResourceGroups.Clear()
        $Global:CreatedSubscriptions.Clear()
        $exceptionRaised = $false
        $startDateTime = Get-Date

        & $Test
        Write-Verbose "=================================================================="
        Write-Verbose "Test Passed - $Test"
        Write-Verbose "=================================================================="
    }
    catch
    {
        Write-Verbose "=================================================================="
        Write-Verbose "Test Failed - $Test"
        Write-Verbose "=================================================================="

        Write-Verbose "Exception info:" -Verbose
        $_
        Write-Verbose "InnerException info:" -Verbose
        $_.Exception.InnerException
        Write-Verbose "Exception stacktrace:" -Verbose
        $_.Exception.Stacktrace
        $exceptionRaised = $true
        throw $_
    }
    finally
    {
        # Try cleaning up the created resources in case of error
        # The test is expected to do the normal cleanup as part the test
        # The following is a best effort to clean up the resources in case of an error in the middle of the test
        if ($exceptionRaised)
        {
            Write-Verbose "Starting cleanup of created resources"
            # cleaning up tenant resource groups with resources
            $Global:CreatedResourceGroups | where {$_.Level -eq 1} | % {
                try { Remove-ResourceGroup -ResourceGroupName $_.ResourceGroupName -SubscriptionId $_.SubscriptionId -Token $_.Token}
                catch {}
            }

            # cleaning up subscriptions
            for ( $i=$Global:CreatedSubscriptions.Count -1; $i -ge 0; $i--)
            {
                try { Remove-Subscription $Global:CreatedSubscriptions[$i].SubscriptionId}
                catch {}
            }

            # cleaning up admin resource groups with subscriptions
            $Global:CreatedResourceGroups | where {$_.Level -eq 0} | % {
                try { Remove-ResourceGroup -ResourceGroupName $_.ResourceGroupName -SubscriptionId $_.SubscriptionId -Token $_.Token}
                catch {}
            }
            Write-Verbose "Done with the cleanup of resources"
        }

        $elapsed = (Get-Date) - $startDateTime
        Write-Verbose "Test Run Time MM:SS - $($elapsed.Minutes)m : $($elapsed.Seconds)s"

        $Global:CreatedSubscriptions.Clear()
        $Global:CreatedResourceGroups.Clear()
    }
}

<#
.SYNOPSIS
Sets Certificate policy to trust all the certificates. This avoids passing -DisableCertValidataion for each cmdlet call when using self signed certificates
#>
function Ignore-SelfSignedCert
{

add-type @"
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    public class TrustAllCertsPolicy : ICertificatePolicy {
        public bool CheckValidationResult(
            ServicePoint srvPoint, X509Certificate certificate,
            WebRequest request, int certificateProblem) {
            return true;
        }
    }
"@
    [System.Net.ServicePointManager]::CertificatePolicy = New-Object TrustAllCertsPolicy

    Write-Warning -Message "CertificatePolicy set to ignore all server certificate errors"
}
