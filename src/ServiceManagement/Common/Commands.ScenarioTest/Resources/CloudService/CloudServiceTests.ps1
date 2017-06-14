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

########################################################################### General Cloud Service Scenario Tests ###########################################################################

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

########################################################################### Publish-AzureServiceProject Scenario Tests ###################################################################

<#
.SYNOPSIS
Tests Publishing a Cache Service.
#>
function Test-PublishCacheService
{
    PublishAndUpdate-CloudService 1 {New-CacheCloudServiceProject $args[0]} {Verify-CacheApp $args[0].Url.ToString()}
}

<#
.SYNOPSIS
Tests Publishing and updating a Cache Service.
#>
function Test-UpdateCacheService
{
    PublishAndUpdate-CloudService 1 {New-CacheCloudServiceProject $args[0]} {Verify-CacheApp $args[0].Url.ToString()} {Test-RemoteDesktop}
}

<#
.SYNOPSIS
Tests Publish-AzureServiceProject with using ServiceSettings.Location
#>
function Test-PublishUsesSettingsLocation
{
    # Setup
    $name = Get-CloudServiceName
    $locations = Get-AzureLocation
    $location = $locations[1].Name
    New-AzureServiceProject $name
    Add-AzureNodeWebRole
    Set-AzureServiceProject -Location $location

    # Test
    Publish-AzureServiceProject

    # Assert
    $service = Get-AzureService $name
    $actual = $service.Location
    Assert-AreEqual $location $actual
}

########################################################################### Remove-AzureService Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Remove-AzureService with non-existing service.
#>
function Test-RemoveAzureServiceWithNonExistingService
{
    # Test
    Assert-Throws { Remove-AzureService "DoesNotExist" -Force } "The specified cloud service `"DoesNotExist`" does not exist."
}

<#
.SYNOPSIS
Tests Remove-AzureService with an existing service that does not have any deployments
#>
function Test-RemoveAzureServiceWithCloudService
{
    <# To Do: implement when we have unsigned version from Management.ServiceManagement assembly #>
}

<#
.SYNOPSIS
Tests Remove-AzureService with an existing service that has production deployment only
#>
function Test-RemoveAzureServiceWithProductionDeployment
{
    # Setup
    New-CloudService 1
    $name = $global:createdCloudServices[0]

    # Test
    $removed = Remove-AzureService $name -Force -PassThru

    # Assert
    Assert-True { $removed }
}

<#
.SYNOPSIS
Tests Remove-AzureService with an existing service that has staging deployment only
#>
function Test-RemoveAzureServiceWithStagingDeployment
{
    <# To Do: implement when we have unsigned version from Management.ServiceManagement assembly #>
}

<#
.SYNOPSIS
Tests Remove-AzureService with an existing service that has production and staging deployments
#>
function Test-RemoveAzureServiceWithFullCloudService
{
    <# To Do: implement when we have unsigned version from Management.ServiceManagement assembly #>
}

<#
.SYNOPSIS
Tests Remove-AzureService with WhatIf
#>
function Test-RemoveAzureServiceWhatIf
{
    # Setup
    New-CloudService 1
    $name = $global:createdCloudServices[0]

    # Test
    Remove-AzureService $name -Force -WhatIf
    $removed = Remove-AzureService $name -Force -PassThru

    # Assert
    Assert-True { $removed }
}

<#
.SYNOPSIS
Tests Remove-AzureService with WhatIf by passing invalid cloud service name and expects no error
#>
function Test-RemoveAzureServiceWhatIfWithInvalidName
{
    # Test
    Remove-AzureService "InvalidName" -Force -WhatIf

    # Assert
    Assert-True { $true }
}

<#
.SYNOPSIS
Tests Remove-AzureService with service piped from Get-AzureService cmdlet
#>
function Test-RemoveAzureServicePipedFromGetAzureService
{
    # Setup
    $name = Get-CloudServiceName
    New-AzureService $name -Location $(Get-DefaultLocation)

    # Test
    $removed = Get-AzureService $name | Remove-AzureService -Force -PassThru

    # Assert
    Assert-True { $removed }
}

########################################################################### Start-AzureService Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Start-AzureService with non-existing service.
#>
function Test-StartAzureServiceWithNonExistingService
{
    # Test
    Assert-Throws { Start-AzureService "DoesNotExist" } "The specified cloud service `"DoesNotExist`" does not exist."
}

<#
.SYNOPSIS
Tests Start-AzureService with an existing service that does not have any deployments
#>
function Test-StartAzureServiceWithEmptyDeployment
{
    # Setup
    $name = Get-CloudServiceName
    $msg = [string]::Format("Deployment for service {0} with Staging slot doesn't exist", $name)
    New-AzureService $name -Location $(Get-DefaultLocation)

    # Test
    Assert-Throws { Start-AzureService $name -Slot Staging } $msg
}

<#
.SYNOPSIS
Tests Start-AzureService with an existing service that has production deployment only
#>
function Test-StartAzureServiceWithProductionDeployment
{
    # Setup
    New-CloudService 1
    $name = $global:createdCloudServices[0]
    Stop-AzureService $name
    Wait-Seconds 30 # Wait for a bit, sometimes the deployment status is stopped but still stopping

    # Test
    $started = Get-AzureService $name | Start-AzureService -PassThru

    # Assert
    Assert-True { $started }
}

<#
.SYNOPSIS
Tests Start-AzureService with an existing service that has staging deployment only
#>
function Test-StartAzureServiceWithStagingDeployment
{
    # Setup
    New-CloudService 1 $null Staging
    $name = $global:createdCloudServices[0]
    Stop-AzureService $name -Slot Staging
    Wait-Seconds 30 # Wait for a bit, sometimes the deployment status is stopped but still stopping

    # Test
    $started = Start-AzureService $name -Slot Staging -PassThru

    # Assert
    Assert-True { $started }
}

<#
.SYNOPSIS
Tests Start-AzureService works without passing name in cloud service project.
#>
function Test-StartAzureServiceWithoutName
{
    # Setup
    New-CloudService 1
    Stop-AzureService
    Wait-Seconds 30 # Wait for a bit, sometimes the deployment status is stopped but still stopping

    # Test
    $started = Start-AzureService -PassThru

    # Assert
    Assert-True { $started }
}

########################################################################### Test-AzureName Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Test-AzureName with not existing hosted service and expects $false.
#>
function Test-AzureNameWithNotExistingHostedService
{
    # Test
    $actual = Test-AzureName -Service "onesdknotexisting"

    # Assert
    Assert-False { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with existing hosted service and expects $true.
#>
function Test-AzureNameWithExistingHostedService
{
    # Setup
    $name = $(Get-CloudServiceName)
    New-AzureService $name -Location $(Get-DefaultLocation)

    # Test
    $actual = Test-AzureName -Service $name

    # Assert
    Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with invalid hosted service name and expects $true
#>
function Test-AzureNameWithInvalidHostedService
{
    # Test
    $actual = Test-AzureName -Service "Invalid Name"

    # Assert
    Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with not existing Storage service and expects $false.
#>
function Test-AzureNameWithNotExistingStorageService
{
    # Test
    $actual = Test-AzureName -Storage "onesdknotexisting"

    # Assert
    Assert-False { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with existing Storage service and expects $true.
#>
function Test-AzureNameWithExistingStorageService
{
    # Setup
    $name = $(Get-CloudServiceName)
    New-AzureStorageAccount $name -Location $(Get-DefaultLocation)

    # Test
    $actual = Test-AzureName -Storage $name

    # Assert
    Assert-True { $actual }

    # Cleanup
    Initialize-CloudServiceTest
}

<#
.SYNOPSIS
Tests Test-AzureName with invalid Storage service name and expects $false
#>
function Test-AzureNameWithInvalidStorageService
{
    # Test
    Assert-Throws { Test-AzureName -Storage "Invalid Name" }
}

<#
.SYNOPSIS
Tests Test-AzureName with not existing service bus namespace and expects $false.
#>
function Test-AzureNameWithNotExistingServiceBusNamespace
{
    # Test
    $actual = Test-AzureName -ServiceBusNamespace "onesdknotexisting"

    # Assert
    Assert-False { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with existing service bus namespace and expects $true.
#>
function Test-AzureNameWithExistingServiceBusNamespace
{
    # Setup
    $name = $(Get-NamespaceName)
    New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation)

    # Test
    $actual = Test-AzureName -ServiceBusNamespace $name

    # Assert
    Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Test-AzureName with invalid service bus namespace name and expects $false
#>
function Test-AzureNameWithInvalidServiceBusNamespace
{
    # Test
    Assert-Throws { Test-AzureName -ServiceBusNamespace "Invalid Name" }
}

########################################################################### Stop-AzureService Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Stop-AzureService with non-existing service.
#>
function Test-StopAzureServiceWithNonExistingService
{
    # Test
    Assert-Throws { Stop-AzureService "DoesNotExist" } "The specified cloud service `"DoesNotExist`" does not exist."
}

<#
.SYNOPSIS
Tests Stop-AzureService with an existing service that does not have any deployments
#>
function Test-StopAzureServiceWithEmptyDeployment
{
    # Setup
    $name = Get-CloudServiceName
    $msg = [string]::Format("Deployment for service {0} with Staging slot doesn't exist", $name)
    New-AzureService $name -Location $(Get-DefaultLocation)

    # Test
    Assert-Throws { Stop-AzureService $name -Slot Staging } $msg
}

<#
.SYNOPSIS
Tests Stop-AzureService with an existing service that has production deployment only
#>
function Test-StopAzureServiceWithProductionDeployment
{
    # Setup
    New-CloudService 1
    $name = $global:createdCloudServices[0]

    # Test
    $Stopped = Get-AzureService $name | Stop-AzureService -PassThru

    # Assert
    Assert-True { $Stopped }
}

<#
.SYNOPSIS
Tests Stop-AzureService with an existing service that has staging deployment only
#>
function Test-StopAzureServiceWithStagingDeployment
{
    # Setup
    New-CloudService 1 $null "Staging"
    $name = $global:createdCloudServices[0]

    # Test
    $Stopped = Stop-AzureService $name -PassThru -Slot "Staging"

    # Assert
    Assert-True { $Stopped }
}

<#
.SYNOPSIS
Tests Stop-AzureService works without passing name in cloud service project.
#>
function Test-StopAzureServiceWithoutName
{
    # Setup
    New-CloudService 1

    # Test
    $stopped = Stop-AzureService -PassThru

    # Assert
    Assert-True { $stopped }
}

########################################################################### Start-AzureEmulator Scenario Tests ###################################################################

<#
.SYNOPSIS
Executes Start-AzureEmulator two times and expect to proceed.
#>
function Test-StartAzureEmulatorTwice
{
    # Setup
    New-TinyCloudServiceProject test
    Start-AzureEmulator -Mode Full
    
    # Test
    $service = Start-AzureEmulator -Mode Full
    
    # Clean up
    Stop-AzureEmulator
     
    # Assert
    Assert-NotNull $service
}

<#
.SYNOPSIS
Executes Start-AzureEmulator using Express mode.
#>
function Test-StartAzureEmulatorExpress
{
    # Setup
    New-TinyCloudServiceProject test
    
    # Test
    $service = Start-AzureEmulator -Mode Express
    
    # Clean up
    Stop-AzureEmulator
    
    # Assert
    Assert-NotNull $service
}

########################################################################### Cloud Service ReverseDnsFqdn Scenario Tests ###################################################################

<#
.SYNOPSIS
Executes New-AzureService using the ReverseDnsFqdn parameter.
#>
function Test-NewAzureServiceWithReverseDnsFqdn
{
    # Setup
    $name = Get-CloudServiceName
    $reverseFqdn = "$name.cloudapp.net."
    
    # Test
    New-AzureService $name -Location $(Get-DefaultLocation) -ReverseDnsFqdn $reverseFqdn
    $service = Get-AzureService $name
   
    # Assert
    Assert-AreEqual $reverseFqdn $service.ReverseDnsFqdn
}

<#
.SYNOPSIS
Executes Set-AzureService using the ReverseDnsFqdn parameter.
#>
function Test-SetAzureServiceWithReverseDnsFqdn
{
    # Setup
    $name = Get-CloudServiceName
    $reverseFqdn = "$name.cloudapp.net."
    
    New-AzureService $name -Location $(Get-DefaultLocation)
    $service = Get-AzureService $name
   
    Assert-Null $service.ReverseDnsFqdn
    
    # Test
    Set-AzureService $name -ReverseDnsFqdn $reverseFqdn
    $service = Get-AzureService $name
    
    # Assert
    Assert-AreEqual $reverseFqdn $service.ReverseDnsFqdn
}

<#
.SYNOPSIS
Executes Set-AzureService using the ReverseDnsFqdn parameter setting it to empty string.
#>
function Test-SetAzureServiceWithEmptyReverseDnsFqdn
{
    # Setup
    $name = Get-CloudServiceName
    $reverseFqdn = "$name.cloudapp.net."
    
    New-AzureService $name -Location $(Get-DefaultLocation) -ReverseDnsFqdn $reverseFqdn
    $service = Get-AzureService $name
   
    Assert-AreEqual $reverseFqdn $service.ReverseDnsFqdn

    # Test
    Set-AzureService $name -ReverseDnsFqdn ''
    $service = Get-AzureService $name
    
    # Assert
    Assert-AreEqual '' $service.ReverseDnsFqdn
}

