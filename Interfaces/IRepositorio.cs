using System;
using System.Collections.Generic;

namespace CRUD.SeriesDIO
{
    public interface IRespositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T objeto);
        void Exclui(int id);
        void Atualiza(int id, T objeto);
        int ProximoId();
    }



}
