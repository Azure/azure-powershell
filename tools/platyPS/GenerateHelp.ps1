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

    # Edge case: existing MAML contains parameters WhatIf and Confirm for a cmdlet, but no description
    # Need to replace the @{Text=} description that will be generated with the auto-generated description from platyPS

    $files = Get-ChildItem -Path $HelpPath

    foreach ($file in $files)
    {
        # Ignore the module page
        if ($file.Name -eq "AzureRM.$Service.md")
        {
            continue
        }

        $content = Get-Content $HelpPath\$file
        $flag = $False

        $newContent = New-Object string[] $content.Length

        for ($idx = 0; $idx -lt $content.Length; $idx++)
        {
            if ($content[$idx] -like "*### -Confirm*" -and $content[$idx + 1] -like "*@{Text=}")
            {
                $flag = $True
                $newContent[$idx] = $content[$idx]
                $newContent[++$idx] = "Prompts you for confirmation before running the cmdlet."
                    
            }
            elseif ($content[$idx] -like "*### -WhatIf*" -and $content[$idx + 1] -like "*@{Text=}")
            {
                $flag = $True
                $newContent[$idx] = $content[$idx]
                $newContent[++$idx] = "Shows what would happen if the cmdlet runs. The cmdlet is not run."
            }
            else
            {
                $newContent[$idx] = $content[$idx]
            }
        }

        # Replace the contents of the markdown file if we found an error with the descriptions
        if ($flag)
        {
            $result = $newContent -join "`r`n"
            $tempFile = Get-Item $HelpPath\$file

            [System.IO.File]::WriteAllText($tempFile.FullName, $result)
        }
    }
}

# Generate the MAML help file from the markdown files
New-ExternalHelp -Path $HelpPath -OutputPath $PathToRepo\src\ResourceManager\$Service\Commands.$Service -Force

# Get the content for the MAML file
$content = Get-Content $PathToRepo\src\ResourceManager\$Service\Commands.$Service\Microsoft.Azure.Commands.$Service.dll-Help.xml

# Keep track of the number of examples we find so we can add enough space in the new array
$exampleCount = 0

for ($idx = 0; $idx -lt $content.Length; $idx++)
{
    if ($content[$idx] -like "*<command:example>*")
    {
        $exampleCount++
    }
}

# Since we will be adding two <maml:para></maml:para> tags to the MAML, we need to adjust the size of the array
$newContentLength = $content.Length + (2 * $exampleCount)
$newContent = New-Object string[] $newContentLength

$buffer = 0

for ($idx = 0; $idx -lt $content.Length; $idx++)
{
    $newContent[$idx + $buffer] = $content[$idx]

    # If the next line is going to be the end of a remark in an example, add the two new lines for spacing
    if ($content[$idx+1] -like "*</dev:remarks>*")
    {
        $newContent[$idx + $buffer + 1] = "<maml:para></maml:para>"
        $newContent[$idx + $buffer + 2] = "<maml:para></maml:para>"

        $buffer += 2
    }
}

# Replace the contents of the current MAML with the new contents
$result = $newContent -join "`r`n"
$tempFile = Get-Item $PathToRepo\src\ResourceManager\$Service\Commands.$Service\Microsoft.Azure.Commands.$Service.dll-Help.xml

[System.IO.File]::WriteAllText($tempFile.FullName, $result)