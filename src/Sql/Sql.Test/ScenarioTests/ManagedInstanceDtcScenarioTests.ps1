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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

<#
    .SYNOPSIS
    Tests regarding managed instance DNS aliases.
#>

<#
    .SYNOPSIS
    Helper function for validating DTC object.
    .DESCRIPTION
    This function accepts DTC alias object and expected parameters.
#>
function ValidateDtc($managedInstanceDtcActualObject, $managedInstanceDtcExpectedObject)
{
    $properties = ($managedInstanceDtcExpectedObject | Get-Member -MemberType Property | Select-Object -ExpandProperty Name)
    $securitySettings = ($managedInstanceDtcExpectedObject.SecuritySettings | Get-Member -MemberType Property | Select-Object -ExpandProperty Name)
    $transactionManagerCommunicationSettings = ($managedInstanceDtcExpectedObject.SecuritySettings.TransactionManagerCommunicationSettings | Get-Member -MemberType Property | Select-Object -ExpandProperty Name)

    # Compare-Object cmdlet returns differences between 2 objects. It should return null if objects are equal.
    Compare-Object $managedInstanceDtcActualObject $managedInstanceDtcExpectedObject -Property $properties | Assert-Null
    Compare-Object $managedInstanceDtcActualObject.SecuritySettings $managedInstanceDtcExpectedObject.SecuritySettings -Property $securitySettings | Assert-Null
    Compare-Object $managedInstanceDtcActualObject.SecuritySettings.TransactionManagerCommunicationSettings $managedInstanceDtcExpectedObject.SecuritySettings.TransactionManagerCommunicationSettings -Property $transactionManagerCommunicationSettings | Assert-Null
}

<#
    .SYNOPSIS
    Tests Get and Set operations on Managed Instance DTC using different parameter sets.
#>
function Test-ManagedInstanceDtcGetAndSetScenarios
{
    try {
        Write-Debug "Creating test MI"
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg $null $null $true
        $managedInstanceName = $managedInstance.ManagedInstanceName

        #Get by name
        Write-Debug "Get by name"
        $originalDtcObject = Get-AzSqlInstanceDtc -ResourceGroupName $managedInstance.ResourceGroupName -InstanceName $managedInstanceName
        $dtc = $originalDtcObject
        $dtc.DtcEnabled = !$dtc.DtcEnabled

        #Set by name. Also use -AsJob in order to test that functionality.
        Write-Debug "Set by name"
        $dtcJob = Set-AzSqlInstanceDtc -ResourceGroupName $managedInstance.ResourceGroupName -InstanceName $managedInstanceName -DtcEnabled $dtc.DtcEnabled -AsJob
        $dtcJob | Wait-Job
        $updatedDtc = $dtcJob.Output

        #Validate
        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Set by instance object
        Write-Debug "Set by instance object"
        $updatedDtc = Set-AzSqlInstanceDtc -InstanceObject $managedInstance -DtcEnabled $(!$dtc.DtcEnabled)
        
        #Get by instance object
        Write-Debug "Get by instance object"
        $dtc = Get-AzSqlInstanceDtc -InstanceObject $managedInstance

        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Set by input Object
        $dtc.SecuritySettings.XaTransactionsEnabled = !$dtc.SecuritySettings.XaTransactionsEnabled

        #XaTransactionsEnabled should be set from the object passed, and DtcEnabled should be set from the parameters
        Write-Debug "Set by input object"
        $updatedDtc = Set-AzSqlInstanceDtc -InputObject $dtc -DtcEnabled $(!$dtc.DtcEnabled)
        $dtc.DtcEnabled = !$dtc.DtcEnabled

        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Set all parameters to different ones by resource ID. Authentication currently only supports "NoAuth", so we don't change that param
        Write-Debug "Set all by resource ID"
        $dtc.ExternalDnsSuffixSearchList.Add("newSuffix.test.net")
        $xaTransactionsMaxTimeout = $dtc.XaTransactionsMaximumTimeout + 2000
        $xaTransactionsDefaultTimeout = $dtc.XaTransactionsMaximumTimeout + 1000
        $updatedDtc = Set-AzSqlInstanceDtc -ResourceId $dtc.Id -DtcEnabled $(!$dtc.DtcEnabled) -ExternalDnsSuffixSearchList $dtc.ExternalDnsSuffixSearchList`
        -XaTransactionsEnabled $(!$dtc.SecuritySettings.XaTransactionsEnabled) -SnaLu6point2TransactionsEnabled $(!$dtc.SecuritySettings.SnaLu6point2TransactionsEnabled)`
        -AllowInboundEnabled $(!$dtc.SecuritySettings.TransactionManagerCommunicationSettings.AllowInboundEnabled) -AllowOutboundEnabled $(!$dtc.SecuritySettings.TransactionManagerCommunicationSettings.AllowOutboundEnabled)`
        -XaTransactionsMaximumTimeout $xaTransactionsMaxTimeout -XaTransactionsDefaultTimeout $xaTransactionsDefaultTimeout

        #Get by resource ID
        Write-Debug "Get by resource ID"
        $dtc = Get-AzSqlInstanceDtc -ResourceId $dtc.Id

        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Revert to original settings
        Write-Debug "Revert to original DTC settings"
        $updatedDtc = Set-AzSqlInstanceDtc -InputObject $originalDtcObject

        Write-Debug "Validating"
        ValidateDtc $updatedDtc $originalDtcObject
    }
    finally {
        Remove-ResourceGroupForTest $rg
    }
}

<#
    .SYNOPSIS
    Tests piping scenarios for ManagedIinstance DTC Get and Set operations.
#>
function Test-ManagedInstanceDtcPipingScenarios
{
    try {
        Write-Debug "Creating test MI"
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg $null $null $true

        #Get by piping parent object
        Write-Debug "Get by piping parent object"
        $originalDtc = $managedInstance | Get-AzSqlInstanceDtc
        $dtc = $originalDtc
        Assert-NotNull $dtc

        #Set by piping parent object
        Write-Debug "Set by piping parent object"
        $dtc.DtcEnabled = !$dtc.DtcEnabled
        $updatedDtc = $managedInstance | Set-AzSqlInstanceDtc -DtcEnabled $dtc.DtcEnabled
        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Get by piping resource ID
        Write-Debug "Get by piping resource ID"
        $newDtc = $dtc.Id | Get-AzSqlInstanceDtc
        Write-Debug "Validating"
        ValidateDtc $newDtc $dtc

        #Set by piping resource ID
        Write-Debug "Set by piping resource ID"
        $dtc.DtcEnabled = !$dtc.DtcEnabled
        $updatedDtc = $dtc.Id | Set-AzSqlInstanceDtc -DtcEnabled $dtc.DtcEnabled
        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc

        #Set by piping input object
        Write-Debug "Set by piping input object"
        $dtc.DtcEnabled = !$dtc.DtcEnabled
        $updatedDtc = $dtc | Set-AzSqlInstanceDtc -DtcEnabled $dtc.DtcEnabled
        Write-Debug "Validating"
        ValidateDtc $updatedDtc $dtc
    }
    finally {
        Remove-ResourceGroupForTest $rg
    }
}