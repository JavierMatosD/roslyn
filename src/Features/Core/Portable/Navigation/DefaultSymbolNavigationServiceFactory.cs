﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Composition;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Microsoft.CodeAnalysis.Navigation
{
    [ExportWorkspaceServiceFactory(typeof(ISymbolNavigationService), ServiceLayer.Default), Shared]
    internal class DefaultSymbolNavigationServiceFactory : IWorkspaceServiceFactory
    {
        private ISymbolNavigationService _singleton;

        [ImportingConstructor]
        public DefaultSymbolNavigationServiceFactory()
        {
        }

        public IWorkspaceService CreateService(HostWorkspaceServices workspaceServices)
        {
            if (_singleton == null)
            {
                _singleton = new DefaultSymbolNavigationService();
            }

            return _singleton;
        }
    }
}
