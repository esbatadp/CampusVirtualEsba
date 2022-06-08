using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades.Enumerables.ErroresLog;
using Newtonsoft.Json;

namespace UnitTestNegocio
{
    [TestClass]
    public class Usuarios
    {
        [TestMethod]
        public void Alta()
        {
            Entidades.Usuario usuario = new Entidades.Usuario();
            usuario.Nombre = "Facu";
            usuario.Apellido = "Sad";
            usuario.Direccion = "Triunvirato 1122";
            usuario.Clave = "123456";
            usuario.Edad = 30;
            usuario.Email = "sadfacundo@gmail.com";
            usuario.Permiso = new Entidades.Permiso("Nuevo",true);
            usuario.TipoUsuario = Entidades.Enumerables.TipoUsuarios.Alumno;
            usuario.Observaciones = "Prueba";
            usuario.Estado = Entidades.Enumerables.Estados.Activo;
            usuario.Activo = false;
            usuario.FechaNacimiento = DateTime.Now;


            Negocio.Usuario.Grabar(usuario);




        }

        [TestMethod]
        public void Login()
        {


        }

        [TestMethod]
        public void ActivarUsuario()
        {

            Negocio.Usuario.Activar("RqdpWtD");

        }

        [TestMethod]
        public void EnviarCorreoRecuperacion()
        {


        }



        [TestMethod]
        public void Listar()
        {
            Negocio.Usuario.Listar();

        }



        [TestMethod]
        public void CorregirUsuarios()
        { 
            foreach (var item in Negocio.Errores_Log.Buscar(Tabla.Usuarios, Acciones.Grabar))
            {
                Entidades.Usuario usuario = JsonConvert.DeserializeObject<Entidades.Usuario>(item.Objeto);
                usuario.Permiso.IdPermiso = 1;
                Negocio.Usuario.Grabar(usuario);
            }          

        }


    }
}
