﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSTopic
    {
        public PSTopic(Topic topic)
        {
            this.Id = topic.Id;
            this.TopicName = topic.Name;
            this.Type = topic.Type;
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(topic.Id);
            this.Location = topic.Location;
            this.ProvisioningState = topic.ProvisioningState;
            this.Tags = topic.Tags;
            this.Endpoint = topic.Endpoint;
            this.InputSchema = topic.InputSchema;
            this.PublicNetworkAccess = topic.PublicNetworkAccess;

            if (topic.InboundIpRules != null)
            {
                this.InboundIpRule = new Dictionary<string, string>();

                foreach (var rule in topic.InboundIpRules)
                {
                    this.InboundIpRule.Add(rule.IpMask, rule.Action);
                }
            }


            if (topic.InputSchemaMapping != null)
            {
                this.InputMappingField = new Dictionary<string, string>();
                this.InputMappingDefaultValue = new Dictionary<string, string>();

                var jsonInputSchemaMapping = topic.InputSchemaMapping as JsonInputSchemaMapping;

                if (jsonInputSchemaMapping.Id != null)
                {
                    this.InputMappingField["id"] = jsonInputSchemaMapping.Id.SourceField;
                }

                if (jsonInputSchemaMapping.Topic != null)
                {
                    this.InputMappingField["topic"] = jsonInputSchemaMapping.Topic.SourceField;
                }

                if (jsonInputSchemaMapping.EventTime != null)
                {
                    this.InputMappingField["eventtime"] = jsonInputSchemaMapping.EventTime.SourceField;
                }

                if (jsonInputSchemaMapping.EventType != null)
                {
                    if (jsonInputSchemaMapping.EventType.SourceField != null)
                    {
                        this.InputMappingField["eventtype"] = jsonInputSchemaMapping.EventType.SourceField;
                    }

                    if (jsonInputSchemaMapping.EventType.DefaultValue != null)
                    {
                        this.InputMappingDefaultValue["eventtype"] = jsonInputSchemaMapping.EventType.DefaultValue;
                    }
                }

                if (jsonInputSchemaMapping.Subject != null)
                {
                    if (jsonInputSchemaMapping.Subject.SourceField != null)
                    {
                        this.InputMappingField["subject"] = jsonInputSchemaMapping.Subject.SourceField;
                    }

                    if (jsonInputSchemaMapping.Subject.DefaultValue != null)
                    {
                        this.InputMappingDefaultValue["subject"] = jsonInputSchemaMapping.Subject.DefaultValue;
                    }
                }

                if (jsonInputSchemaMapping.DataVersion != null)
                {
                    if (jsonInputSchemaMapping.DataVersion.SourceField != null)
                    {
                        this.InputMappingField["dataversion"] = jsonInputSchemaMapping.DataVersion.SourceField;
                    }

                    if (jsonInputSchemaMapping.DataVersion.DefaultValue != null)
                    {
                        this.InputMappingDefaultValue["dataversion"] = jsonInputSchemaMapping.DataVersion.DefaultValue;
                    }
                }
            }
        }

        public string ResourceGroupName { get; set; }

        public string TopicName { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string Endpoint { get; set; }

        public string ProvisioningState { get; set; }

        public string InputSchema { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public IDictionary<string, string> InputMappingField { get; set; }

        public IDictionary<string, string> InputMappingDefaultValue { get; set; }

        public IDictionary<string, string> InboundIpRule { get; set; }

        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Return a string representation of this topic
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
