<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

Microsoft.PowerShell.Core\Set-StrictMode -Version Latest

<#
.DESCRIPTION
   Get zero or more result items from a task. Optionally, skip N items or take only the top N items. If paged, assigns $PageResult.Result
   the page item result, and the returned result items are the items within the page.

.PARAMETER  TaskResult
    The started Task.

.PARAMETER  SkipInfo
    Object containing skip parameters or $null. Should contain the properties: 'Count', 'Max'

.PARAMETER  TopInfo
    Object containing top parameters or $null. Should contain the properties: 'Count', 'Max'

.PARAMETER  PageResult
    Object containing page result. Should contain the property: 'Result'

.PARAMETER  PageType
    Expected type of task result when the result is a page.
#>
function Get-TaskResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [object]
        $TaskResult,

        [Parameter(Mandatory = $false)]
        [PSCustomObject]
        $SkipInfo,

        [Parameter(Mandatory = $false)]
        [PSCustomObject]
        $TopInfo,

        [Parameter(Mandatory = $false)]
        [PSCustomObject]
        $PageResult,

        [Parameter(Mandatory = $false)]
        [Type]
        $PageType
    )

    function Get-Exception {
        param(
            $Exception
        )
        try {
            $cloudException = "Code = $($Exception.Body.Code)`nMessage = $($Exception.Body.Message)"
            $Exception = $cloudException
        } catch {
            # Catch exception so no output.
        } finally {
            throw $Exception
        }
    }

    $ErrorActionPreference = 'Stop'
    $null = $TaskResult.AsyncWaitHandle.WaitOne()
    Write-Debug -Message "$($TaskResult | Out-String)"

    if ((Get-Member -InputObject $TaskResult -Name 'Result') -and
        $TaskResult.Result -and
        (Get-Member -InputObject $TaskResult.Result -Name 'Body') -and
        $TaskResult.Result.Body) {
        Write-Verbose -Message 'Operation completed successfully.'
        $result = $TaskResult.Result.Body
        Write-Debug -Message "$($result | Out-String)"
        if ($PageType -and ($result -is $PageType)) {
            if ($PageResult) {
                $PageResult.Page = $result
            }
            foreach ($item in $result) {
                if ($SkipInfo -and ($SkipInfo.Count++ -lt $SkipInfo.Max)) {
                } else {
                    if ((-not $TopInfo) -or ($TopInfo.Max -eq -1) -or ($TopInfo.Count++ -lt $TopInfo.Max)) {
                        $item
                    } else {
                        break
                    }
                }
            }
        } else {
            $result
        }
    } elseif ($TaskResult.IsFaulted) {
        Write-Verbose -Message 'Operation failed.'
        if ($TaskResult.Exception) {
            if ((Get-Member -InputObject $TaskResult.Exception -Name 'InnerExceptions') -and $TaskResult.Exception.InnerExceptions) {
                foreach ($ex in $TaskResult.Exception.InnerExceptions) {
                    Get-Exception -Exception $ex
                }
            } elseif ((Get-Member -InputObject $TaskResult.Exception -Name 'InnerException') -and $TaskResult.Exception.InnerException) {
                Get-Exception -Exception $TaskResult.Exception.InnerException
            } else {
                Get-Exception -Exception $TaskResult.Exception
            }
        }
    } elseif ($TaskResult.IsCanceled) {
        Write-Verbose -Message 'Operation got cancelled.'
        Throw 'Operation got cancelled.'
    } else {
        Write-Verbose -Message 'Operation completed successfully.'
    }
}
