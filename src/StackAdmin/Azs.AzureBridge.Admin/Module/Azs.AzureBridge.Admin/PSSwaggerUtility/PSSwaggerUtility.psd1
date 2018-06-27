@{
RootModule = 'PSSwaggerUtility.psm1'
ModuleVersion = '0.3.0'
GUID = '49b0a58f-c657-49a1-8c16-e48031f5e2e4'
Author = 'Microsoft Corporation'
CompanyName = 'Microsoft Corporation'
Copyright = '(c) Microsoft Corporation. All rights reserved.'
Description = @'
PowerShell module with PSSwagger common helper functions.
Please refer to https://github.com/PowerShell/PSSwagger/blob/developer/README.md for more details.
'@
FunctionsToExport = @('Start-PSSwaggerJobHelper',
                      'New-PSSwaggerClientTracing',
                      'Register-PSSwaggerClientTracing',
                      'Unregister-PSSwaggerClientTracing',
                      'Remove-AuthenticodeSignatureBlock',
                      'Get-OperatingSystemInfo',
                      'Get-XDGDirectory',
                      'Get-PSCommonParameter',
                      'Add-PSSwaggerClientType',
                      'Get-PSSwaggerMsi',
                      'Get-PSSwaggerExternalDependencies',
                      'Initialize-PSSwaggerDependencies',
                      'Get-AutoRestCredential')
CmdletsToExport = @('Start-PSSwaggerJob')
VariablesToExport = ''
AliasesToExport = ''

PrivateData = @{
    PSData = @{
        Tags = @('Swagger',
                 'OpenApi',
                 'PSEdition_Desktop',
                 'PSEdition_Core',
                 'Linux',
                 'Mac')
        ProjectUri = 'https://github.com/PowerShell/PSSwagger'
        LicenseUri = 'https://github.com/PowerShell/PSSwagger/blob/master/LICENSE'
        ReleaseNotes = @'
Please refer to https://github.com/PowerShell/PSSwagger/blob/developer/CHANGELOG.md
'@
    }
}


}

