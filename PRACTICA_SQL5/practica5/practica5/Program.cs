/*
 * Creado por SharpDevelop.
 * Usuario: COMPAQ* Fecha: 20/11/2014
 * Hora: 01:34 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using MySql.Data.MySqlClient;
namespace practica55
{
	
	
	
	class Program : MySQL
	{
		public void mostrarTodos(){

	this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string telefono1 = myReader ["telefono"].ToString();
	            string email1 = myReader ["email"].ToString();
	            Console.WriteLine("ID: " + id +
				                  " Código: " + codigo +" Nombre: " + nombre + "telefono :" + telefono1 + "email :" + email1);
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}
		public void insertarRegistroNuevo(string nombre1, string telefono1,string email ,string codigo){
			this.abrirConexion();
			string sql = "INSERT INTO `Agenda` (`nombre`, `telefono`,`email`,`codigo`) VALUES ('" + nombre1 + "', '" + telefono1 + "','" + email+"','"+codigo+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			
		}
		public void eliminarRegistroPorId(string id){
			this.abrirConexion();
			string sql = "DELETE FROM `agenda` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);			this.cerrarConexion();
		}
		private string querySelect(){
			return "SELECT * " + "FROM agenda";
		
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		
		
		
		
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Bienvenidos!");
			Program p = new Program ();
			// TODO: Implement Functionality Here
			string nombre1,telefono1,email1,codigo1,registro;
			int opc;
			do{
				Console.WriteLine("1  Ingresar Registros\n");
				Console.WriteLine("2 Ver Registros\n");
				Console.WriteLine("3  Eliminar Registros\n");
				Console.WriteLine("4  Salir\n");
				opc =int.Parse (Console.ReadLine());
				switch(opc)
				{
				case 1 :
					
					Console.WriteLine("Ingresar Nombre completo");
			nombre1=Console.ReadLine();
			Console.WriteLine("Ingrese Telefono");
			telefono1=Console.ReadLine();
			Console.WriteLine("Ingrese Email");
			email1=Console.ReadLine();
			Console.WriteLine("Ingrese codigo");
			codigo1=Console.ReadLine();
		
			
	        p.insertarRegistroNuevo(nombre1,telefono1,email1,codigo1);
	        Console.WriteLine("Registro Agregado;");
				break;
				case 2 :
	        p.mostrarTodos();
	             break;
	            case 3 :
	             Console.WriteLine("Ingrese ID del Registro Para Borrar\n");
	             registro=Console.ReadLine();
	             p.eliminarRegistroPorId(registro);
	             Console.WriteLine("registro eliminado!!!\n");
	             break;
				}
			
		    
			}while(opc!=4);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
