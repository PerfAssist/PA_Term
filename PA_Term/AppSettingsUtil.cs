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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usmooth.app
{
    public class AppSettingsUtil
    {
        public static string Localhost = "127.0.0.1";

        public static bool AppendAsRecentlyConnected(string remoteAddr)
        {
            if (PA_Term.Properties.Settings.Default.RecentAddrList == null)
            {
                PA_Term.Properties.Settings.Default.RecentAddrList = new System.Collections.Specialized.StringCollection();
            }
            else
            {
                if (remoteAddr == Localhost || PA_Term.Properties.Settings.Default.RecentAddrList.Contains(remoteAddr))
                    return false;
            }

            PA_Term.Properties.Settings.Default.RecentAddrList.Add(remoteAddr);
            PA_Term.Properties.Settings.Default.Save();
            return true;
        }
    }
}
