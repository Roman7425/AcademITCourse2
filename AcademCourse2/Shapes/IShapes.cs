﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IShapes
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }
}
