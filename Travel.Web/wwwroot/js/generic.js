/**
*Fech generico asyncrono get
*/

async function fetchGet(url, tiporespuesta, callback) {
    try {
        var raiz = document.getElementById("hdfOculto").value;
        //http://localhost........
        var urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz
            + url
        var res = await fetch(urlCompleta)
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        //JSON (Object)
        callback(res)

    } catch (e) {
        alert("Ocurrion un error\n"+ e);
    }
}
/**
*Fech generico asyncrono post
*/
async function fetchPost(url, tiporespuesta, frm, callback) {
    try {
        var raiz = document.getElementById("hdfOculto").value;

        //http://localhost........
        var urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url
        var res = await fetch(urlCompleta, {
            method: "POST",
            body: frm
        });
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        //JSON (Object)
        callback(res)


    } catch (e) {
        console.log(e)
        alert("Ocurrion un error\n" + e);

    }
}
/**
*Fech generico asyncrono post
*/
async function fetchPostMassive(url, tiporespuesta, frm, callback) {
    try {
        var raiz = document.getElementById("hdfOculto").value;

        //http://localhost........
        var urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url
        var res = await fetch(urlCompleta, {
            method: "POST",
            body: frm
        });
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        //JSON (Object)
        callback(res)


    } catch (e) {
        console.log(e)
        document.getElementById('customfileinputEdit').value = '';
        Mensaje(1);

    }
}
/**
*Método genérico para llenar select
*/
function llenarCombo(data, idcontrol, propiedadId, propiedadNombre, textoprimeraopcion = "---Seleccione---", valueprimeraopcion = "0") {

    var contenido = "";
    var objActual;

    contenido += "<option value='" + valueprimeraopcion + "'>" + textoprimeraopcion + "</option>"
    for (var i = 0; i < data.length; i++) {
        objActual = data[i];
        contenido += "<option value='" + objActual[propiedadId] + "'>" + objActual[propiedadNombre] + "</option>"
    }
    document.getElementById(idcontrol).innerHTML = contenido;
}
