function getUseModules() {
    $usedModule = & 'gmo'
    foreach($module in $usedModule)
    {
      $name = $module.Name
      $version = $module.Version
      Write-Host -ForegroundColor Green "Using module name: $name $version"
    }
} 

function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}