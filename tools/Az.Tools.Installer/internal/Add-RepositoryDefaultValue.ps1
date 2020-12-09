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
            $defaultValueMap.Add("${cmdlet}:$parameterName", {(Get-PSRepository).Where( {$_.SourceLocation.Contains('www.powershellgallery.com')}).Name})
        }
    }
    catch 
    {
        # All this functionality is optional, so suppress errors 
        Write-Debug -Message "Error registering argument completer: $_"      
    }

    Set-Variable -Scope Global -Name "PSDefaultParameterValues" -Value $defaultValueMap
}