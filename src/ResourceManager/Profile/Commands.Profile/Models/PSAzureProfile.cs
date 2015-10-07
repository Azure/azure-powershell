using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile.Models
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
                Context = profile.Context
            };

            profile.Environments
                .ForEach((e) => result.Environments.Add(e.Key, (PSAzureEnvironment)e.Value));
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
                Context = profile.Context
            };
            profile.Environments
                    .ForEach((e) => result.Environments.Add(e.Key, (AzureEnvironment)e.Value));
            return result;
        }

        /// <summary>
        /// The set of AzureCloud environments.
        /// </summary>
        public IDictionary<string, PSAzureEnvironment> Environments
        {
            get { return _env; }
        }

        /// <summary>
        /// The current credentials and mestadata for connectiong with the current Azure cloud instance.
        /// </summary>
        public PSAzureContext Context { get; set; }

        public override string ToString()
        {
            return Context!= null? Context.ToString() : null;
        }
    }
}
