﻿// Copyright (c) 2023 - 2024, Owners of https://github.com/autogenhub
// SPDX-License-Identifier: Apache-2.0
// Contributions to this project, i.e., https://github.com/autogenhub/autogen, 
// are licensed under the Apache License, Version 2.0 (Apache-2.0).
// Portions derived from  https://github.com/microsoft/autogen under the MIT License.
// SPDX-License-Identifier: MIT
// Copyright (c) Microsoft Corporation. All rights reserved.
// ToolCallAggregateMessage.cs

using System.Collections.Generic;

namespace AutoGen.Core;

/// <summary>
/// An aggregate message that contains a tool call message and a tool call result message.
/// This message type is used by <see cref="FunctionCallMiddleware"/> to return both <see cref="ToolCallMessage"/> and <see cref="ToolCallResultMessage"/>.
/// </summary>
public class ToolCallAggregateMessage : AggregateMessage<ToolCallMessage, ToolCallResultMessage>, ICanGetTextContent, ICanGetToolCalls
{
    public ToolCallAggregateMessage(ToolCallMessage message1, ToolCallResultMessage message2, string? from = null)
        : base(message1, message2, from)
    {
    }

    public string? GetContent()
    {
        return this.Message2.GetContent();
    }

    public IEnumerable<ToolCall> GetToolCalls()
    {
        return this.Message1.GetToolCalls();
    }
}
