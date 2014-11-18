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

########################################################################### General Service Bus Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests any cloud based cmdlet with invalid credentials and expect it'll throw an exception.
#>
function Test-WithInvalidCredentials
{
    param([ScriptBlock] $cloudCmdlet)
    
    # Setup
    Remove-AllSubscriptions

    # Test
    Assert-Throws $cloudCmdlet "No current subscription has been designated. Use Select-AzureSubscription -Current <subscriptionName> to set the current subscription."
}

########################################################################### Get-AzureSBLocation Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests using List-AzureSBLocation and make sure that it's contents are filled out correctly.
#>
function Test-ListAzureSBLocation
{
    Get-AzureSBLocation | % { Assert-NotNull $_.Code;Assert-NotNull $_.FullName }
}

<#
.SYNOPSIS
Tests using List-AzureSBLocation and piping it's output to New-AzureSBNamespace.
#>
function Test-ListAzureSBLocation1
{
    # Setup
    $expectedName = Get-NamespaceName
    $expectedLocation = Get-DefaultServiceBusLocation

    # Test
    $namespace = Get-AzureSBLocation | 
    Select @{Name="Location";Expression={$_."Code"}} | 
    Where {$_.Location -eq $expectedLocation} | 
    % { New-Object PSObject -Property @{Name=$expectedName;Location=$_.Location} } | 
    New-AzureSBNamespace
  
    # Assert
    $actualName = $namespace.Name
    $actualLocation = $namespace.Region
    Assert-AreEqual $expectedName $actualName
    Assert-AreEqual $expectedLocation  $actualLocation

    # Cleanup
    $createdNamespaces += $expectedName
    Test-CleanupServiceBus
}

########################################################################### Get-AzureSBNamespace Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet and expects that no namespaces are returned.
#>
function Test-GetAzureSBNamespaceWithEmptyNamespaces
{
    # Setup
    Initialize-NamespaceTest

    # Test
    $namespaces = Get-AzureSBNamespace

    # Assert
    $expectedCount = (Get-AzureSBNamespace).Count
    Assert-AreEqual $namespaces.Count $expectedCount
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet and expects that one namespace is returned.
#>
function Test-GetAzureSBNamespaceWithOneNamespace
{
    # Setup
    Initialize-NamespaceTest
    New-Namespace 1

    # Test
    $namespaces = Get-AzureSBNamespace

    # Assert
    if ($namespaces.Count -gt 1) { Write-Warning "The test initialization did not succeed"; exit }
    Assert-AreEqualArray $global:createdNamespaces $($namespaces | Select -ExpandProperty Name)

    # Cleanup
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet and expects that multiple namespaces are returned.
#>
function Test-GetAzureSBNamespaceWithMultipleNamespaces
{
    # Setup
    Initialize-NamespaceTest
    New-Namespace 3

    # Test
    $namespaces = Get-AzureSBNamespace

    # Assert
    if ($namespaces.Count -gt 3) { Write-Warning "The test initialization did not succeed"; exit }
    Assert-AreEqualArray $global:createdNamespaces $($namespaces | Select -ExpandProperty Name)

    # Cleanup
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet using a valid name and expects getting the same object back.
#>
function Test-GetAzureSBNamespaceWithValidExisitingNamespace
{
    # Setup
    Initialize-NamespaceTest
    New-Namespace 1
    $expectedName = $createdNamespaces[0]

    # Test
    $namespace = Get-AzureSBNamespace $expectedName

    # Assert
    Assert-NotNull $namespace
    $actualName = $namespace.Name
    Assert-AreEqual $expectedName $actualName

    # Cleanup
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet using a non-existing name and expects that an exception is thrown.
#>
function Test-GetAzureSBNamespaceWithValidNonExisitingNamespace
{
    # Setup
    $invalidName = "OneSDKNotCreated"

    # Test
    Assert-Throws { Get-AzureSBNamespace $invalidName } "Internal Server Error. This could happen due to an incorrect/missing namespace"
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet and pipe it's result to Remove-AzureSBNamespace cmdlet.
#>
function Test-GetAzureSBNamespacePipedToRemoveAzureSBNamespace
{
    # Setup
    Initialize-NamespaceTest
    New-Namespace 2
    $actual = $true

    # Test
    Get-AzureSBNamespace | Where {$_.Status -eq "Active"} | Remove-AzureSBNamespace -PassThru -Force | % {$actual = $actual -and $_}

    # Assert
    Assert-True { $actual } "Piping Get-AzureSBNamespace into Remove-AzureSBNamespace failed"

    # Cleanup
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running Get-AzureSBNamespace cmdlet and pipe it's result to Set-AzureWebsite cmdlet.
#>
function Test-GetAzureSBNamespaceWithWebsites
{
    # Setup
    Initialize-NamespaceTest
    $namespaceName = Get-NamespaceName
    New-AzureSBNamespace $namespaceName $(Get-DefaultServiceBusLocation)
    Wait-NamespaceStatus $namespaceName "Active"
    $websiteName = Get-NamespaceName
    New-AzureWebsite $websiteName
    $settingName = "NamespaceConnectionString"

    # Test
    Get-AzureSBNamespace $namespaceName | % { Set-AzureWebsite $websiteName -AppSettings @{ $settingName = $_.ConnectionString } }

    # Assert
    $website = Get-AzureWebsite $websiteName
    $namespace = Get-AzureSBNamespace $namespaceName
    Assert-AreEqual $namespace.ConnectionString $website.AppSettings[$settingName]

    # Cleanup
    $createdNamespaces += $namespaceName
    Remove-AzureWebsite $websiteName -Force
    Test-CleanupServiceBus
}

########################################################################### New-AzureSBNamespace Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests running New-AzureSBNamespace cmdlet and expects new namespace created.
#>
function Test-NewAzureSBNamespaceWithValidNewNamespace
{
    # Setup
    $name = Get-NamespaceName

    # Test
    $actual = New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)

    # Assert
    Assert-AreEqual $name $actual.Name
    Assert-AreEqual $(Get-DefaultServiceBusLocation) $actual.Region
    Assert-True { "Activating" -eq $actual.Status -or "Active" -eq $actual.Status } "The namespace status does not equal to active or activating"

    # Cleanup
    $createdNamespaces += $name
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running New-AzureSBNamespace cmdlet on an existing namespace and expects exception.
#>
function Test-NewAzureSBNamespaceWithValidExistingNamespace
{
    # Setup
    $name = Get-NamespaceName
    New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)

    # Test
    Assert-Throws { New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation) } "Internal Server Error. This could happen because the namespace name is already used or due to an incorrect location name. Use Get-AzureSBLocation cmdlet to list valid names."

    # Cleanup
    $createdNamespaces += $name
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running New-AzureSBNamespace cmdlet with an invalid location expects exception.
#>
function Test-NewAzureSBNamespaceWithInvalidLocation
{
    # Setup

    # Test
    Assert-Throws { New-AzureSBNamespace $(Get-NamespaceName) "Invalid Location" } "The provided location `"Invalid Location`" does not exist in the available locations use Get-AzureSBLocation for listing available locations.`r`nParameter name: Location"
}

<#
.SYNOPSIS
Tests running New-AzureSBNamespace cmdlet and pipe it's result to Set-AzureWebsite cmdlet.
#>
function Test-NewAzureSBNamespaceWithWebsite
{
    # Setup
    $websiteName = Get-NamespaceName
    New-AzureWebsite $websiteName
    $settingName = "NamespaceConnectionString"
    $namespaceName = Get-NamespaceName

    # Test
    $used = Test-AzureName -ServiceBusNamespace $namespaceName
    Assert-False { $used } "The service bus name '$namespaceName' is not available"
    
    Get-AzureSBLocation | Select @{Name="Location";Expression={$_."Code"}} | Where {$_.Location -eq $(Get-DefaultServiceBusLocation)} | New-AzureSBNamespace $namespaceName
    
    do
    {
        $namespace = Get-AzureSBNamespace $namespaceName
        Wait-Seconds 5
    } while ($namespace.Status -ne "Active")

    $namespace | % { Set-AzureWebsite $websiteName -AppSettings @{ $settingName = $_.ConnectionString } }

    # Assert
    $website = Get-AzureWebsite $websiteName
    Assert-AreEqual $namespace.ConnectionString $website.AppSettings[$settingName]

    # Cleanup
    $createdNamespaces += $namespaceName
    Remove-AzureWebsite $websiteName -Force
    Test-CleanupServiceBus
}

<#
.SYNOPSIS
Tests running New-AzureSBNamespace cmdlet without location and expects new namespace created.
#>
function Test-NewAzureSBNamespaceWithDefaultLocation
{
    # Setup
    $name = Get-NamespaceName

    # Test
    $actual = New-AzureSBNamespace $name

    # Assert
    Assert-AreEqual $name $actual.Name
    Assert-AreEqual $(Get-DefaultServiceBusLocation) $actual.Region
    Assert-True { "Activating" -eq $actual.Status -or "Active" -eq $actual.Status } "The namespace status does not equal to active or activating"

    # Cleanup
    $createdNamespaces += $name
    Test-CleanupServiceBus
}

########################################################################### Remove-AzureSBNamespace Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests running Remove-AzureSBNamespace cmdlet and expects to remove the namespace.
#>
function Test-RemoveAzureSBNamespaceWithExistingNamespace
{
    # Setup
    $name = Get-NamespaceName
    New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)
    Wait-NamespaceStatus $name "Active"

    # Test
    Remove-AzureSBNamespace $name -Force

    # Assert
    $namespace = Get-AzureSBNamespace $name
    Assert-AreEqual "Removing" $namespace.Status
}

<#
.SYNOPSIS
Tests running Remove-AzureSBNamespace cmdlet with non-existing namespace and expects to get an exception
#>
function Test-RemoveAzureSBNamespaceWithNonExistingNamespace
{
    # Test
    Assert-Throws { Remove-AzureSBNamespace "NonExistingOneSDKName" -Force } "Internal Server Error. This could happen because the namespace does not exist or it does not exist under your subscription."
}

<#
.SYNOPSIS
Tests running Remove-AzureSBNamespace cmdlet pipe a namespace object into it.
#>
function Test-RemoveAzureSBNamespaceInputPiping
{
    # Setup
    $name = Get-NamespaceName

    # Test
    $used = Test-AzureName -ServiceBusNamespace $name
    Assert-False { $used } "The service bus name '$name' is not available"

    New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)
    
    Wait-NamespaceStatus $name "Active"
    
    Get-AzureSBNamespace $name | Remove-AzureSBNamespace -Force

    # Assert
    try
    { 
        $namespace = Get-AzureSBNamespace $name
        Assert-AreEqual "Removing" $namespace.Status
    }
    catch
    {
        # Succeed in case that the namespace was removed already.
    }
}

<#
.SYNOPSIS
Tests running Remove-AzureSBNamespace cmdlet with WhatIf parameter.
#>
function Test-RemoveAzureSBNamespaceWhatIf
{
    # Setup
    Initialize-NamespaceTest
    $name = Get-NamespaceName
    New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)
    Wait-NamespaceStatus $name "Active"

    # Test
    $message = Remove-AzureSBNamespace $name -WhatIf -Force
    $removed = Remove-AzureSBNamespace $name -Force -PassThru

    # Assert
    Assert-True { $removed }
}

<#
.SYNOPSIS
Tests running Remove-AzureSBNamespace cmdlet with WhatIf parameter.
#>
function Test-RemoveAzureSBNamespaceWhatIfError
{
    # Test
    Assert-Throws { Remove-AzureSBNamespace "123InvalidName" -WhatIf -Force } "The provided name `"123InvalidName`" does not match the service bus namespace naming rules.`r`nParameter name: Name"
}