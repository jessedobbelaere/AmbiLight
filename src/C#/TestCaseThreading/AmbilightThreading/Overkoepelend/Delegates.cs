using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseThreading {
    public delegate void UpdateLogDelegate(string s);
    public delegate void ShowError(string s);
    public delegate void NewSection(int x, int y, int width, int height);
}
