using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// List Parks
        /// </summary>
        /// <returns></returns>
        IList<Park> ListParks();
    
        /// <summary>
        /// Menu Selection
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <returns></returns>
        Park ListInfo(string menuChoice);
    }
}
