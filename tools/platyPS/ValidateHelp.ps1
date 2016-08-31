[CmdletBinding()]
Param(
    [Parameter(Mandatory=$True, Position=0)]
    [String]$Service,
    [Parameter(Mandatory=$True, Position=1)]
    [String]$PathToRepo
)

$HelpPath = "$PathToRepo\src\ResourceManager\$Service\Commands.$Service\help"

# Check to see if the given service has any markdown help files
if (!(Test-Path $HelpPath))
{
    Write-Host "The service $Service does not contain any markdown help files"
}
else
{
    # Keep track of errors in the markdown
    [String[]]$errors = @()

    # Get all of the markdown help files
    $files = Get-ChildItem -Path $HelpPath

    foreach ($file in $files)
    {
        $fileErrors = @()

        # For each help file, check to see if they are missing help in any section
        $content = Get-Content $HelpPath\$file
        
        # Iterate over each line in the file
        for ($idx = 0; $idx -lt $content.Length; $idx++)
        {
            switch ($content[$idx])
            {
                "## SYNOPSIS"
                {
                    # Check for a synopsis of the cmdlet
                    if ([string]::IsNullOrWhiteSpace("$($content[$idx+1])"))
                    {
                        $fileErrors += "`tNo snyopsis found"
                    }
                }
                "## DESCRIPTION"
                {
                    # Check for a description of the cmdlet
                    if ([string]::IsNullOrWhiteSpace("$($content[$idx+1])"))
                    {
                        $fileErrors += "`tNo description found"
                    }
                }
                "## EXAMPLES"
                {
                    while ($content[$idx] -notcontains "``````")
                    {
                        $idx++
                    }

                    # Check for the platyPS example template
                    if ($content[$idx+1] -contains "PS C:\> {{ Add example code here }}")
                    {
                        $fileErrors += "`tNo examples found"
                    }

                    # Check for other missing example formats
                    if ([string]::IsNullOrWhiteSpace("$($content[$idx+1])"))
                    {
                        $fileErrors += "`tNo examples found"
                    }
                }
                "@{Text=}"
                {
                    # This case occurs when there is no description provided for a parameter
                    $parameter = $content[$idx-1].Substring(5)
                    $fileErrors += "`tNo description found for parameter $parameter"
                }
                "## OUTPUTS"
                {
                    # Check for a description of the output from the cmdlet
                    if ($content[$idx+2] -notlike "###*")
                    {
                        $fileErrors += "`tNo output description found"
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
            $errors += $file
            $errors += $fileErrors
            $errors += "`n"
        }
    }

    # If there were any errors recorded, print them out and throw
    if ($errors.Count -gt 0)
    {
        $errors | foreach { Write-Host $_ }
        throw "ERROR: Some help files are incomplete, check above messages for details"
    }
    else
    {
        Write-Host "SUCCESS: All help files are complete"
    }
}