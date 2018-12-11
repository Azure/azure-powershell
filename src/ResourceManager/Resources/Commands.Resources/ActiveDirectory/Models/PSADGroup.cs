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

namespace Microsoft.Azure.Commands.ActiveDirectory
{
<<<<<<< HEAD:src/ResourceManager/StorageSync/Commands.StorageSync/OutputWriters/AFSConsoleWriter.cs
    using Interfaces;
    using System;

    internal class AfsConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
=======
    public class PSADGroup : PSADObject
    {
        public bool? SecurityEnabled { get; set; }

        public string MailNickname { get; set; }

        public string ObjectType => "Group";
>>>>>>> a0fa6ac1b3130536628ae5c0ed8870f9f7a9eb63:src/ResourceManager/Resources/Commands.Resources/ActiveDirectory/Models/PSADGroup.cs
    }
}
