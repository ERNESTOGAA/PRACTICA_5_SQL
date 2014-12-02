/*
 * Creado por SharpDevelop.
 * Usuario: BETY
 * Fecha: 20/11/2014
 * Hora: 01:35 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using MySql.Data.MySqlClient;
namespace practica55
{
	/// <summary>
	/// Description of MySQL.
	/// </summary>
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL()
		{
	
		}
		protected void abrirConexion(){
			string connectionString =
          		"Server=localhost;" +
	          	"Database=agenda;" +
	          	"User ID=root;" +
	          	"Password=1234;" +
	          	"Pooling=false;";
	       this.myConnection = new MySqlConnection(connectionString);
	       this.myConnection.Open();
		}
		
		protected void cerrarConexion(){
			this.myConnection.Close(); 
			this.myConnection = null;
		}				
		
		
	}
}