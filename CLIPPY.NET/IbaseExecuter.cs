using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIPPY.NET
{
    public interface IBaseExecuter
    {
        bool CanExecute(string inputText);

        string Execute(string inputText);
    }
}
