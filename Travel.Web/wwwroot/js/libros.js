/**
 * Método para cargar la lista de autores,editoriales y libros inmediatamente se solicite la página.
 */
window.onload = function () {

    ListLibros();
    ListEditoriales();
    ListAutores();
}
/**
 * Método para mostrar el modal para ingresar un libro nuevo.
 */
function newR() {
    ListEditorialesN();
    ListAutoresN();
    $('#new').modal('show');
}
/**
 * Método que lista los libros.
 */
function ListLibros() {
    fetchGet("Libros/ListLibros", "json", function (res) {
        var tbody = document.getElementById("tbData");
        var contenido = "";
        var nregistros = res.length;
        var obj;
        for (var i = 0; i < nregistros; i++) {
            obj = res[i]
            contenido += `
                                <tr>
                                    <td hidden="hidden">${obj.id_Libro}</td>
                                    <td>${obj.isbn}</td>                                  
                                    <td>${obj.titulo}</td>
                                    <td>${obj.nombres_Autor}</td>
                                    <td>${obj.nombre_Editorial}</td>`

            contenido += `<td>
                <i class="fas fa-edit btn btn-primary btn-sm" aria-hidden="true"onclick="edit(${obj.id_Libro})"></i>
                <i class="fas fa-trash-alt btn btn-danger btn-sm" aria-hidden="true"onclick="del(${obj.id_Libro})" hidden="hidden"></i>
                </td></tr>`
        }
        tbody.innerHTML = contenido;
        if (res.length != "") {
            $("#tbLibros").DataTable({
                "paging": true,
                "retrieve": true,
                "responsive": true, "lengthChange": false, "autoWidth": false,
                "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            }).buttons().container().appendTo('#tbLibros_wrapper .col-md-6:eq(0)');
        }
    });
}
/**
 * Método para editar los libros.
 * @param {number} id - El radio del círculo.
 */
function edit(id) {

   //document.getElementById("especialistaEdit").removeAttribute("disabled");

    fetchGet("Libros/ListLibrosXId?Id=" + id, "json", function (data) {
        if (data != "") {
            for (var i = 0; i < data.length; i++) {

                document.getElementById("idLibroEdit").value = data[i].id_Libro;
                document.getElementById("iSBNLibroEdit").value = data[i].isbn;
                document.getElementById("tituloLibroEdit").value = data[i].titulo;
                document.getElementById("sinopsisLibroEdit").value = data[i].sinopsis;
                document.getElementById("n_PaginasLibroEdit").value = data[i].n_Paginas;
                document.getElementById("editorialLibroEdit").value = data[i].id_Editorial;
                document.getElementById("autorLibroEdit").value = data[i].id_Autor;
                document.getElementById("idAutorLibroEdit").value = data[i].id_Autor_Libro;


            }
        }
        $('#edit').modal('show');

    });

}
/**
 * Método para guardar un registro nuevo.
 */
function saveNew() {

    var id = document.getElementById("idLibro").value;
    var iSBN = document.getElementById("iSBNLibro").value;
    var titulo = document.getElementById("tituloLibro").value;
    var sinopsis = document.getElementById("sinopsisLibro").value;
    var npaginas = document.getElementById("n_PaginasLibro").value;

    if ((iSBN != "") & (titulo != "") & (sinopsis != "") & (npaginas != "")) {

        var frmEnviar = document.getElementById("frmEnviarNew");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Libros/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7, "Libros");
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

    var id = document.getElementById("idLibroEdit").value;
    var iSBN = document.getElementById("iSBNLibroEdit").value;
    var titulo = document.getElementById("tituloLibroEdit").value;
    var sinopsis = document.getElementById("sinopsisLibroEdit").value;
    var npaginas = document.getElementById("n_PaginasLibroEdit").value;


    if ((iSBN != "") & (titulo != "") & (sinopsis != "") & (npaginas != "") & (id != 0)) {

        var frmEnviar = document.getElementById("frmEnviarEdit");
        var frm = new FormData(frmEnviar)

        fetchPostMassive("Libros/Save", "text", frm, function (rpta) {
            if (rpta != "") {
                Mensaje(7, "Libros");
            } else {
                Mensaje(8);
            }
        });
    }
    else {
        Mensaje(1);
    }
}
function newR() {
    ListEditorialesN();
    ListAutoresN();
    $('#new').modal('show');
}
/**
 * Método que lista los autores en el modal edit.
 */
function ListEditoriales() {
    fetchGet("Libros/ListEditoriales", "json", function (data) {
        if (data != "") {
            llenarCombo(data, "editorialLibroEdit", "id_Editorial", "nombre_Editorial")
        }
        else {
            $("#editorialLibroEdit").empty();
        }

    });
}
function newR() {
    ListEditorialesN();
    ListAutoresN();
    $('#new').modal('show');
}
/**
 * Método que lista los autores en el modal edit.
 */
function ListAutores() {
    fetchGet("Libros/ListAutores", "json", function (data) {
        if (data != "") {
            llenarCombo(data, "autorLibroEdit", "id_Autor", "nombres_Autor")
        }
        else {
            $("#autorLibroEdit").empty();
        }

    });
}
function newR() {
    ListEditorialesN();
    ListAutoresN();
    $('#new').modal('show');
}
/**
 * Método que lista los editoriales en el modal new.
 */
function ListEditorialesN() {
    fetchGet("Libros/ListEditoriales", "json", function (data) {
        if (data != "") {
            llenarCombo(data, "editorialLibro", "id_Editorial", "nombre_Editorial")
        }
        else {
            $("#editorialLibro").empty();
        }

    });
}
function newR() {
    ListEditorialesN();
    ListAutoresN();
    $('#new').modal('show');
}
/**
 * Método que lista los autores en el modal new..
 */
function ListAutoresN() {
    fetchGet("Libros/ListAutores", "json", function (data) {
        if (data != "") {
            llenarCombo(data, "autorLibro", "id_Autor", "nombres_Autor")
        }
        else {
            $("#autorLibro").empty();
        }

    });
}
