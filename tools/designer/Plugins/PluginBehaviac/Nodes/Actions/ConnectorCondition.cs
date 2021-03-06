﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2009, Daniel Kollmann
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// - Neither the name of Daniel Kollmann nor the names of its contributors may be used to endorse
//   or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY
// WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// The above software in this distribution may have been modified by THL A29 Limited ("Tencent Modifications").
//
// All Tencent Modifications are Copyright (C) 2015 THL A29 Limited.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using Behaviac.Design.Nodes;

namespace PluginBehaviac.Nodes
{
	public class ConnectorCondition : BaseNode.ConnectorMultiple
	{
        public ConnectorCondition(BaseNode.ConnectedChildren connectedChildren, string label, string identifier, int minCount, int maxCount)
            : base(connectedChildren, label, identifier, minCount, maxCount)
		{
		}

        public override bool AcceptsChildren(IList<Type> children, bool acceptEvenFull = false)
		{
			if(!base.AcceptsChildren(children))
			{
				return false;
			}

			foreach(Type t in children)
			{
                if (t != typeof(Nodes.Condition) &&
                    !t.IsSubclassOf(typeof(Behaviac.Design.Nodes.Condition)) &&
					!t.IsSubclassOf(typeof(Nodes.OperatorCondition)) )
				{
					return false;
				}
			}

			return true;
		}

		public override BaseNode.Connector Clone(BaseNode.ConnectedChildren connectedChildren)
		{
            return new ConnectorCondition(connectedChildren, _label, _identifier, _minCount, _maxCount);
		}
	}
}
