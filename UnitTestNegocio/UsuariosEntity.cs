using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades.Enumerables.ErroresLog;
using Newtonsoft.Json;
using ServiciosEntityFramework.Models;

namespace UnitTestNegocio
{
    [TestClass]
    public class UsuariosEntity
    {
        private CampusVirtualEntities db = new CampusVirtualEntities();

        [TestMethod]
        public void Alta()
        {

            ServiciosEntityFramework.Models.Usuarios usuario = new ServiciosEntityFramework.Models.Usuarios();
            ServiciosEntityFramework.Models.Permisos permiso = new ServiciosEntityFramework.Models.Permisos();

            usuario.Nombre = "Facu";
            usuario.Apellido = "Sad";
            usuario.Direccion = "Triunvirato 1122";
            usuario.Clave = "123456";
            usuario.edad = 30;
            usuario.Email = "sadfacundo@gmail.com";
            usuario.Permisos = permiso;
            usuario.IdTipoUsuario = 1;
            usuario.Observaciones = "Prueba";
            usuario.IdEstado = 1;
            usuario.Activo = true;
            usuario.FechaNacimiento = DateTime.Now;


            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

      


    }
}
