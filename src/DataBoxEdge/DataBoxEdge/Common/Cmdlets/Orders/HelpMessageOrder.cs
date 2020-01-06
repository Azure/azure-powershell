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


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Orders
{
    class HelpMessageOrder
    {
        internal const string ObjectName = "Order";

        internal const string ForwardTrackingInfo = "Fetch the Forward TrackingInfo for the Device";
        internal const string ReturnTrackingInfo = "Fetch the Return TrackingInfo for the Device";
        internal const string CurrentOrderStatus = "Current order status";
        internal const string OrderStatusHistory = "History of order status updates";

        // Constants for Contact Info
        internal const string ContactPerson = "Name of the contact person";
        internal const string CompanyName = "Name of the company";
        internal const string Phone = "Phone number of the contact person";
        internal const string Email = "List of Emails to receive updates, Accepts max of 10 emails";

        // Constants for Shipping Address
        internal const string AddressLine1 = "Address first line";
        internal const string PostalCode = "Postal Code of the Address";
        internal const string City = "Name of the City";
        internal const string State = "Name of the State";
        internal const string Country = "Name of the Country";
        internal const string AddressLine2 = "Address second line";
        internal const string AddressLine3 = "Address third line";
    }
}