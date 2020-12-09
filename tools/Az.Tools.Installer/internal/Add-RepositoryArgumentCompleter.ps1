function Add-RepositoryArgumentCompleter()
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string[]]$cmdlets,
        
        [Parameter(Mandatory=$true)]
        [string]$parameterName
    )

    try
    {
        if(Get-Command -Name Register-ArgumentCompleter -ErrorAction SilentlyContinue)
        {
            Register-ArgumentCompleter -CommandName $cmdlets -ParameterName $parameterName -ScriptBlock {
                param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter) 
                
                Get-PSRepository -Name "$wordTocomplete*"-ErrorAction SilentlyContinue -WarningAction SilentlyContinue | Foreach-Object { 
                    [System.Management.Automation.CompletionResult]::new($_.Name, $_.Name, 'ParameterValue', $_.Name) 
                } 
           }
        }
    }
    catch 
    {
        # All this functionality is optional, so suppress errors 
        Write-Debug -Message "Error registering argument completer: $_"      
    }
}