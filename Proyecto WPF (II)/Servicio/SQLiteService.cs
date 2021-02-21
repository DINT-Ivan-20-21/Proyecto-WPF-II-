using System;
using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;
using Proyecto_WPF__II_.Modelo;

namespace Proyecto_WPF__II_.Servicio
{
    class SQLiteService
    {
        private readonly SqliteConnection _conexion;

        public SQLiteService()
        {
            _conexion = new SqliteConnection("Data Source=cine.db");

            //Comprobamos si es la primera ejecucion
            if (DateTime.Parse(Properties.Settings.Default.lastUpdate).Date != DateTime.Now.Date)
            {

                //Cogemos las peliculas nuevas
                foreach (Pelicula pelicula in ApiRestService.GetCartelera())
                {
                    if (BuscaPelicula(pelicula.Id) == null)
                    {
                        Insertar(pelicula);
                    }
                }

                //Borrarmos las ventas
                EliminarVentas();

                Properties.Settings.Default.lastUpdate = DateTime.Now.ToShortDateString();
                Properties.Settings.Default.Save();
            }
        }

        public ObservableCollection<Pelicula> LeerPeliculas()
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    peliculas.Add(new Pelicula(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetString(2),
                        lector.GetInt32(3),
                        lector.GetString(4),
                        lector.GetString(5)
                        ));
                }
            }
            _conexion.Close();

            return peliculas;
        }

        public ObservableCollection<Sesion> LeerSesiones()
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM sesiones";
            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    sesiones.Add(new Sesion(
                        lector.GetInt32(0),
                        BuscaPelicula(lector.GetInt32(1)),
                        BuscaSala(lector.GetInt32(2)),
                        lector.GetDateTime(3)
                        ));
                }
            }
            _conexion.Close();

            return sesiones;
        }

        public ObservableCollection<Sesion> BuscaSesionesPorSala(int id)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM sesiones WHERE sala = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = id;

            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    sesiones.Add(new Sesion(
                        lector.GetInt32(0),
                        BuscaPelicula(lector.GetInt32(1)),
                        BuscaSala(lector.GetInt32(2)),
                        lector.GetDateTime(3)
                        ));
                }
            }
            _conexion.Close();

            return sesiones;
        }

        public ObservableCollection<Sesion> BuscaSesionesPorPelicula(int id)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM sesiones JOIN salas ON sesiones.sala = salas.idSala WHERE pelicula = @id AND disponible = true";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = id;

            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    sesiones.Add(new Sesion(
                        lector.GetInt32(0),
                        BuscaPelicula(lector.GetInt32(1)),
                        BuscaSala(lector.GetInt32(2)),
                        lector.GetDateTime(3)
                        ));
                }
            }
            _conexion.Close();

            return sesiones;
        }

        public ObservableCollection<Sala> LeerSalas()
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Sala> salas = new ObservableCollection<Sala>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    salas.Add(new Sala(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetInt32(2),
                        lector.GetBoolean(3)
                        ));
                }
            }
            _conexion.Close();

            return salas;
        }

        public ObservableCollection<Venta> LeerVentas()
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM ventas";
            SqliteDataReader lector = _comando.ExecuteReader();

            ObservableCollection<Venta> ventas = new ObservableCollection<Venta>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    ventas.Add(new Venta(
                        lector.GetInt32(0),
                        BuscaSesion(lector.GetInt32(1)),
                        lector.GetInt32(2),
                        lector.GetString(3)
                        ));
                }
            }
            _conexion.Close();

            return ventas;
        }


        private Pelicula BuscaPelicula(int id)
        {
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM peliculas WHERE idPelicula = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = id;

            SqliteDataReader lector = _comando.ExecuteReader();

            Pelicula pelicula = null;
            if (lector.HasRows)
            {
                lector.Read();
                pelicula = new Pelicula(
                     lector.GetInt32(0),
                     lector.GetString(1),
                     lector.GetString(2),
                     lector.GetInt32(3),
                     lector.GetString(4),
                     lector.GetString(5)
                     );
            }

            return pelicula;
        }

        private Sala BuscaSala(int id)
        {
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM salas WHERE idSala = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = id;

            SqliteDataReader lector = _comando.ExecuteReader();

            Sala sala = null;
            if (lector.HasRows)
            {
                lector.Read();
                sala = new Sala(
                     lector.GetInt32(0),
                     lector.GetString(1),
                     lector.GetInt32(2),
                     lector.GetBoolean(3)
                     );
            }

            return sala;
        }

        private Sesion BuscaSesion(int id)
        {
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM sesiones WHERE idSesion = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = id;

            SqliteDataReader lector = _comando.ExecuteReader();

            Sesion sesion = null;
            if (lector.HasRows)
            {
                lector.Read();
                sesion = new Sesion(
                     lector.GetInt32(0),
                     BuscaPelicula(lector.GetInt32(1)),
                     BuscaSala(lector.GetInt32(2)),
                     DateTime.Parse(lector.GetString(3))
                     );
            }

            return sesion;
        }

        public void Insertar(Pelicula pelicula)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO peliculas VALUES (@id, @titulo, @cartel, @anyo, @genero, @calificacion)";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters.Add("@titulo", SqliteType.Text);
            _comando.Parameters.Add("@cartel", SqliteType.Text);
            _comando.Parameters.Add("@anyo", SqliteType.Integer);
            _comando.Parameters.Add("@genero", SqliteType.Text);
            _comando.Parameters.Add("@calificacion", SqliteType.Text);
            _comando.Parameters["@id"].Value = pelicula.Id;
            _comando.Parameters["@titulo"].Value = pelicula.Titulo;
            _comando.Parameters["@cartel"].Value = pelicula.Cartel;
            _comando.Parameters["@anyo"].Value = pelicula.Año;
            _comando.Parameters["@genero"].Value = pelicula.Genero;
            _comando.Parameters["@calificacion"].Value = pelicula.Calificacion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Insertar(Sesion sesion)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones VALUES (null, @pelicula, @sala, @hora)";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion.Pelicula.Id;
            _comando.Parameters["@sala"].Value = sesion.Sala.Id;
            _comando.Parameters["@hora"].Value = sesion.Hora.ToShortTimeString();
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Insertar(Sala sala)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO salas VALUES (null, @numero, @capacidad, @disponible)";
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Text);
            _comando.Parameters["@numero"].Value = sala.Numero;
            _comando.Parameters["@capacidad"].Value = sala.Capacidad;
            _comando.Parameters["@disponible"].Value = sala.Disponible;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Insertar(Venta venta)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO ventas VALUES (null, @sesion, @cantidad, @pago)";
            _comando.Parameters.Add("@sesion", SqliteType.Integer);
            _comando.Parameters.Add("@cantidad", SqliteType.Integer);
            _comando.Parameters.Add("@pago", SqliteType.Text);
            _comando.Parameters["@sesion"].Value = venta.Sesion.Id;
            _comando.Parameters["@cantidad"].Value = venta.Cantidad;
            _comando.Parameters["@pago"].Value = venta.Pago;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Actualizar(Sesion sesion)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE sesiones SET pelicula = @pelicula, sala = @sala, hora = @hora  WHERE idSesion=@id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@id"].Value = sesion.Id;
            _comando.Parameters["@pelicula"].Value = sesion.Pelicula.Id;
            _comando.Parameters["@sala"].Value = sesion.Sala.Id;
            _comando.Parameters["@hora"].Value = sesion.Hora.ToShortTimeString();
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Actualizar(Sala sala)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE salas SET numero = @numero, capacidad = @capacidad, disponible = @disponible WHERE idSala=@id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Text);
            _comando.Parameters["@id"].Value = sala.Id;
            _comando.Parameters["@numero"].Value = sala.Numero;
            _comando.Parameters["@capacidad"].Value = sala.Capacidad;
            _comando.Parameters["@disponible"].Value = sala.Disponible;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void EliminarVentas()
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "TRUNCATE TABLE ventas";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Eliminar(Sesion sesion)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM sesiones WHERE idSesion = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = sesion.Id;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public int CantidadEntradasVendidas(int idSesion)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT SUM(ventas.cantidad) FROM sesiones JOIN ventas ON sesiones.idSesion = ventas.sesion WHERE idSesion = @id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = idSesion;

            Object cantidad = _comando.ExecuteScalar();

            _conexion.Close();

            return cantidad is DBNull ? 0 : Convert.ToInt32(cantidad);
        }

        public bool ExisteNumeroSala(string numero)
        {
            _conexion.Open();
            SqliteCommand _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT COUNT(*) FROM salas WHERE numero = @numero";
            _comando.Parameters.Add("@numero", SqliteType.Integer);
            _comando.Parameters["@numero"].Value = numero;

            int cantidad = Convert.ToInt32(_comando.ExecuteScalar());

            _conexion.Close();

            return cantidad != 0;
        }
    }
}