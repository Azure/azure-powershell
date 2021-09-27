function Add-RepositoryDefaultValue()
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string[]]$cmdlets,
        
        [Parameter(Mandatory=$true)]
        [string]$parameterName
    )

    $defaultValueMap = Get-Variable PSDefaultParameterValues -Scope Global -ValueOnly
    try
    {
        foreach($cmdlet in $cmdlets) {
            $defaultValueMap.Add("${cmdlet}:$parameterName", {
                $repos = Get-PSRepository
                if ($repos.Length -eq 1) {
                    $repos.Name
                }
                else {
                    throw "There are multiple resgistered repositories:$($repos.Name). Please specify one explicitly."
                }
            })
        }
    }
    catch 
    {
        # All this functionality is optional, so suppress errors 
        Write-Debug -Message "Error registering argument completer: $_"      
    }

    Set-Variable -Scope Global -Name "PSDefaultParameterValues" -Value $defaultValueMap
}