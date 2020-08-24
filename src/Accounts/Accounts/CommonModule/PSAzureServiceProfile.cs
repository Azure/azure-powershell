// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Profile.CommonModule
{
    /// <summary>
    /// Representation of a service profile
    /// </summary>
    public class PSAzureServiceProfile
    {
        private PSAzureServiceProfile()
        {
        }

        /// <summary>
        ///  The name of the profile
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A textual description of the profile
        /// </summary>
        public string Description { get; set; }

        internal static PSAzureServiceProfile Create( string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            return new PSAzureServiceProfile { Name = name, Description = GetProfileDescription(name) };
        }

        /// <summary>
        /// Get a descriptin of the profile based on the format of the profile name
        /// </summary>
        /// <param name="name">The name of the profile</param>
        /// <returns>A textual description of the given profile</returns>
        internal static string GetProfileDescription(string name)
        {
            if (name.ContainsNotNull("hybrid"))
            {
                return $"{Resources.HybridProfileDescription}{GetDateString(name)}";
            }

            if (name.ContainsNotNull("profile"))
            {
                return $"{Resources.SovereignProfileDescription}{GetDateString(name)}";
            }

            return $"{Resources.ProdProfileDescription}{GetDateString(name)}";
        }

        /// <summary>
        /// Extract the profile creation date from the profile name
        /// </summary>
        /// <param name="name">The name of the profile</param>
        /// <returns>If the input name of the profile is a well-formed profile name, 
        /// the creation date of the profile.  Otherwise an empty string.</returns>
        internal static object GetDateString(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {

                var match = Regex.Match(name, @"(?!<\d)(\d\d\d\d)-(\d\d)(?!\d)");
                int month;
                if (match.Success && match.Groups != null && match.Groups.Count > 2
                    && int.TryParse(match.Groups[2].Value, out month) && month < 13 && month > 0)
                {
                    return $" This profile was defined in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {match.Groups[1].Value}.";
                }
            }

            return string.Empty;
        }


    }
}
