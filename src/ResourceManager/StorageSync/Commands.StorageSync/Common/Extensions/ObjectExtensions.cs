// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// Object extensions class
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// This function will transform an object to json formatted string.
        /// </summary>
        /// <param name="currentObject">current object</param>
        /// <returns>Json formatted string</returns>
        public static string ToJson(this object currentObject)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                new JsonFormatter().WriteToStreamAsync(currentObject.GetType(), currentObject, stream, null, null).Wait();
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }
    }
}
