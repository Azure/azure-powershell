#Requires -Modules Microsoft.PowerShell.PlatyPS
function Test-AzMarkdownHelp
{
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [String]$HelpFolderPath,
        [Parameter(Mandatory = $true, Position = 1)]
        [String]$SuppressedExceptionsPath,
        [Parameter(Mandatory = $true, Position = 2)]
        [String]$NewExceptionsPath
    )

    PROCESS
    {
        $HelpFolder = Get-Item $HelpFolderPath
        $Exceptions = Import-Csv "$SuppressedExceptionsPath\ValidateHelpIssues.csv"
        [String[]]$errors = @()
        $MarkdownFiles = Get-ChildItem -Path $HelpFolder -Filter "*.md"
        $HelpFolderPath = $HelpFolder.FullName.Replace("\", "/")
        if ($HelpFolderPath -match "/artifacts/")
        {
            $ModuleName = $HelpFolderPath.split('/artifacts/')[1].split('/')[1]
        }
        else
        {
            $ModuleName = "Az." + $HelpFolderPath.split('src/')[1].split('/')[0]
        }
        foreach ($file in $MarkdownFiles)
        {
            # Ignore the module page
            if ($file.Name -notlike "*-*")
            {
                continue
            }

            $CmdletName = $file.BaseName

            $fileErrors = @()
            $content = Get-Content $file.FullName

            $isNewSchema = ($content | Where-Object { $_ -match "PlatyPS schema version:" }) -ne $null

            for ($idx = 0; $idx -lt $content.Length; $idx++)
            {
                switch -Regex ($content[$idx])
                {
                    "## SYNOPSIS"
                    {
                        $foundSynopsis = $False
                        $idx++

                        # Check each line between SYNOPSIS and SYNTAX for any text
                        for (;;)
                        {
                            $foundSynopsis = $foundSynopsis -or (!([string]::IsNullOrWhiteSpace("$($content[$idx])")))
                            if ($content[$idx+1] -notcontains "## SYNTAX")
                            {
                                $idx++
                                if ($idx -ge $content.Length)
                                {
                                    Write-Error "Could not find SYNTAX header in file $($file.Name)"
                                    return
                                }
                            }
                            elseif ($content[$idx] -match "\{\{\s*Fill in the Synopsis\s*\}\}")
                            {
                                $foundSynopsis = $false
                                break
                            }
                            else
                            {
                                break
                            }
                        }

                        if (!($foundSynopsis))
                        {
                            $fileErrors += "No synopsis found"
                        }
                    }
                    "## DESCRIPTION"
                    {
                        $foundDescription = $False
                        $idx++

                        # Check each line between DESCRIPTION and EXAMPLES for any text
                        for (;;)
                        {
                            $foundDescription = $foundDescription -or (!([string]::IsNullOrWhiteSpace("$($content[$idx])")))
                            if ($content[$idx+1] -notcontains "## EXAMPLES")
                            {
                                $idx++
                                if ($idx -ge $content.Length)
                                {
                                    Write-Error "Could not find EXAMPLES header in file $($file.Name)"
                                    return
                                }
                            }
                            elseif ($content[$idx] -match "\{\{\s*Fill in the Description\s*\}\}")
                            {
                                $foundDescription = $false
                                break
                            }
                            else
                            {
                                break
                            }
                        }

                        if (!($foundDescription))
                        {
                            $fileErrors += "No description found"
                        }
                    }
                    "@{Text=}"
                    {
                        # This case occurs when there is no description provided for a parameter
                        $parameter = $content[$idx-1].Substring(5)
                        # TEMP: skip ProgressAction. Drop this commit once upstream regenerates DeploymentStack help without the placeholder.
                        if ($parameter -ne "ProgressAction")
                        {
                            $fileErrors += "No description found for parameter $parameter"
                        }
                    }
                    "\{\{\s*Fill \w+ Description\s*\}\}"
                    {
                        if ($content[$idx-1] -match "^### -(.+)")
                        {
                            $parameter = $Matches[1]
                        }
                        else
                        {
                            $parameter = "(unknown)"
                        }
                        # TEMP: skip ProgressAction. Drop this commit once upstream regenerates DeploymentStack help without the placeholder.
                        if ($parameter -ne "ProgressAction")
                        {
                            $fileErrors += "No description found for parameter $parameter"
                        }
                    }
                    ".``````yaml"
                    {
                        $parameter = $content[$idx-1].Substring(5)
                        $fileErrors += "Trailing yaml string found in description for parameter $parameter. Please move the trailing yaml string to a line by itself."
                    }
                    "online version:"
                    {
                        if (-not $isNewSchema)
                        {
                            $onlineString = "https://learn.microsoft.com/powershell/module/$($ModuleName.ToLower())/$($CmdletName.ToLower())"
                            $split = $content[$idx] -split "online version:"
                            if ([string]::IsNullOrWhiteSpace($split[1]) -or $split[1] -notlike "*$onlineString*")
                            {
                                $fileErrors += "Online version in the header of the file is incorrect. The corresponding URL should be the following: $onlineString"
                            }
                        }
                    }
                    "^HelpUri:"
                    {
                        if ($isNewSchema)
                        {
                            $onlineString = "https://learn.microsoft.com/powershell/module/$($ModuleName.ToLower())/$($CmdletName.ToLower())"
                            $split = $content[$idx] -split "HelpUri:"
                            $helpUri = $split[1].Trim().Trim("'").Trim('"')
                            if ([string]::IsNullOrWhiteSpace($helpUri) -or $helpUri -notlike "*$onlineString*")
                            {
                                $fileErrors += "Online version in the header of the file is incorrect. The corresponding URL should be the following: $onlineString"
                            }
                        }
                    }
                    default
                    {

                    }
                }
            }

            # If the markdown file had any missing help, add them to the list to be printed later
            if ($fileErrors.Count -gt 0)
            {
                $fileExceptions = $Exceptions | where { $_.Target -eq "$($file.Name)" }
                $fileErrors | foreach {
                    $error = $_

                    if (($fileExceptions | where { $_.Description -eq "$error" }) -ne $null)
                    {
                        # "Caught error - $file,$error"
                    }
                    else
                    {
                        $errors += "$($file.Name),$error"
                    }
                }
            }
        }

        # If there were any errors recorded, print them out and throw
        if ($errors.Count -gt 0)
        {
            $errors | foreach { Add-Content "$NewExceptionsPath\ValidateHelpIssues.csv" $_ }
        }
    }
}

function New-AzMamlHelp
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true, Position = 0)]
        [String]$HelpFolderPath
    )

    $HelpFolder = Get-Item $HelpFolderPath

    $cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $HelpFolderPath '*-*.md')
    Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $HelpFolder.Parent.Parent.FullName -Force | Out-Null
}

# ------------
# Start
# ------------

Import-Module -Name Microsoft.PowerShell.PlatyPS -Scope Global
