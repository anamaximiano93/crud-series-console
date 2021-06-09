using System;
using System.Collections.Generic;

namespace CRUD.SeriesDIO
{
    public class SerieRepositorio : IRespositorio<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listSerie;
        }

        public int ProximoId()
        {
            return listSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listSerie[id];
        }
    }


}
