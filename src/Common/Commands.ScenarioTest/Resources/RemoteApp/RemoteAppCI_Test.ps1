
##. .\Utility.ps1

$waitInterval = 60 * 5

function CreateCloudCollection([string] $Collection)
{
    $regionList = Get-AzureRemoteAppLocation | % Name
    $region = Get-Random -InputObject $regionList
    Assert -Condition {-not [String]::IsNullOrWhiteSpace($region)}

    $templateList = Get-AzureRemoteAppTemplateImage | ? Type -eq Platform
    $candidateTemplate = $templateList | ? {$_.RegionList -contains $region}
    Assert({$candidateTemplate -ne $null})    
    $template = Get-Random -InputObject $candidateTemplate
    Assert -Condition {$template -ne $null}

    $billingPlans = Get-AzureRemoteAppPlan | % Name
    $billingPlan = Get-Random -InputObject $billingPlans
    Assert -Condition {-not [String]::IsNullOrWhiteSpace($billingPlan)}

    echo "New-AzureRemoteAppCollection -CollectionName $Collection -ImageName $($template.Name) -Plan $billingPlan -Location $region -Description 'Test Collection'"
    $trackIdCollection = New-AzureRemoteAppCollection -CollectionName $Collection -ImageName $template.Name -Plan $billingPlan -Location $region -Description 'Test Collection' -ErrorAction SilentlyContinue -ErrorVariable er
    if ($? -eq $false)
    {
       throw $er
    }

    $curTime = Get-Date
    do
    {
        echo "Waiting current time: $(Get-Date)"
        sleep -Seconds $waitInterval

        $collectionState = Get-AzureRemoteAppOperationResult -TrackingId $trackIdCollection.TrackingId -ErrorAction SilentlyContinue -ErrorVariable er
        if ($? -eq $false)
        {
           throw $er
        }

        echo "Collection state: $($collectionState.Status)"
   } while ($collectionState.Status -eq 'InProgress' -or $collectionState.Status -eq 'Pending')

   echo "State of collection is $($collectionState.Status)"
   $Collection
}


function PublishRemoteApplications([string] $Collection)
{
   $numOfApps = 5
   $availablePrograms = Get-AzureRemoteAppStartMenuProgram $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }


   $currentPrograms =  Get-AzureRemoteAppProgram -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }

   $programsToPublish = Get-Random -InputObject $availablePrograms -Count 5
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
   Assert -Condition {($publishedPrograms.Count-$currentPrograms.Count) -eq $numOfApps}

   $applications
}


function AddRemoteAppUsers([string] $Collection, [string[]] $msaUsers)
{
   $msaUsers | % {
       Add-AzureRemoteAppUser -CollectionName $Collection -Type MicrosoftAccount -UserUpn $_ -ErrorAction SilentlyContinue -ErrorVariable er
       if ($? -eq $false)
       {
           throw $er
       }
   }

   $addedUsers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   if ($? -eq $false)
   {
       throw $er
   }
   Assert -Condition {$addedUsers.Count -ge $msaUsers.Count}

   $addedUsers | select Name, UserIdType
}

function RemoveRemoteAppUsers([string] $Collection, [string[]] $msaUsers)
{
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

   $currentUsers = Get-AzureRemoteAppUser -CollectionName $Collection -ErrorAction SilentlyContinue -ErrorVariable er
   Assert -Condition {$currentUsers.Count -eq ($previousUsers.Count-$msaUsers.Count)}
}

function UnpublishRemoteApplications([string] $Collection, [string[]] $applications)
{
   $applications | % {
       Unpublish-AzureRemoteAppProgram -CollectionName $Collection -Alias $_ -ErrorAction SilentlyContinue -ErrorVariable er
       if ($? -eq $false)
       {
           throw $er
       }
   }

   $previouApps = get-AzureRemoteAppProgram $Collection | % Alias

   $collisions = $previouApps | ? {$applications -contains $_}
   Assert -Condition {$collisions.Count -eq 0}
}

function DeleteRemoteAppCollection([string] $Collection)
{
    $trackIdCollection =  Remove-AzureRemoteAppCollection -CollectionName $Collection
    $curTime = Get-Date
    do
    {
        echo "Waiting current time: $(Get-Date)"
        sleep -Seconds $waitInterval

        $collectionState = Get-AzureRemoteAppOperationResult -TrackingId $trackIdCollection.TrackingId -ErrorAction SilentlyContinue -ErrorVariable er
        if ($? -eq $false)
        {
           throw $er
        }

        echo "Collection state: $($collectionState.Status)"
   } while ($collectionState.Status -eq 'InProgress' -or $collectionState.Status -eq 'Pending')
}


function CheckinTest()
{
    $collection = 'CICollection'
    $msaUsers = "auxtm259@live.com", "auxtm260@live.com", "auxtm261@live.com"

    CreateCloudCollection $collection
<#
    $applications = PublishRemoteApplications $collection
    AddRemoteAppUsers $collection $msaUsers
    RemoveRemoteAppUsers $collection $msaUsers
    UnpublishRemoteApplications $collection ($applications | % {$_.ApplicationAlias})
#>
    DeleteRemoteAppCollection $collection
}