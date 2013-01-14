#region license
// Bamboo.Prevalence - a .NET object prevalence engine
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// Based on the original concept and implementation of Prevayler (TM)
// by Klaus Wuestefeld. Visit http://www.prevayler.org for details.
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, 
// and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// Contact Information
//
// http://bbooprevalence.sourceforge.net
// mailto:rodrigobamboo@users.sourceforge.net
#endregion

using System;
using Bamboo.Prevalence.Implementation;
using Bamboo.Prevalence.Tests.Model;
using NUnit.Framework;
using Bamboo.Prevalence;
using Bamboo.Prevalence.Attributes;

namespace Bamboo.Prevalence.Tests.Model
{
	/// <summary>
	/// An transparently prevalent class. The methods can be
	/// directly exposed to clients, there's no need to use command
	/// and query objects (they will be created automatically
	/// by the system as needed).
	/// </summary>
	[Serializable]
	[TransparentPrevalence]	
	public class TransparentAddingSystem : System.MarshalByRefObject, IAddingSystem
	{
		private int _total;

		public TransparentAddingSystem()
		{		
		}

		public int Total
		{
			// property accessor are treated as query objects (read lock)
			get
			{
				AssertIsPrevalenceEngineCall();

				return _total;
			}
		}

		// public methods are treated as command objects (write lock)
		// unless the attribute Query has been applied to the method.
		public int Add(int amount)
		{
			AssertIsPrevalenceEngineCall();

			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount", amount, "amount must be positive!");
			}
			_total += amount;
			return _total;
		}

		[PassThrough]
		public void PassThroughMethod()
		{
			Assertion.AssertNull("PassThrough should prevent engine call!", PrevalenceEngine.Current);
		}

		private void AssertIsPrevalenceEngineCall()
		{
			// Just making sure that this call was intercepted and
			// the PrevalenceEngine is available!
			Assertion.AssertNotNull("PrevalenceEngine.Current", PrevalenceEngine.Current);
		}
	}
}