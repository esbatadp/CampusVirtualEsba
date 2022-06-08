using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestNegocio
{
    [TestClass]
    public class CursoAlumno
    {
        [TestMethod]
        public void Alta()
        {

            Entidades.Curso_Alumno curso_Alumno = new Entidades.Curso_Alumno();
            // curso_Alumno.Alumno = Negocio.Usuario.Obtener(11);            curso_Alumno.Curso = Negocio.Curso.Obtener(2);

            Negocio.Curso_Alumno.Grabar(curso_Alumno);

        }

        [TestMethod]
        public void Modificacion()
        {
            Entidades.Curso_Alumno curso_Alumno = new Entidades.Curso_Alumno();
            curso_Alumno.IdCursoAlumno = 1019;
            curso_Alumno.Alumno = Negocio.Usuario.Obtener(12);
            curso_Alumno.Curso = Negocio.Curso.Obtener(2);

            Negocio.Curso_Alumno.Grabar(curso_Alumno);
        }

        [TestMethod]
        public void Baja()
        {
           
            Negocio.Curso_Alumno.Eliminar(1019);
        }

        [TestMethod]
        public void Consulta()
        {
            List<Entidades.Curso_Alumno> listaCursoAlumnos= Negocio.Curso_Alumno.Listar();
        }

    }
}
