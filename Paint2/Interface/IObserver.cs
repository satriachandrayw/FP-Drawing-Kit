using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDrawingKit.Interface
{
    public interface IObserver //Observer
    {
        void Update(Observerable observable);
    }
}
