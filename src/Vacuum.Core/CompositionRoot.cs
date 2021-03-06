﻿#region License

// Copyright (c) 2015, Matt Holmes
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the project nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT  LIMITED TO, THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL 
// THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT  LIMITED TO, PROCUREMENT 
// OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
// EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Windows.Threading;
using LightInject;
using Microsoft.Practices.Prism.PubSubEvents;
using Vacuum.Core.Commands;
using Vacuum.Core.Configuration;
using Vacuum.Core.Profiles;
using Vacuum.Core.Speech;
using Vacuum.Core.Storage;
using Vacuum.Core.Ui;

namespace Vacuum.Core {
    public class CompositionRoot : ICompositionRoot {
        public void Compose (IServiceRegistry serviceRegistry) {
            serviceRegistry.RegisterInstance<IDispatchHandler> (new DispatchHandler (Dispatcher.CurrentDispatcher));
            serviceRegistry.Register<Log> (new PerContainerLifetime ());
            serviceRegistry.Register<IEventAggregator, EventAggregator> (new PerContainerLifetime ());
            serviceRegistry.Register<IStorageService, StorageService> (new PerContainerLifetime ());
            serviceRegistry.Register<IOptionsService, OptionsService> (new PerContainerLifetime ());
            serviceRegistry.Register<IProfileService, ProfileService> (new PerContainerLifetime ());
            serviceRegistry.Register<ICommandService, CommandService> (new PerContainerLifetime ());
            serviceRegistry.Register<IFlyoutService, FlyoutService> (new PerContainerLifetime ());
            serviceRegistry.Register<ISpeechService, SpeechService> (new PerContainerLifetime ());
        }
    }
}
