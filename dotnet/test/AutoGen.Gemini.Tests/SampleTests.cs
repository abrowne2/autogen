﻿// Copyright (c) 2023 - 2024, Owners of https://github.com/autogenhub
// SPDX-License-Identifier: Apache-2.0
// Contributions to this project, i.e., https://github.com/autogenhub/autogen, 
// are licensed under the Apache License, Version 2.0 (Apache-2.0).
// Portions derived from  https://github.com/microsoft/autogen under the MIT License.
// SPDX-License-Identifier: MIT
// Copyright (c) Microsoft Corporation. All rights reserved.
// SampleTests.cs

using AutoGen.Gemini.Sample;
using AutoGen.Tests;

namespace AutoGen.Gemini.Tests;

public class SampleTests
{
    [ApiKeyFact("GCP_VERTEX_PROJECT_ID")]
    public async Task TestChatWithVertexGeminiAsync()
    {
        await Chat_With_Vertex_Gemini.RunAsync();
    }

    [ApiKeyFact("GCP_VERTEX_PROJECT_ID")]
    public async Task TestFunctionCallWithGeminiAsync()
    {
        await Function_Call_With_Gemini.RunAsync();
    }

    [ApiKeyFact("GCP_VERTEX_PROJECT_ID")]
    public async Task TestImageChatWithVertexGeminiAsync()
    {
        await Image_Chat_With_Vertex_Gemini.RunAsync();
    }
}
