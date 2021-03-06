/*!lic_info

The MIT License (MIT)

Copyright (c) 2015 SeaSunOpenSource

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

﻿using NNanomsg;
using NNanomsg.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace usmooth.app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            UsLogFileReceiver.Instance = new UsLogFileReceiver();
            UsLogging.Receivers += UsLogFileReceiver.Instance.LogIntoFile;
            NetUtil.LogHandler = UsLogging.Printf;
            NetUtil.LogErrorHandler = UsLogging.Errorf;

            NetManager.Instance = new NetManager();
            NetManager.Instance.Client.RegisterCmdHandler(eNetCmd.SV_App_Logging, Handle_ServerLogging);
        }

        private bool Handle_ServerLogging(eNetCmd cmd, UsCmd c)
        {
            UsLogPacket pkt = new UsLogPacket(c);
            UsNetLogging.Print(pkt);
            return true;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            UsLogFileReceiver.Instance.Dispose();
            NetManager.Instance.Dispose();
        }
    }
}
