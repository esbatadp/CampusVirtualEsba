using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Menu
    {
     

        #region Metodos publicos
        public static List<Entidades.Menu> Buscar(int idUsuario)
        {
            DataTable dt = new DataTable();
            dt = Datos.Menus.Buscar(idUsuario);
            List<Entidades.Menu> ListaMenu = new List<Entidades.Menu>();

            foreach (DataRow item in dt.Rows)
            {
                ListaMenu.Add(ArmarDatos(item));
            }

            return ListaMenu;
        }
        #endregion

        public static void CambiarEstado(int idMenu)
        {
            Datos.Menus.ModificarEstado(idMenu);
        }

        public static int Grabar(Entidades.Menu Menu)
        {
            try
            {
                if (Validar(Menu, out string error))
                {
                    if (Menu.IdMenu == null)
                    {

                        return Insertar(Menu);
                    }
                    else
                    {
                        return Modificar(Menu);
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #region Metodos privados
        private static int Insertar(Entidades.Menu Menu)
        {
            return Datos.Menus.Insertar(Menu);
        }

        private static int Modificar(Entidades.Menu Menu)
        {
            Datos.Menus.Modificar(Menu);

            return Menu.IdMenu.Value;
        }

        private static bool Validar(Entidades.Menu Menu, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(Menu.Descripcion))
                error += "La Descripcion ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(Menu.Controlador))
                error += "El Controlador ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(Menu.Accion))
                error += "La Accion ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }
        private static Entidades.Menu ArmarDatos(DataRow item)
        {
            Entidades.Menu Menu = new Entidades.Menu();
            Menu.IdMenu = Convert.ToInt32(item["IdMenu"]);
            Menu.Descripcion = item["IdMenu"].ToString();
            Menu.Controlador= item["IdMenu"].ToString();
            Menu.Accion = item["IdMenu"].ToString();
            Menu.Activo = Convert.ToBoolean(item["Activo"]);
            return Menu;
        }
        #endregion

    }
}
