function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    $DebugPreference = 'Continue'

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    ####### Prerequisite #######
    # Visit https://github.com/Azure/azvmimagebuilder/tree/main/quickquickstarts to get more details
    # 1. Create a resource group
    $rg = $env.AddWithCache("rg", "azps-test-" + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $location = $env.AddWithCache("location", "eastus", $UsePreviousConfigForRecord)
    New-AzResourceGroup -Name $rg -Location $location

    # 2. Create an user identity
    Write-Host -ForegroundColor Green "Creating an user identity..."
    $identityName = $env.AddWithCache("identityName", "azps-mi-" + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $identity = New-AzUserAssignedIdentity -ResourceGroupName $rg -Name $identityName -Location $location
    $env.AddWithCache("identity", $identity, $UsePreviousConfigForRecord)

    # 3. Create a role definition
    Write-Host -ForegroundColor Green "Creating a role definition..."
    $roleName = $env.AddWithCache("roleName", 'Image Builder Service Image Creation Role ' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $role = New-AzRoleDefinition -Role @{
        Name = $roleName;
        IsCustom = $True;
        Description = "Image Builder access to create resources for the image build, you should delete or split out as appropriate";
        Actions = @(
            "Microsoft.Compute/galleries/read",
            "Microsoft.Compute/galleries/images/read",
            "Microsoft.Compute/galleries/images/versions/read",
            "Microsoft.Compute/galleries/images/versions/write",
            "Microsoft.Compute/images/write",
            "Microsoft.Compute/images/read",
            "Microsoft.Compute/images/delete"
        );
        AssignableScopes = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$rg"
    }
    $env.AddWithCache("role", $role, $UsePreviousConfigForRecord)

    # 4. Grant role definition above to the user assigned identity
    Start-Sleep -Seconds 60 # Sleep to allow get-azserviceprincipal work
    Write-Host -ForegroundColor Green "Assigning a role to the user identity..."
    New-AzRoleAssignment -ObjectId $identity.PrincipalId -RoleDefinitionId $role.Id -Scope "/subscriptions/$($env.SubscriptionId)/resourceGroups/$rg"

    # 5. Create an image gallery
    Write-Host -ForegroundColor Green "Create an image gallery..."
    $testGalleryName = $env.AddWithCache("testGalleryName", "azpsgallery" + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    New-AzGallery -GalleryName $testGalleryName -ResourceGroupName $rg -Location $location

    # 6. Create a gallery definition
    Write-Host -ForegroundColor Green "Create a gallery definition..."
    $imageDefName = $env.AddWithCache("imageDefName", "azpsvmimage1", $UsePreviousConfigForRecord)
    $image = New-AzGalleryImageDefinition -GalleryName $testGalleryName -ResourceGroupName $rg -Location $location -Name $imageDefName -OsState generalized -OsType Linux -Publisher bez -Offer UbuntuServer -Sku '18.04-LTS'
    $env.AddWithCache("image", $image, $UsePreviousConfigForRecord)

    # 7. Create a template with shared image
    Write-Host -ForegroundColor Green "Creating a image builder template..."
    $templateName = $env.AddWithCache("templateName", 'azps-tmp-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $runOutputName = $env.AddWithCache("runOutputName", 'runoutput1', $UsePreviousConfigForRecord)
    $JsonTemplatePath = Join-Path $PSScriptRoot JsonTemplateFile.json
    $Content = Get-Content -Path $JsonTemplatePath  -Raw
    $Content = $Content -replace '<subscriptionID>', $env.SubscriptionId
    $Content = $Content -replace '<rgName>', $rg
    $Content = $Content -replace '<identityName>', $identityName
    $Content = $Content -replace '<testGalleryName>', $testGalleryName
    $Content = $Content -replace '<imageDefName>', $imageDefName
    $Content = $Content -replace '<runOutputName>', $runOutputName
    $Content | Out-File -FilePath $JsonTemplatePath -Force
    New-AzImageBuilderTemplate -Name $templateName -ResourceGroupName $rg -JsonTemplatePath $JsonTemplatePath

    # 9. Add user id to access the template
    Write-Host "Add user id to access the template"
    New-AzRoleAssignment -ObjectId $identity.PrincipalId -RoleDefinitionName Contributor -ResourceGroupName $rg

    # 10. Start the image builder above
    # Need to record start image builder separetely.
    # Only below lines are not needed in recording stop test cases
    # Write-Host -ForegroundColor Green "Starting the image builder template..."
    # Start-Sleep -Seconds 25
    # Start-AzImageBuilderTemplate -Name $templateName -ResourceGroupName $rg -NoWait

    # Prepare some variables for test usage
    $newTemplateName1 = $env.AddWithCache("newTemplateName1", 'azps-tmp-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $newTemplateName2 = $env.AddWithCache("newTemplateName2", 'azps-tmp-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $newTemplateName3 = $env.AddWithCache("newTemplateName3", 'azps-tmp-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)

    # 11. Create a new Trigger
    $newTempTriggerName1 = $env.AddWithCache("newTempTriggerName1", 'azps-trigger-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    $newTempTriggerName2 = $env.AddWithCache("newTempTriggerName2", 'azps-trigger-' + (RandomString -allChars $false -len 6), $UsePreviousConfigForRecord)
    New-AzImageBuilderTrigger -ImageTemplateName $templateName -ResourceGroupName $rg -Name $newTempTriggerName1 -Kind "SourceImage"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
    # 0. Restore JsonTemplateFile.json
    git restore JsonTemplateFile.json

    # 1. Grant role definition above to the user assigned identity
    Get-AzRoleAssignment -ObjectId $env.identity.PrincipalId -RoleDefinitionName $env.roleName -Scope "/subscriptions/$($env.SubscriptionId)/resourceGroups/$rg" | Remove-AzRoleAssignment -Confirm:$false

    # 2. Remove role definition
    Get-AzRoleDefinition -Name $env.roleName | Remove-AzRoleDefinition -Force

    # 3. remove resource group
    Get-AzResourceGroup -Name $env.rg | Remove-AzResourceGroup
}

