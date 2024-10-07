using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio.Clases
{
    internal class SqliteDB
    {
        public SQLiteConnection ConexionDB()
        {
            var db = new SQLiteConnection("GestionPracticas_sqlite.db");
            return db;
        }
        public void SqliteIniciarTablas(SQLiteConnection db)
        {
            db.CreateTable<Clases.Solicitud>();
            db.CreateTable<Clases.Asistencia>();
            db.CreateTable<Clases.Guia>();
            db.CreateTable<Clases.Alumno>();
            db.CreateTable<Clases.Profesor>();
            db.CreateTable<Clases.Area>();
            db.CreateTable<Clases.Laboratorio>();
            db.CreateTable<Clases.Departamento>();
        }
    }
}
