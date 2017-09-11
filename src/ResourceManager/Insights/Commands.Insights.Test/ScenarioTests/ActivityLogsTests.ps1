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
Tests getting the logs associated to a correlation Id.
#>
function Test-GetAzureLogAllParameters
{
    # Setup
    $correlation = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/alertrules/checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d/incidents/L3N1YnNjcmlwdGlvbnMvYTkzZmIwN2MtNmM5My00MGJlLWJmM2ItNGYwZGViYTEwZjRiL3Jlc291cmNlR3JvdXBzL0RlZmF1bHQtV2ViLUVhc3RVUy9wcm92aWRlcnMvbWljcm9zb2Z0Lmluc2lnaHRzL2FsZXJ0cnVsZXMvY2hlY2tydWxlMy00YjEzNTQwMS1hMzBjLTQyMjQtYWUyMS1mYTUzYTViZDI1M2QwNjM1NjA5MjE5ODU0NzQ1NDI0'
	$rgname = 'Default-Web-EastUS'
    $rname = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/alertrules/checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d'
	$rpname = 'microsoft.insights'

    try 
    {
		Write-Verbose " ****** Get ActivityLog records by corrrelationId "
        $actual = Get-AzureRmLog -CorrelationId $correlation -starttime 2015-03-02T18:00:00Z -endtime 2015-03-02T20:00:00Z -detailedOutput

        # Assert TODO add more asserts
		Assert-AreEqual 2 $actual.Count

		Write-Verbose " ****** Get ActivityLog records by resource group "
		$actual = Get-AzureRmLog -ResourceGroup $rgname -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z

        # Assert TODO add more asserts
		Assert-AreEqual 2 $actual.Count

		Write-Verbose " ****** Get ActivityLog records by resource Id"
		$actual = Get-AzureRmLog -ResourceId $rname -startTime 2015-03-03T15:42:50Z -endTime 2015-03-03T16:42:50Z

        # Assert TODO add more asserts
		# Assert-Throws { Set-AzureResourceGroup -Name $rgname -Tags @{"testtag" = "testval"} } "Invalid tag format. Expect @{Name = `"tagName`"} or @{Name = `"tagName`"; Value = `"tagValue`"}"
		Assert-AreEqual 2 $actual.Count

		Write-Verbose " ****** Get ActivityLog records by resource provider"
		$actual = Get-AzureRmLog -ResourceProvider $rpname -startTime 2015-03-03T15:42:50Z -endTime 2015-03-03T16:42:50Z

        # Assert
		Assert-AreEqual 2 $actual.Count

		Write-Verbose " ****** Get ActivityLog records by subscription Id"
        $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z 

        # Assert
        Assert-AreEqual 1 $actual.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs for a subscription Id.
#>
function Test-GetAzureSubscriptionIdLogMaxEvents
{
    # No Setup needed

    try 
    {
	    {
		   # There are 7 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the command is using the default MaxEvent and following continuation token.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z 
		   Assert-AreEqual 7 $actual.Count
		}

		{
		   # There are 7 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the command is using the default MaxEvent and following continuation token.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents -3
		   Assert-AreEqual 7 $actual.Count
		}

		{
		   # There are 7 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the command is using the default MaxEvent and following continuation token.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents 0
		   Assert-AreEqual 7 $actual.Count
		}

		{
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents 3
		   Assert-AreEqual 3 $actual.Count
		}
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs for a subscription Id.
#>
function Test-GetAzureSubscriptionIdLogPaged
{
    # No Setup needed

    try 
    {
        {
		   # There are 8 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the commands is following the continuation token to get the records in the second page.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z 
		   Assert-AreEqual 8 $actual.Count
        }

		{
		   # There are 8 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the commands is following the continuation token to get only one record in the second page.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents 7
		   Assert-AreEqual 7 $actual.Count
        }

		{
		   # There are 8 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the commands could have followed the continuation token but did not because it reached MaxEvents first.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z  -MaxEvents 6
		   Assert-AreEqual 6 $actual.Count
        }

        {
		   # There are 8 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the commands could have followed the continuation token but did not because it reached MaxEvents first.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents 3
		   Assert-AreEqual 3 $actual.Count
        }

		{
		   # There are 8 elements in the recorded sessions. The page is set to 6 elements. 
		   # So if this succeeds, the commands is following the continuation token to get the records in the second page and reached the last record before reaching MaxEvents.
		   $actual = Get-AzureRmLog -starttime 2015-01-15T12:30:00Z -endtime 2015-01-15T20:30:00Z -MaxEvents 15
		   Assert-AreEqual 8 $actual.Count
        }
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}