﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_wpf.MVVM
{
    public interface IViewModel
    {
        Action Close { get; set; }
    }
}
