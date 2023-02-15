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

# Test constants
$endpointTypeDatabaseMirroring = "DATABASE_MIRRORING"
$endpointTypeServiceBroker = "SERVICE_BROKER"
$endpointCertType = "Microsoft.Sql/managedInstances/endpointCertificates"

<#
    .SYNOPSIS
    Tests endpoint certificate
#>
function Test-EndpointCertificate
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName
                
        # generate expected cert ids
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $instanceId = $instance.Id
        $certId1 = $instanceId + "/endpointCertificates/" + $endpointTypeDatabaseMirroring
        $certId2 = $instanceId + "/endpointCertificates/" + $endpointTypeServiceBroker

        # Get DBM certificate - (GetByNameParameterSet)
        $getCert1ByNameParameterSet = Get-AzSqlInstanceEndpointCertificate -ResourceGroupName $rgName -InstanceName $miName -Name $endpointTypeDatabaseMirroring
        Write-Debug ('$getCert1ByNameParameterSet is ' + (ConvertTo-Json $getCert1ByNameParameterSet))
        Assert-NotNull $getCert1ByNameParameterSet
        Assert-AreEqual	$getCert1ByNameParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByNameParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByNameParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByNameParameterSet.Type $endpointCertType
        Assert-AreEqual	$getCert1ByNameParameterSet.Name $endpointTypeDatabaseMirroring
        Assert-NotNull $getCert1ByNameParameterSet.PublicKey

        # Get DBM certificate - (GetByParentObjectParameterSet)
        $getCert1ByParentObjectParameterSet = Get-AzSqlInstanceEndpointCertificate -InstanceObject $instance -Name $endpointTypeDatabaseMirroring
        Write-Debug ('$getCert1ByParentObjectParameterSet is ' + (ConvertTo-Json $getCert1ByParentObjectParameterSet))
        Assert-NotNull $getCert1ByParentObjectParameterSet
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByParentObjectParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.Type $endpointCertType
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.Name $endpointTypeDatabaseMirroring
        Assert-NotNull $getCert1ByParentObjectParameterSet.PublicKey

        # Get DBM certificate - (GetByResourceIdParameterSet)
        $getCert1ByResourceIdParameterSet = Get-AzSqlInstanceEndpointCertificate -ResourceId $certId1
        Write-Debug ('$getCert1ByResourceIdParameterSet is ' + (ConvertTo-Json $getCert1ByResourceIdParameterSet))
        Assert-NotNull $getCert1ByResourceIdParameterSet
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByResourceIdParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.Type $endpointCertType
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.Name $endpointTypeDatabaseMirroring
        Assert-NotNull $getCert1ByResourceIdParameterSet.PublicKey

        # Get SB certificate - (GetByInstanceResourceIdParameterSet)
        $getCert1ByInstanceResourceIdParameterSet = Get-AzSqlInstanceEndpointCertificate -InstanceResourceId $instanceId -Name $endpointTypeServiceBroker
        Write-Debug ('$getCert1ByInstanceResourceIdParameterSet is ' + (ConvertTo-Json $getCert1ByInstanceResourceIdParameterSet))
        Assert-NotNull $getCert1ByInstanceResourceIdParameterSet
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByInstanceResourceIdParameterSet.Id $certId2
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.Type $endpointCertType
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.Name $endpointTypeServiceBroker
        Assert-NotNull $getCert1ByInstanceResourceIdParameterSet.PublicKey

        # Get SB certificate - Using parameter alias (Name -> EndpointType)
        $getCert2 = Get-AzSqlInstanceEndpointCertificate -ResourceGroupName $rgName -InstanceName $miName -EndpointType $endpointTypeServiceBroker
        Write-Debug ('$getCert2 is ' + (ConvertTo-Json $getCert2))
        Assert-NotNull $getCert2
        Assert-AreEqual	$getCert2.ResourceGroupName $rgName
        Assert-AreEqual	$getCert2.InstanceName $miName
        Assert-AreEqual $getCert2.Id $certId2
        Assert-AreEqual	$getCert2.Type $endpointCertType
        Assert-AreEqual	$getCert2.Name $endpointTypeServiceBroker
        Assert-NotNull $getCert2.PublicKey

        # List all certificates
        $listCerts = Get-AzSqlInstanceEndpointCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCerts is ' + (ConvertTo-Json $listCerts))
        Assert-NotNull $listCerts
        Assert-AreEqual	$listCerts.Count 2

        # Get non existant cert #1 THROWS (via DeleteByInputObjectParameterSet)
        $msgExcGet = "The requested resource of type '" + $endpointCertType + "' with name '" + "INVALID_TYPE" + "' was not found."
        Assert-Throws { Get-AzSqlInstanceEndpointCertificate -InstanceObject $instance -EndpointType "INVALID_TYPE" } $msgExc
        
        # Grab certificates #1 and #2 via ParentObject piping
        $listCertRespByParentObjectPipe = $instance | Get-AzSqlInstanceEndpointCertificate
        $getCertRespByParentObjectPipe =  $instance | Get-AzSqlInstanceEndpointCertificate -Name $endpointTypeDatabaseMirroring
        $getCertRespByParentObjectPipe =  $instance | Get-AzSqlInstanceEndpointCertificate -Name $endpointTypeServiceBroker
        Write-Debug ('$listCertRespByParentObjectPipe is ' + (ConvertTo-Json $listCertRespByParentObjectPipe))
        Write-Debug ('$getCertRespByParentObjectPipe is ' + (ConvertTo-Json $getCertRespByParentObjectPipe))
        Write-Debug ('$getCertRespByParentObjectPipe is ' + (ConvertTo-Json $getCertRespByParentObjectPipe))
        Assert-NotNull $listCertRespByParentObjectPipe
        Assert-NotNull $getCertRespByParentObjectPipe
        Assert-NotNull $getCertRespByParentObjectPipe
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}
