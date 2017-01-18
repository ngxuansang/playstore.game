using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ICore
{
    public interface IDatabaseAct<TObject>
    {
        long Insert();

        void Update(TObject newObj);

        void Delete(TObject obj);
    }
}