[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$FailedTestFolder
)

$filesInFailingTests = Get-ChildItem $FailedTestFolder
if (!($filesInFailingTests -eq $null))
{
    throw "Failing tests, please check files in src/TestResults/FailingTests"
}