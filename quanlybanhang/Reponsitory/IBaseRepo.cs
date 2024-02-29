using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Reponsitory
{
    interface IBaseRepo<Obj>
    {
        void create(Obj o);
        void update(Obj o);
        void delete(string id);
        List<Obj> getAll();
        Obj get(int id);
        Obj getByCode(string code);
    }
}
