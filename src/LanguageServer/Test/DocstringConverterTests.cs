﻿// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using FluentAssertions;
using Microsoft.Python.Core;
using Microsoft.Python.LanguageServer.Documentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUtilities;
using static Microsoft.Python.LanguageServer.Tests.FluentAssertions.DocstringAssertions;

namespace Microsoft.Python.LanguageServer.Tests {
    [TestClass]
    public class DocstringConverterTests {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
            => TestEnvironmentImpl.TestInitialize($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}");

        [TestCleanup]
        public void Cleanup() => TestEnvironmentImpl.TestCleanup();

        [DataRow("A\nB", "A\nB")]
        [DataRow("A\n\nB", "A\n\nB")]
        [DataRow("A\n\nB", "A\n\nB")]
        [DataRow("A\n    B", "A\nB")]
        [DataRow("    A\n    B", "A\nB")]
        [DataRow("\nA\n    B", "A\n    B")]
        [DataRow("\n    A\n    B", "A\nB")]
        [DataRow("\nA\nB\n", "A\nB")]
        [DataRow("  \n\nA \n    \nB  \n    ", "A\n\nB")]
        [DataTestMethod, Priority(0)]
        public void PlaintextIndention(string docstring, string expected) {
            docstring.Should().ConvertToPlaintext(expected);
        }

        [TestMethod, Priority(0)]
        public void Doctest() {
            var docstring = @"This is a doctest:

>>> print('foo')
foo
";

            var markdown = @"This is a doctest:

```
>>> print('foo')
foo
```
";
            docstring.Should().ConvertToMarkdown(markdown);
        }
    }
}
