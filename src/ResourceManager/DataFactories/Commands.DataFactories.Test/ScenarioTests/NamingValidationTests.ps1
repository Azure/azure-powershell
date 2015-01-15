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

# Make sure the naming error contains the below link to ADF naming rules MSDN page
$invalidNameError = "http://msdn.microsoft.com/en-us/library/dn835027.aspx"

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidResourceGroupName
{	    
    $rgName = "adf#$%"
	$dfName = "adf"

    Assert-ThrowsContains { Get-AzureDataFactory -ResourceGroupName $rgName } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactory -ResourceGroupName $rgName -Name $dfName -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactory -ResourceGroupName $rgName -Name $dfName -Force } $invalidNameError

	Assert-ThrowsContains { Get-AzureDataFactoryLinkedService -ResourceGroupName $rgName -DataFactoryName $dfName} $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryLinkedService -ResourceGroupName $rgName -DataFactoryName $dfName -Name "ls" -File .\Resources\linkedService.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryLinkedService -ResourceGroupName $rgName -DataFactoryName $dfName -Name "ls" -Force } $invalidNameError

	Assert-ThrowsContains { Get-AzureDataFactoryTable -ResourceGroupName $rgName -DataFactoryName $dfName} $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryTable -ResourceGroupName $rgName -DataFactoryName $dfName -Name "table" -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryTable -ResourceGroupName $rgName -DataFactoryName $dfName -Name "table" -Force } $invalidNameError
	
	Assert-ThrowsContains { Get-AzureDataFactoryPipeline -ResourceGroupName $rgName -DataFactoryName $dfName} $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryPipeline -ResourceGroupName $rgName -DataFactoryName $dfName -Name "pipeline" -File .\Resources\pipeline.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryPipeline -ResourceGroupName $rgName -DataFactoryName $dfName -Name "pipeline" -Force } $invalidNameError

	Assert-ThrowsContains { Get-AzureDataFactoryHub -ResourceGroupName $rgName -DataFactoryName $dfName} $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryHub -ResourceGroupName $rgName -DataFactoryName $dfName -Name "hub" -File .\Resources\hub.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryHub -ResourceGroupName $rgName -DataFactoryName $dfName -Name "hub" -Force } $invalidNameError

	Assert-ThrowsContains { Set-AzureDataFactorySliceStatus -ResourceGroupName $rgName -DataFactoryName $rgName -TableName "table" -StartDateTime "2015-01-01" -Status PendingExecution } $invalidNameError

    Assert-ThrowsContains { Suspend-AzureDataFactoryPipeline -ResourceGroupName $rgName -DataFactoryName $rgName -Name "pipeline" -Force } $invalidNameError

	Assert-ThrowsContains { Resume-AzureDataFactoryPipeline -ResourceGroupName $rgName -DataFactoryName $rgName -Name "pipeline" -Force } $invalidNameError

	Assert-ThrowsContains { Set-AzureDataFactoryPipelineActivePeriod -ResourceGroupName $rgName -DataFactoryName $rgName -PipelineName "pipeline" -StartDateTime "2015-01-01" -Force } $invalidNameError

	$password = ConvertTo-SecureString "password" -AsPlainText -Force
	Assert-ThrowsContains { New-AzureDataFactoryEncryptValue -ResourceGroupName $rgName -DataFactoryName $dfName -Value $password } $invalidNameError

	Assert-ThrowsContains { Save-AzureDataFactoryLog -ResourceGroupName $rgName -DataFactoryName $dfName -Id "id" } $invalidNameError
}

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidDataFactoryName
{	    
    Assert-ThrowsContains { Get-AzureDataFactory -ResourceGroupName "adf" -Name "adf_invalidname"  } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactory -ResourceGroupName "adf" -Name "datafactorynameistolongdatafactorynameistolongdatafactorynameistolongdatafactorynameistolong" -Force } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactory -ResourceGroupName "adf" -Name "adf+invalidname" -Location "westus" -Force } $invalidNameError	

	$password = ConvertTo-SecureString "password" -AsPlainText -Force
	Assert-ThrowsContains { New-AzureDataFactoryEncryptValue -ResourceGroupName "adf" -DataFactoryName "adf+invalidname" -Value $password } $invalidNameError

	Assert-ThrowsContains { Save-AzureDataFactoryLog -ResourceGroupName "adf" -DataFactoryName "adf+invalidname" -Id "id" } $invalidNameError
}

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidLinkedServiceName
{	    
    Assert-ThrowsContains { Get-AzureDataFactoryLinkedService -ResourceGroupName "adf" -DataFactoryName "adf" -Name "linked.service" } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryLinkedService -ResourceGroupName "adf" -DataFactoryName "adf" -Name "linked?service" -File .\Resources\linkedService.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryLinkedService -ResourceGroupName "adf" -DataFactoryName "adf" -Name "linked%service" -Force } $invalidNameError
}

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidTableName
{	    
    Assert-ThrowsContains { Get-AzureDataFactoryTable -ResourceGroupName "adf" -DataFactoryName "adf" -Name "table+"  } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryTable -ResourceGroupName "adf" -DataFactoryName "adf" -Name "table&" -File .\Resources\table.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryTable -ResourceGroupName "adf" -DataFactoryName "adf" -Name "table>" -Force } $invalidNameError

	Assert-ThrowsContains { Set-AzureDataFactorySliceStatus -ResourceGroupName "adf" -DataFactoryName "adf" -TableName "table<" -StartDateTime "2015-01-01" -Status PendingExecution } $invalidNameError
}

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidPipelineName
{	    
    Assert-ThrowsContains { Get-AzureDataFactoryPipeline -ResourceGroupName "adf" -DataFactoryName "adf" -Name "pipeline&"  } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryPipeline -ResourceGroupName "adf" -DataFactoryName "adf" -Name "pipeline\\" -File .\Resources\pipeline.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryPipeline -ResourceGroupName "adf" -DataFactoryName "adf" -Name "pipeline<" -Force } $invalidNameError

	Assert-ThrowsContains { Suspend-AzureDataFactoryPipeline -ResourceGroupName "adf" -DataFactoryName "adf" -Name "pipeline<" -Force } $invalidNameError

	Assert-ThrowsContains { Resume-AzureDataFactoryPipeline -ResourceGroupName "adf" -DataFactoryName "adf" -Name "pipeline<" -Force } $invalidNameError

	Assert-ThrowsContains { Set-AzureDataFactoryPipelineActivePeriod -ResourceGroupName "adf" -DataFactoryName "adf" -PipelineName "pipeline<" -StartDateTime "2015-01-01" -Force } $invalidNameError
}

<#
.SYNOPSIS
Test naming restriction support.
#>
function Test-InvalidHubName
{	    
    Assert-ThrowsContains { Get-AzureDataFactoryHub -ResourceGroupName "adf" -DataFactoryName "adf" -Name "hub&"  } $invalidNameError

	Assert-ThrowsContains { New-AzureDataFactoryHub -ResourceGroupName "adf" -DataFactoryName "adf" -Name "hub\\" -File .\Resources\hub.json -Force } $invalidNameError

	Assert-ThrowsContains { Remove-AzureDataFactoryHub -ResourceGroupName "adf" -DataFactoryName "adf" -Name "hub<" -Force } $invalidNameError
}