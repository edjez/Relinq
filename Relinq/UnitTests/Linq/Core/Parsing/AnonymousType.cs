// This file is part of the re-linq project (relinq.codeplex.com)
// Copyright (C) 2005-2009 rubicon informationstechnologie gmbh, www.rubicon.eu
// 
// re-linq is free software; you can redistribute it and/or modify it under 
// the terms of the GNU Lesser General Public License as published by the 
// Free Software Foundation; either version 2.1 of the License, 
// or (at your option) any later version.
// 
// re-linq is distributed in the hope that it will be useful, 
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with re-linq; if not, see http://www.gnu.org/licenses.
// 
using System;
using System.Collections.Generic;

namespace Remotion.Linq.UnitTests.Linq.Core.Parsing
{
  public class AnonymousType<TA, TB>
  {
    public AnonymousType ()
    {
    }

    public AnonymousType (TA a, TB b)
    {
      this.a = a;
      this.b = b;
    }

    public TA a { get; set; }
    public TB b { get; set; }
    public List<int> List { get; set; }
  }

  public class AnonymousType
  {
    public AnonymousType ()
    {
    }

    public AnonymousType (int a, int b)
    {
      this.a = a;
      this.b = b;
    }

    public int a { get; set; }
    public int b { get; set; }
    public List<int> List { get; set; }
  }
}