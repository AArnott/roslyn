﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Host;

namespace Microsoft.CodeAnalysis.GenerateEqualsAndGetHashCodeFromMembers
{
    /// <summary>
    /// Service that can be used to generate <see cref="object.Equals(object)"/> and
    /// <see cref="object.GetHashCode"/> overloads for use from other IDE features.
    /// </summary>
    internal interface IGenerateEqualsAndGetHashCodeService : ILanguageService
    {
        Task<Document> FormatDocumentAsync(Document document, CancellationToken cancellationToken);

        Task<IMethodSymbol> GenerateEqualsMethodAsync(Document document, INamedTypeSymbol namedType, ImmutableArray<ISymbol> members, string localNameOpt, CancellationToken cancellationToken);
        Task<IMethodSymbol> GenerateEqualsMethodThroughIEquatableEqualsAsync(Document document, INamedTypeSymbol namedType, CancellationToken cancellationToken);

        Task<IMethodSymbol> GenerateIEquatableEqualsMethodAsync(Document document, INamedTypeSymbol namedType, ImmutableArray<ISymbol> members, CancellationToken cancellationToken);

        Task<IMethodSymbol> GenerateGetHashCodeMethodAsync(Document document, INamedTypeSymbol namedType, ImmutableArray<ISymbol> members, CancellationToken cancellationToken);
    }
}
