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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    /// <summary>
    /// Transport types.
    /// </summary>
    public enum PSTransportType
    {
        /// <summary>
        /// Advanced Message Queuing Protocol transport. Try Amqp over TCP first and fallback to Amqp over WebSocket if that fails.
        /// </summary>
        Amqp = 0,

        /// <summary>
        /// HyperText Transfer Protocol version 1 transport.
        /// </summary>
        Http1 = 1,

        /// <summary>
        /// Advanced Message Queuing Protocol transport over WebSocket only.
        /// </summary>
        Amqp_WebSocket_Only = 2,

        /// <summary>
        /// Advanced Message Queuing Protocol transport over native TCP only.Advanced Message Queuing Protocol transport. Try Amqp over TCP first and fallback to Amqp over WebSocket if that fails
        /// </summary>
        Amqp_Tcp_Only = 3,
    
        /// <summary>
        /// Message Queuing Telemetry Transport. Try Mqtt over TCP first and fallback to Mqtt over WebSocket if that fails.
        /// </summary>
        Mqtt = 4,

        /// <summary>
        /// Message Queuing Telemetry Transport over Websocket only.
        /// </summary>
        Mqtt_WebSocket_Only = 5,

        /// <summary>
        /// Message Queuing Telemetry Transport over native TCP only.
        /// </summary>
        Mqtt_Tcp_Only = 6
    }
}
