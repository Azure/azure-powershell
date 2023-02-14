# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Azure Data Share synchronization setting CRUD cycle
#>
function Test-SynchronizationSettingCrud
{
    $resourceGroup = getAssetName

	try{
		$AccountName = getAssetName
		$ShareName = getAssetName
		$Name = getAssetName

		$RecurrenceInterval = "hour"
		$SynchronizationTime = "06/19/2019 22:53:33"

		$createdSetting = New-AzDataShareSynchronizationSetting -AccountName $AccountName -ResourceGroupName $resourceGroup -ShareName $ShareName -RecurrenceInterval $RecurrenceInterval -SynchronizationTime $SynchronizationTime -Name $Name
    
		Assert-NotNull $createdSetting
		Assert-AreEqual $RecurrenceInterval $createdSetting.RecurrenceInterval
		Assert-AreEqual $SynchronizationTime $createdSetting.SynchronizationTime
		Assert-AreEqual $Name $createdSetting.Name

		$gottenSetting = Get-AzDataShareSynchronizationSetting -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName

		Assert-NotNull $gottenSetting
		Assert-AreEqual $RecurrenceInterval $gottenSetting.RecurrenceInterval
		Assert-AreEqual $SynchronizationTime $gottenSetting.SynchronizationTime
		Assert-AreEqual $Name $gottenSetting.Name

		$removed = Remove-AzDataShareSynchronizationSetting -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $Name -PassThru

		Assert-True { $removed }

		$gottenSetting = Get-AzDataShareSynchronizationSetting -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $Name

		Assert-NotNull $gottenSetting
		Assert-AreEqual $RecurrenceInterval $gottenSetting.RecurrenceInterval
		Assert-AreEqual $SynchronizationTime $gottenSetting.SynchronizationTime
		Assert-AreEqual $Name $gottenSetting.Name

		$removed = Remove-AzDataShareSynchronizationSetting -ResourceId $gottenSetting.id -PassThru

		Assert-True { $removed }

		$gottenSetting = Get-AzDataShareSynchronizationSetting -ResourceId $gottenSetting.id

		Assert-NotNull $gottenSetting
		Assert-AreEqual $RecurrenceInterval $gottenSetting.RecurrenceInterval
		Assert-AreEqual $SynchronizationTime $gottenSetting.SynchronizationTime
		Assert-AreEqual $Name $gottenSetting.Name
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}
