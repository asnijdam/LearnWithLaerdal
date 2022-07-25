using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LearnWithLaerdal.Helpers
{
    internal interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
