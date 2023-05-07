/**
 * Método para cargar la lista de autores inmediatamente se solicite la página.
 */
window.onload = function () {

    ListAutores();
}
/**
 * Método para mostrar el modal para ingresar un autor nuevo.
 */
function newR() {

    $('#new').modal('show');
}

/**
 * Método que lista los autores.
 */
function ListAutores() {
    fetchGet("Autores/ListAutores", "json", function (res) {
        var tbody = document.getElementById("tbData");
        var contenido = "";
        var nregistros = res.length;
        var obj;
        for (var i = 0; i < nregistros; i++) {
            obj = res[i]
            contenido += `
                                <tr>
                                    <td>${obj.id_Autor}</td>
                                    <td>${obj.nombres_Autor}</td>
                                    <td>${obj.apellidos_Autor}</td>`

            contenido += `<td>
                <i class="fas fa-edit btn btn-primary btn-sm" aria-hidden="true"onclick="edit(${obj.id_Autor})"></i>
                <i class="fas fa-trash-alt btn btn-danger btn-sm" aria-hidden="true"onclick="del(${obj.id_Autor})" hidden="hidden"></i>
                </td></tr>`
        }
        tbody.innerHTML = contenido;
        if (res.length != "") {
            $("#tbAutores").DataTable({
                "paging": true,
                "retrieve": true,
                "responsive": true, "lengthChange": false, "autoWidth": false,
                "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            }).buttons().container().appendTo('#tbAutores_wrapper .col-md-6:eq(0)');
        }
    });
}

/**
 * Método para editar los autores.
 * @param {number} id - El radio del círculo.
 */
function edit(id) {
    fetchGet("Autores/ListAutoresXId?Id=" + id, "json", function (data) {
        if (data != "") {
            for (var i = 0; i < data.length; i++) {

                document.getElementById("idAutorEdit").value = data[i].id_Autor;
                document.getElementById("nameAutorEdit").value = data[i].nombres_Autor;
                document.getElementById("apellidoAutorEdit").value = data[i].apellidos_Autor;


            }
        }
        $('#edit').modal('show');

    });
}

/**
 * Método para guardar un registro nuevo.
 */
function saveNew() {

    var id = document.getElementById("idAutor").value;
    var nombre = document.getElementById("nameAutor").value;
    var apellido = document.getElementById("apellidoAutor").value;

    if ((nombre != "") & (apellido != "")) {

        var frmEnviar = document.getElementById("frmEnviarNew");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Autores/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7, "Autores");
            } else {
                Mensaje(8);
            }
        });
    }
    else {
        Mensaje(1);
    }
}
/**
 * Método para editar un registro.
 */
function saveEdit() {

    var id = document.getElementById("idAutorEdit").value;
    var nombre = document.getElementById("nameAutorEdit").value;
    var apellido = document.getElementById("apellidoAutorEdit").value;


    if ((nombre != "") & (apellido != "") & (id != 0)) {

        var frmEnviar = document.getElementById("frmEnviarEdit");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Autores/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7, "Autores");
            } else {
                Mensaje(8);
            }
        });
    }
    else {
        Mensaje(1);
    }
}
