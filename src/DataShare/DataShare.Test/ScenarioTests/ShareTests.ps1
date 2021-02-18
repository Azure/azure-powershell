# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full Share CRUD cycle
#>
function Test-ShareCrud
{
    $resourceGroup = getAssetName

	try
	{
		$AccountName = getAssetName
		$ShareName = getAssetName
		$description = "Test Share"
		$terms = "Test terms"
		$shareKind = "CopyBased"
		$createdShare = New-AzDataShare -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareName -Description $description -Terms $terms

		Assert-NotNull $createdShare
		Assert-AreEqual $ShareName $createdShare.Name
		Assert-AreEqual "CopyBased" $createdShare.ShareKind
		Assert-AreEqual $description $createdShare.Description
		Assert-AreEqual $terms $createdShare.Terms
		Assert-AreEqual "Succeeded" $createdShare.ProvisioningState

		$retrievedShare = Get-AzDataShare -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareName

		Assert-NotNull $retrievedShare
		Assert-AreEqual $ShareName $retrievedShare.Name
		Assert-AreEqual "Succeeded" $retrievedShare.ProvisioningState

		$newDescription = "SDK Description"
		$newTerms = "SDK Terms of Use"
		$updateShare = Set-AzDataShare -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareName -Description $newDescription -Terms $newTerms 

		Assert-NotNull $updateShare
		Assert-AreEqual $ShareName $updateShare.Name
		Assert-AreEqual $newDescription $updateShare.Description
		Assert-AreEqual $newTerms $updateShare.Terms
		Assert-AreEqual "Succeeded" $updateShare.ProvisioningState

		$removed = Remove-AzDataShare -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareName -PassThru

		Assert-True { $removed }
		Assert-ThrowsContains { Get-AzDataShare -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareName } "Resource 'sdktestingshare1' does not exist"
	}
    finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}
