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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using System.Collections;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Configuration.
    /// </summary>
    public class DscConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscConfiguration"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account.
        /// </param>
        /// <param name="configuration">
        /// The configuration script.
        /// </param>
        public DscConfiguration(string resourceGroupName, string automationAccountName, AutomationManagement.Models.DscConfiguration configuration)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("Configuration", configuration).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = configuration.Name;
            this.Location = configuration.Location;
            this.Tags = null;

            if (configuration.Properties == null) return;

            this.CreationTime = configuration.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = configuration.Properties.LastModifiedTime.ToLocalTime();
            this.Description = configuration.Properties.Description;
            this.LogVerbose = configuration.Properties.LogVerbose;
            this.State = configuration.Properties.State;
            this.Location = configuration.Location;

            this.Tags = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in configuration.Tags)
            {
                this.Tags.Add(kvp.Key, kvp.Value);
            }

            this.Parameters = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in configuration.Properties.Parameters)
            {
                this.Parameters.Add(kvp.Key, (object)kvp.Value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DscConfiguration"/> class.
        /// </summary>
        public DscConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Hashtable Parameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log verbose is enabled.
        /// </summary>
        public bool LogVerbose { get; set; }

        /*
        /// <summary>
        /// Gets or sets the content source.
        /// </summary>
        public ContentSource Source { get; set; }
         */
    }

    /// <summary>
    /// The content source
    /// </summary>
    public class ContentSource
    {
        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        public ContentHash ContentHash { get; set; }

        /// <summary>
        /// Gets or sets the content source type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the value of the content. This is based on the content source type.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the version of the content.
        /// </summary>
        public string Version { get; set; }
    }

    /// <summary>
    /// The content link
    /// </summary>
    public class ContentLink
    {
        /// <summary>
        /// Gets or sets the Uri.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the Content hash.
        /// </summary>
        public ContentHash ContentHash { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version { get; set; }
    }

    /// <summary>
    /// The content Hash
    /// </summary>
    public class ContentHash
    {
        /// <summary>
        /// Gets or sets the Algorithm.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// The allowed values for content source type
    /// </summary>
    public enum ContentSourceType
    {
        embeddedContent,
        uri
    }
}
