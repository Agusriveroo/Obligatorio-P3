document.querySelector("#Dto_TipoEnvio").addEventListener('change', MostrarDatosTipoEnvio);
MostrarDatosTipoEnvio();

function MostrarDatosTipoEnvio() {

    let tipoSlc = document.querySelector("#Dto_TipoEnvio").value;
   

    if (tipoSlc == "comun") {

        document.querySelector("#opcionesComun").style.display = "block";
        document.querySelector("#opcionesUrgente").style.display = "none";

    } else  {

        document.querySelector("#opcionesComun").style.display = "none";
        document.querySelector("#opcionesUrgente").style.display = "block";

    }

}