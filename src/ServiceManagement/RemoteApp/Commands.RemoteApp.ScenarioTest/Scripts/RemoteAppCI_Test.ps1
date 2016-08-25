
function PollingInterval()
{
   if ($env:AZURE_TEST_MODE -eq 'Playback') 
   {
      $pollingIntervalSecs = 5
   } 
   else 
   {
      $pollingIntervalSecs = 60 * 5
   }
   $pollingIntervalSecs
}

function Assert([ScriptBlock] $Condition)
{
   if ((& $Condition) -eq $false)
   {
        throw "Assertion Failed $($Condition.ToString()): $(Get-PSCallStack | Out-String)"
   }
}

<#
    This will pick a location, image, billing plan and create a ARA App collection and returns the collection name.
#>
function CreateCloudCollection([string] $Collection)
{

    Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
    [PSObject[]] $locationList = Get-AzureRemoteAppLocation | % Name
    Assert -Condition {$locationList -ne $null -or $locationList.Count -lt 1}    

    [PSObject[]] $templateImageList = Get-AzureRemoteAppTemplateImage | ? {$_.Type -eq 'Platform' -and $_.OfficeType -ne 'Office365'}
    Assert -Condition {$templateImageList -ne $null -or $templateImageList.Count -lt 1}    
 
    $templateImage = $null
    $locCounter = 0
    $imageCounter = 0
    $found = $false
    do
    {   
        $location = $locationList[$locCounter]
        do
        {
            $templateImage = $templateImageList[$imageCounter]
            if ($templateImage.RegionList -contains $location)
            {
               $found = $true
            }
            
            $imageCounter++
        } while ($imageCounter -lt $templateImageList.Count -and -not $found)

        $locCounter++
    } while ($locCounter -lt $locationList.Count -and -not $found)

    Assert -Condition {$found}

    $billingPlans = Get-AzureRemoteAppPlan | % Name
    $billingPlan = $billingPlans[0]
    Assert -Condition {-not [String]::IsNullOrWhiteSpace($billingPlan)}

    Write-Verbose "New-AzureRemoteAppCollection -CollectionName $Collection -ImageName $($templateImage.Name) -Plan $billingPlan -Location $location -Description 'Test Collection'"
    $trackIdCollection = New-AzureRemoteAppCollection -CollectionName $Collection -ImageName $templateImage.Name -Plan $billingPlan -Location $location -Description 'Test Collection' -ErrorAction SilentlyContinue -ErrorVariable er
    if ($? -eq $false)
    {
       throw $er
    }

    do
    {
        Write-Verbose "Waiting current time: $(Get-Date)"
        if ($env:AZURE_TEST_MODE -eq "Record"){
          sleep -Seconds (PollingInterval)
        }
        $collectionState = Get-AzureRemoteAppOperationResult -TrackingId $trackIdCollection.TrackingId -ErrorAction SilentlyContinue -ErrorVariable er
        if ($? -eq $false)
        {
           throw $er
        }

        Write-Verbose "Collection state: $($collectionState.Status)"
   } while ($collectionState.Status -eq 'InProgress' -or $collectionState.Status -eq 'Pending')

   Assert -Condition {$collectionState.Status -eq 'Success'}
   Write-Verbose "$($MyInvocation.MyCommand.name) succsssfully created this collection $Collection" 
}


<#
    This will pick a 5 applications to publish, verifies that they've been published and returns the Publishing Info.
#>
function PublishRemoteApplications([string] $Collection)
{
   Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
   $numOfApps = 5
   $availablePrograms = Get-AzureRemoteAppStartMenuProgram $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   Assert({$availablePrograms.Count -ge $numOfApps})

   $currentPrograms =  Get-AzureRemoteAppProgram -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   $programsToPublish = $availablePrograms[0..2]
   $programsToPublish += $availablePrograms[$($availablePrograms.Count-2)..$($availablePrograms.Count-1)] 
   Assert({$programsToPublish.Count -eq $numOfApps})
   $applications = $programsToPublish | % { 
       Publish-AzureRemoteAppProgram -CollectionName $Collection -StartMenuAppId $_.StartMenuAppId -ErrorAction SilentlyContinue -ErrorVariable er
       if ($? -eq $false)
       {
           throw $er
       }
   }

   $publishedPrograms =  Get-AzureRemoteAppProgram -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   Assert -Condition {($publishedPrograms.Count - $currentPrograms.Count) -eq $numOfApps}

   $applications |  % {Write-Verbose "($([IO.FileInfo]$_.ApplicationVirtualPath))"}
   Write-Verbose "$($MyInvocation.MyCommand.name) completed succsssfully" 

   $applications
}


<#
    This will pick a add the given users to the collection.
#>
function AddRemoteAppUsers([string] $Collection, [string[]] $msaUsers)
{
   Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
   $previousUsers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   $msaUsers | % {
       Add-AzureRemoteAppUser -CollectionName $Collection -Type MicrosoftAccount -UserUpn $_ -ErrorAction SilentlyContinue -ErrorVariable er
       if ($? -eq $false)
       {
           throw $er
       }
   }

   $currentUsers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   Assert -Condition {($previousUsers.Count + $msaUsers.Count) -eq $currentUsers.Count}
   Write-Verbose "$($MyInvocation.MyCommand.name) completed succsssfully" 

   $currentUsers | % {Write-Verbose "Username: $($_.Name),and Type: $($_.UserIdType)" }
}

<#
    This will remove the given users from the collection.
#>
function RemoveRemoteAppUsers([string] $Collection, [string[]] $msaUsers)
{
   Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
   $previousUsers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   $msaUsers | % {
       Remove-AzureRemoteAppUser -CollectionName $Collection -Type MicrosoftAccount -UserUpn $_ -ErrorAction SilentlyContinue -ErrorVariable er
       if ($? -eq $false)
       {
           throw $er
       }
   }

   $currentUssers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   Assert -Condition {$currentUsers -eq $null}
   Write-Verbose "$($MyInvocation.MyCommand.name) completed succsssfully" 
}

<#
    This will unpublish the specified applications from the collection.
#>
function UnpublishRemoteApplications([string] $Collection, [string[]] $applications)
{
   Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
   $applications | % {
       Unpublish-AzureRemoteAppProgram -CollectionName $Collection -Alias $_ -ErrorAction SilentlyContinue -ErrorVariable er  | Out-Null
       if ($? -eq $false)
       {
           throw $er
       }
   }

   if ($env:AZURE_TEST_MODE -eq "Record"){
    Sleep 60 # seconds
   }
   $remainingApps = Get-AzureRemoteAppProgram $Collection | % Alias

   $failedToUnpublish = $remainingApps | ? {$applications -contains $_}
   Assert -Condition {$failedToUnpublish -eq $null}
   Write-Verbose "$($MyInvocation.MyCommand.name) completed succsssfully" 
}

<#
    This delete the collection
#>
function DeleteRemoteAppCollection([string] $Collection)
{
    Write-Verbose "Entering $($MyInvocation.MyCommand.name)" 
    $trackIdCollection =  Remove-AzureRemoteAppCollection -CollectionName $Collection

    do
    {
        Write-Verbose "Waiting current time: $(Get-Date)"
        if ($env:AZURE_TEST_MODE -eq "Record"){
          sleep -Seconds (PollingInterval)
        }
        $collectionState = Get-AzureRemoteAppOperationResult -TrackingId $trackIdCollection.TrackingId -ErrorAction SilentlyContinue -ErrorVariable er
        if ($? -eq $false)
        {
           throw $er
        }

        Write-Verbose "Collection state: $($collectionState.Status)"
   } while ($collectionState.Status -eq 'InProgress' -or $collectionState.Status -eq 'Pending')

   Assert -Condition {$collectionState.Status -eq 'Success'}
   Write-Verbose "$($MyInvocation.MyCommand.name) completed succsssfully" 
}


function TestRemoteAppEndToEnd()
{
    $collection = 'CICollection'
    $msaUsers = "auxtm259@live.com", "auxtm260@live.com", "auxtm261@live.com"
    Set-Variable -Name VerbosePreference -Value Continue

    Write-Verbose "Starting current time: $(Get-Date)"
    CreateCloudCollection $collection
    $applications = PublishRemoteApplications $collection
    AddRemoteAppUsers $collection $msaUsers
    RemoveRemoteAppUsers $collection $msaUsers
    UnpublishRemoteApplications $collection ($applications | % {$_.ApplicationAlias})
    DeleteRemoteAppCollection $collection
}
