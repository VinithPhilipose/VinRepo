using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSolution.BL
{
    /// <summary>
    /// Interface created for Pyramid calculation Logic
    /// </summary>
    public interface IPyramidLogic
    {
        Task<IList<Int32>> processPyramidData(string selectedFile);
    }
}
