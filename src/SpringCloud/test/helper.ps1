function getUseModules() {
    $usedModule = & 'gmo'
    foreach($module in $usedModule)
    {
      $name = $module.Name
      $version = $module.Version
      Write-Host -ForegroundColor Green "Using module name: $name $version"
    }
} 

function RandomNumber([int32]$len) {
    return -join (0,1,2,3,4,5,6,7,8,9 | Get-Random -Count $len | % {[int32]$_})
}
function RandomLetters([int32]$len) {
    return -join ((65..90) + (97..122) | Get-Random -Count $len | % {[char]$_})
}

function CreateKeyVaultCertificate($vaultName, $certName, $subjectName) {
    Write-Host -ForegroundColor Yellow "Create key vault certificate policy for test..."
    $policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName $subjectName -IssuerName "Self" -ValidityInMonths 6 -ReuseKeyOnRenewal
    Add-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificatePolicy $policy
    Write-Host -ForegroundColor Yellow "Created successfully."
}