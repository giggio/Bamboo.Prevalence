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

namespace Bamboo.Prevalence.Implementation
{
	/// <summary>
	/// Assertion utility.
	/// </summary>
	public class Assertion
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="parameter"></param>
		public static void AssertParameterNotNull(string paramName, object parameter)
		{
			if (null == parameter)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="description"></param>
		/// <param name="condition"></param>
		public static void AssertParameter(string paramName, string description, bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException(description, paramName);
			}
		}

        public static void AssertNotNull(string a, object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
        }
        public static void AssertNotNull(object obj)
        {
            AssertNotNull(string.Empty, obj);
        }

        public static void AssertSame(object objA, object objB)
        {
            
            if (objA == null && objB == null) return;
            if (!ReferenceEquals(objA, objB))
            {
                throw new ArgumentException("objB");
            }
        }
        public static void AssertEquals(string a, object objA, object objB)
        {
            if (objA == null && objB == null) return;
            if (!objA.Equals(objB))
            {
                throw new ArgumentException("objB");
            }
        }
        public static void AssertEquals(object objA, object objB)
        {
            if (objA == null && objB == null) return;
            if (!objA.Equals(objB))
            {
                throw new ArgumentException("objB");
            }
        }

        protected static void Assert(string p1, bool isTrue)
        {
            if (!isTrue) throw new ArgumentException("isTrue");
        }
        protected void Assert(bool isTrue)
        {
            Assert(string.Empty, isTrue);
        }
        protected void Fail(string msg)
        {
            throw new Exception(msg);
        }

	    public static void AssertNull(string msg, object obj)
	    {
            if (null != obj)
            {
                throw new ArgumentNullException(msg);
            }
        }
	    public static void AssertNull(object obj)
	    {
            if (null != obj)
            {
                throw new ArgumentNullException();
            }
        }
	}
}
