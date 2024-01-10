function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Cliente")

    } else {
        toastr["error"](json.message, "Eliminar Cliente")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Cliente?",
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

    document.querySelectorAll('#btnEditar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        $("#Id").val(x.getAttribute("data-id"));
        $("#Id2").val(x.getAttribute("data-id"));
        $("#TcNombreEdit").val(x.getAttribute("data-TcNombre"));
        $("#TcAp1Edit").val(x.getAttribute("data-TcAp1"));
        $("#TcAp2Edit").val(x.getAttribute("data-TcAp2"));
        $("#TcNumTelefonoEdit").val(x.getAttribute("data-TcNumTelefono"));
        $("#TcCorreoElectronicoEdit").val(x.getAttribute("data-TcCorreoElectronico"));
        $("#modalEditar").modal();
    }));
}

document.querySelector('#frmCrear').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Cliente/Crear";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Agregar Cliente");

                refrescarTabla();

                $("#modalCrear").modal("hide");
                $("#TcNombre").val("");
                $("#TcAp1").val("");
                $("#TcAp2").val("");
                $("#TcNumTelefono").val("");
                $("#TcCorreoElectronico").val("");
            } else {
                toastr["error"](json.message, "Agregar Cliente")
            }
        });
});

document.querySelector('#frmEditar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Cliente/Actualizar/";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Editar Cliente");

                refrescarTabla();

                $("#modalEditar").modal("hide");
            } else {
                toastr["error"](json.message, "Editar Cliente")
            }
        });
});


function refrescarTabla() {
    $("#tblDatos").load('/Cliente/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();