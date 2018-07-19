
$global:SkippedTests = @(
    'TestForAllFarmsStartGarbageCollection'
)

$global:Location = "local"
$global:Provider = "Microsoft.Storage.Admin"
$global:ResourceGroupName = "System.local"

if (-not $global:RunRaw) {
    $scriptBlock = {
        Get-MockClient -ClassName 'StorageAdminClient' -TestName $global:TestName -Verbose
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

# Extracts the name needed for parameters
function Select-Name {
    param($Name)
    if ($name.contains("/")) {
        $Name = $Name.Substring($Name.LastIndexOf("/") + 1)
    }
    $Name
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
