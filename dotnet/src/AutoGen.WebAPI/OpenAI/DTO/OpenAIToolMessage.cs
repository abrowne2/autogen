﻿// Copyright (c) 2023 - 2024, Owners of https://github.com/autogenhub
// SPDX-License-Identifier: Apache-2.0
// Contributions to this project, i.e., https://github.com/autogenhub/autogen, 
// are licensed under the Apache License, Version 2.0 (Apache-2.0).
// Portions derived from  https://github.com/microsoft/autogen under the MIT License.
// SPDX-License-Identifier: MIT
// Copyright (c) Microsoft Corporation. All rights reserved.
// OpenAIToolMessage.cs

using System.Text.Json.Serialization;

namespace AutoGen.WebAPI.OpenAI.DTO;

internal class OpenAIToolMessage : OpenAIMessage
{
    [JsonPropertyName("role")]
    public override string? Role { get; } = "tool";

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("tool_call_id")]
    public string? ToolCallId { get; set; }
}
