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

# Scenario tests for New-AzDenyAssignment and Remove-AzDenyAssignment

# Helper: Get a valid user principal ID for the exclude list / per-principal tests.
# In Record mode with SP auth, Graph API calls (Get-AzADUser) may fail
# due to insufficient permissions. Use the known tenant admin user ID.
function Get-TestExcludePrincipalId
{
    # Prefer environment variable for CI/CD flexibility
    if ($env:TEST_EXCLUDE_PRINCIPAL_ID) {
        return $env:TEST_EXCLUDE_PRINCIPAL_ID
    }
    try {
        return (Get-AzADUser -SignedIn).Id
    } catch {
        # SP auth fallback: known user in the test tenant — override via TEST_EXCLUDE_PRINCIPAL_ID
        return "1840cc0e-55b5-442d-bbf6-52c0c7e27302"
    }
}
#
# UADA API model:
#   - Principals can be Everyone (SystemDefined with Guid.Empty) or a specific User/ServicePrincipal
#   - ExcludePrincipals is required for Everyone mode; optional for per-principal mode
#   - Group type principals are not supported
#   - DataActions not supported
#   - DoNotApplyToChildScopes not supported
#   - Read actions cannot be denied; only write/delete/action

<#
.SYNOPSIS
Creates a deny assignment at subscription scope with basic parameters.
#>
function Test-NewDaAtSubscriptionScope
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-SubScope-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment at subscription scope" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -ExcludePrincipalId $excludePrincipalId

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
        Assert-AreEqual $subscriptionScope $da.Scope
        Assert-NotNull $da.Id
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Creates a deny assignment at resource group scope.
#>
function Test-NewDaAtResourceGroupScope
{
    $rgName = "PowershellTest"
    $rg = Get-AzResourceGroup -Name $rgName
    $rgScope = $rg.ResourceId
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-RGScope-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment at resource group scope" `
            -Scope $rgScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -ExcludePrincipalId $excludePrincipalId

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
        Assert-True { $da.Scope -like "*$rgName*" }
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Verifies that data actions are rejected by PP1 API.
#>
function Test-NewDaWithDataActions
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId

    Assert-Throws {
        New-AzDenyAssignment `
            -DenyAssignmentName "Test-DA-DataActions" `
            -Scope $subscriptionScope `
            -DataAction "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read" `
            -ExcludePrincipalId $excludePrincipalId
    }
}

<#
.SYNOPSIS
Creates a deny assignment with multiple excluded principals.
#>
function Test-NewDaWithExcludePrincipals
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludeUser = Get-TestExcludePrincipalId
    $spId = "c090fe3f-66fa-4e18-8142-107d8f4cd0e4"  # DenyAssignmentTestApp
    $daName = "Test-DA-ExcludePrincipals-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        # Exclude both the user and the test service principal
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment with multiple exclude principals" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -ExcludePrincipalId @($excludeUser, $spId) `
            -ExcludePrincipalType @("User", "ServicePrincipal")

        Assert-NotNull $da
        Assert-True { $da.ExcludePrincipals.Count -ge 2 }
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Verifies that DoNotApplyToChildScopes is rejected by PP1 API.
#>
function Test-NewDaDoNotApplyToChildScopes
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId

    Assert-Throws {
        New-AzDenyAssignment `
            -DenyAssignmentName "Test-DA-ChildScopes" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -ExcludePrincipalId $excludePrincipalId `
            -DoNotApplyToChildScope
    }
}

<#
.SYNOPSIS
Creates a deny assignment from a JSON input file.
#>
function Test-NewDaFromInputFile
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-InputFile-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $inputObj = @{
        denyAssignmentName = $daName
        description = "Created from input file"
        actions = @("Microsoft.Storage/storageAccounts/write")
        notActions = @()
        dataActions = @()
        notDataActions = @()
        excludePrincipalIds = @($excludePrincipalId)
    }

    $tempFile = [System.IO.Path]::Combine([System.IO.Path]::GetTempPath(), ([Guid]::NewGuid().ToString() + ".json"))
    $inputObj | ConvertTo-Json -Depth 5 | Set-Content -Path $tempFile

    try
    {
        $da = New-AzDenyAssignment `
            -InputFile $tempFile `
            -Scope $subscriptionScope

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
        Remove-Item -Path $tempFile -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Creates a deny assignment with a specific GUID.
#>
function Test-NewDaWithCustomId
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $customId = [Guid]::NewGuid()
    $daName = "Test-DA-CustomId-" + $customId.ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment with custom ID" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -ExcludePrincipalId $excludePrincipalId `
            -DenyAssignmentId $customId

        Assert-NotNull $da
        Assert-True { $da.Id -like "*$customId*" }
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Removes a deny assignment by its ID.
#>
function Test-RemoveDaById
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-RemoveById-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $da = New-AzDenyAssignment `
        -DenyAssignmentName $daName `
        -Description "Test removal by ID" `
        -Scope $subscriptionScope `
        -Action "Microsoft.Storage/storageAccounts/write" `
        -ExcludePrincipalId $excludePrincipalId

    Assert-NotNull $da

    try
    {
        Remove-AzDenyAssignment -Id $da.Id -Force

        $result = Get-AzDenyAssignment -Id $da.Id -ErrorAction SilentlyContinue
        Assert-Null $result
    }
    catch
    {
        # Cleanup on failure
        Remove-AzDenyAssignment -Id $da.Id -Force -ErrorAction SilentlyContinue
        throw
    }
}

<#
.SYNOPSIS
Removes a deny assignment by name and scope.
#>
function Test-RemoveDaByNameAndScope
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-RemoveByName-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $da = New-AzDenyAssignment `
        -DenyAssignmentName $daName `
        -Description "Test removal by name and scope" `
        -Scope $subscriptionScope `
        -Action "Microsoft.Storage/storageAccounts/write" `
        -ExcludePrincipalId $excludePrincipalId

    Assert-NotNull $da

    Remove-AzDenyAssignment -DenyAssignmentName $daName -Scope $subscriptionScope -Force

    $result = Get-AzDenyAssignment -Id $da.Id -ErrorAction SilentlyContinue
    Assert-Null $result
}

<#
.SYNOPSIS
Removes a deny assignment using pipeline InputObject.
#>
function Test-RemoveDaByInputObject
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-RemoveByObj-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $da = New-AzDenyAssignment `
        -DenyAssignmentName $daName `
        -Description "Test removal by InputObject" `
        -Scope $subscriptionScope `
        -Action "Microsoft.Storage/storageAccounts/write" `
        -ExcludePrincipalId $excludePrincipalId

    Assert-NotNull $da

    $da | Remove-AzDenyAssignment -Force

    $result = Get-AzDenyAssignment -Id $da.Id -ErrorAction SilentlyContinue
    Assert-Null $result
}

<#
.SYNOPSIS
Removes a deny assignment with PassThru and verifies the returned object.
#>
function Test-RemoveDaWithPassThru
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-PassThru-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $da = New-AzDenyAssignment `
        -DenyAssignmentName $daName `
        -Description "Test removal with PassThru" `
        -Scope $subscriptionScope `
        -Action "Microsoft.Storage/storageAccounts/write" `
        -ExcludePrincipalId $excludePrincipalId

    Assert-NotNull $da

    $result = Remove-AzDenyAssignment -Id $da.Id -PassThru -Force

    Assert-NotNull $result
    Assert-AreEqual $da.Id $result.Id
}

<#
.SYNOPSIS
End-to-end: Create a deny assignment, verify it via Get, then delete it and verify deletion.
#>
function Test-NewAndRemoveDaEndToEnd
{
    # Clear errors from module loading to avoid false test failures
    $Error.Clear()
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $excludePrincipalId = Get-TestExcludePrincipalId
    $daName = "Test-DA-E2E-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    # 1. Create
    $da = New-AzDenyAssignment `
        -DenyAssignmentName $daName `
        -Description "End-to-end test deny assignment" `
        -Scope $subscriptionScope `
        -Action "Microsoft.Storage/storageAccounts/write" `
        -ExcludePrincipalId $excludePrincipalId

    Assert-NotNull $da
    Assert-AreEqual $daName $da.DenyAssignmentName
    Assert-AreEqual "End-to-end test deny assignment" $da.Description

    # 2. Verify via Get
    $fetched = Get-AzDenyAssignment -Id $da.Id
    Assert-NotNull $fetched
    Assert-AreEqual $da.DenyAssignmentName $fetched.DenyAssignmentName
    Assert-AreEqual $da.Id $fetched.Id

    # 3. Delete
    Remove-AzDenyAssignment -Id $da.Id -Force

    # 4. Verify gone
    $gone = Get-AzDenyAssignment -Id $da.Id -ErrorAction SilentlyContinue
    Assert-Null $gone
}

# =============================================
# Per-Principal deny assignment tests
# =============================================

# Helper: Get a test service principal ID
function Get-TestServicePrincipalId
{
    if ($env:TEST_SERVICE_PRINCIPAL_ID) {
        return $env:TEST_SERVICE_PRINCIPAL_ID
    }
    return "c090fe3f-66fa-4e18-8142-107d8f4cd0e4"  # DenyAssignmentTestApp
}

<#
.SYNOPSIS
Creates a deny assignment targeting a specific user principal.
#>
function Test-NewDaWithUserPrincipal
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $userId = Get-TestExcludePrincipalId
    $daName = "Test-DA-UserPrincipal-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment targeting a specific user" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -PrincipalId $userId `
            -PrincipalType "User"

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
        Assert-True { $da.Principals.Count -eq 1 }
        Assert-AreEqual $userId $da.Principals[0].ObjectId
        Assert-AreEqual "User" $da.Principals[0].ObjectType
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Creates a deny assignment targeting a specific service principal.
#>
function Test-NewDaWithServicePrincipal
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $spId = Get-TestServicePrincipalId
    $daName = "Test-DA-SPPrincipal-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Test deny assignment targeting a specific service principal" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -PrincipalId $spId `
            -PrincipalType "ServicePrincipal"

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
        Assert-True { $da.Principals.Count -eq 1 }
        Assert-AreEqual $spId $da.Principals[0].ObjectId
        Assert-AreEqual "ServicePrincipal" $da.Principals[0].ObjectType
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Verifies that ExcludePrincipalId is optional in per-principal mode.
#>
function Test-NewDaPerPrincipalNoExcludes
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $userId = Get-TestExcludePrincipalId
    $daName = "Test-DA-NoExcludes-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        # No ExcludePrincipalId — should succeed in per-principal mode
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Per-principal DA without excluded principals" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -PrincipalId $userId `
            -PrincipalType "User"

        Assert-NotNull $da
        Assert-True { $da.ExcludePrincipals.Count -eq 0 -or $da.ExcludePrincipals -eq $null }
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Verifies that ExcludePrincipalId works as an optional parameter in per-principal mode.
#>
function Test-NewDaPerPrincipalWithExcludes
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $spId = Get-TestServicePrincipalId
    $excludeUser = Get-TestExcludePrincipalId
    $daName = "Test-DA-PerPrincipalExcl-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    try
    {
        $da = New-AzDenyAssignment `
            -DenyAssignmentName $daName `
            -Description "Per-principal DA with excluded principals" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -PrincipalId $spId `
            -PrincipalType "ServicePrincipal" `
            -ExcludePrincipalId $excludeUser `
            -ExcludePrincipalType "User"

        Assert-NotNull $da
        Assert-True { $da.Principals.Count -eq 1 }
        Assert-AreEqual $spId $da.Principals[0].ObjectId
        Assert-True { $da.ExcludePrincipals.Count -ge 1 }
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
    }
}

<#
.SYNOPSIS
Verifies that Group principal type is rejected client-side.
#>
function Test-NewDaPerPrincipalGroupRejected
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $groupId = [Guid]::NewGuid().ToString()

    # Group type should be rejected by ValidateSet on the cmdlet parameter.
    # The error will be a ParameterBindingValidationException.
    Assert-Throws {
        New-AzDenyAssignment `
            -DenyAssignmentName "Test-DA-Group" `
            -Scope $subscriptionScope `
            -Action "Microsoft.Storage/storageAccounts/write" `
            -PrincipalId $groupId `
            -PrincipalType "Group"
    }
}

<#
.SYNOPSIS
Creates a per-principal deny assignment from a JSON input file.
#>
function Test-NewDaPerPrincipalFromInputFile
{
    $subscriptionScope = "/subscriptions/$((Get-AzContext).Subscription.Id)"
    $userId = Get-TestExcludePrincipalId
    $daName = "Test-DA-PerPrincipalFile-" + [Guid]::NewGuid().ToString().Substring(0, 8)

    $inputObj = @{
        denyAssignmentName = $daName
        description = "Per-principal DA created from input file"
        actions = @("Microsoft.Storage/storageAccounts/write")
        notActions = @()
        dataActions = @()
        notDataActions = @()
        principalIds = @($userId)
        principalTypes = @("User")
    }

    $tempFile = [System.IO.Path]::Combine([System.IO.Path]::GetTempPath(), ([Guid]::NewGuid().ToString() + ".json"))
    $inputObj | ConvertTo-Json -Depth 5 | Set-Content -Path $tempFile

    try
    {
        $da = New-AzDenyAssignment `
            -InputFile $tempFile `
            -Scope $subscriptionScope

        Assert-NotNull $da
        Assert-AreEqual $daName $da.DenyAssignmentName
        Assert-True { $da.Principals.Count -eq 1 }
        Assert-AreEqual $userId $da.Principals[0].ObjectId
    }
    finally
    {
        if ($da)
        {
            Remove-AzDenyAssignment -Id $da.Id -Force
        }
        Remove-Item -Path $tempFile -Force -ErrorAction SilentlyContinue
    }
}
