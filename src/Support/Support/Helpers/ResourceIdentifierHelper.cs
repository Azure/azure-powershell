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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Support.Helpers
{
    public class ResourceIdentifierHelper
    {
        public enum ResourceType
        {
            Services,
            ProblemClassifications,
            SupportTickets,
            Communications
        }

        public static ResourceIdentifier BuildResourceIdentifier(string id, ResourceType resourceType)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new PSArgumentException("Resource identifier cannot be null.", "id");
            }

            string[] tokens = id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            switch (resourceType)
            {
                case ResourceType.Services:
                    if (tokens.Length != 4)
                    {
                        throw new PSArgumentException("Invalid format of the resource identifier.", "id");
                    }

                    if (!tokens[2].Equals(resourceType.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    return new ResourceIdentifier
                    {
                        ResourceType = tokens[2],
                        ResourceName = tokens[3]
                    };

                case ResourceType.ProblemClassifications:
                    if (tokens.Length != 6)
                    {
                        throw new PSArgumentException("Invalid format of the resource identifier.", "id");
                    }

                    if (!tokens[2].Equals(ResourceType.Services.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    if (!tokens[4].Equals(resourceType.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    return new ResourceIdentifier
                    {
                        ParentResource = tokens[3],
                        ResourceType = tokens[4],
                        ResourceName = tokens[5]
                    };

                case ResourceType.SupportTickets:
                    if (tokens.Length != 6)
                    {
                        throw new PSArgumentException("Invalid format of the resource identifier.", "id");
                    }

                    if (!tokens[4].Equals(resourceType.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    return new ResourceIdentifier
                    {
                        Subscription = tokens[1],
                        ResourceType = tokens[4],
                        ResourceName = tokens[5]
                    };

                case ResourceType.Communications:
                    if (tokens.Length != 8)
                    {
                        throw new PSArgumentException("Invalid format of the resource identifier.", "id");
                    }

                    if (!tokens[4].Equals(ResourceType.SupportTickets.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    if (!tokens[6].Equals(resourceType.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("Invalid resource type.", "id");
                    }

                    return new ResourceIdentifier
                    {
                        Subscription = tokens[1],
                        ParentResource = tokens[5],
                        ResourceType = tokens[6],
                        ResourceName = tokens[7]
                    };

                default:
                    throw new PSArgumentException(string.Format("Unsupported resource type {0}", resourceType));
            }
        }
    }
}
