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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usmooth.common;

public class UsFlyToObjectEventArgs : EventArgs {
	public UsFlyToObjectEventArgs(int instID) {
		_instID = instID;
	}

	public int _instID = 0;
}

// the notifier would do nothing in game 
// 		and notify the editor if the event is handled
public class UsEditorNotifer {
	public static UsEditorNotifer Instance = new UsEditorNotifer ();

	public void PostMessage_FlyToObject(int instID) {
		SysPost.InvokeMulticast (this, OnFlyToObject, new UsFlyToObjectEventArgs(instID));
	}

	public event SysPost.StdMulticastDelegation OnFlyToObject;
}

public delegate List<Texture> GetAllTexturesOfMaterial(Material mat);

public class UsEditorQuery {

	public static GetAllTexturesOfMaterial Func_GetAllTexturesOfMaterial; 
	 
	public static List<Texture> GetAllTexturesOfMaterial(Material mat) {
		if (mat == null || Func_GetAllTexturesOfMaterial == null) {
			return null;
		}

		return Func_GetAllTexturesOfMaterial (mat);
	}
}
