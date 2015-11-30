using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public interface ICommand
    {
        void Execute(string filename);
    }
}
