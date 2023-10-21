using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
//Generamos el controlador basee de la api 
public class Empresacontroller : ControllerBase{
    private const string V = "";

    //generamos los datos que van a ser ingresados en los usarios de la base
    public Empresa_E[] datos_empresas = new Empresa_E[]{


    new Empresa_E{Id= 1,Nombre_cliente="Alexis",Apellido_cliente="Ortega",Edad_Cliente=33,Rut_Cliente="17775614-8",Nombre_Empresa="Hamtastore",Rut_Empresa="28886541-5",Giro_Empresa="almacen",Total_Ventas=3000000,Monto_ventas=300,Monto_Iva=570000,Ganancia_Neta=2400000},
    new Empresa_E{Id= 2,Nombre_cliente="Danae",Apellido_cliente="Paz",Edad_Cliente=31,Rut_Cliente="18184871-5",Nombre_Empresa="LuluStore",Rut_Empresa="569854652-5",Giro_Empresa="Venta_Aros",Total_Ventas=2000000,Monto_ventas=200,Monto_Iva=380000,Ganancia_Neta=1430000},
    new Empresa_E{Id= 3,Nombre_cliente="Maria",Apellido_cliente="biglia",Edad_Cliente=22,Rut_Cliente="8124597-5",Nombre_Empresa="MariaStore",Rut_Empresa="185658457-5",Giro_Empresa="almacen",Total_Ventas=1000000,Monto_ventas=100,Monto_Iva=190000,Ganancia_Neta=810000}


 
                                 
};
// generamos el metodo Get para verlo en nuestro formato HTTP y la ruota donde buscara los datos
[HttpGet]
[Route("Empresa")]


// Generamos el formato de if para poder listar a todos los usuarios de la base y retornamos un mensaje cuando ya no hay mas usuarios
public IActionResult ListarEmpresa(){
    if (datos_empresas != null){

         for(int i = 0; i<datos_empresas.Length; i++)
                {
            Console.WriteLine(datos_empresas[i]);
    }
    return StatusCode(200, datos_empresas);
} else {
            Console.WriteLine("no existen mas empresas");
    return StatusCode(404);        
}}


// genermaos el metodo get nuevamente y generamos el formato en el cual se hara la busqueda especifica que en este caso sera la ID de la empresa

 [HttpGet]
 [Route("Empresa/{Id}")]
  public IActionResult ListarEmpresaId(int Id){


        //creamos elemento de control para recorrer el arreglo
        if (Id > 0 && Id <= datos_empresas.Length){

            //imprimimos en consola que se encontro la Empresa
            Console.WriteLine("Se encontro la empresa");

            //imprimimos el status code 200 que es correcto
            return StatusCode(200, datos_empresas[Id-1]);


        }else{

            //imprimimos en consola que no se encontro la Empresa
            Console.WriteLine("Empresa No encontrada");
            return StatusCode(404);

        }

    }


//Nuevamente generamos el metodo y la ruota donde se generara la nueva Empresa
[HttpPost]
    [Route("Empresa")]
    public IActionResult CrearEmpresa([FromBody] Empresa_E empresa){


        //generamos un elemento de control para el ingreso de nueva Empresa
        if(empresa != null){

            //imprimimos en consola que se creo la Empresa
            Console.WriteLine("Se creo la empresa");
            return StatusCode(201, empresa);
            
            }else{

                //imprimimos en consola que no se creo la Empresa
                Console.WriteLine("No se pudo crear la empresa");
                return StatusCode(404);
                
                }

    }

[HttpPut]
[Route("Empresa/{id}")]

   public IActionResult EditarEmpresa(int id, [FromBody] Empresa_E empresa_e){
        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= datos_empresas.Length){

            //Generamos la editación de todos los datos de la empresa la cual se editara
                datos_empresas[id-1].Id = empresa_e.Id;
                datos_empresas[id-1].Nombre_cliente = empresa_e.Nombre_cliente;
                datos_empresas[id-1].Apellido_cliente = empresa_e.Apellido_cliente;
                datos_empresas[id-1].Edad_Cliente = empresa_e.Edad_Cliente;
                datos_empresas[id-1].Rut_Cliente = empresa_e.Rut_Cliente;
                datos_empresas[id-1].Nombre_Empresa = empresa_e.Nombre_Empresa;
                datos_empresas[id-1].Rut_Empresa = empresa_e.Rut_Empresa;
                datos_empresas[id-1].Giro_Empresa = empresa_e.Giro_Empresa;
                datos_empresas[id-1].Total_Ventas = empresa_e.Total_Ventas;
                datos_empresas[id-1].Monto_ventas = empresa_e.Monto_ventas;
                datos_empresas[id-1].Monto_Iva = empresa_e.Monto_Iva;
                datos_empresas[id-1].Ganancia_Neta = empresa_e.Ganancia_Neta;
            

            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, datos_empresas[id-1]);

        }else if(id==0){

            //imprimimos en consola que no se encontro la Empresa
            Console.WriteLine("Persona No encontrada");
            return StatusCode(404);


        }else{

            //imprimimos que no se pudo editar la Empresa
            Console.WriteLine("No se pudo editar la persona");
            return StatusCode(400);

        }



    }

    //Generamos el metodo de busqueda por ID para buscar a la empresa la cual sera elimina en la base de datos
[HttpDelete]
    [Route("Empresa/{Id}")]

    public IActionResult BorrarPersona(int Id){

        //creamos elemento de control para recorrer el arreglo
        if (Id > 0 && Id <= datos_empresas.Length){

            //procedemos a la eliminacion de la Empresa
            datos_empresas[Id-1] = null;
            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, datos_empresas);
            
         
            }else{

                //imprimimos en consola que no se encontro la Empresa
                Console.WriteLine("empresa No encontrada");
                return StatusCode(404);
                
                }

    }
}