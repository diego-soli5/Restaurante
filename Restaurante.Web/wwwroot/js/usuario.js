function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Usuario")

    } else {
        //swalAlert('Eliminar Usuario', json.message, false);
        toastr["error"](json.message, "Eliminar Usuario")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminarUsr').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Usuario?",
            showDenyButton: true,
            confirmButtonText: "Si",
            denyButtonText: `No`
        }).then((result) => {
            if (result.isConfirmed) {

                const url = x.href;

                x.disabled = true;

                fetch(url, { method: 'POST' })
                    .then(response => response.json())
                    .then(json => this.manageResponse(json));

            }
        });
    }));
}

document.querySelector('#frmRegistrar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Usuario/Registrar";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Registrar Usuario");

                refrescarTabla();

                $("#modalRegistrar").modal("hide");
                $("#TcNombre").val("");
                $("#TcNombreUsuario").val("");
                $("#TcContrasena").val("");
                $("#TcCorreoElectronico").val("");
            } else {
                toastr["error"](json.message, "Registrar Usuario")
            }
        });
});


function refrescarTabla() {
    $("#tblUsuarios").load('/Usuario/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();