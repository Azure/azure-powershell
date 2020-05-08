﻿# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full DataSet ADLSGen1 CRUD cycle
#>
function Test-AdlsGen1Crud
{
	$resourceGroup = getAssetName

	try
	{
		$AccountName = getAssetName
		$ShareName = getAssetName
		$DataSetName = getAssetName
		$StorageAccountId = "/subscriptions/e3c4699f-415a-4437-901e-3be6271b5113/resourceGroups/dsktestingstorageRG/providers/Microsoft.DataLakeStore/accounts/psstorage"
		$FolderPath = "providerFolder"
		$FileName = "psFilePath"
		$createdFolderDataset = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -AdlsGen1FolderPath $FolderPath
	
		Assert-NotNull $createdFolderDataset
		Assert-AreEqual $DataSetName $createdFolderDataset.Name

		$createdFileDataset = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -AdlsGen1FolderPath $FolderPath -FileName $FileName

		Assert-NotNull $createdFileDataset
		Assert-AreEqual $DataSetName $createdFileDataset.Name
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}
