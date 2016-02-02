using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Models
{
    /// <summary>
    /// Credential and environment data for connecting with an Azure instance in the current session.
    /// </summary>
    public class PSAzureProfile
    {
        private Dictionary<string, PSAzureEnvironment> _env = new Dictionary<string, PSAzureEnvironment>();

        /// <summary>
        /// Convert between implementations of AzureProfile.
        /// </summary>
        /// <param name="profile">The profile to convert.</param>
        /// <returns>The converted profile.</returns>
        public static implicit operator PSAzureProfile(AzureRMProfile profile)
        {
            if (profile == null)
            {
                return null;
            }

            var result =  new PSAzureProfile
            {
                Context = profile.Context,
                IsTelemetryCollectionEnabled = profile.IsTelemetryCollectionEnabled
            };

            profile.Environments
                .ForEach((e) => result.Environments[e.Key] = (PSAzureEnvironment)e.Value);
            return result;
        }

       /// <summary>
       /// Convert between implementations of AzureProfile.
       /// </summary>
       /// <param name="profile">The profile to convert.</param>
       /// <returns>The converted profile.</returns>
       public static implicit operator AzureRMProfile(PSAzureProfile profile)
        {
           if (profile == null)
           {
               return null;
           }

            var result = new AzureRMProfile
            {
                Context = profile.Context,
                IsTelemetryCollectionEnabled = profile.IsTelemetryCollectionEnabled
            };
            profile.Environments.ForEach((e) => result.Environments[e.Key] = (AzureEnvironment) e.Value);
            return result;
        }

        /// <summary>
        /// The set of AzureCloud environments.
        /// </summary>
        public IDictionary<string, PSAzureEnvironment> Environments
        {
            get { return _env; }
        }

        public string EnvironmentNames
        {
            get { return _env == null || _env.Keys == null? null : string.Join(", ", _env.Keys.ToArray()); }
        }

        /// <summary>
        /// The current credentials and metadata for connecting with the current Azure cloud instance.
        /// </summary>
        public PSAzureContext Context { get; set; }

        /// <summary>
        /// When set to true, collects telemetry information.
        /// </summary>
        public bool? IsTelemetryCollectionEnabled { get; set; }

        public override string ToString()
        {
            return Context?.ToString();
        }
    }
}
