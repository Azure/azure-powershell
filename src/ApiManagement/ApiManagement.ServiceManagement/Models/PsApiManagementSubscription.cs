//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class PsApiManagementSubscription : PsApiManagementArmResource
    {
        // productId regex
        static readonly Regex ProductArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/products/(?<productId>[^/]+)", RegexOptions.IgnoreCase);
        static readonly Regex ProductIdRegex = new Regex(@"/products/(?<productId>[^/]+)", RegexOptions.IgnoreCase);

        // userId regex
        static readonly Regex UserArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/users/(?<userId>[^/]+)", RegexOptions.IgnoreCase);

        // subscriptionId regex
        static readonly Regex SubscriptionIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/subscriptions/(?<subscriptionId>[^/]+)", RegexOptions.IgnoreCase);

        public string SubscriptionId { get; set; }

        [Obsolete("UserId attribute is deprecated in the new subscription Model.Please use OwnerId attribute. Will be removed in future releases.")]
        public string UserId
        {
            get
            {
                if (OwnerId == null)
                {
                    return null;
                }

                var match = UserArmIdRegex.Match(OwnerId);
                if (match.Success)
                {
                    var userIdNameValue = match.Groups["userId"];
                    if (userIdNameValue != null && userIdNameValue.Success)
                    {
                        return userIdNameValue.Value;
                    }
                }

                return null;
            }
            set
            {
                var match = UserArmIdRegex.Match(OwnerId);
                if (match.Success)
                {
                    var userIdNameValue = match.Groups["userId"];
                    if (userIdNameValue != null && userIdNameValue.Success)
                    {
                        this.UserId = userIdNameValue.Value;
                    }
                }
                else
                {
                    this.UserId = value;
                }
            }
        }

        public string OwnerId { get; set; }

        [Obsolete("ProductId attribute is deprecated in the new subscription Model. Please use Scope attribute. Will be removed in future releases.")]
        public string ProductId
        {
            get
            {
                var match = ProductArmIdRegex.Match(Scope);
                if (match.Success)
                {
                    var productIdName = match.Groups["productId"];
                    if (productIdName != null && productIdName.Success)
                    {
                        return productIdName.Value;
                    }
                }

                match = ProductIdRegex.Match(Scope);
                if (match.Success)
                {
                    var productIdName = match.Groups["productId"];
                    if (productIdName != null && productIdName.Success)
                    {
                        return productIdName.Value;
                    }
                }

                return null;

            }
            set
            {
                // setting productId, sets the Product
                var match = ProductArmIdRegex.Match(Scope);
                if (match.Success)
                {
                    var productIdName = match.Groups["productId"];
                    if (productIdName != null && productIdName.Success)
                    {
                        this.ProductId = productIdName.Value;
                    }
                }
                else
                {
                    this.ProductId = value;
                }
            }
        }

        public string Scope { get; set; }

        public string Name { get; set; }

        public PsApiManagementSubscriptionState State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? NotificationDate { get; set; }

        public string PrimaryKey { get; set; }

        public string SecondaryKey { get; set; }

        public string StateComment { get; set; }

        //
        // Summary:
        //     Gets or sets determines whether tracing is enabled
        public bool? AllowTracing { get; set; }

        public PsApiManagementSubscription() { }

        public PsApiManagementSubscription(string armResourceId)
        {
            this.Id = armResourceId;
            var match = SubscriptionIdRegex.Match(Id);
            if (match.Success)
            {
                var subscriptionIdResult = match.Groups["subscriptionId"];
                if (subscriptionIdResult != null && subscriptionIdResult.Success)
                {
                    this.SubscriptionId = subscriptionIdResult.Value;
                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid SubscriptionId");
        }
    }
}