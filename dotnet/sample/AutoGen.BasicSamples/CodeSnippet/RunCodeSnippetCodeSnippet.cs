﻿// Copyright (c) 2023 - 2024, Owners of https://github.com/autogenhub
// SPDX-License-Identifier: Apache-2.0
// Contributions to this project, i.e., https://github.com/autogenhub/autogen, 
// are licensed under the Apache License, Version 2.0 (Apache-2.0).
// Portions derived from  https://github.com/microsoft/autogen under the MIT License.
// SPDX-License-Identifier: MIT
// Copyright (c) Microsoft Corporation. All rights reserved.
// RunCodeSnippetCodeSnippet.cs

#region code_snippet_0_1
using AutoGen.Core;
using AutoGen.DotnetInteractive;
using AutoGen.DotnetInteractive.Extension;
#endregion code_snippet_0_1

namespace AutoGen.BasicSample.CodeSnippet;
public class RunCodeSnippetCodeSnippet
{
    public async Task CodeSnippet1()
    {
        IAgent agent = new DefaultReplyAgent("agent", "Hello World");

        #region code_snippet_1_1
        var kernel = DotnetInteractiveKernelBuilder
            .CreateDefaultInProcessKernelBuilder() // add C# and F# kernels
            .Build();
        #endregion code_snippet_1_1

        #region code_snippet_1_2
        // register middleware to execute code block
        var dotnetCodeAgent = agent
            .RegisterMiddleware(async (msgs, option, innerAgent, ct) =>
            {
                var lastMessage = msgs.LastOrDefault();
                if (lastMessage == null || lastMessage.GetContent() is null)
                {
                    return await innerAgent.GenerateReplyAsync(msgs, option, ct);
                }

                if (lastMessage.ExtractCodeBlock("```csharp", "```") is string codeSnippet)
                {
                    // execute code snippet
                    var result = await kernel.RunSubmitCodeCommandAsync(codeSnippet, "csharp");
                    return new TextMessage(Role.Assistant, result, from: agent.Name);
                }
                else
                {
                    // no code block found, invoke next agent
                    return await innerAgent.GenerateReplyAsync(msgs, option, ct);
                }
            });

        var codeSnippet = @"
        ```csharp
        Console.WriteLine(""Hello World"");
        ```";

        await dotnetCodeAgent.SendAsync(codeSnippet);
        // output: Hello World
        #endregion code_snippet_1_2

        #region code_snippet_1_3
        var content = @"
        ```csharp
        // This is csharp code snippet
        ```

        ```python
        // This is python code snippet
        ```
        ";
        #endregion code_snippet_1_3

        #region code_snippet_1_4
        var pythonKernel = DotnetInteractiveKernelBuilder
            .CreateDefaultInProcessKernelBuilder()
            .AddPythonKernel(venv: "python3")
            .Build();

        var pythonCode = """
        print('Hello from Python!')
        """;
        var result = await pythonKernel.RunSubmitCodeCommandAsync(pythonCode, "python3");
        #endregion code_snippet_1_4
    }
}
