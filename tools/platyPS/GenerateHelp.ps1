[CmdletBinding()]
Param(
    [Parameter(Mandatory=$True, Position=0)]
    [String]$Service,
    [Parameter(Mandatory=$True, Position=1)]
    [String]$PathToRepo
)

# Check to see if platyPS is already an installed module
if ((Get-Module -ListAvailable -Name platyPS).Count -eq 0)
{
    Write-Host "Installing platyPS"
    Install-Module -Name platyPS -scope CurrentUser
    Import-Module platyPS
}

# If we can't find a path for the given service, then it doesn't exist in AzureRM
if (!(Test-Path $PathToRepo\src\ResourceManager\$Service\Commands.$Service))
{
    throw "Cannot find path to $PathToRepo\src\ResourceManager\$Service\Commands.$Service"
}

# Import service module
Import-Module "$PathToRepo\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.$Service\AzureRM.$Service.psd1"

$HelpPath = "$PathToRepo\src\ResourceManager\$Service\Commands.$Service\help"

# Check to see if there is already a folder containing markdown files for the given service
if (Test-Path $HelpPath)
{
    # Update the markdown files with the changes made in the cmdlets
    Update-MarkdownHelpModule $HelpPath -AlphabeticParamsOrder
}
else
{
    Write-Host "Creating folder in $HelpPath to store markdown files"
    New-Item $HelpPath -ItemType Directory > $null

    # Generate markdown files
    New-MarkdownHelp -Module AzureRM.$Service -OutputFolder $HelpPath -WithModulePage -AlphabeticParamsOrder
}

# Generate the MAML help file from the markdown files
New-ExternalHelp -Path $HelpPath -OutputPath $PathToRepo\src\ResourceManager\$Service\Commands.$Service -Force