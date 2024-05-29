// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure subscription details.
    /// </summary>
    public class PSAzureTenant : IAzureTenant
    {
        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator PSAzureTenant(AzureTenant other)
        {
            if (other == null)
            {
                return null;
            }

            return new PSAzureTenant(other);
        }

        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator AzureTenant(PSAzureTenant other)
        {
            if (other == null)
            {
                return null;
            }

            var result = new AzureTenant();
            result.CopyFrom(other);
            return result;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PSAzureTenant()
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="other">The tenanht to copy</param>
        public PSAzureTenant(IAzureTenant other)
        {
            this.CopyFrom(other);
        }

        public PSAzureTenant(PSObject other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            this.Id = other.GetProperty<string>(nameof(Id));
            this.PopulateExtensions(other);
        }
        /// <summary>
        /// The tenant id.
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.Table, Position = 1)]
        public string Id { get; set; }

        /// <summary>
        /// For legacy support - the tenant id
        /// </summary>
        public string TenantId { get { return Id; } }

        /// <summary>
        /// Extended proeprties of the tenant
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);


        public override string ToString()
        {
            return this.Id;
        }

        [Ps1Xml(Label = "TenantCategory", Target = ViewControl.Table, Position = 2)]
        public string TenantCategory
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.TenantCategory);
            }
        }

        public string Country
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.Country);
            }
        }

        public string CountryCode
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.CountryCode);
            }
        }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.DisplayName);
            }
        }

        [Ps1Xml(Label = "Domains", Target = ViewControl.Table, Position = 3)]
        public string[] Domains
        {
            get
            {
                return this.GetPropertyAsArray(AzureTenant.Property.Domains);
            }
        }
        public string DefaultDomain
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.DefaultDomain);
            }
        }

        public string TenantType
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.TenantType);
            }
        }

        public string TenantBrandingLogoUrl
        {
            get
            {
                return this.GetProperty(AzureTenant.Property.TenantBrandingLogoUrl);
            }
        }
    }
}
