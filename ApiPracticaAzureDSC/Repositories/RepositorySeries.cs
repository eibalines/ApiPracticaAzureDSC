using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPracticaAzureDSC.Models;
using ApiPracticaAzureDSC.Data;

namespace ApiPracticaAzureDSC.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }
        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }
        public Personaje FindPersonaje(int idpersonaje)
        {
            return this.context.Personajes.SingleOrDefault
                (z => z.IdPersonaje == idpersonaje);
        }
        public int GetMaxIdPersonaje()
        {
            if(this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else {
                return this.context.Personajes.Max(num => num.IdPersonaje) + 1;
              }
        }
        public void InsertarPersonaje(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }
        public void EditarPersonaje(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = FindPersonaje(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }
        public void DeletePersonaje(int idpersonaje)
        {
            Personaje personaje = FindPersonaje(idpersonaje);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChanges();
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }
        public Serie FindSerie(int idserie)
        {
            return this.context.Series.SingleOrDefault
                (z => z.IdSerie == idserie);
        }
        public int GetMaxIdSerie()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Series.Max(num => num.IdSerie) + 1;
            }
        }
        public void InsertarSerie(string nombre, string imagen, float puntuacion, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = this.GetMaxIdSerie();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anyo = anyo;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public void EditarSerie(int idserie, string nombre, string imagen, float puntuacion, int anyo)
        {
            Serie serie = FindSerie(idserie);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anyo = anyo;
            this.context.SaveChanges();
        }

        public void DeleteSerie(int idserie)
        {
            Serie serie = this.FindSerie(idserie);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }

        public List<Personaje> GetPersonajesSerie(int idserie)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }

        public Personaje GetPersonajeSerie(int idserie, int idpersonaje)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie &&
                           datos.IdPersonaje == idpersonaje
                           select datos;
            return consulta.FirstOrDefault();
        }

    }
}
