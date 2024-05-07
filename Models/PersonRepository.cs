using jcordovat5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace jcordovat5.Models
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn= new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona persona = new() { Name = name};
                result = conn.Insert(persona);
                StatusMessage = string.Format("Se inserto una persona", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al insertar la persona", name, ex.Message);
            }
        }

        public List<Persona> getAllPeople() {

            try
            {
                Init ();
                return conn.Table<Persona>().ToList();   
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al Listar", ex.Message);
            }
            return new List<Persona>();
        }


        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var existingPerson = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (existingPerson != null)
                {
                    conn.Delete(existingPerson);
                    StatusMessage = "Persona eliminada exitosamente";
                }
                else
                {
                    StatusMessage = "No se encontró ninguna persona con ese ID";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al eliminar la persona: {ex.Message}";
            }
        }

        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();
                var existingPerson = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (existingPerson != null)
                {
                    existingPerson.Name = newName;
                    conn.Update(existingPerson);
                    StatusMessage = "Persona actualizada exitosamente";
                }
                else
                {
                    StatusMessage = "No se encontró ninguna persona con ese ID";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al actualizar la persona: {ex.Message}";
            }
        }

    }
}
