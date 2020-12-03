@{
    ModuleVersion = '1.0'
    RootModule = '.\SecretManagementExtension.psm1'
    FunctionsToExport = @('Set-Secret','Get-Secret','Remove-Secret','Get-SecretInfo','Test-SecretVault')
}
