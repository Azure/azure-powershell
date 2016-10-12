<#
.ExternalHelp help\platyPSHelp-help.xml
#>
function New-ServiceMarkdownHelp
{
    [CmdletBinding()]
    Param(
        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [String]$Service,

        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [Parameter(ParameterSetName="Storage", Mandatory=$True)]
        [ValidateSet("Debug", "Release")]
        [String]$BuildTarget,

        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Switch]$ResourceManager,

        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [Switch]$ServiceManagement,

        [Parameter(ParameterSetName="Storage", Mandatory=$True)]
        [Switch]$Storage,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$PathToModule,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$PathToCommandsFolder
    )

    PROCESS
    {
        # Get the path to the platyPSHelp module root
        $PSModule = $ExecutionContext.SessionState.Module
        $PSModuleRoot = $PSModule.ModuleBase

        # Use the platyPSHelp module root to get the path to the repository
        $PathToRepo = (Get-Item $PSModuleRoot).Parent.Parent.FullName

        # Set the necessary variables for an ARM service
        if ($ResourceManager.IsPresent)
        {
            $PathToModule = "$PathToRepo\src\Package\$BuildTarget\ResourceManager\AzureResourceManager\AzureRM.$Service\AzureRM.$Service.psd1"
            $PathToCommandsFolder = "$PathToRepo\src\ResourceManager\$Service\Commands.$Service"
        }
        # Set the necessary variables for an RDFE service
        elseif ($ServiceManagement.IsPresent)
        {
            throw "Currently platyPSHelp is unavailable for RDFE services. Please refer to the platyps-help.md documentation for more information."
            $PathToModule = Get-ServiceManagementDll -Service $Service -PathToAzure "$PathToRepo\src\Package\$BuildTarget\ServiceManagement\Azure"
            $PathToCommandsFolder = "$PathToRepo\src\ServiceManagement\$Service\Commands.$Service"
        }
        # Set the necessary variables for Storage
        elseif ($Storage.IsPresent)
        {
            $PathToModule = "$PathToRepo\src\Package\$BuildTarget\Storage\Azure.Storage\Azure.Storage.psd1"
            $PathToCommandsFolder = "$PathToRepo\src\Storage\Commands.Storage"
        }

        $ModuleName = (Get-Item $PathToModule).BaseName

        # If the "FullPath" parameter set is not used, make sure the paths created above are accessible
        if (!($PSCmdlet.ParameterSetName -eq "FullPath"))
        {
            if (!((Test-Path $PathToModule) -and (Test-Path $PathToCommandsFolder)))
            {
                throw "Unable to find paths based on the given parameters. Consider using the FullPath parameter set."
            }
        }

        $PathToHelp = "$PathToCommandsFolder\help"

        # Import the service module
        Import-Module $PathToModule -Scope Global

        Write-Host "Creating folder in $PathToHelp to store markdown files"
        New-Item $PathToHelp -ItemType Directory > $null

        # Generate the markdown files for each cmdlet in the service
        New-MarkdownHelp -Module $ModuleName -OutputFolder $PathToHelp -WithModulePage -AlphabeticParamsOrder

        # Edge case: if the existing MAML contains WhatIf and Confirm parameters, but no description, they will have a "@{Text=}" description in markdown
        # Need to replace this description with the auto-generated descriptions used by platyPS
        $files = Get-ChildItem -Path $PathToHelp

        foreach ($file in $files)
        {
            # Ignore the module page
            if ($file.Name -eq "$ModuleName.md")
            {
                continue
            }

            $content = Get-Content $PathToHelp\$file
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
                $tempFile = Get-Item $PathToHelp\$file

                [System.IO.File]::WriteAllText($tempFile.FullName, $result)
            }
        }

        # Generate the MAML help file from the markdown files
       New-ServiceExternalHelp -PathToCommandsFolder $PathToCommandsFolder
    }
}

<#
.ExternalHelp help\platyPSHelp-help.xml
#>
function Update-ServiceMarkdownHelp
{
    [CmdletBinding()]
    Param(
        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [String]$Service,

        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [Parameter(ParameterSetName="Storage", Mandatory=$True)]
        [ValidateSet("Debug", "Release")]
        [String]$BuildTarget,

        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Switch]$ResourceManager,

        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [Switch]$ServiceManagement,

        [Parameter(ParameterSetName="Storage", Mandatory=$True)]
        [Switch]$Storage,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$PathToModule,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$PathToCommandsFolder
    )

    PROCESS
    {
        # Get the path to the platyPSHelp module root
        $PSModule = $ExecutionContext.SessionState.Module
        $PSModuleRoot = $PSModule.ModuleBase

        # Use the platyPSHelp module root to get the path to the repository
        $PathToRepo = (Get-Item $PSModuleRoot).Parent.Parent.FullName

        # Set the necessary variables for an ARM service
        if ($ResourceManager.IsPresent)
        {
            $PathToModule = "$PathToRepo\src\Package\$BuildTarget\ResourceManager\AzureResourceManager\AzureRM.$Service\AzureRM.$Service.psd1"
            $PathToCommandsFolder = "$PathToRepo\src\ResourceManager\$Service\Commands.$Service"
        }
        # Set the necessary variables for an RDFE service
        elseif ($ServiceManagement.IsPresent)
        {
            throw "Currently platyPSHelp is unavailable for RDFE services. Please refer to the platyps-help.md documentation for more information."
            $PathToModule = "$PathToRepo\src\Package\$BuildTarget\ServiceManagement\Azure\Azure.psd1"
            $PathToCommandsFolder = "$PathToRepo\src\ServiceManagement\$Service\Commands.$Service"
        }
        # Set the necessary variables for Storage
        elseif ($Storage.IsPresent)
        {
            $PathToModule = "$PathToRepo\src\Package\$BuildTarget\Storage\Azure.Storage\Azure.Storage.psd1"
            $PathToCommandsFolder = "$PathToRepo\src\Storage\Commands.Storage"
        }

        $ModuleName = (Get-Item $PathToModule).BaseName

        # If the "FullPath" parameter set is not used, make sure the paths created above are accessible
        if (!($PSCmdlet.ParameterSetName -eq "FullPath"))
        {
            if (!((Test-Path $PathToModule) -and (Test-Path $PathToCommandsFolder)))
            {
                throw "Unable to find paths based on the given parameters. Consider using the FullPath parameter set."
            }
        }

        $PathToHelp = "$PathToCommandsFolder\help"

        if (!(Test-Path $PathToHelp))
        {
            throw "Unable to find markdown help folder. Please make sure markdown has been created for your service."
        }

        # Import the service module
        Import-Module $PathToModule -Scope Global

        # Update the markdown files with the changes made in the cmdlets
        Update-MarkdownHelpModule $PathToHelp -AlphabeticParamsOrder -RefreshModulePage

        # Generate the MAML help file from the markdown files
        New-ServiceExternalHelp -PathToCommandsFolder $PathToCommandsFolder
    }
}

function New-ServiceExternalHelp
{
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory=$True)]
        [string]$PathToCommandsFolder
    )

    $PathToHelp = "$PathToCommandsFolder\help"

    # Generate the MAML help file from the markdown files
    New-ExternalHelp -Path $PathToHelp -OutputPath $PathToCommandsFolder -Force

    # Get the name of the MAML file
    $dir = Get-ChildItem $PathToCommandsFolder

    $MAML = $dir | Where { $_.Extension -eq ".xml" } 

    # Get the content for the MAML file
    $content = Get-Content "$PathToCommandsFolder\$($MAML.Name)"

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
    $tempFile = Get-Item "$PathToCommandsFolder\$($MAML.Name)"

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)

    # Check to ensure that the MAML file is still valid XML
    [Reflection.Assembly]::LoadWithPartialName("System.Xml.Linq") | Out-Null
    [System.Xml.Linq.XDocument]::Load($tempFile.FullName) | Out-Null
}

function Get-ServiceManagementDll
{
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory=$True)]
        [String]$Service,

        [Parameter(Mandatory=$True)]
        [String]$PathToAzure
    )

    $dlls = @{  
                "Automation"       = "Automation\Microsoft.Azure.Commands.Automation.dll";
                "Compute"          = "Compute\Microsoft.WindowsAzure.Commands.ServiceManagement.dll";
                "HDInsights"       = "HDInsight\Microsoft.WindowsAzure.Commands.HDInsight.dll";
                "ManagedCache"     = "ManagedCache\Microsoft.Azure.Commands.ManagedCache.dll";
                "Networking"       = "Networking\Microsoft.WindowsAzure.Commands.ServiceManagement.Network.dll";
                "Profile"          = "Services\Microsoft.WindowsAzure.Commands.Profile.dll";
                "RecoveryServices" = "RecoveryServices\Microsoft.Azure.Commands.RecoveryServicesRdfe.dll";
                "RemoteApp"        = "RemoteApp\Microsoft.WindowsAzure.Commands.RemoteApp.dll";
                "Services"         = "Services\Microsoft.WindowsAzure.Commands.dll";
                "Sql"              = "Sql\Microsoft.WindowsAzure.Commands.SqlDatabase.dll";
                "StorSimple"       = "StorSimple\Microsoft.WindowsAzure.Commands.StorSimple.dll";
                "TrafficManager"   = "TrafficManager\Microsoft.WindowsAzure.Commands.TrafficManager.dll"; 
            }

    if ($dlls.Keys -contains $Service)
    {
        return "$PathToAzure\$($dlls[$Service])"
    }

    throw "Unable to find dll for the given service."
}

<#
.ExternalHelp help\platyPSHelp-help.xml
#>
function Validate-ServiceMarkdownHelp
{
    [CmdletBinding()]
    Param(
        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [String]$Service,

        [Parameter(ParameterSetName="ResourceManager", Mandatory=$True)]
        [Switch]$ResourceManager,

        [Parameter(ParameterSetName="ServiceManagement", Mandatory=$True)]
        [Switch]$ServiceManagement,

        [Parameter(ParameterSetName="Storage", Mandatory=$True)]
        [Switch]$Storage,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$PathToHelp,

        [Parameter(ParameterSetName="FullPath", Mandatory=$True)]
        [String]$ModuleName
    )

    PROCESS
    {
        # Get the path to the platyPSHelp module root
        $PSModule = $ExecutionContext.SessionState.Module
        $PSModuleRoot = $PSModule.ModuleBase

        # Use the platyPSHelp module root to get the path to the repository
        $PathToRepo = (Get-Item $PSModuleRoot).Parent.Parent.FullName

        # Set the necessary variables for an ARM service
        if ($ResourceManager.IsPresent)
        {
            $PathToHelp = "$PathToRepo\src\ResourceManager\$Service\Commands.$Service\help"
            $ModuleName = "AzureRM.$Service"
        }
        # Set the necessary variables for an RDFE service
        elseif ($ServiceManagement.IsPresent)
        {
            $PathToHelp = "$PathToRepo\src\ServiceManagement\$Service\Commands.$Service\help"
            $ModuleName = "Azure"
        }
        # Set the necessary variables for Storage
        elseif ($Storage.IsPresent)
        {
            $PathToHelp = "$PathToRepo\src\Storage\Commands.Storage\help"
            $ModuleName = "Azure.Storage"
        }

        # If the "FullPath" parameter set is not used, make sure the paths created above are accessible
        if (!($PSCmdlet.ParameterSetName -eq "FullPath"))
        {
            if (!(Test-Path $PathToHelp))
            {
                throw "Unable to find markdown help based on the given parameters. Consider using the FullPath parameter set."
            }
        }

        # Keep track of errors in the markdown
        [String[]]$errors = @()

        # Get all of the markdown help files
        $files = Get-ChildItem -Path $PathToHelp

        foreach ($file in $files)
        {
            # Ignore the module page
            if ($file.Name -eq "$ModuleName.md")
            {
                continue
            }

            $fileErrors = @()

            # For each help file, check to see if they are missing help in any section
            $content = Get-Content $PathToHelp\$file
            
            # Iterate over each line in the file
            for ($idx = 0; $idx -lt $content.Length; $idx++)
            {
                switch ($content[$idx])
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
                            }
                            else
                            {
                                break
                            }
                        }

                        if (!($foundSynopsis))
                        {
                            $fileErrors += "-- No synopsis found"
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
                            }
                            else
                            {
                                break
                            }
                        }

                        if (!($foundDescription))
                        {
                            $fileErrors += "-- No description found"
                        }
                    }
                    "## EXAMPLES"
                    {
                        # Move the index to the start of the PowerShell code
                        while ($content[$idx] -notcontains "``````")
                        {
                            $idx++
                        }

                        # Check for the platyPS example template
                        # 
                        # ```
                        # PS C:\> {{ Add example code here }}
                        # ```
                        # 
                        if ($content[$idx+1] -contains "PS C:\> {{ Add example code here }}")
                        {
                            $fileErrors += "-- No examples found"
                        }

                        # Check for other missing example formats (such as empty)
                        # 
                        # ```
                        # 
                        # ```
                        # 
                        if ([string]::IsNullOrWhiteSpace("$($content[$idx+1])"))
                        {
                            $fileErrors += "-- No examples found"
                        }
                    }
                    "@{Text=}"
                    {
                        # This case occurs when there is no description provided for a parameter
                        $parameter = $content[$idx-1].Substring(5)
                        $fileErrors += "-- No description found for parameter $parameter"
                    }
                    "## OUTPUTS"
                    {
                        $foundOutput = $False
                        $idx++

                        # Check each line between OUTPUTS and NOTES for any text
                        for (;;)
                        {
                            $foundOutput = $foundOutput -or (!([string]::IsNullOrWhiteSpace("$($content[$idx])")))

                            if ($content[$idx+1] -notcontains "## NOTES")
                            {
                                $idx++
                            }
                            else
                            {
                                break
                            }
                        }

                        if (!($foundOutput))
                        {
                            $fileErrors += "-- No output description found"
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
                $errors += "==========`n"
                $errors += "File: $file`n"
                $errors += $fileErrors
                $errors += ""
            }
        }

        # If there were any errors recorded, print them out and throw
        if ($errors.Count -gt 0)
        {
            $errors | foreach { Write-Host $_ }
            throw "Some help files are incomplete, check above messages for details"
        }
        else
        {
            Write-Host "All help files are complete"
        }
    }
}

Export-ModuleMember -Function New-ServiceMarkdownHelp
Export-ModuleMember -Function Update-ServiceMarkdownHelp
Export-ModuleMember -Function Validate-ServiceMarkdownHelp