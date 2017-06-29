<#
    .SYNOPSIS
    Powershell script to get files changed in a pull request.

    .DESCRIPTION
    Powershell script to get files changed in a pull request.It gets all the commits from a pull request,
    then it gets all the paths from files that have been changed in a given pull request.

    .PARAMETER repositoryOwner

    The git repositiry owner.

    .PARAMETER repositoryName

    The git repository name

    .PARAMETER pullRequestNumber

    The pull request from the git repository to target

    .EXAMPLE

    \GetGitHubPullRequestFilesChanged.ps1 -RepositoryOwner Azure -RepositoryName azure-powershell -PullRequestNumber 4086
#>




#Get a list of the commits of a given pull request. First get the url commits url.
#Then, get the list of commits.
function Get-CommitsList
{
    Param(
    [string]$RepositoryOwner, 
    [string]$RepositoryName, 
    [int]$PullRequestNumber
    )

    $query = "https://api.github.com/repos/$RepositoryOwner/$RepositoryName/pulls/$PullRequestNumber/commits"
    try
    {
        $jsonResult = Invoke-WebRequest $query -ErrorAction Stop           
    }
    catch
    {
        
        $code = $_.Exception.Response.StatusCode.Value__
        $message = ""
        if ($code -ge 400 -and $code -le 499){            
            $message =  "Request to GitHub Api failed. List of commits could not be returned."+
                        "One or multiple parameters are incorrect."
        } else {
            $message = "The server returned an error. List of commits could not bet returned."
        }
        $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception
        throw $exception
    }
    $commits = ConvertFrom-Json -InputObject $jsonResult.Content
    
    return ,$commits
}

function Get-FilesChangedFromCommits
{
    Param(
    [string]$RepositoryOwner, 
    [string]$RepositoryName,
    [object[]]$Commits
    )
    
    #For each commit of pull request get a list of all the files that have changed.
    #Then, include all files that have changed in a list called $filesChanged

    $filesChanged = New-Object 'System.Collections.Generic.HashSet[string]'

    foreach($commit in $Commits)
    {
        $sha  = $commit.sha
        $query = "https://api.github.com/repos/$RepositoryOwner/$RepositoryName/commits/$sha"
        $jsonResult = Invoke-WebRequest $query -ErrorAction Stop    
        
        $commitMetadata =  ConvertFrom-Json -InputObject $jsonResult.Content

        foreach($file in $commitMetadata.files)
        {
            $filesChanged.Add($file.filename) | Out-Null            
        }    
    }

    return $filesChanged
}

function Get-PullRequestFileChanges{

[CmdletBinding()]
Param(
[Parameter(Mandatory=$True)]
[string]$RepositoryOwner,
[Parameter(Mandatory=$True)]
[string]$RepositoryName,
[Parameter(Mandatory=$True)]
[int]$PullRequestNumber
)
PROCESS {
    $commits = Get-CommitsList -RepositoryOwner $RepositoryOwner -RepositoryName $RepositoryName -PullRequestNumber $PullRequestNumber
    Get-FilesChangedFromCommits -RepositoryOwner $RepositoryOwner -RepositoryName $RepositoryName -commits $commits
    }
}





