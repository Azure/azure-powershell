# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full Consumer Source DataSets CRUD cycle
#>
function Test-SourceDataSetsCrud
{
    $resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareSubscriptionName = getAssetName
	$SourceDataSets = Get-AzDataShareSourceDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName

	Assert-NotNull $SourceDataSets
}
