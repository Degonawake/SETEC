// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


          

           document.addEventListener("DOMContentLoaded", function () {
               let SearchList = document.getElementById("search");
               let SearchNombre = document.getElementById("floatnombre");
               let SearchContrato = document.getElementById("floatContrato");
               var BuscarValor = document.getElementById("NewGestion");
               var IdentidadValue = document.getElementById("IdeIngreso");
               var NombreValue = document.getElementById("IdeName");
               var contratoValue = document.getElementById("IdeContrato");
               var NextValue = document.getElementById("NextContrato");
               var BackValue = document.getElementById("BackContrato");
               var NombRead = document.getElementById("floatnombre");
               var ContRead = document.getElementById("floatContrato");
               var AntRead = document.getElementById("floatAntiguedad"); 
               var CanalRead = document.getElementById("floatCanal"); 
               var ArtiRead = document.getElementById("floatArticulos"); 
               var CartRead = document.getElementById("floatCartera"); 
               var AtrRead = document.getElementById("floatAtraso"); 
               var FactRead = document.getElementById("floatFactura"); 
               var CreRead = document.getElementById("floatCredito"); 
               var MorRead = document.getElementById("floatMora"); 
               var DesRead = document.getElementById("floatDescuento"); 
               var PagRead = document.getElementById("floatPagoDescuento"); 
               var FacVRead = document.getElementById("floatVfactura");
               var codigoGestionSelect = document.getElementById("SelectCod");
               var codigoGestionInput = document.getElementById("SelectDes");
               var Coordlat = document.getElementById("lat");         
               var Coordlon = document.getElementById("lon");


               function GetCoord() 
                { 
                   const options = {
                       enableHighAccuracy: true,
                       timeout: 5000,
                       maximumAge: 0,
                   };
                    if(navigator.geolocation)
                    {

                        var success = function(position)
                        {
                            var latitud = position.coords.latitude,
                                longitud = position.coords.longitude;
                            console.log(latitud);
                            console.log(longitud);
                            Coordlat.value = latitud+", "+longitud;
                            
                        }
                        navigator.geolocation.getCurrentPosition(success, function(msg)
                        {
                            console.error( msg );
                        },options);
                    }
                }


               codigoGestionSelect.addEventListener("change", function () {
                        
                        console.log("Entro Funcion")
                        var selectedOption = codigoGestionSelect.options[codigoGestionSelect.selectedIndex];
                        var index = codigoGestionSelect.selectedIndex;       
                        console.log("El indice de la lista es: ",index)
                        var selectedText = selectedOption.text;

                        codigoGestionInput.value = modeloGestion[index].DescGestion;
                });

               BuscarValor.addEventListener("click", function () {
                    event.preventDefault();
                   IdentidadValue.value = SearchList.value;
                    NombreValue.value = SearchNombre.value;
                    
                    contratoValue.value = SearchContrato.value;
                    contratoValue.value = SearchContrato.value;
                    GetCoord();
                });

               NextValue.addEventListener("click", function () {
                  
                   console.log("La cantidad de contratos es: ", NumContratos);
                   console.log(modelo[0]);
                   console.log(modeloGestion[0]);

                   if (contador < NumContratos - 1) 
                   {
                        
                       contador++;
                       console.log("contador:", contador);
                       console.log("Cantidad de Contratos",modelo[contador].Contrato);
                       console.log("Antiguedad",modelo[contador].Antiguedad);
                       console.log("Nombre",modelo[contador].Nombre);
                       NombRead.value = modelo[contador].Nombre;
                       ContRead.value = modelo[contador].Contrato;
                       AntRead.value = modelo[contador].Antiguedad;
                       CanalRead.value = modelo[contador].Canal_de_venta;
                       ArtiRead.value = modelo[contador].Articulos;
                       CartRead.value = modelo[contador].Tipo_de_cartera;
                       AtrRead.value = modelo[contador].Dias_de_atraso;
                       FactRead.value = modelo[contador].Vencimiento_factura;
                       CreRead.value = modelo[contador].Saldo_total_credito;
                       MorRead.value = modelo[contador].Saldo_en_Mora;
                       DesRead.value = modelo[contador].Descuento;
                       PagRead.value = modelo[contador].Pago_con_descuento;
                       FacVRead.value = modelo[contador].Vencimiento_factura;
                   }
                   else 
                   {
                    alert("No hay mas contratos para el cliente")
                   }
                });
            
                BackValue.addEventListener("click", function () {
                   //var NombRead = document.getElementById("floatNombre");
                  
                   console.log("La cantidad de contratos es: ", NumContratos);
                   console.log(modelo[0]);


                   if (contador > 0) 
                   {
                        
                       contador--;
                       console.log("contador:", contador);
                       console.log("Cantidad de Contratos",modelo[contador].Contrato);
                       console.log("Antiguedad",modelo[contador].Antiguedad);
                       console.log("Nombre",modelo[contador].Nombre);

                       NombRead.value = modelo[contador].Nombre;
                       ContRead.value = modelo[contador].Contrato;
                       AntRead.value = modelo[contador].Antiguedad;
                       CanalRead.value = modelo[contador].Canal_de_venta;
                       ArtiRead.value = modelo[contador].Articulos;
                       CartRead.value = modelo[contador].Tipo_de_cartera;
                       AtrRead.value = modelo[contador].Dias_de_atraso;
                       FactRead.value = modelo[contador].Vencimiento_factura;
                       CreRead.value = modelo[contador].Saldo_total_credito;
                       MorRead.value = modelo[contador].Saldo_en_Mora;
                       DesRead.value = modelo[contador].Descuento;
                       PagRead.value = modelo[contador].Pago_con_descuento;
                       FacVRead.value = modelo[contador].Vencimiento_factura;
                   }
                   else 
                   {
                    alert("No hay mas contratos para el cliente")
                   }
                    
                   
                    
                    
                    
          


                });
     
        });

