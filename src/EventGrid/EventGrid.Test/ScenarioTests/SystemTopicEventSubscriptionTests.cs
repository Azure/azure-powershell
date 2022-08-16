// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.EventGrid.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.EventGrid.Test.ScenarioTests
{
    public class SystemTopicEventSubscriptionTests : EventGridTestRunner
    {
        public SystemTopicEventSubscriptionTests(ITestOutputHelper output) : base(output)
        {
        }

        /* this test passes in local in both playback and record but fails in pipeline
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SystemTopicEventSubscriptionTests_CRUDTest()
        {
            TestRunner.RunTestScript("SystemTopicEventSubscriptionTests");
        }*/
    }
}
