// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




document.addEventListener("DOMContentLoaded", function () {
    let SearchList = document.getElementById("search");
    let SearchIde = document.getElementById("floatide");
    let SearchNombre = document.getElementById("floatnombre");
    let SearchContrato = document.getElementById("floatContrato");
    var BuscarValor = document.getElementById("NewGestion");
    var AgendaRead = document.getElementById("floatage");
    var AgendaValue = document.getElementById("IdeAgen");
    var IdentidadValue = document.getElementById("IdeIngreso");
    var NombreValue = document.getElementById("IdeName");
    var contratoValue = document.getElementById("IdeContrato");
    var NextValue = document.getElementById("NextContrato");
    var BackValue = document.getElementById("BackContrato");
    var IdeRead = document.getElementById("floatide");
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

    var codigoGestionSelect2 = document.getElementById("SelectCod2");
    var codigoGestionInput2 = document.getElementById("SelectDes2");


    var Coordlat = document.getElementById("lat");
    var Coordlon = document.getElementById("lon");
    var Cart2Read = document.getElementById("floatCartera2");
    var GestorRead = document.getElementById("floatGestor");
    var AgenteRead = document.getElementById("floatagente");
    var AgenciaRead = document.getElementById("floatAgencia");
    var EmpresaLRead = document.getElementById("floatEmpresa_Labor");
    var EmpresaLTRead = document.getElementById("floatTel_Empresa_Labor");
    var EmpresaLDRead = document.getElementById("floatDireccion_Empresa_Labor");
    var ConsolidadoRead = document.getElementById("floatConsolidado_BD");
    var CiudadRead = document.getElementById("floatCiudad");
    var Gen1Read = document.getElementById("floatGen1");
    var Gen2Read = document.getElementById("floatGen2");
    var Gen3Read = document.getElementById("floatGen3");


    function actualizarCampos() {
        IdeRead.value = modelo[contador].Identidad;
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
        Cart2Read.value = modelo[contador].Cartera;
        AgenciaRead.value = modelo[contador].Agencia;
        EmpresaLRead.value = modelo[contador].Empresa_Labor;
        EmpresaLTRead.value = modelo[contador].Tel_Empresa_Labor;
        EmpresaLDRead.value = modelo[contador].Direccion_Empresa_Labor;
        ConsolidadoRead.value = modelo[contador].Consolidado_BD;
        CiudadRead.value = modelo[contador].Ciudad;
        Gen1Read.value = modelo[contador].Gen1;
        Gen2Read.value = modelo[contador].Gen2;
        Gen3Read.value = modelo[contador].Gen3;
        AgenteRead.value = modelo[contador].Agente;
    }




    NextValue.addEventListener("click", function () {

        console.log("La cantidad de contratos es: ", NumContratos);
        console.log(modelo[0]);
        console.log(modeloGestion[0]);

        if (contador < NumContratos - 1) {

            console.log("Agente: ", modelo[contador].Agente);
            console.log("Agencia: ", modelo[contador].Agencia);
            console.log("Empresa Labor: ", modelo[contador].Empresa_Labor);

            contador++;
            IdeRead.value = modelo[contador].Identidad;
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
            Cart2Read.value = modelo[contador].Cartera;
            AgenciaRead.value = modelo[contador].Agencia;
            EmpresaLRead.value = modelo[contador].Empresa_Labor;
            EmpresaLTRead.value = modelo[contador].Tel_Empresa_Labor;
            EmpresaLDRead.value = modelo[contador].Direccion_Empresa_Labor;
            ConsolidadoRead.value = modelo[contador].Consolidado_BD;
            CiudadRead.value = modelo[contador].Ciudad;
            Gen1Read.value = modelo[contador].Gen1;
            Gen2Read.value = modelo[contador].Gen2;
            Gen3Read.value = modelo[contador].Gen3;
            AgenteRead.value = modelo[contador].Agente;
        }
        else {
            swal.fire('Mensaje', 'No hay mas contatos cargados para este cliente', 'warning')
        }
    });

 
    BackValue.addEventListener("click", function () {
        //var NombRead = document.getElementById("floatNombre");

        console.log("La cantidad de contratos es: ", NumContratos);
        console.log(modelo[0]);


        if (contador > 0) {

            contador--;
            console.log("contador:", contador);
            console.log("Cantidad de Contratos", modelo[contador].Contrato);
            console.log("Antiguedad", modelo[contador].Antiguedad);
            console.log("Nombre", modelo[contador].Nombre);
            IdeRead.value = modelo[contador].Identidad;
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

           
            AgenciaRead.value = modelo[contador].Agencia;
            EmpresaLRead.value = modelo[contador].Empresa_Labor;
            EmpresaLTRead.value = modelo[contador].Tel_Empresa_Labor;
            EmpresaLDRead.value = modelo[contador].Direccion_Empresa_Labor;
            ConsolidadoRead.value = modelo[contador].Consolidado_BD;
            CiudadRead.value = modelo[contador].Ciudad;
            Gen1Read.value = modelo[contador].Gen1;
            Gen2Read.value = modelo[contador].Gen2;
            Gen3Read.value = modelo[contador].Gen3;
            AgenteRead.value = modelo[contador].Agente;
        }
        else {
            swal.fire('Mensaje', 'Ya este en el primer contrato registrado', 'warning')
        }

    });
   



    /*
    function GetCoord() {
        const options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0,
        };
        if (navigator.geolocation) {

            var success = function (position) {
                var latitud = position.coords.latitude,
                    longitud = position.coords.longitude;
                console.log(latitud);
                console.log(longitud);
                Coordlat.value = latitud + ", " + longitud;

            }
            navigator.geolocation.getCurrentPosition(success, function (msg) {
                console.error(msg);
            }, options);
        }
    }
    */


    function GetCoord() {
        const options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0,
        };

        function success(position) {
            var latitud = position.coords.latitude,
                longitud = position.coords.longitude;
            console.log(latitud);
            console.log(longitud);
            Coordlat.value = latitud + ", " + longitud;
        }

        function error(err) {
            console.error(err);
            // Si se deniega el permiso, intenta forzar la obtención de la ubicación
            if (err.code === 1 || err.code === 2 || err.code === 3) {
                navigator.geolocation.getCurrentPosition(success, error, options);
            }
        }

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(success, error, options);
        } else {
            console.error("Geolocalización no está soportada en este navegador");
        }
    }

    codigoGestionSelect.addEventListener("change", function () {

       
        var selectedOption = codigoGestionSelect.options[codigoGestionSelect.selectedIndex];
        var index = codigoGestionSelect.selectedIndex;
        console.log("El indice de la lista es: ", index);
        var selectedText = selectedOption.text;

        codigoGestionInput.value = modeloGestion[index].DescGestion;

    }

    );

   

    BuscarValor.addEventListener("click", function () {
        event.preventDefault();
        IdentidadValue.value = SearchIde.value;
        NombreValue.value = SearchNombre.value;
        contratoValue.value = SearchContrato.value;
        IdeGestor.value = document.getElementById("floatgestor").value;
        IdeAgente.value = document.getElementById("floatagente").value;
        IdeAgencia.value = document.getElementById("floatAgencia").value;
        IdeCartera.value = document.getElementById("floatCartera2").value;
        IdeSaldoMora.value = document.getElementById("floatMora").value;
        IdeSaldoTotal.value = document.getElementById("floatCredito").value;
        









       
    
        GetCoord();

        var fechaAgendaFormatoV = document.getElementById("floatage").value;
        console.log(fechaAgendaFormatoV);
        var fechaEnFormato = convertirFormato(fechaAgendaFormatoV);
       
        document.getElementById("IdeAgen").value = fechaEnFormato;



    }); 

  


    function convertirFormato(fechaAgendaFormatoV) {

        var partesFecha = fechaAgendaFormatoV.split(" ");
        var partesFechaNumerica = partesFecha[0].split("/");
      
        var fecha = new Date(
            parseInt(partesFechaNumerica[2]),
            parseInt(partesFechaNumerica[1]) - 1,
            parseInt(partesFechaNumerica[0])

        );
        var fechaFormateada = fecha.toISOString().slice(0, 10) + " 00:00:00";
        console.log(fechaFormateada);
        return fechaFormateada;
    }

    




    


   

    

});

document.addEventListener("DOMContentLoaded", function () {

    var AddressVar = document.getElementById("FileAddress")
    const dataTableBody = document.getElementById("data-table").getElementsByTagName('tbody')[0];
            AddressVar.addEventListener("change", function () {
                const selectedFiles = AddressVar.files;
                const file = selectedFiles[0];
                if (file.name.endsWith('.csv')) {
                    const reader = new FileReader();
                    Papa.parse(file, {
                        header: true,
                        delimiter: ";",
                        dynamicTyping: true,
                        encoding: "UTF-8",
                        complete: function (results) {
                            const data = results.data;
                            dataTableBody.innerHTML = "";
                            data.forEach(function (row) {
                                const newRow = dataTableBody.insertRow();
                                for (const key in row) {
                                    const cell = newRow.insertCell();
                                    cell.textContent = row[key];

                                }
                            });
                            const jsonData = JSON.stringify(data);
                            document.getElementById("datos").value = jsonData;
                            console.log(jsonData)
                        },
                    });
                } else if (file.name.endsWith('.xlsx')) {

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var data = e.target.result;
                        var workbook = XLSX.read(data, { type: "arraybuffer" });


                        var firstSheet = workbook.Sheets[workbook.SheetNames[0]];
                        var data = XLSX.utils.sheet_to_json(firstSheet);

                        processData(data);
                    };
                    reader.readAsArrayBuffer(file);
                } else {

                    Swal.fire('Error', 'Formato no admitido', 'error');
                }


                function processData(data) {

                    const headers = Object.keys(data[0]);//variable para asignar los encabezados


                    dataTableBody.innerHTML = "";

                    const headerRow = dataTableBody.insertRow();
                    headers.forEach(function (headerText) {
                        const headerCell = document.createElement("th");
                        headerCell.textContent = headerText;
                        headerRow.appendChild(headerCell);
                    });


                    data.forEach(function (row) {
                        const newRow = dataTableBody.insertRow();
                        for (const key in row) {
                            const cell = newRow.insertCell();
                            cell.textContent = row[key];
                        }
                    });
                    const jsonData = JSON.stringify(data);
                    document.getElementById("datos").value = jsonData;
                    console.log(jsonData);
                }


            });
        
    



    $(document).ready(function () {
        $('#searchDateString').select2();
    });

    $(document).ready(function () {
        $('.select2').select2();
    });





   
        document.getElementById('takePhotoBtn').addEventListener('click', function() {
            // Solicitar acceso a la cámara
            navigator.mediaDevices.getUserMedia({ video: true })
                .then(function (stream) {
                    var video = document.createElement('video');
                    video.srcObject = stream;
                    video.autoplay = true;

                    // Mostrar el video en un elemento de vídeo
                    document.body.appendChild(video);

                    // Capturar la imagen cuando se hace clic en el botón
                    document.getElementById('takePhotoBtn').addEventListener('click', function () {
                        var canvas = document.createElement('canvas');
                        var context = canvas.getContext('2d');
                        canvas.width = video.videoWidth;
                        canvas.height = video.videoHeight;
                        context.drawImage(video, 0, 0, canvas.width, canvas.height);

                        // Mostrar la vista previa de la foto
                        var photoPreview = document.getElementById('photoPreview');
                        photoPreview.src = canvas.toDataURL('image/jpeg');
                        photoPreview.style.display = 'block';

                        // Detener el video y detener la transmisión
                        video.pause();
                        video.srcObject.getTracks().forEach(function (track) {
                            track.stop();
                        });

                        // Eliminar el video
                        document.body.removeChild(video);
                    });
                })
                .catch(function (error) {
                    console.error('Error al acceder a la cámara:', error);
                });
    });
  

})

