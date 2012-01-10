﻿using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation data for
    /// MethodInfo instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IMethodInfoDocumentationExtractor
    {
        /// <summary>
        /// Extract XML documentation for a certain MethodInfo instance.
        /// </summary>
        XmlElement ExtractDocumentation(MethodInfo methodInfo);
    }
}
