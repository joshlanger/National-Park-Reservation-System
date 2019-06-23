using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
    
        /// <summary>
        /// Menu Selection
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <returns></returns>
        Park ListInfo(string menuChoice);
    }
}
