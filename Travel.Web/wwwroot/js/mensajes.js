/**
 * Método para mostrar las alertas de sweetalert2.
 */
function Mensaje(msg, aux) {
    switch (msg) {
        case 1:
            {
                Swal.fire({
                    text: "Los campos son obligatorios",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 2:
            {
                Swal.fire({
                    //position: 'top-end',
                    icon: 'warning',
                    text: 'No existe resultado para la fecha seleccionada',
                    showConfirmButton: false,
                    timer: 1500
                }).then(function () {
                    /*window.location.href = '/SendWhatsAppTextMessage/SendWhatsAppTextMessage'*/
                    window.location.href = '/' + aux
                    //window.location.href = '/FormatosPrueba/' + aux + '/' + aux
                })
                break;
            }
        case 3:
            {
                Swal.fire({
                    text: "El campo " + aux + " debe ser númerico",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 4:
            {
                Swal.fire({
                    text: "Debe seleccionar un destinatario",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 5:
            {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'El reporte se ha enviado correctamente',
                    showConfirmButton: false,
                    timer: 1500
                });
                break;
            }
        case 6:
            {
                if (aux != '') {
                    $('#' + aux).modal('hide');
                }

                Swal.fire({
                    //customClass: {
                    //    container: 'my-swal'
                    //},
                    title: '<h1 style="color:white">Por favor espere...</h1>',
                    width: 600,
                    heigh : 600,
                    customClass: 'swal-height',
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    background: '#19191a',
                    showConfirmButton: false,
                    onBeforeOpen: () => {
                        Swal.showLoading()
                    },
                });
                break;
            }
        case 7:
            {
                Swal.fire({
                    //position: 'top-end',
                    icon: 'success',
                    text: 'Registro guardado correctamente',
                    showConfirmButton: false,
                    timer: 1500
                }).then(function () {
                    /*window.location.href = '/SendWhatsAppTextMessage/SendWhatsAppTextMessage'*/
                    window.location.href = '/' + aux
                    //window.location.href = '/FormatosPrueba/' + aux + '/' + aux
                });
                break;
            }
        case 8:
            {
                Swal.fire({
                    text: "Ocurrio un error al guardar, intentalo nuevamente",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 9:
            {
                Swal.fire({
                    text: "Ocurrio un error al agregar los archivos",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 10:
            {
                Swal.fire({
                    text: "Ocurrio un error al borrar, intentalo nuevamente",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        case 11:
            {
                Swal.fire({
                    text: "Usuario o contraseña incorrecto",
                    icon: "warning",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
                break;
            }
        default:
            {
                return false;
                break;
            }
    }
}
