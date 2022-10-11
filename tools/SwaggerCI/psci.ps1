param(
    [Parameter(Position=0, Mandatory=$true)]
    [string]
    $InputFile,

    [Parameter(Position=1, Mandatory=$true)]
    [string]
    $OutputFile
)

Import-Module (Join-Path $PSScriptRoot 'psci.psm1')

Invoke-SwaggerCI -ConfigFilePath $InputFile -ResultFilePath $OutputFile
