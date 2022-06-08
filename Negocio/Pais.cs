using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Pais
    {
        #region Metodos publicos
        public static List<Entidades.Pais> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Paises.Listar();

            List<Entidades.Pais> listaPaises = new List<Entidades.Pais>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }


            return listaPaises;
        }

        public static Entidades.Pais Obtener(int idPais)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.Obtener(idPais);

            return ArmarDatos(dt.Rows[0]);
        }

        public static List<Entidades.Pais> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.Buscar(descripcion);
            List<Entidades.Pais> listaPaises = new List<Entidades.Pais>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }

            return listaPaises;
        }          

        public static void Eliminar(int idPais)
        {
            Datos.Paises.Eliminar(idPais);
        }


        public static int Grabar(Entidades.Pais pais)
        {

            if (pais.IdPais == null)
                return Datos.Paises.Insertar(pais);
            else
            {
                Datos.Paises.Modificar(pais);
                return pais.IdPais.Value;
            }
            


        }

        #endregion

        #region Metodos privados
        private static Entidades.Pais ArmarDatos(DataRow item)
        {
            Entidades.Pais pais = new Entidades.Pais(Convert.ToInt32(item["IdPais"]), item["Descripcion"].ToString());
            return pais;
        }
        #endregion
    }
}
