/**
 * Método para visualizar la hora en el footer.
 */
function date() {
    var date = new Date();
    var d = date.getDate();
    var day = (d < 10) ? '0' + d : d;
    var m = date.getMonth() + 1;
    var month = (m < 10) ? '0' + m : m;
    var yy = date.getYear();
    var year = (yy < 1000) ? yy + 1900 : yy;

    var fechaA = (day + '/' + month + "/" + year);
    var ano = year;
    document.getElementById("datetime").innerHTML = fechaA;
}