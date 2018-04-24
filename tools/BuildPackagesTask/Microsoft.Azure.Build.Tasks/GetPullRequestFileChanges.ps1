# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Powershell script to get files changed in a pull request.

    .DESCRIPTION
    Powershell script to get files changed in a pull request(PR). 

    .PARAMETER repositoryOwner

    The git repositiry owner.

    .PARAMETER repositoryName

    The git repository name

    .PARAMETER pullRequestNumber

    The pull request from the git repository to target

    .EXAMPLE

    Get-PullRequestFileChanges -RepositoryOwner Azure -RepositoryName azure-powershell -PullRequestNumber 4086
#>


function Invoke-SafeWebRequest{
    Param(
    [Parameter(Mandatory=$True)]
    [string]$Query
    )
    try
    {
        Write-Debug "Sending query to the server..."
        [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
        $jsonResult = Invoke-WebRequest $Query -ErrorAction Stop  
    }
    catch
    {
        Write-Debug "Something went wrong."
        $code = $_.Exception.Response.StatusCode.Value__
        $message = ""

        if ($code -ge 400 -and $code -le 499){            
            $message =  "Request to GitHub Api failed. List of commits could not be returned. "+
                        "One or multiple parameters are incorrect."
        } else {
            $message = "The server returned an error. List of commits could not bet returned. "
        }

        $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception
        Write-Debug $exception.ToString 
        throw $exception
    }

    return $jsonResult
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
    $filesChanged = New-Object 'System.Collections.Generic.HashSet[string]'    
    Write-Debug "Number of files detected so far: $($filesChanged.Count)"
    # The maximum number of files that can be  retrieved is 300. For more info: https://developer.github.com/v3/pulls/#list-pull-requests-files   
    $currentPage = 0

    do 
    {
        Write-Debug "Starting pagination..."
        $currentPage += 1
        Write-Debug "Current page is: $currentPage"
        $query = "https://api.github.com/repos/$RepositoryOwner/$RepositoryName/pulls/$PullRequestNumber/files?page=$currentPage&per_page=100"  
        Write-Debug "Query to be send is: $query"               
        $jsonResult = Invoke-SafeWebRequest $query
        Write-Debug "Response from server received successfully."
        Write-Debug "Response from server: $jsonResult"
        Write-Debug "Extracting content from response..."
        [object[]]$files = ConvertFrom-Json -InputObject $jsonResult.Content
        Write-Debug "Number of files on page '$currentPage' is: $($files.Count)"
      
        foreach ($file in $files)
        {
                $filesChanged.Add($file.filename) | Out-Null            
        }

        Write-Debug "Number of files detected so far: $($filesChanged.Count)"
        # get link that contains information about pages    
        $link = $jsonResult.Headers.Link
        Write-Debug "Getting next page information..."
        $isThereNextPage = $link -match 'rel="next"'
        Write-Debug "Pages left?: $isThereNextPage"
    } while ($isThereNextPage)

    Write-Debug "List of files changed: "
    foreach ($fileName in $filesChanged) {
        Write-Debug " $fileName"
    }  

    Write-Debug "Total: $($filesChanged.Count)"

    return $filesChanged
    }
}
