/**
 * Método para cargar la lista de editoriales inmediatamente se solicite la página.
 */
window.onload = function () {

    ListEditoriales();
}
/**
 * Método para mostrar el modal para ingresar un editorial nuevo.
 */
function newR() {

    $('#new').modal('show');
}
/**
 * Método que lista los editoriales.
 */
function ListEditoriales() {
    fetchGet("Editoriales/ListEditoriales", "json", function (res) {
        var tbody = document.getElementById("tbData");
        var contenido = "";
        var nregistros = res.length;
        var obj;
        for (var i = 0; i < nregistros; i++) {
            obj = res[i]
            contenido += `
                                <tr>
                                    <td>${obj.id_Editorial}</td>
                                    <td>${obj.nombre_Editorial}</td>
                                    <td>${obj.sede}</td>`

            contenido += `<td>
                <i class="fas fa-edit btn btn-primary btn-sm" aria-hidden="true"onclick="edit(${obj.id_Editorial})"></i>
                <i class="fas fa-trash-alt btn btn-danger btn-sm" aria-hidden="true"onclick="del(${obj.id_Editorial})" hidden="hidden"></i>
                </td></tr>`
        }
        tbody.innerHTML = contenido;
        if (res.length != "") {
            $("#tbEditoriales").DataTable({
                "paging": true,
                "retrieve": true,
                "responsive": true, "lengthChange": false, "autoWidth": false,
                "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            }).buttons().container().appendTo('#tbEditoriales_wrapper .col-md-6:eq(0)');
        }
    });
}

/**
 * Método para editar los editoriales por Id.
 * @param {number} id - El radio del círculo.
 */
function edit(id) {
    fetchGet("Editoriales/ListEditorialesXId?Id=" + id, "json", function (data) {
        if (data != "") {
            for (var i = 0; i < data.length; i++) {
               
                document.getElementById("idEditorialEdit").value = data[i].id_Editorial;
                document.getElementById("nameEditorialEdit").value = data[i].nombre_Editorial;
                document.getElementById("sededitorialEdit").value = data[i].sede;


            }
        }
        $('#edit').modal('show');

    });

}
/**
 * Método para guardar un registro nuevo.
 */
function saveNew() {

    var id = document.getElementById("idEditorial").value;
    var nombre = document.getElementById("nameEditorial").value;
    var sede = document.getElementById("sededitorial").value;

    if ((nombre != "") & (sede != "")) {

        var frmEnviar = document.getElementById("frmEnviarNew");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Editoriales/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7,"Editoriales");
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

    var id = document.getElementById("idEditorialEdit").value;
    var nombre = document.getElementById("nameEditorialEdit").value;
    var sede = document.getElementById("sededitorialEdit").value;


    if ((nombre != "") & (sede != "") & (id != 0)) {

        var frmEnviar = document.getElementById("frmEnviarEdit");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Editoriales/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7, "Editoriales");
            } else {
                Mensaje(8);
            }
        });
    }
    else {
        Mensaje(1);
    }
}