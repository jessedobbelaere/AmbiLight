using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseThreading {
    
    /// <summary>
    /// Update the log delegate
    /// </summary>
    /// <param name="s">String message</param>
    public delegate void UpdateLogDelegate(string s);

    /// <summary>
    /// Show error delegate
    /// </summary>
    /// <param name="s">String message</param>
    public delegate void ShowError(string s);

    /// <summary>
    /// New section delegate
    /// </summary>
    /// <param name="x">X Coordinate</param>
    /// <param name="y">Y Coordinate</param>
    /// <param name="width">The width</param>
    /// <param name="height">The height</param>
    public delegate void NewSection(int x, int y, int width, int height);
}
